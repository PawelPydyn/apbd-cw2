using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class KontenerChlodniczyC : Kontener
    {
        protected String rodzaj_produktu { get; set; }
        protected double temperatura { get; set; }
        private  Dictionary<string, double> temepraturaProduktu; // product - temperatura
        private  Dictionary<string, int> productCounter; //np zliczanie ze baban byl dodany 20 razy

        public KontenerChlodniczyC(double masa_ladunku,
                                   double wyokosc,
                                   double waga_wlasna,
                                   double glebokosc,
                                   string rodzaj_kontenera,
                                   double maksymalna_ladownosc,
                                   double temperatura) : base(masa_ladunku, wyokosc, waga_wlasna, glebokosc, rodzaj_kontenera, maksymalna_ladownosc)
        {
            this.rodzaj_produktu = rodzaj_produktu;
            this.temperatura = temperatura;
            temepraturaProduktu = new Dictionary<string, double>();
            productCounter = new Dictionary<string, int>();
        }
        public void addProduct(string product, double temp)
        {
            if (!temepraturaProduktu.ContainsKey(product))
            {
                temepraturaProduktu.Add(product, temp);
            } else
            {
                throw new Exception($"Produkt {product} juz istnieje ");
            }
        }
        public void loadProducts(string product, int val)
        {
            if (!temepraturaProduktu.ContainsKey(product))
            {
                throw new Exception($"Produkt {product} nie jest obsługiwany.");
            }

            if (temepraturaProduktu[product] > temperatura)
            {
                throw new Exception($"Temperatura w kontenerze ({temperatura}) jest zbyt wysoka dla produktu {product} ({temepraturaProduktu[product]}).");
            }

            if (productCounter.Count == 0)
            {
                productCounter.Add(product, val);
            }
            else if (productCounter.ContainsKey(product))
            {
                productCounter[product] += val;
            }
            else
            {
                throw new Exception($"Nie można dodać produktu {product}, ponieważ kontener zawiera już inny produkt.");
            }
        }
    }
}
