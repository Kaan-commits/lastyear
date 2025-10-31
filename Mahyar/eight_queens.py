#!/usr/bin/env python3
"""
8 Vezir Problemi - Genotipten Fenotipe Dönüştürme
Genotype: 1-8 arası 8 benzersiz sayıdan oluşan permütasyon listesi
Phenotype: 8x8 satranç tahtasında vezirlerin görsel temsili
"""

def display_board(genotype):
    """
    Bir genotipi (8 sayıdan oluşan liste) alır ve satranç tahtasını yazdırır.
    
    Args:
        genotype: 1'den 8'e kadar sayılardan oluşan liste. 
                  İndeks = sütun (0-7), Değer = satır (1-8)
    
    Örnek:
        genotype = [4, 2, 7, 3, 6, 8, 5, 1]
        - Sütun 0'da vezir satır 4'te (indeks 3)
        - Sütun 1'de vezir satır 2'de (indeks 1)
        - ...
    """
    # 8x8 boş tahta oluştur
    board = [['.' for _ in range(8)] for _ in range(8)]
    
    # Genotipi fenotipe dönüştür (vezirleri yerleştir)
    for col_index, row_value in enumerate(genotype):
        # row_value 1-8 arası, array indeksi 0-7 arası
        row_index = row_value - 1
        board[row_index][col_index] = 'Q'
    
    # Tahtayı yazdır
    print("\n8 Vezir Tahtası:")
    print("=" * 17)  # Üst çizgi
    for row in board:
        print(' '.join(row))
    print("=" * 17)  # Alt çizgi
    print()


def validate_genotype(genotype):
    """Genotipin geçerli olup olmadığını kontrol eder."""
    if len(genotype) != 8:
        return False, "Genotip 8 elemandan oluşmalıdır"
    
    if not all(1 <= x <= 8 for x in genotype):
        return False, "Tüm değerler 1-8 arasında olmalıdır"
    
    if len(set(genotype)) != 8:
        return False, "Tüm değerler benzersiz olmalıdır (permütasyon)"
    
    return True, "Geçerli genotip"


def count_conflicts(genotype):
    """
    Genotipdeki çapraz çatışmaları sayar.
    (Satır ve sütun çatışmaları permütasyon sayesinde zaten yoktur)
    
    Returns:
        Çapraz çatışma sayısı (0 = çözüm bulundu!)
    """
    conflicts = 0
    n = len(genotype)
    
    for i in range(n):
        for j in range(i + 1, n):
            # Aynı çaprazda mı kontrol et
            row_diff = abs(genotype[i] - genotype[j])
            col_diff = abs(i - j)
            
            if row_diff == col_diff:
                conflicts += 1
    
    return conflicts


# Test ve örnek kullanım
if __name__ == "__main__":
    print("=" * 50)
    print("8 VEZİR PROBLEMİ - GENOTİP → FENOTİP")
    print("=" * 50)
    
    # Ödevdeki örnek genotip
    genotype_example = [4, 2, 7, 3, 6, 8, 5, 1]
    
    # Genotipi doğrula
    is_valid, message = validate_genotype(genotype_example)
    print(f"\nGenotip: {genotype_example}")
    print(f"Doğrulama: {message}")
    
    if is_valid:
        # Tahtayı görüntüle
        display_board(genotype_example)
        
        # Çatışmaları kontrol et
        conflicts = count_conflicts(genotype_example)
        print(f"Çapraz çatışma sayısı: {conflicts}")
        if conflicts == 0:
            print("✓ Bu geçerli bir çözüm! Hiçbir vezir birbirini tehdit etmiyor.")
        else:
            print(f"✗ Bu çözüm geçersiz - {conflicts} çapraz çatışma var.")
    
    print("\n" + "=" * 50)
    print("DİĞER ÖRNEKLER")
    print("=" * 50)
    
    # Bilinen geçerli bir çözüm
    valid_solution = [4, 2, 7, 3, 6, 8, 5, 1]
    print("\nGeçerli Çözüm Örneği:")
    display_board(valid_solution)
    print(f"Çatışmalar: {count_conflicts(valid_solution)}")
    
    # Başka bir test genotipi
    test_genotype = [1, 2, 3, 4, 5, 6, 7, 8]
    print("\nTest Genotipi (sıralı):")
    display_board(test_genotype)
    print(f"Çatışmalar: {count_conflicts(test_genotype)}")
    print("(Beklenen: Çok fazla çatışma)")
