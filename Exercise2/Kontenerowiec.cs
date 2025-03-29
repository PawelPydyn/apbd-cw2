using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class Kontenerowiec
    {
        public string nazwa { get; set; }
        public double maksymalna_predkosc { get; set; }
        public int maksymalnaLiczbaKontenerow { get; set; }
        public double maksymalnaWagaLadunku { get; set; }
        private List<Kontener> kontenery;

        public Kontenerowiec(string nazwa, double maksPredkosc, int maxKontenery, double maxWaga)
        {
            
            this.nazwa = nazwa;
            this.maksymalna_predkosc = maksPredkosc;
            this.maksymalnaLiczbaKontenerow = maxKontenery;
            this.maksymalnaWagaLadunku = maxWaga;
            kontenery = new List<Kontener>();
        }

        public void zaladujKontener(Kontener kontener)
        {
            if (kontenery.Count >= maksymalnaLiczbaKontenerow)
                throw new Exception("Przekroczona maksymalna liczba kontenerów!");

            double aktualnaWaga = kontenery.Sum(k => k.masa_ladunku + k.waga_wlasna);
            if (aktualnaWaga + kontener.masa_ladunku + kontener.waga_wlasna > maksymalnaWagaLadunku)
                throw new Exception("Przekroczona maksymalna waga statku!");

            kontenery.Add(kontener);
        }

        public void zaladujListeKontenerow(List<Kontener> lista)
        {
            foreach (var kontener in lista)
            {
                zaladujKontener(kontener);
            }
        }

        public void usunKontener(string numerSeryjny)
        {
            var kontener = kontenery.FirstOrDefault(k => k.numer_seryjny == numerSeryjny);
            if (kontener == null)
                throw new Exception("Nie znaleziono kontenera!");
            kontenery.Remove(kontener);
        }

        public void zastapKontener(string numerSeryjny, Kontener nowyKontener)
        {
            usunKontener(numerSeryjny);
            zaladujKontener(nowyKontener);
        }

        public void przeniesKontenerNaInnyStatek(string numerSeryjny, Kontenerowiec innyKontenerowiec)
        {
            var kontener = kontenery.FirstOrDefault(k => k.numer_seryjny == numerSeryjny);
            if (kontener == null)
                throw new Exception("Nie znaleziono kontenera!");

            usunKontener(numerSeryjny);
            innyKontenerowiec.zaladujKontener(kontener);
        }

        public void wypiszInformacjeOStatku()
        {
            Console.WriteLine($"Statek: {nazwa}, Max prędkość: {maksymalna_predkosc} węzłów");
            Console.WriteLine($"Liczba kontenerów: {kontenery.Count}/{maksymalnaLiczbaKontenerow}");
            Console.WriteLine($"Całkowita waga ładunku: {kontenery.Sum(k => k.masa_ladunku + k.waga_wlasna)}/{MaksymalnaWagaLadunku} ton");
            Console.WriteLine("Lista kontenerów:");
            foreach (var kontener in kontenery)
            {
                Console.WriteLine(kontener);
            }
        }
    }
}
