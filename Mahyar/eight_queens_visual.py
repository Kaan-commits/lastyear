import matplotlib.pyplot as plt
import matplotlib.patches as patches
import numpy as np


def display_board_graphical(genotype, title="8 Vezir Tahtası"):

    fig, ax = plt.subplots(figsize=(8, 8), facecolor='white')
    
    # Satranç tahtası oluştur
    for row in range(8):
        for col in range(8):
            # Siyah-beyaz desen
            color = 'white' if (row + col) % 2 == 0 else 'black'
            
            square = patches.Rectangle((col, 7-row), 1, 1, 
                                      linewidth=0.5, 
                                      edgecolor='gray', 
                                      facecolor=color)
            ax.add_patch(square)
    
    # Vezirleri yerleştir
    for col_index, row_value in enumerate(genotype):
        row_index = row_value - 1
        x = col_index + 0.5
        y = 7 - row_index + 0.5
        
        # Vezir rengini kare rengine göre ayarla (kontrast için)
        is_white_square = (row_index + col_index) % 2 == 0
        queen_color = 'darkred' if is_white_square else 'gold'
        
        # Vezir simgesi - basit ve temiz
        ax.text(x, y, '♛', 
               fontsize=45, ha='center', va='center', 
               color=queen_color, weight='bold',
               zorder=3)
    
    # Eksen ayarları
    ax.set_xlim(0, 8)
    ax.set_ylim(0, 8)
    ax.set_aspect('equal')
    ax.axis('off')
    
    # Koordinat etiketleri (minimal)
    # Sütun numaraları (1-8)
    for i in range(8):
        ax.text(i + 0.5, -0.2, str(i+1), 
                ha='center', va='top', 
                fontsize=11, weight='bold', 
                color='black')
    
    # Satır numaraları (1-8)
    for i in range(8):
        ax.text(-0.2, 7 - i + 0.5, str(i+1), 
                ha='right', va='center', 
                fontsize=11, weight='bold',
                color='black')
    
    # Başlık
    plt.title(title, fontsize=14, weight='bold', pad=15, color='black')
    
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
    title = f"8 Queen Problem\nGenotype: {genotype}\nConflicts: {conflicts}"
    
    # Grafik görselleştirme
    fig = display_board_graphical(genotype, title)
    
    # Dosyaya kaydet
    output_file = "eight_queens_board.png"
    plt.savefig(output_file, dpi=150, bbox_inches='tight')
    print(f"✓ Grafik kaydedildi: {output_file}")
    
    # Ekranda göster
    plt.show()
    
    print(f"\nGenotip: {genotype}")
    print(f"Çatışmalar: {conflicts}")
    if conflicts == 0:
        print("✓ Geçerli çözüm!")