# 8 Vezir Problemi - Genotip → Fenotip Dönüştürme

## 📋 Proje Açıklaması

Bu proje, **8 Vezir Problemi** için bir genotipi (permütasyon) fenotipe (satranç tahtası görselleştirmesi) dönüştüren Python fonksiyonları içerir.

### 🎯 Problem Tanımı

8 Vezir Problemi'nde amaç, 8x8'lik bir satranç tahtasına sekiz vezir yerleştirmek ve hiçbir iki vezirin birbirini tehdit etmemesini sağlamaktır. Bu demektir ki:
- Aynı satırda iki vezir olamaz
- Aynı sütunda iki vezir olamaz  
- Aynı çaprazda iki vezir olamaz

### 🧬 Genotip Temsili (Permütasyon Tabanlı)

**Genotip**: 1'den 8'e kadar benzersiz sayılardan oluşan bir liste.

- **İndeks** (0-7): Sütun numarası
- **Değer** (1-8): Vezirin bulunduğu satır

**Örnek**: `[4, 2, 7, 3, 6, 8, 5, 1]`
- Sütun 1'de vezir satır 4'te
- Sütun 2'de vezir satır 2'de
- Sütun 3'te vezir satır 7'de
- ...ve böyle devam eder

Bu temsil otomatik olarak aynı satır/sütun çakışmalarını önler!

## 📁 Dosyalar

### 1. `eight_queens.py` (Ana Dosya)
Konsol tabanlı görselleştirme ve doğrulama fonksiyonları.

**Fonksiyonlar**:
- `display_board(genotype)`: Tahtayı konsola yazdırır (Q = vezir, . = boş)
- `validate_genotype(genotype)`: Genotipin geçerliliğini kontrol eder
- `count_conflicts(genotype)`: Çapraz çatışmaları sayar

### 2. `eight_queens_visual.py` (Bonus - Grafik)
Matplotlib ile görsel satranç tahtası oluşturur.

**Fonksiyonlar**:
- `display_board_graphical(genotype, title)`: PNG grafik oluşturur

## 🚀 Kullanım

### Temel Kullanım (Konsol)

```bash
python3 eight_queens.py
```

**Örnek Çıktı**:
```
8 Vezir Tahtası:
=================
. . . . . . . Q
. Q . . . . . .
. . . Q . . . .
Q . . . . . . .
. . . . . . Q .
. . . . Q . . .
. . Q . . . . .
. . . . . Q . .
=================

Çapraz çatışma sayısı: 0
✓ Bu geçerli bir çözüm!
```

### Kendi Genotipini Test Etme

```python
from eight_queens import display_board, count_conflicts

# Kendi genotipini oluştur
my_genotype = [3, 5, 7, 2, 4, 8, 1, 6]

# Görselleştir
display_board(my_genotype)

# Çatışmaları kontrol et
conflicts = count_conflicts(my_genotype)
print(f"Çatışmalar: {conflicts}")
```

### Grafik Görselleştirme (İsteğe Bağlı)

```bash
python3 eight_queens_visual.py
```

Bu komut `eight_queens_board.png` dosyasını oluşturur.

**Gereksinim**: matplotlib kütüphanesi
```bash
pip install matplotlib
```

## 📊 Çıktı Örnekleri

### Konsol Çıktısı
```
Genotip: [4, 2, 7, 3, 6, 8, 5, 1]
Doğrulama: Geçerli genotip

8 Vezir Tahtası:
. . . . . . . Q
. Q . . . . . .
. . . Q . . . .
Q . . . . . . .
...
```

### Grafik Çıktı
Renkli satranç tahtası (açık/koyu kareler) üzerinde kırmızı vezir simgeleri (♛).

## 🧪 Test Senaryoları

Kod aşağıdaki test senaryolarını içerir:

1. **Geçerli Çözüm**: `[4, 2, 7, 3, 6, 8, 5, 1]` → 0 çatışma ✓
2. **Kötü Çözüm**: `[1, 2, 3, 4, 5, 6, 7, 8]` → 28 çatışma ✗

## 🔍 Doğrulama Fonksiyonu

`validate_genotype()` şunları kontrol eder:
- Liste uzunluğu = 8
- Tüm değerler 1-8 arasında
- Tüm değerler benzersiz (permütasyon)

## 🎓 Genetik Algoritma için Kullanım

Bu fonksiyonlar, **Genetik Algoritma** ile 8 Vezir Problemi'ni çözerken:
- **Fitness fonksiyonu**: `count_conflicts()` → ne kadar az o kadar iyi
- **Görselleştirme**: Her nesil için en iyi bireyi `display_board()` ile göster
- **Doğrulama**: Çözüm bulunduğunda (conflicts == 0) doğrula

## 📝 Notlar

- Permütasyon temsili sayesinde satır/sütun çakışmaları zaten engellenmiştir
- Sadece çapraz çatışmalar kontrol edilmelidir
- Toplam 92 farklı geçerli çözüm vardır (simetri dönüşümleriyle 12 benzersiz)

## 🛠️ Gereksinimler

- Python 3.6+
- matplotlib (sadece grafik versiyon için)

```bash
# Grafik versiyon için
pip install matplotlib
```

## 📚 Referanslar

- [8 Queens Problem - Wikipedia](https://en.wikipedia.org/wiki/Eight_queens_puzzle)
- [Genetic Algorithms](https://en.wikipedia.org/wiki/Genetic_algorithm)

## ✅ Tamamlanan Görevler

- ✓ `display_board()` fonksiyonu
- ✓ Konsol tabanlı görselleştirme
- ✓ Genotip doğrulama
- ✓ Çatışma sayma fonksiyonu
- ✓ Test senaryoları
- ✓ Bonus: Matplotlib grafik görselleştirme

---

**Hazırlayan**: Kaan Kara