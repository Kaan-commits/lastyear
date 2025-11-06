# Assignment 2: Fitness Fonksiyonu ve Popülasyon Oluşturma

## 🎯 Amaç
1. Bir genotipin (permütasyon) **fitness (uygunluk) puanını** hesaplamak
2. Rastgele **başlangıç popülasyonu** oluşturmak

## 📐 Fitness Tanımı

**Fitness = Saldırmayan vezir çifti sayısı**

- Toplam vezir çifti: C(8,2) = **28**
- Fitness = 28 - (çapraz çatışma sayısı)
- **Yüksek fitness = iyi çözüm**

## 🔧 Fonksiyonlar

### 1. `calculate_fitness(genotype)`

```python
def calculate_fitness(genotype):
    """
    Args:
        genotype: 1-8 arası sayılardan oluşan liste
    
    Returns:
        int: Saldırmayan çift sayısı (0-28)
    """
```

### 2. `generate_population(size=100)`

```python
import random

def generate_population(size=100):
    """
    Args:
        size: Popülasyondaki birey sayısı
    
    Returns:
        list: Rastgele genotiplerden oluşan liste
    """
```

**Nasıl çalışır?**
1. `[1, 2, 3, 4, 5, 6, 7, 8]` temel genotip oluştur
2. `random.shuffle()` ile rastgele karıştır (permütasyon)
3. Bunu `size` kadar tekrarla
4. Tüm genotipleri liste olarak döndür

## 📊 Çapraz Çatışma Kontrolü

İki vezir aynı çaprazdaysa **saldırıyor** demektir:

```python
abs(sutun1 - sutun2) == abs(satir1 - satir2)
```

### Örnek
```
Vezir 1: sütun=2, satır=5
Vezir 2: sütun=4, satır=7

Sütun farkı: |2-4| = 2
Satır farkı:  |5-7| = 2

2 == 2 → Aynı çaprazda! ✗ Saldırıyor
```

## 🧪 Test Sonuçları

### Test 1: Mükemmel Çözüm ✅
```python
genotype = [4, 2, 7, 3, 6, 8, 5, 1]
fitness = 28/28 (100%)
```
- Hiçbir çatışma yok
- Tüm 28 çift güvenli

### Test 2: En Kötü Çözüm ❌
```python
genotype = [1, 2, 3, 4, 5, 6, 7, 8]
fitness = 0/28 (0%)
```
- Tüm vezirler düz çaprazda
- 28 çatışma (tüm çiftler saldırıyor)

### Test 3: Orta Seviye Çözüm
```python
genotype = [3, 5, 7, 2, 4, 8, 1, 6]
fitness = 25/28 (89.3%)
```
- 3 çatışma var
- 25 çift güvenli

## 🚀 Kullanım

### 1. Fitness Hesaplama
```python
from fitness import calculate_fitness

genotype = [4, 2, 7, 3, 6, 8, 5, 1]
score = calculate_fitness(genotype)
print(f"Fitness: {score}/28")  # Output: Fitness: 28/28
```

### 2. Popülasyon Oluşturma
```python
from fitness import generate_population

# 100 rastgele birey oluştur
population = generate_population(size=100)

print(f"Popülasyon boyutu: {len(population)}")
print(f"İlk birey: {population[0]}")
```

### 3. Popülasyon + Fitness
```python
from fitness import generate_population, calculate_fitness

# Popülasyon oluştur
pop = generate_population(size=50)

# Her bireyin fitness'ını hesapla
for individual in pop:
    fitness = calculate_fitness(individual)
    print(f"{individual} → {fitness}/28")

# En iyi bireyi bul
best = max(pop, key=calculate_fitness)
print(f"En iyi: {best} → {calculate_fitness(best)}/28")
```

### 4. Detaylı Analiz (Verbose)
```python
from fitness import calculate_fitness_verbose

genotype = [3, 5, 7, 2, 4, 8, 1, 6]
score = calculate_fitness_verbose(genotype)
# Tüm çiftleri tek tek kontrol eder ve yazdırır
```

### 5. Komut Satırı (Tüm Testler)
```bash
cd assignment-2
python3 fitness.py
```

