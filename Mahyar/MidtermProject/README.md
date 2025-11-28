# TSP Genetik Algoritma Projesi

Bu proje, Traveling Salesman Problem (TSP) için Genetik Algoritma implementasyonudur.

## 📁 Dosyalar

- `tsp_genetic_algorithm.py`: Tek dosyada tüm kod (sınıflar + main)
- `*.tsp`: TSP problem dosyaları (berlin52, att48, a280, att532)

## 🎯 Algoritma Özellikleri

### Başlatma
- TSP dosyasından veri okuma (EUC_2D ve ATT formatları)
- İlk popülasyon: 100 rastgele tur

### Genetik Operatörler
- **Seçim**: %50 Rank-based, %50 Roulette Wheel
- **Çaprazlama**: Cycle Crossover
- **Mutasyon**: %50 Insert, %50 Random Slide
- **Elitizm**: En iyi kromozom korunur

### Sonlandırma
- 100 nesil tamamlandığında
- Ardışık 5 nesil iyileşme olmadığında

## 🚀 Kullanım

```bash
python3 tsp_genetic_algorithm.py
```

Tüm `.tsp` dosyalarını okur ve sonuçları karşılaştırır.

## 📊 Fitness Hesaplama

```
Fitness = 1 / Toplam Mesafe
```

## 🎓 Algoritma Akışı

1. 100 rastgele tur oluştur
2. Her nesil:
   - En iyi çözümü koru (Elitizm)
   - Ebeveyn seç (Rank/Roulette)
   - Cycle Crossover uygula
   - Mutasyon uygula (Insert/Slide)
3. Sonlandırma kriterine kadar devam et

## 📝 Not

Sonuçlar rastgele başlatma nedeniyle her çalıştırmada farklı olabilir.
