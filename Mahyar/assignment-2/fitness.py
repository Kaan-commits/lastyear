#!/usr/bin/env python3
# Kaan Kara - 220404046
import random

def generate_population(size=100):

    population = []
    
    for _ in range(size):
        genotype = [1, 2, 3, 4, 5, 6, 7, 8]
        random.shuffle(genotype)
        population.append(genotype)
    
    return population

def calculate_fitness(genotype):

    n = len(genotype)
    total_pairs = n * (n - 1) // 2
    attacking_pairs = 0
    
    for i in range(n):
        for j in range(i + 1, n):

            col1, row1 = i, genotype[i] - 1
            col2, row2 = j, genotype[j] - 1
            
            col_diff = abs(col1 - col2)
            row_diff = abs(row1 - row2)
            
            if col_diff == row_diff:
                attacking_pairs += 1
    
    fitness = total_pairs - attacking_pairs
    return fitness

# Örnek Kullanım
if __name__ == "__main__":
    # Bölüm 1 Örneği: Uygunluk Fonksiyonu
    perfect_solution = [4, 2, 7, 3, 6, 8, 5, 1]
    fitness = calculate_fitness(perfect_solution)
    print(f"Mükemmel bir çözümün uygunluğu: {fitness}")
    
    # Bölüm 2 Örneği: Başlangıç Popülasyonu Oluşturma
    initial_population = generate_population(100)
    print(f"{len(initial_population)} genotipten oluşan bir popülasyon oluşturuldu.")
    print("Popülasyondaki ilk genotip:", initial_population[0])