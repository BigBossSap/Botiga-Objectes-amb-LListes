﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botiga_Objectes
{
    class Botiga
    {


        public string nom_botiga { get; set; }

        private List<Producte> productes;

        private int nombre_productes;



        public Botiga(int num)
        {
            productes = new List<Producte>();
            nombre_productes = 20;


        }

        public bool AfegirProducte(Producte Producte)
        {
            bool afegit = false;
           


            if (productes.Count() < nombre_productes)
            {
                productes.Add(Producte);
                afegit = true;
            }
          
            return afegit;


        }

        private int BuscarProducte(Producte producte)
        {
            
            int pos=productes.IndexOf(producte);

            
            return pos;

        }

       

        //public Producte TornarProducte(string nom)
        //{
        //    int cont = 0;
        //    int pos = 0;
        //    for (int i = 0; i < ProductesBotiga.Length; i++)
        //    {
        //        if (ProductesBotiga[i] == null)
        //        {

        //        }


        //        else if (ProductesBotiga[i].Nom == nom)
        //        {
        //            pos = cont;
        //            cont++;
        //        }

        //        cont++;


        //    }
        //    return ProductesBotiga[pos];
        //}

        //ModificarProducte(Producte producte, String nou_nom, double nou_preu) : Mètode
        //    públic.Donat un producte hem de buscar-lo a la taula de productes per saber
        //    quina posició de la taula ocupa, per així
        //    després modificar les dades. Retorna un booleà amb true si l’ha modificat i false si ho ha pogut.

        public bool ModificarProducte(Producte producte, string nomNou, double preuNou, double ivaNou)
        {
            bool modificat = false;

            int pos = BuscarProducte(producte);
                
                productes[pos].Nom = nomNou;
                productes[pos].Preu_sense_iva = preuNou;
                productes[pos].Iva = ivaNou;
                modificat = true;
            

            return modificat;


        }

        //public bool ModificarProducte(string producte, string nomNou, double preuNou)
        //{
        //    bool trobat = false;

        //    if (BuscarProducte(producte) != -1)
        //    {
        //        int pos = BuscarProducte(producte);
        //        ProductesBotiga[pos].Nom = nomNou;
        //        ProductesBotiga[pos].Preu = preuNou;
        //        trobat = true;
        //    }

        //    return trobat;


        //}

        //EsborrarProducte(Producte producte) : Mètode públic.Donat un producte hem de buscar-lo a
        //    la taula de productes per saber quina posició de la taula ocupa, 
        //    per així després esborrar-lo.Per esborrar-lo de la taula, 
        //    posarem null en el lloc de la taula que s’hagi trobat.


        public bool EsborrarProducte(Producte producte)
        {
            bool esborrat = false;

            productes.Remove(producte);


            return esborrat;
        }

        //PrestatgeLliure() : Mètode privat.Retorna la 
        //    posició de la taula a on es pot afegir un producte. 
        //    Retorna -1 si la botiga està plena.

        private bool PrestatgeLLiure()
        {
            
            bool lliure = false;

            if (productes.Count() < nombre_productes)
                lliure = true;

            

            return lliure;
        


        }

        //ToString(): retorna de forma amigable un string amb tots els productes amb 
        //    els seus preus i iva respectius. 
        //    Recorda que no es pot fer servir el Console.Write 
        //    dintre de l’objecte, el Console.Write s’ha de fer servir des del main().

        public string ToString()
        {
            string botigaText = "";

            foreach(Producte prod in productes)
            {

                botigaText += prod.Nom;
                botigaText += prod.Preu_sense_iva;
                botigaText += prod.Iva;


            }
          


            return botigaText;




        }
    }
}
