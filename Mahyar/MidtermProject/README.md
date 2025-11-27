# TSP Genetik Algoritma Projesi

Bu proje, Traveling Salesman Problem (TSP) için Genetik Algoritma implementasyonudur.

## 📁 Dosyalar

- `tsp_genetic_algorithm.py`: Ana genetik algoritma implementasyonu
- `demo.py`: Demo ve test dosyası
- `*.tsp`: TSP problem dosyaları (berlin52, att48, a280, att532)

## 🎯 Proje Özellikleri

### Başlatma (Initialization)
- TSP dosyasından veri okuma (EUC_2D ve ATT formatları desteklenir)
- Kromozom yapısı: Şehirlerin permutasyonu
- İlk popülasyon: 100 rastgele kromozom

### Genetik Operatörler

#### Seçim (Selection)
- **%50 Sıra Tabanlı Seçim (Rank Based Selection)**: `rank_based_selection()`
- **%50 Rulet Tekerleği Seçimi (Roulette Wheel Selection)**: `roulette_wheel_selection()`

#### Çaprazlama (Crossover)
- **Döngü Çaprazlaması (Cycle Crossover)**: `cycle_crossover()`
  - TSP için uygun, geçerli permutasyonlar üretir

#### Mutasyon (Mutation)
- **%50 Araya Ekleme Mutasyonu (Insert Mutation)**: `insert_mutation()`
  - Rastgele bir şehir seçilip başka bir pozisyona eklenir
- **%50 Rastgele Kaydırma (Random Slide)**: `random_slide_mutation()`
  - Rastgele bir alt dizi seçilip kaydırılır

### Evrimsel Süreç
- **Elitizm**: En iyi kromozom her nesilde korunur
- **Popülasyon Boyutu**: 100
- **Her Nesil**: 99 yeni çözüm üretilir

### Sonlandırma Kriterleri
1. **100 nesil** sonra, VEYA
2. En iyi çözüm **ardışık 5 yineleme** boyunca değişmediğinde

## 🚀 Kullanım

### Demo'yu Çalıştırma
```bash
python demo.py
```

Bu komut:
- Tüm TSP dosyalarını okur
- Her biri için genetik algoritmayı çalıştırır
- Nesil bazında iyileşmeleri gösterir
- Sonuçları karşılaştırır

### Tek Bir Dosya için Test
```python
from tsp_genetic_algorithm import TSPData, GeneticAlgorithm

# TSP verisini yükle
tsp_data = TSPData("berlin52.tsp")

# Genetik Algoritmayı çalıştır
ga = GeneticAlgorithm(tsp_data, population_size=100)
best_solution = ga.run(max_generations=100, stagnation_limit=5)

print(f"En İyi Mesafe: {best_solution.get_total_distance():.2f}")
print(f"En İyi Tur: {best_solution.genes}")
```

## 📊 Örnek Çıktı

```
==============================================================================
                        TSP GENETİK ALGORİTMA DEMO
==============================================================================

Parametreler:
  • Popülasyon Boyutu: 100
  • Maksimum Nesil: 100
  • Durgunluk Limiti: 5 nesil
  • Elitizm: Aktif (en iyi 1 kromozom)
  • Seçim: %50 Rank-based, %50 Roulette Wheel
  • Çaprazlama: Cycle Crossover
  • Mutasyon: %50 Insert, %50 Random Slide

################################################################################
# TSP DOSYASI: berlin52.tsp
################################################################################
TSP Dosyası Yüklendi: berlin52
Şehir Sayısı: 52
Mesafe Tipi: EUC_2D

============================================================
GENETİK ALGORİTMA BAŞLADI
============================================================

İlk Popülasyon Oluşturuldu: 100 kromozom
Başlangıç En İyi Mesafe: 45623.45

Nesil 1: En İyi Mesafe = 43891.23
Nesil 2: En İyi Mesafe = 41567.89
...
Nesil 100: En İyi Mesafe = 8234.56

✓ Sonlandırma: 100 nesil tamamlandı

============================================================
GENETİK ALGORİTMA TAMAMLANDI
============================================================
```

## 🔧 Parametreler

Parametreleri `demo.py` veya doğrudan kod içinde değiştirebilirsiniz:

- `population_size`: Popülasyon boyutu (varsayılan: 100)
- `max_generations`: Maksimum nesil sayısı (varsayılan: 100)
- `stagnation_limit`: Durgunluk limiti (varsayılan: 5)

## 📈 Fitness Hesaplama

Fitness = 1 / Toplam Mesafe

- Daha kısa mesafe = Daha yüksek fitness
- Her kromozom için tur mesafesi hesaplanır
- Son şehirden başlangıca dönüş de dahildir

## 🎓 Algoritma Akışı

1. **Başlatma**: 100 rastgele tur oluştur
2. **Her Nesil**:
   - En iyi çözümü koru (Elitizm)
   - 99 çift ebeveyn seç (Rank/Roulette)
   - Cycle Crossover uygula
   - Mutasyon uygula (Insert/Slide)
   - Yeni popülasyon oluştur
3. **Sonlandırma**: Kriter sağlanana kadar devam et
4. **Sonuç**: En iyi tur ve mesafeyi raporla

## 📝 Notlar

- TSP dosyaları TSPLIB formatında olmalıdır
- EUC_2D ve ATT mesafe tipleri desteklenir
- Her nesilde en iyi mesafe konsola yazdırılır
- Sonuçlar deterministik değildir (rastgelelik içerir)

## 👨‍💻 Geliştirme

Yeni özellikler eklemek için:
- `GeneticAlgorithm` sınıfına yeni operatörler eklenebilir
- Farklı seçim/çaprazlama/mutasyon yöntemleri denenebilir
- Grafik arayüz (matplotlib) eklenebilir
- Sonuçlar dosyaya kaydedilebilir
