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

def calculate_fitness_verbose(genotype):
    n = len(genotype)
    total_pairs = n * (n - 1) // 2
    attacking_pairs = 0
    
    print(f"\nGenotip: {genotype}")
    print(f"Toplam vezir çifti sayısı: C({n},2) = {total_pairs}")
    print("\nÇapraz çatışma kontrolü:")
    print("-" * 60)
    
    for i in range(n):
        for j in range(i + 1, n):
            col1, row1 = i, genotype[i] - 1
            col2, row2 = j, genotype[j] - 1
            
            col_diff = abs(col1 - col2)
            row_diff = abs(row1 - row2)
            
            is_attacking = col_diff == row_diff
            status = "✗ SALDIRIYOR" if is_attacking else "✓ Güvenli"
            
            print(f"Vezir çifti ({i+1},{j+1}): "
                  f"sütun_fark={col_diff}, satır_fark={row_diff} → {status}")
            
            if is_attacking:
                attacking_pairs += 1
    
    fitness = total_pairs - attacking_pairs
    
    print("-" * 60)
    print(f"\nSaldıran çift sayısı: {attacking_pairs}")
    print(f"Saldırmayan çift sayısı: {fitness}")
    print(f"Fitness Puanı: {fitness}/{total_pairs}")
    
    if fitness == total_pairs:
        print("🎉 MÜKEMMEL ÇÖZÜM! Hiçbir vezir birbirini tehdit etmiyor!")
    elif fitness == 0:
        print("❌ EN KÖTÜ ÇÖZÜM! Tüm vezirler birbirini tehdit ediyor!")
    else:
        percentage = (fitness / total_pairs) * 100
        print(f"📊 Çözüm kalitesi: %{percentage:.1f}")
    
    return fitness

if __name__ == "__main__":
    print("=" * 70)
    print("8 VEZİR PROBLEMİ - FİTNESS FONKSİYONU")
    print("=" * 70)

    print("\n" + "=" * 70)
    print("TEST 1: Bilinen Mükemmel Çözüm")
    print("=" * 70)
    perfect_solution = [4, 2, 7, 3, 6, 8, 5, 1]
    fitness1 = calculate_fitness_verbose(perfect_solution)
    
    print("\n" + "=" * 70)
    print("TEST 2: En Kötü Çözüm (Düz Çapraz)")
    print("=" * 70)
    worst_solution = [1, 2, 3, 4, 5, 6, 7, 8]
    fitness2 = calculate_fitness_verbose(worst_solution)
    
    print("\n" + "=" * 70)
    print("TEST 3: Orta Seviye Çözüm")
    print("=" * 70)
    medium_solution = [3, 5, 7, 2, 4, 8, 1, 6]
    fitness3 = calculate_fitness_verbose(medium_solution)
    
    print("\n" + "=" * 70)
    print("HIZLI TEST SONUÇLARI")
    print("=" * 70)
    test_cases = [
        [4, 2, 7, 3, 6, 8, 5, 1],
        [1, 2, 3, 4, 5, 6, 7, 8],
        [8, 7, 6, 5, 4, 3, 2, 1],
        [3, 5, 7, 2, 4, 8, 1, 6],
    ]
    
    for i, genotype in enumerate(test_cases, 1):
        fitness = calculate_fitness(genotype)
        print(f"Test {i}: {genotype}")
        print(f"         Fitness = {fitness}/28 ({(fitness/28)*100:.1f}%)")
        print()
    
    print("\n" + "=" * 70)
    print("TEST 4: POPÜLASYON OLUŞTURMA")
    print("=" * 70)

    print("\n1. Küçük popülasyon (size=5):")
    small_pop = generate_population(size=5)
    for i, individual in enumerate(small_pop, 1):
        fitness = calculate_fitness(individual)
        print(f"   Birey {i}: {individual} → Fitness: {fitness}/28")

    print("\n2. Normal popülasyon (size=100):")
    normal_pop = generate_population(size=100)
    print(f"   Popülasyon boyutu: {len(normal_pop)}")
    print(f"   İlk birey: {normal_pop[0]}")
    print(f"   Son birey: {normal_pop[-1]}")

    print("\n3. Popülasyon İstatistikleri:")
    fitness_scores = [calculate_fitness(ind) for ind in normal_pop]
    
    avg_fitness = sum(fitness_scores) / len(fitness_scores)
    max_fitness = max(fitness_scores)
    min_fitness = min(fitness_scores)
    
    print(f"   Ortalama fitness: {avg_fitness:.2f}/28 ({(avg_fitness/28)*100:.1f}%)")
    print(f"   En iyi fitness:   {max_fitness}/28 ({(max_fitness/28)*100:.1f}%)")
    print(f"   En kötü fitness:  {min_fitness}/28 ({(min_fitness/28)*100:.1f}%)")
    
    # En iyi bireyi göster
    best_individual = normal_pop[fitness_scores.index(max_fitness)]
    print(f"\n   En iyi birey: {best_individual}")
    print(f"   Fitness: {max_fitness}/28")
    
    if max_fitness == 28:
        print("   🎉 Popülasyonda mükemmel çözüm bulundu!")
    else:
        print(f"   ℹ️  Mükemmel çözüme {28 - max_fitness} çatışma kaldı.")

    print("\n4. Doğrulama:")
    all_valid = all(sorted(ind) == [1, 2, 3, 4, 5, 6, 7, 8] for ind in normal_pop)
    print(f"   Tüm bireyler geçerli permütasyon mu? {'✓ Evet' if all_valid else '✗ Hayır'}")
    
    print("\n" + "=" * 70)
    print("TÜM TESTLER TAMAMLANDI!")
    print("=" * 70)