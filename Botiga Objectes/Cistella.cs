using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Botiga_Objectes
{
    class Cistella
    {
        public string Data { get; set; }
        private List<Producte> Productes;
        private int nombre_productes;
        public double Moneder;
        public Cistella( int nombre_productes, double diners)
        {
            Productes = new List<Producte>();
            Moneder = diners;
            this.nombre_productes = nombre_productes;
        }
       
        public bool ComprarProducte(Producte producte, int quantitat)
        {
            
            // Sense poder accedir a la llista de prestatge ni al metode buscar producte, no se com comprovar 
            // si el producte existeix.
            bool resultat = false;
            if (Moneder - producte.PreuProducte() * quantitat >= 0)
            {
                if (!(Productes.Count + quantitat > nombre_productes))
                {
                    for (int i = 0; i < quantitat; i++)
                    {
                        Productes.Add(new Producte(producte.Nom,producte.Preu_sense_iva,producte.Iva));                        
                        resultat = true;
                    }
                }
            }
            if (resultat)
                Moneder-= producte.PreuProducte() * quantitat;
            return resultat;
        }
        public double CostTotal()
        {
            double costTotal=0;
            foreach(Producte producte in Productes)
            {
                costTotal += producte.PreuProducte();
            }
            return costTotal;
        }
      
        public string ToString()
        {
            string cistellaText = "";
            foreach(Producte p in Productes)
            {
                cistellaText += new string(' ', Console.WindowWidth / 3) + $"Nom: <{p.Nom}>  \n";
                cistellaText += new string(' ', Console.WindowWidth / 3) + $"Preu: {p.Preu_sense_iva}€ \n";
                cistellaText += new string(' ', Console.WindowWidth / 3) + $"Iva:  {p.Iva}% \n";
            }
            cistellaText += $"Cost Total Iva Inclos: {CostTotal()}";
            return cistellaText;
        }
    }
}
