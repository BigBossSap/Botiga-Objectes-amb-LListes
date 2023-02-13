using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga_Objectes
{
    class Botiga
    {
        public string nom_botiga { get; set; }
        private List<Producte> prestatge;
        private int nombre_productes;
        public Botiga(int num)
        {
            prestatge = new List<Producte>();
            nombre_productes = 20;
        }
        public bool AfegirProducte(Producte Producte)
        {
            bool afegit = false;
            if (prestatge.Count() < nombre_productes)
            {
                prestatge.Add(Producte);
                afegit = true;
            }
            return afegit;
        }
        private int BuscarProducte(Producte producte)
        {
            int pos=prestatge.IndexOf(producte);
            return pos;
        }
        public Producte TornarProducte(string nom)
        {
            Producte producte = null;
            producte= prestatge.Find(a => a.Nom.Equals(nom));
            return producte;
        }
        
        public bool ModificarProducte(Producte producte, string nomNou, double preuNou, double ivaNou)
        {
            bool modificat = false;
            int pos = BuscarProducte(producte);
            if (pos != -1)
            {
                prestatge[pos].Nom = nomNou;
                prestatge[pos].Preu_sense_iva = preuNou;
                prestatge[pos].Iva = ivaNou;
                modificat = true;
            }
            return modificat;
        }
        
        public bool EsborrarProducte(Producte producte)
        {
            bool esborrat = false;
            if (prestatge.Remove(producte))
                esborrat = true;
            return esborrat;
        }
        
        private bool PrestatgeLLiure()
        {
            bool lliure = false;
            if (prestatge.Count() < nombre_productes)
                lliure = true;
            return lliure;
        }
        
        public string ToString()
        {
            string botigaText = "";
            foreach(Producte prod in prestatge)
            {
                botigaText += $"Producte: {prod.Nom} \n";
                botigaText += $"Preu: {prod.Preu_sense_iva} ";
                botigaText += $"IVA: {prod.Iva}\n\n";
            }
            return botigaText;
        }
    }
}
