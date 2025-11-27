#Kaan Kara - 220404046
from tsp_genetic_algorithm import TSPData, GeneticAlgorithm
import os


def run_demo(tsp_file: str, max_generations: int = 100, stagnation_limit: int = 5):

    print(f"\n# TSP DOSYASI: {os.path.basename(tsp_file)}")
    print("#"*50)  
    tsp_data = TSPData(tsp_file)
    ga = GeneticAlgorithm(tsp_data, population_size=100)
    best_solution = ga.run(max_generations=max_generations, stagnation_limit=stagnation_limit)
    
    print("\n  SONUÇ ÖZETİ:")
    print(f"   Problem: {tsp_data.name}")
    print(f"   Şehir Sayısı: {tsp_data.dimension}")
    print(f"   Nesil Sayısı: {ga.generation}")
    print(f"   En İyi Mesafe: {best_solution.get_total_distance():.2f}")
    print(f"   Başlangıç Mesafesi: {ga.best_history[0]:.2f}")
    print(f"   İyileşme: {((ga.best_history[0] - best_solution.get_total_distance()) / ga.best_history[0] * 100):.2f}%")
    print(f"\n   En İyi Tur (ilk 20 şehir): {best_solution.genes[:20]}")
    print("\n     Nesil Bazında İyileşme (Her 10 nesilde bir):")
    step = max(1, ga.generation // 10)
    for i in range(0, len(ga.best_history), step):
        distance = ga.best_history[i]
        bar_length = int((1 - distance / ga.best_history[0]) * 40)
        bar = "█" * bar_length
        print(f"      Nesil {i:3d}: {distance:8.2f} {bar}")
    
    return ga


def main():
    current_dir = os.path.dirname(os.path.abspath(__file__))
    tsp_files = [
        os.path.join(current_dir, "berlin52.tsp"),
        os.path.join(current_dir, "att48.tsp"),
    ]
    
    other_files = ["a280.tsp", "att532.tsp"]
    for file in other_files:
        file_path = os.path.join(current_dir, file)
        if os.path.exists(file_path):
            tsp_files.append(file_path)
    
    print("\nParametreler:")
    print("  • Popülasyon Boyutu: 100")
    print("  • Maksimum Nesil: 100")
    print("  • Durgunluk Limiti: 5 nesil")
    print("  • Elitizm: Aktif (en iyi 1 kromozom)")
    print("  • Seçim: %50 Rank-based, %50 Roulette Wheel")
    print("  • Çaprazlama: Cycle Crossover")
    print("  • Mutasyon: %50 Insert, %50 Random Slide")
    
    results = []
    
    for tsp_file in tsp_files:
        if os.path.exists(tsp_file):
            ga = run_demo(tsp_file)
            results.append({
                'file': os.path.basename(tsp_file),
                'cities': ga.tsp_data.dimension,
                'generations': ga.generation,
                'best_distance': ga.best_chromosome.get_total_distance(),
                'initial_distance': ga.best_history[0],
                'improvement': ((ga.best_history[0] - ga.best_chromosome.get_total_distance()) / ga.best_history[0] * 100)
            })
        else:
            print(f"\n⚠️  Dosya bulunamadı: {tsp_file}")
    
    print("\n" + " "*25 + "GENEL ÖZET")
    print(f"\n{'Dosya':<20} {'Şehir':<8} {'Nesil':<8} {'En İyi':<12} {'İyileşme':<10}")
    print("-"*80)
    
    for result in results:
        print(f"{result['file']:<20} {result['cities']:<8} {result['generations']:<8} "
              f"{result['best_distance']:<12.2f} {result['improvement']:<10.2f}%")

if __name__ == "__main__":
    main()