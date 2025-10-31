#!/usr/bin/env python3
"""
8 Vezir Problemi - Grafik Görselleştirme (Matplotlib)
Genotipi görsel satranç tahtası olarak gösterir
"""

import matplotlib.pyplot as plt
import matplotlib.patches as patches
import numpy as np


def display_board_graphical(genotype, title="8 Vezir Tahtası"):
    """
    Genotipi grafik olarak görselleştirir (matplotlib).
    
    Args:
        genotype: 1'den 8'e kadar sayılardan oluşan liste
        title: Grafik başlığı
    """
    fig, ax = plt.subplots(figsize=(8, 8))
    
    # Satranç tahtası oluştur
    for row in range(8):
        for col in range(8):
            # Satranç tahtası renk deseni (açık/koyu kareler)
            color = '#F0D9B5' if (row + col) % 2 == 0 else '#B58863'
            square = patches.Rectangle((col, 7-row), 1, 1, 
                                       linewidth=1, 
                                       edgecolor='black', 
                                       facecolor=color)
            ax.add_patch(square)
    
    # Vezirleri yerleştir
    for col_index, row_value in enumerate(genotype):
        row_index = row_value - 1
        
        # Vezir simgesi (♛) veya basit daire + Q
        # ♛ karakteri her sistemde görünmeyebilir, bu yüzden hem simge hem de Q kullanıyoruz
        ax.text(col_index + 0.5, 7 - row_index + 0.5, '♛', 
                fontsize=40, ha='center', va='center', 
                color='red', weight='bold')
    
    # Eksen ayarları
    ax.set_xlim(0, 8)
    ax.set_ylim(0, 8)
    ax.set_aspect('equal')
    ax.axis('off')
    
    # Sütun numaraları (1-8)
    for i in range(8):
        ax.text(i + 0.5, -0.3, str(i+1), 
                ha='center', va='top', fontsize=12, weight='bold')
    
    # Satır numaraları (1-8)
    for i in range(8):
        ax.text(-0.3, 7 - i + 0.5, str(i+1), 
                ha='right', va='center', fontsize=12, weight='bold')
    
    plt.title(title, fontsize=16, weight='bold', pad=20)
    plt.tight_layout()
    
    return fig


def count_conflicts(genotype):
    """Çapraz çatışmaları sayar."""
    conflicts = 0
    n = len(genotype)
    
    for i in range(n):
        for j in range(i + 1, n):
            row_diff = abs(genotype[i] - genotype[j])
            col_diff = abs(i - j)
            if row_diff == col_diff:
                conflicts += 1
    
    return conflicts


# Test ve örnek kullanım
if __name__ == "__main__":
    # Ödevdeki örnek genotip
    genotype = [4, 2, 7, 3, 6, 8, 5, 1]
    
    conflicts = count_conflicts(genotype)
    title = f"8 Vezir Problemi\nGenotip: {genotype}\nÇatışmalar: {conflicts}"
    
    # Grafik görselleştirme
    fig = display_board_graphical(genotype, title)
    
    # Dosyaya kaydet
    output_file = "eight_queens_board.png"
    plt.savefig(output_file, dpi=150, bbox_inches='tight')
    print(f"✓ Grafik kaydedildi: {output_file}")
    
    # Ekranda göster (isteğe bağlı)
    plt.show()
    
    print(f"\nGenotip: {genotype}")
    print(f"Çatışmalar: {conflicts}")
    if conflicts == 0:
        print("✓ Geçerli çözüm!")
