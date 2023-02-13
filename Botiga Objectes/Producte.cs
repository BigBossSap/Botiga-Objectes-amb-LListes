using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga_Objectes
{
    public class Producte
    {
        public string Nom { get; set; }
        public double Preu_sense_iva { get; set; }
        public double Iva { get; set; }
        public Producte()
            {
                        }
        public Producte(string producte, double preu, double iva)
        {
            Nom = producte;
            Preu_sense_iva = preu;
            Iva = iva;
        }
        public double PreuProducte()
        {
            double preuTotal;
            preuTotal = Preu_sense_iva + (Preu_sense_iva * Iva/100);
            return preuTotal;
        }
        public string LlistarProducte()
        {
            string text = $"Producte: {Nom}, preu sense IVA: {Preu_sense_iva}, preu amb IVA: {PreuProducte()}, IVA aplicat: {Iva}";
            return text;
        }
    }
}