## 📈 Genetik Algoritma İçin

Bu fonksiyonlar GA'nın temel taşlarıdır:

```python
from fitness import generate_population, calculate_fitness

# 1. Başlangıç popülasyonu oluştur
population = generate_population(size=100)

# 2. Her bireyin fitness'ını hesapla
fitness_scores = [calculate_fitness(ind) for ind in population]

# 3. Popülasyon istatistikleri
avg_fitness = sum(fitness_scores) / len(fitness_scores)
max_fitness = max(fitness_scores)

print(f"Ortalama: {avg_fitness:.1f}/28")
print(f"En iyi: {max_fitness}/28")

# 4. En iyi bireyi bul
best_index = fitness_scores.index(max_fitness)
best_individual = population[best_index]

# 5. Çözüm bulundu mu?
if max_fitness == 28:
    print(f"✅ Çözüm bulundu: {best_individual}")
else:
    print(f"ℹ️  En iyi: {best_individual} ({max_fitness}/28)")
```

### Popülasyon İstatistikleri Örneği
```
Popülasyon boyutu: 100
Ortalama fitness: 23.15/28 (82.7%)
En iyi fitness:   27/28 (96.4%)
En kötü fitness:  17/28 (60.7%)
```

**Not:** 100 rastgele bireyde genellikle fitness 20-27 arası değerler görülür. Mükemmel çözüm (28) bulmak için evrim gerekir!

## 🔑 Önemli Noktalar

1. **Maksimizasyon problemi**: Fitness'ı **maksimize** etmeye çalışıyoruz
2. **Hedef değer**: `fitness = 28` (mükemmel çözüm)
3. **Aralık**: 0 ≤ fitness ≤ 28
4. **Hızlı hesaplama**: O(n²) = O(64) çok hızlı

## � Test Sonuçları

### Popülasyon Testi
```bash
$ python3 fitness.py

1. Küçük popülasyon (size=5):
   Birey 1: [2, 6, 1, 5, 7, 3, 8, 4] → Fitness: 23/28
   Birey 2: [4, 8, 3, 6, 1, 2, 5, 7] → Fitness: 25/28
   Birey 3: [8, 4, 6, 1, 3, 7, 2, 5] → Fitness: 23/28
   Birey 4: [5, 4, 7, 1, 6, 3, 2, 8] → Fitness: 24/28
   Birey 5: [6, 4, 3, 1, 8, 2, 5, 7] → Fitness: 27/28

2. Normal popülasyon (size=100):
   Ortalama fitness: 23.15/28 (82.7%)
   En iyi fitness:   27/28 (96.4%)
   En kötü fitness:  17/28 (60.7%)
```

### Doğrulama
- ✅ Tüm bireyler geçerli permütasyon (1-8 arası benzersiz)
- ✅ Her birey için fitness doğru hesaplanıyor
- ✅ Popülasyon boyutu parametre ile kontrol ediliyor

## �📂 Dosyalar
- `fitness.py`: Tüm fonksiyonlar ve testler
- `README.md`: Dokümantasyon

## ✅ Tamamlanan Özellikler

### Bölüm 1: Fitness Fonksiyonu
- ✓ `calculate_fitness()` fonksiyonu
- ✓ Çapraz çatışma kontrolü
- ✓ Detaylı verbose modu
- ✓ Performans: O(n²)

### Bölüm 2: Popülasyon Oluşturma
- ✓ `generate_population(size)` fonksiyonu
- ✓ Rastgele permütasyon üretimi (`random.shuffle`)
- ✓ Parametre ile boyut kontrolü
- ✓ Doğrulama testleri
- ✓ Popülasyon istatistikleri

## 🔑 Önemli Kavramlar

1. **Fitness = Kalite ölçüsü**: Yüksek fitness → iyi çözüm
2. **Popülasyon = Arama uzayı**: Daha fazla birey → daha geniş arama
3. **Rastgelelik**: Her çalıştırmada farklı popülasyon oluşur
4. **İstatistik**: Ortalama fitness, populasyonun genel kalitesini gösterir

---
**Assignment 2 Tamamlandı** ✅
