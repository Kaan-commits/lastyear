import random
import math
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
        print(f"Mesafe Tipi: {self.edge_weight_type}")
    
    def calculate_distance(self, city1: int, city2: int) -> float:
        x1, y1 = self.cities[city1]
        x2, y2 = self.cities[city2]
        
        if self.edge_weight_type == "EUC_2D":
            return math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
        elif self.edge_weight_type == "ATT":
            xd = x1 - x2
            yd = y1 - y2
            rij = math.sqrt((xd**2 + yd**2) / 10.0)
            tij = int(round(rij))
            if tij < rij:
                return tij + 1
            else:
                return tij
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
    
    def __repr__(self):
        return f"Chromosome(fitness={self.fitness:.6f}, distance={self.get_total_distance():.2f})"


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
            chromosome = Chromosome(genes, self.tsp_data)
            self.population.append(chromosome)
        
        self.population.sort(key=lambda x: x.fitness, reverse=True)
        self.best_chromosome = self.population[0]
        self.best_history.append(self.best_chromosome.get_total_distance())
        
        print(f"\nİlk Popülasyon Oluşturuldu: {self.population_size} kromozom")
        print(f"Başlangıç En İyi Mesafe: {self.best_chromosome.get_total_distance():.2f}")
    
    def rank_based_selection(self) -> Chromosome:
        sorted_pop = sorted(self.population, key=lambda x: x.fitness)
        n = len(sorted_pop)
        ranks = list(range(1, n + 1))
        total_rank = sum(ranks)
        probabilities = [rank / total_rank for rank in ranks]
        selected = random.choices(sorted_pop, weights=probabilities, k=1)[0]
        return selected
    
    def roulette_wheel_selection(self) -> Chromosome:
        total_fitness = sum(chromosome.fitness for chromosome in self.population)
        
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
        
        for i in range(size):
            if child1_genes[i] == -1:
                child1_genes[i] = parent2.genes[i]
            if child2_genes[i] == -1:
                child2_genes[i] = parent1.genes[i]
        
        child1 = Chromosome(child1_genes, self.tsp_data)
        child2 = Chromosome(child2_genes, self.tsp_data)
        
        return child1, child2
    
    def insert_mutation(self, chromosome: Chromosome) -> Chromosome:
        genes = chromosome.genes.copy()
        size = len(genes)
        
        if size < 2:
            return Chromosome(genes, self.tsp_data)
        
        remove_idx = random.randint(0, size - 1)
        gene = genes.pop(remove_idx)
        insert_idx = random.randint(0, size - 1)
        genes.insert(insert_idx, gene)
        
        return Chromosome(genes, self.tsp_data)
    
    def random_slide_mutation(self, chromosome: Chromosome) -> Chromosome:
        genes = chromosome.genes.copy()
        size = len(genes)
        
        if size < 3:
            return Chromosome(genes, self.tsp_data)
        
        start = random.randint(0, size - 2)
        end = random.randint(start + 1, size - 1)
        subset = genes[start:end + 1]
        shift = random.randint(1, len(subset) - 1)
        subset = subset[shift:] + subset[:shift]
        genes[start:end + 1] = subset
        
        return Chromosome(genes, self.tsp_data)
    
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
        current_best = self.population[0]
        
        if current_best.fitness > self.best_chromosome.fitness:
            self.best_chromosome = current_best
        
        self.best_history.append(self.best_chromosome.get_total_distance())
    
    def should_terminate(self, max_generations: int = 100, stagnation_limit: int = 5) -> bool:
        if self.generation >= max_generations:
            print(f"\n✓ Sonlandırma: {max_generations} nesil tamamlandı")
            return True
        
        if len(self.best_history) >= stagnation_limit:
            recent_bests = self.best_history[-stagnation_limit:]
            if len(set(recent_bests)) == 1:
                print(f"\n✓ Sonlandırma: {stagnation_limit} nesil boyunca iyileşme yok")
                return True
        
        return False
    
    def run(self, max_generations: int = 100, stagnation_limit: int = 5, verbose: bool = True):
        
        self.initialize_population()
        
        while not self.should_terminate(max_generations, stagnation_limit):
            self.create_next_generation()
            
            if verbose:
                print(f"Nesil {self.generation}: En İyi Mesafe = {self.best_chromosome.get_total_distance():.2f}")
        
        print(f"Toplam Nesil Sayısı: {self.generation}")
        print(f"En İyi Çözüm Mesafesi: {self.best_chromosome.get_total_distance():.2f}")
        print(f"En İyi Tur: {self.best_chromosome.genes[:10]}... (ilk 10 şehir)")
        print("="*60)
        
        return self.best_chromosome