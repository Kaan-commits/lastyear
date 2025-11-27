# Assignment 3: Genetik Operatörler
**Kaan Kara - 220404046**

---

## 📋 Proje Açıklaması

Bu ödev, 8 Vezir Problemi için Genetik Algoritma'nın temel operatörlerini içerir:
1. **Seçilim (Selection)** - Turnuva Seçilimi
2. **Çaprazlama (Crossover)** - Tek Noktalı Çaprazlama
3. **Mutasyon (Mutation)** - Takas Mutasyonu

---

## 🎯 Bölüm 1: Turnuva Seçilimi (Tournament Selection)

### Ne yapar?
Popülasyondan en iyi bireyleri seçmek için turnuva düzenler.

### Nasıl çalışır?
1. Popülasyondan rastgele 3 birey seçilir
2. Bu 3 bireyin fitness puanları karşılaştırılır
3. En yüksek fitness'a sahip olan kazanır
4. Kazanan, yeni nesil için ebeveyn olarak kullanılır

### Örnek:
```
Turnuvaya girenler:
  - Birey 0: fitness = 28
  - Birey 2: fitness = 18
  - Birey 4: fitness = 15

Kazanan: Birey 0 (fitness: 28)
```

### Fonksiyon:
```python
def tournament_selection(population, fitness_scores, tournament_size=3):
    # Rastgele tournament_size kadar birey seç
    # En yüksek fitness'lı olanı döndür
```

---

## 🧬 Bölüm 2: Çaprazlama (Crossover)

### Ne yapar?
İki ebeveynin genlerini birleştirerek yeni bir yavru oluşturur.

### Nasıl çalışır?
1. Rastgele bir çaprazlama noktası seçilir (örn: 3)
2. Yavru, çaprazlama noktasına kadar Ebeveyn 1'den gen alır
3. Kalan genler Ebeveyn 2'den alınır (tekrar etmeyecek şekilde)

### Örnek:
```
Ebeveyn 1: [4, 2, 7, | 3, 6, 8, 5, 1]
Ebeveyn 2: [1, 5, 2, | 6, 8, 7, 4, 3]
                      ↑ çaprazlama noktası: 3

Yavru:     [4, 2, 7, | 6, 8, 1, 5, 3]
            └─────┘   └───────────┘
           Ebeveyn 1   Ebeveyn 2'den
                       (sırayla, tekrarsız)
```

### Neden bu yöntem?
Normal çaprazlama permütasyonlarda geçersiz yavrular üretebilir (tekrar eden sayılar). Bu yöntem her zaman geçerli permütasyon üretir.

### Fonksiyon:
```python
def crossover(parent1, parent2):
    # Rastgele çaprazlama noktası seç
    # Yavru oluştur (geçerli permütasyon)
```

---

## 🔄 Bölüm 3: Mutasyon (Mutation)

### Ne yapar?
Genotipin iki rastgele pozisyonunu yer değiştirir.

### Nasıl çalışır?
1. Rastgele bir sayı üretilir (0-1 arası)
2. Bu sayı mutasyon oranından küçükse mutasyon gerçekleşir
3. İki rastgele pozisyon seçilir ve değerleri yer değiştirir

### Örnek:
```
Önceki:  [4, 2, 7, 3, 6, 8, 5, 1]
                ↓           ↓
         İndeks 1 ve 4 seçildi (2 ve 6)

Sonraki: [4, 6, 7, 3, 2, 8, 5, 1]
                ↑           ↑
         Değerler yer değiştirdi
```

### Mutasyon Oranı:
- `mutation_rate = 0.05` → %5 olasılıkla mutasyon
- `mutation_rate = 0.5` → %50 olasılıkla mutasyon
- Düşük oran: Yavaş evrim, daha stabil
- Yüksek oran: Hızlı değişim, daha fazla çeşitlilik

### Fonksiyon:
```python
def mutate(genotype, mutation_rate=0.05):
    # mutation_rate olasılıkla
    # İki pozisyonu değiştir
```

---

## 🚀 Kullanım

### Dosyayı çalıştır:
```bash
cd assignment-3
python3 genetic_operators.py
```

### Kendi kodunda kullan:
```python
from genetic_operators import tournament_selection, crossover, mutate

# Popülasyon ve fitness puanları
population = [[4,2,7,3,6,8,5,1], [1,2,3,4,5,6,7,8], ...]
fitness_scores = [28, 0, ...]

# Ebeveyn seç
parent1 = tournament_selection(population, fitness_scores)
parent2 = tournament_selection(population, fitness_scores)

# Yavru oluştur
child = crossover(parent1, parent2)

# Mutasyon uygula
mutated_child = mutate(child, mutation_rate=0.05)
```

---

## 📊 Test Sonuçları

### Turnuva Seçilimi:
- ✅ Yüksek fitness'lı bireyler daha sık seçilir
- ✅ Düşük fitness'lı bireyler nadiren seçilir
- ✅ Rastgelelik sayesinde çeşitlilik korunur

### Çaprazlama:
- ✅ Her zaman geçerli permütasyon üretir
- ✅ Her çalıştırmada farklı yavru oluşabilir (rastgele çaprazlama noktası)
- ✅ İki ebeveynin özelliklerini birleştirir

### Mutasyon:
- ✅ Mutasyon oranı doğru çalışır
- ✅ Mutasyon sonrası permütasyon geçerliliğini korur
- ✅ Genetik çeşitliliği artırır

---

## 🧠 Genetik Algoritma Akışı

```
1. Başlangıç Popülasyonu Oluştur
   ↓
2. Her birey için Fitness Hesapla
   ↓
3. [SEÇİLİM] Ebeveynleri seç (Turnuva)
   ↓
4. [ÇAPRAZLAMA] Yavrular oluştur
   ↓
5. [MUTASYON] Yavrulara mutasyon uygula
   ↓
6. Yeni nesil oluştu
   ↓
7. Durma koşulu sağlanmadıysa 2'ye dön
```

---

## 💡 Önemli Notlar

### Neden Turnuva Seçilimi?
- Basit ve etkili
- En iyi bireyleri seçme eğilimi
- Ama zayıf bireyler de şans alabilir (çeşitlilik)

### Neden Bu Çaprazlama Yöntemi?
- Permütasyonlar için özel tasarım
- **Her zaman** geçerli sonuç üretir
- Klasik çaprazlama tekrar eden sayılar üretir

### Mutasyon Neden Önemli?
- Lokal minimumlardan kaçınmak için
- Genetik çeşitliliği korur
- Arama uzayını keşfetmeyi sağlar

---

## 📁 Dosya Yapısı

```
assignment-3/
├── genetic_operators.py    # Ana kod dosyası
└── README.md              # Bu dosya
```

---

## 🎓 Kavramlar

- **Genotip**: Bireyin genetik yapısı (bizde: [1,2,3,4,5,6,7,8] permütasyonu)
- **Fitness**: Bireyin çözüme ne kadar yakın olduğu (0-28 arası)
- **Ebeveyn**: Yeni nesil oluşturmak için seçilen bireyler
- **Yavru**: İki ebeveynden oluşturulan yeni birey
- **Popülasyon**: Tüm bireylerin kümesi
- **Nesil**: Bir döngüdeki tüm popülasyon

---

**Hazırlayan:** Kaan Kara (220404046)  
**Tarih:** Kasım 2025  
**Ders:** Evolutionary Computation
