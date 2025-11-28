# Kaan Kara - 220404046

import random
import math
import os
from typing import List, Tuple, Dict
import copy

class TSPData:
    
    def __init__(self, filename: str):
        self.filename = filename
        self.cities: Dict[int, Tuple[float, float]] = {}
        self.dimension = 0
        self.edge_weight_type = "EUC_2D"
        self.name = ""
        self.load_tsp_file()
    
    def load_tsp_file(self):
        with open(self.filename, 'r') as f:
            lines = f.readlines()
        
        reading_coords = False
        for line in lines:
            line = line.strip()
            
            if line.startswith('NAME'):
                self.name = line.split(':')[1].strip()
            elif line.startswith('DIMENSION'):
                self.dimension = int(line.split(':')[1].strip())
            elif line.startswith('EDGE_WEIGHT_TYPE'):
                self.edge_weight_type = line.split(':')[1].strip()
            elif line == 'NODE_COORD_SECTION':
                reading_coords = True
            elif line == 'EOF':
                break
            elif reading_coords and line:
                parts = line.split()
                if len(parts) >= 3:
                    city_id = int(parts[0])
                    x = float(parts[1])
                    y = float(parts[2])
                    self.cities[city_id] = (x, y)
        
        print(f"TSP Dosyası Yüklendi: {self.name}")
        print(f"Şehir Sayısı: {self.dimension}")
    
    def calculate_distance(self, city1: int, city2: int) -> float:
        x1, y1 = self.cities[city1]
        x2, y2 = self.cities[city2]
        
        if self.edge_weight_type == "ATT":
            xd = x1 - x2
            yd = y1 - y2
            rij = math.sqrt((xd**2 + yd**2) / 10.0)
            tij = int(round(rij))
            return tij + 1 if tij < rij else tij
        else:
            return math.sqrt((x2 - x1)**2 + (y2 - y1)**2)


class Chromosome:
    
    def __init__(self, genes: List[int], tsp_data: TSPData):
        self.genes = genes
        self.tsp_data = tsp_data
        self.fitness = self.calculate_fitness()
    
    def calculate_fitness(self) -> float:
        total_distance = 0.0
        for i in range(len(self.genes)):
            from_city = self.genes[i]
            to_city = self.genes[(i + 1) % len(self.genes)]
            total_distance += self.tsp_data.calculate_distance(from_city, to_city)
        return 1.0 / total_distance if total_distance > 0 else 0
    
    def get_total_distance(self) -> float:
        return 1.0 / self.fitness if self.fitness > 0 else float('inf')


