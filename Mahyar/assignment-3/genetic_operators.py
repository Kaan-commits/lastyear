#!/usr/bin/env python3
# Kaan Kara - 220404046

import random


def tournament_selection(population, fitness_scores, tournament_size=3):
    tournament_indices = random.sample(range(len(population)), tournament_size)
    
    best_index = tournament_indices[0]
    best_fitness = fitness_scores[best_index]
    
    for idx in tournament_indices[1:]:
        if fitness_scores[idx] > best_fitness:
            best_fitness = fitness_scores[idx]
            best_index = idx


    return population[best_index].copy()


def crossover(parent1, parent2):

    n = len(parent1)
    
    crossover_point = random.randint(1, n - 1)
    
    child = []
    
    for i in range(crossover_point):
        child.append(parent1[i])
    
    for gene in parent2:
        if gene not in child:
            child.append(gene)
    
    return child


def mutate(genotype, mutation_rate=0.05):

    mutated = genotype.copy()
    
    if random.random() < mutation_rate:
        idx1, idx2 = random.sample(range(len(mutated)), 2)
        
        mutated[idx1], mutated[idx2] = mutated[idx2], mutated[idx1]
    
    return mutated


if __name__ == "__main__":
    test_population = [
        [4, 2, 7, 3, 6, 8, 5, 1],
        [1, 2, 3, 4, 5, 6, 7, 8],
        [3, 5, 7, 2, 4, 8, 1, 6],
    ]
    test_fitness = [28, 0, 18]
    
    print("Test 1: Turnuva Seçilimi")
    selected = tournament_selection(test_population, test_fitness)
    print(f"Seçilen: {selected}\n")
    
    print("Test 2: Çaprazlama")
    parent1 = [4, 2, 7, 3, 6, 8, 5, 1]
    parent2 = [1, 5, 2, 6, 8, 7, 4, 3]
    child = crossover(parent1, parent2)
    print(f"Ebeveyn 1: {parent1}")
    print(f"Ebeveyn 2: {parent2}")
    print(f"Yavru:     {child}\n")
    
    print("Test 3: Mutasyon")
    original = [4, 2, 7, 3, 6, 8, 5, 1]
    mutated = mutate(original, mutation_rate=1.0)
    print(f"Orijinal: {original}")
    print(f"Mutasyon: {mutated}")