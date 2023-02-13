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

        //       ComprarProducte(Producte producte, int quantitat) : Afegeix un producte
        //       tantes vegades com indiqui quantitat.


        public bool ComprarProducte(Producte producte, int quantitat)
        {
            // 0 = no hi ha diners, 1=afegit, -1 No afegit per espai.
            // Sense poder accedir a la llista de prestatge ni al metode buscar producte, no se com comprovar 
            // si el producte existeix.
            bool resultat = false;

            if (Moneder - producte.PreuProducte() * quantitat >= 0)
            {

                if (!(Productes.Count + quantitat > nombre_productes))
                {
                    for (int i = 0; i < quantitat; i++)
                    {
                        Productes.Add(producte);
                        resultat = true;
                    }

                }

            }

            
            
           
        
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

        


        //ToString() : retorna de forma amigable un string amb tots els 
        //    productes.Retorna també el total amb iva inclòs.
        //    Recordar que no es pot fer servir el Console.Write 
        //    dintre de l’objecte, el Console.Write s’ha 
        //        de fer servir des del main().

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