class GeneticAlgorithm:
    
    def __init__(self, tsp_data: TSPData, population_size: int = 100):
        self.tsp_data = tsp_data
        self.population_size = population_size
        self.population: List[Chromosome] = []
        self.generation = 0
        self.best_chromosome: Chromosome = None
        self.best_history: List[float] = []
    
    def initialize_population(self):
        city_ids = list(self.tsp_data.cities.keys())
        
        for _ in range(self.population_size):
            genes = city_ids.copy()
            random.shuffle(genes)
            self.population.append(Chromosome(genes, self.tsp_data))
        
        self.population.sort(key=lambda x: x.fitness, reverse=True)
        self.best_chromosome = self.population[0]
        self.best_history.append(self.best_chromosome.get_total_distance())
        print(f"Başlangıç En İyi Mesafe: {self.best_chromosome.get_total_distance():.2f}\n")
    
    def rank_based_selection(self) -> Chromosome:
        sorted_pop = sorted(self.population, key=lambda x: x.fitness)
        n = len(sorted_pop)
        ranks = list(range(1, n + 1))
        total_rank = sum(ranks)
        probabilities = [rank / total_rank for rank in ranks]
        return random.choices(sorted_pop, weights=probabilities, k=1)[0]
    
    def roulette_wheel_selection(self) -> Chromosome:
        total_fitness = sum(c.fitness for c in self.population)
        if total_fitness == 0:
            return random.choice(self.population)
        
        pick = random.uniform(0, total_fitness)
        current = 0
        for chromosome in self.population:
            current += chromosome.fitness
            if current >= pick:
                return chromosome
        return self.population[-1]
    
    def cycle_crossover(self, parent1: Chromosome, parent2: Chromosome) -> Tuple[Chromosome, Chromosome]:
        size = len(parent1.genes)
        child1_genes = [-1] * size
        child2_genes = [-1] * size
        visited = [False] * size
        
        while not all(visited):
            start_idx = visited.index(False)
            current_idx = start_idx
            cycle_indices = []
            
            while not visited[current_idx]:
                visited[current_idx] = True
                cycle_indices.append(current_idx)
                value_in_parent2 = parent2.genes[current_idx]
                current_idx = parent1.genes.index(value_in_parent2)
            
            cycle_num = len([i for i in range(start_idx) if visited[i]]) // len(cycle_indices)
            
            for idx in cycle_indices:
                if cycle_num % 2 == 0:
                    child1_genes[idx] = parent1.genes[idx]
                    child2_genes[idx] = parent2.genes[idx]
                else:
                    child1_genes[idx] = parent2.genes[idx]
                    child2_genes[idx] = parent1.genes[idx]
        
        return Chromosome(child1_genes, self.tsp_data), Chromosome(child2_genes, self.tsp_data)
    
    def insert_mutation(self, chromosome: Chromosome) -> Chromosome:
        genes = chromosome.genes.copy()
        if len(genes) < 2:
            return Chromosome(genes, self.tsp_data)
        
        remove_idx = random.randint(0, len(genes) - 1)
        gene = genes.pop(remove_idx)
        insert_idx = random.randint(0, len(genes) - 1)
        genes.insert(insert_idx, gene)
        return Chromosome(genes, self.tsp_data)
    
    def random_slide_mutation(self, chromosome: Chromosome) -> Chromosome:
        genes = chromosome.genes.copy()
        if len(genes) < 3:
            return Chromosome(genes, self.tsp_data)
        
        start = random.randint(0, len(genes) - 2)
        end = random.randint(start + 1, len(genes) - 1)
        subset = genes[start:end + 1]
        shift = random.randint(1, len(subset) - 1)
        genes[start:end + 1] = subset[shift:] + subset[:shift]
        return Chromosome(genes, self.tsp_data)
    
    def two_opt(self, chromosome: Chromosome) -> Chromosome:
        best_genes = chromosome.genes.copy()
        best_distance = chromosome.get_total_distance()
        improved = True
        
        while improved:
            improved = False
            for i in range(len(best_genes) - 1):
                for k in range(i + 2, len(best_genes)):

                    new_genes = best_genes.copy()
                    new_genes[i:k] = reversed(best_genes[i:k])
                    
                    new_chromosome = Chromosome(new_genes, self.tsp_data)
                    new_distance = new_chromosome.get_total_distance()
                    
                    if new_distance < best_distance:
                        best_genes = new_genes
                        best_distance = new_distance
                        improved = True
                        break
                if improved:
                    break
        
        return Chromosome(best_genes, self.tsp_data)
    
    def three_opt(self, chromosome: Chromosome) -> Chromosome:
        best_genes = chromosome.genes.copy()
        best_distance = chromosome.get_total_distance()
        improved = True
        
        while improved:
            improved = False
            n = len(best_genes)
            
            for i in range(n - 2):
                for j in range(i + 2, n - 1):
                    for k in range(j + 2, n + (1 if i > 0 else 0)):
                        
                        candidates = []
                        
                        candidates.append(best_genes[:])
                        
                        candidates.append(best_genes[:i] + best_genes[j:k] + best_genes[i:j] + best_genes[k:])
                        
                        candidates.append(best_genes[:i] + best_genes[j:k][::-1] + best_genes[i:j] + best_genes[k:])
                        
                        candidates.append(best_genes[:i] + best_genes[j:k] + best_genes[i:j][::-1] + best_genes[k:])
                        
                        candidates.append(best_genes[:i] + best_genes[i:j][::-1] + best_genes[j:k][::-1] + best_genes[k:])
                        
                        for candidate in candidates:
                            new_chromosome = Chromosome(candidate, self.tsp_data)
                            new_distance = new_chromosome.get_total_distance()
                            
                            if new_distance < best_distance:
                                best_genes = candidate
                                best_distance = new_distance
                                improved = True
                                break
                        
                        if improved:
                            break
                    if improved:
                        break
                if improved:
                    break
        
        return Chromosome(best_genes, self.tsp_data)
    
    def create_next_generation(self):
        new_population = []
        self.population.sort(key=lambda x: x.fitness, reverse=True)
        new_population.append(copy.deepcopy(self.population[0]))
        
        while len(new_population) < self.population_size:
            if random.random() < 0.5:
                parent1 = self.rank_based_selection()
                parent2 = self.rank_based_selection()
            else:
                parent1 = self.roulette_wheel_selection()
                parent2 = self.roulette_wheel_selection()
            
            child1, child2 = self.cycle_crossover(parent1, parent2)
            
            if random.random() < 0.5:
                child1 = self.insert_mutation(child1)
                child2 = self.insert_mutation(child2)
            else:
                child1 = self.random_slide_mutation(child1)
                child2 = self.random_slide_mutation(child2)
            
            new_population.append(child1)
            if len(new_population) < self.population_size:
                new_population.append(child2)
        
        self.population = new_population[:self.population_size]
        self.generation += 1
        
        self.population.sort(key=lambda x: x.fitness, reverse=True)
        if self.population[0].fitness > self.best_chromosome.fitness:
            self.best_chromosome = self.population[0]
        
        self.best_history.append(self.best_chromosome.get_total_distance())
    
    def should_terminate(self, max_generations: int, stagnation_limit: int) -> bool:
        if self.generation >= max_generations:
            print(f"\n Sonlandırma: {max_generations} nesil tamamlandı")
            return True
        
        if len(self.best_history) >= stagnation_limit:
            recent_bests = self.best_history[-stagnation_limit:]
            if len(set(recent_bests)) == 1:
                print(f"\n Sonlandırma: {stagnation_limit} nesil boyunca iyileşme yok")
                return True
        return False
    
    def run(self, max_generations: int = 100, stagnation_limit: int = 5, verbose: bool = True, use_local_search: bool = False):
        self.initialize_population()
        
        while not self.should_terminate(max_generations, stagnation_limit):
            self.create_next_generation()
            if verbose and self.generation % 10 == 0:
                print(f"Nesil {self.generation}: En İyi Mesafe = {self.best_chromosome.get_total_distance():.2f}")
        
        if use_local_search:
            print("\n2-opt optimizasyonu uygulanıyor...")
            self.best_chromosome = self.two_opt(self.best_chromosome)
            print(f"2-opt sonrası: {self.best_chromosome.get_total_distance():.2f}")
            
            print("3-opt optimizasyonu uygulanıyor...")
            self.best_chromosome = self.three_opt(self.best_chromosome)
            print(f"3-opt sonrası: {self.best_chromosome.get_total_distance():.2f}")
        
        print(f"\nSonuç: {self.generation} nesil, En İyi Mesafe: {self.best_chromosome.get_total_distance():.2f}")
        return self.best_chromosome


def main():
    
    current_dir = os.path.dirname(os.path.abspath(__file__))
    tsp_files = ["berlin52.tsp", "att48.tsp", "a280.tsp", "att532.tsp"]
    results = []
    
    for filename in tsp_files:
        filepath = os.path.join(current_dir, filename)
        if not os.path.exists(filepath):
            continue
            
        print("\n" + "="*60)
        print(f"TSP: {filename}")
        print("="*60)
        
        tsp_data = TSPData(filepath)
        ga = GeneticAlgorithm(tsp_data, population_size=100)
        
        use_local = tsp_data.dimension <= 100
        ga.run(max_generations=100, stagnation_limit=5, use_local_search=use_local)
        
        improvement = ((ga.best_history[0] - ga.best_chromosome.get_total_distance()) / ga.best_history[0] * 100)
        results.append({
            'file': filename,
            'cities': tsp_data.dimension,
            'generations': ga.generation,
            'best': ga.best_chromosome.get_total_distance(),
            'improvement': improvement,
            'local_search': 'Evet' if use_local else 'Hayır'
        })
    
    print("\n" + "="*60)
    print("ÖZET")
    print("="*60)
    print(f"{'Dosya':<15} {'Şehir':<8} {'Nesil':<8} {'En İyi':<12} {'İyileşme':<10} {'2/3-opt':<8}")
    print("-"*70)
    for r in results:
        print(f"{r['file']:<15} {r['cities']:<8} {r['generations']:<8} {r['best']:<12.2f} {r['improvement']:<10.2f}% {r['local_search']:<8}")
    print("="*70 + "\n")


if __name__ == "__main__":
    main()