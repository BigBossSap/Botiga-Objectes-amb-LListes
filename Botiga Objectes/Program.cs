using System;

namespace Botiga_Objectes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WindowHeight = 50;
            Console.WindowWidth = 75;

            

            Producte taula = new Producte("taula", 100, 21);
            Producte cadira = new Producte("cadira", 80, 16);
            Producte mesa = new Producte("nevera", 75, 8);
            Botiga botiga = new Botiga(20);
            Cistella cistella = new Cistella(20,2000);
            botiga.Nom = "Mercadona";
            botiga.AfegirProducte(taula);
            botiga.AfegirProducte(cadira);
            botiga.AfegirProducte(mesa);
            string[] opcions = new string[] { "1-Client", "2-Administrador","3-Joc de proves TEST", "4-Sortir"};
            menutest menu = new menutest(opcions);
            
            menu.MostrarMenu();
            int seleccio = menu.seleccio();
            //Console.WriteLine(botiga.BotigaText());
            //Console.WriteLine(botiga.BuscarProducte(mesa)); 

            //Console.WriteLine(taula.LlistarProducte());
            //Console.WriteLine(cadira.LlistarProducte());
            //Console.WriteLine(cadira.LlistarProducte());

            //Console.WriteLine(taula.PreuProducte()); 
          
            
            while (seleccio != 3) {
                switch (seleccio)
                {

                    case 0:
                        string[] opcionsClient = new string[] { "1-Afegir producte", "2-Mostrar Cistella","3-Cost Total-Diners restants","4-Enrere" };
                        menutest menuClient = new menutest(opcionsClient);
                        menuClient.MostrarMenu();
                        int seleccio2 = menuClient.seleccio();
                        while (seleccio2 != 3)
                        {
                            switch (seleccio2)
                            {
                                case 0:

                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("Productes disponibles: ");
                                    Console.WriteLine(botiga.BotigaText());
                                    Console.WriteLine("Quin producte vols comprar?");
                                    string producteComprar = Console.ReadLine();
                                    Producte compra = botiga.TornarProducte(producteComprar);
                                    if (compra != null)


                                    {
                                        Console.WriteLine("Quantitat:");
                                        int quantitat = Convert.ToInt32(Console.ReadLine());
                                        int resultat= cistella.ComprarProducte(compra, quantitat);

                                        if (resultat==1)
                                            Console.WriteLine($"Producte {producteComprar} afegit a la cistella {quantitat} veguades");
                                        else if (resultat==0)
                                            Console.WriteLine("Insuficients diners o espai a la cistella.");

                                        Console.WriteLine("Presiona qualsevol tecla pero continuar.");
                                        Console.ReadLine();

                                    }

                                    

                                    else
                                    {
                                        Console.WriteLine("Producte no trobat");
                                        Console.ReadLine();
                                        Console.WriteLine("Presiona qualsevol tecla pero continuar.");
                                        Console.ReadLine();
                                    }


                                    break;
                                case 1:
                                    
                                    Console.Clear();
                                    Console.WriteLine();
                                    
                                    Console.WriteLine(cistella.CistellaText());
                                    Console.WriteLine();
                                    Console.WriteLine("Presiona qualsevol tecla pero continuar.");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    
                                    Console.WriteLine(cistella.cistellaCostTotal());
                                    Console.WriteLine(cistella.Moneder);
                                    Console.WriteLine("Presiona qualsevol tecla pero continuar.");
                                    Console.ReadLine();


                                    break;

                                

                                
                            }

                            menuClient.MostrarMenu();
                            seleccio2 = menuClient.seleccio();

                        }

                        break;

                    case 1:
                        string[] opcionsAdmin = new string[] { "1-Afegir Producte a la Botiga", "2-Mostrar Productes de la Botiga", "3-Modificar Producte", "4-Eliminar Producte", "5-Enrere" };
                        menutest menuAdmin = new menutest(opcionsAdmin);
                        menuAdmin.MostrarMenu();
                        int seleccio3 = menuAdmin.seleccio();

                        while (seleccio3 != 4)
                        {

                            switch (seleccio3)
                            {

                                case 0:
                                    Console.WriteLine();
                                    Console.Write("Nom del producte: ");
                                    string nom = Console.ReadLine();
                                    Console.Write("Preu del producte: ");
                                    double preu = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("IVA del producte: ");
                                    double iva=Convert.ToDouble(Console.ReadLine());

                                    Producte nouProducte=new Producte(nom, preu, iva);
                                    botiga.AfegirProducte(nouProducte);

                                    break;


                                case 1:
                                    
                                    Console.WriteLine();
                                    Console.WriteLine(botiga.BotigaText()); 
                                    Console.WriteLine("Presiona");
                                    Console.ReadKey();


                                    break;

                                case 2:
                                   
                                    Console.WriteLine(botiga.BotigaText());
                                    Console.WriteLine("Quin produce vols modificar?");
                                    string producteModificar = Console.ReadLine();
                                    if (botiga.TornarProducte(producteModificar) != null)


                                    {
                                        Console.WriteLine("Nou nom: ");
                                        string nouNom = Console.ReadLine();
                                        Console.WriteLine("Nou Preu:");
                                        int nouPreu = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Nou Iva:");
                                        int nouIva = Convert.ToInt32(Console.ReadLine());
                                        Producte Modificar = botiga.TornarProducte(producteModificar);
                                        botiga.ModificarProducte(Modificar, nouNom, nouPreu, nouIva);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Producte no trobat");
                                        Console.ReadLine();
                                    }

                                    Console.WriteLine("Presiona");
                                    Console.ReadKey();


                                    break;

                                case 3:


                                    Console.WriteLine(botiga.BotigaText());
                                    Console.WriteLine("Quin produce vols eliminar?");
                                    string producteEliminar = Console.ReadLine();
                                    if (botiga.TornarProducte(producteEliminar) != null)


                                    {
                                        
                                        
                                        botiga.EsborrarProducte(botiga.TornarProducte(producteEliminar));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Producte no trobat");
                                        Console.ReadLine();
                                    }
                                    Console.WriteLine("Presiona");
                                    Console.ReadKey();

                                    break;


                            }


                            menuAdmin.MostrarMenu();
                            seleccio3 = menuAdmin.seleccio();


                        }


                        break;


                    case 2:

                        int nota_correccio = 0;
                        try
                        {
                            Console.WriteLine();
                            Botiga botiga2 = new Botiga(3);

                            Producte producte1=new Producte();
                            producte1.Nom = "Gelat";
                            producte1.Preu_sense_iva = 2;
                            producte1.Iva = 7;
                            //Afegir Producte
                            botiga2.AfegirProducte(producte1);
                            nota_correccio++;

                            Producte producte2 = new Producte();
                            producte2.Nom = "Pizza";
                            producte2.Preu_sense_iva = 5;
                            producte2.Iva = 12;

                            //Esborrar Producte
                            botiga2.EsborrarProducte(producte2);
                            if (botiga2.BuscarProducte(producte2) < 0) nota_correccio += 2;


                            Cistella cistella2 = new Cistella(10, 50);
                            //Comprar Producte
                            cistella2.ComprarProducte(producte1, 2);
                            if(cistella2.ProductesCistella[0].Nom=="Gelat"&& cistella2.ProductesCistella[1].Nom == "Gelat")
                            nota_correccio++;
                            else
                                Console.WriteLine("No s'han pogut afegir els productes.");

                            //Error per superar capacitat de la cistella:

                            cistella2.ComprarProducte(producte1, 30);
                            if (cistella2.ProductesCistella[3]== null)
                            {
                                Console.WriteLine("No s'han pogut afegir els productes. CORRECTE");
                                nota_correccio++;
                            }

                            else
                            {
                                Console.WriteLine("s'han pogut afegir els productes. INCORRECTE");
                                
                            }
                            //Cost Total Productes Cistella
                            double cost = cistella2.cistellaCostTotal();                                                 

                                if ((cistella2.cistellaCostTotal() >= 4.28) && (cistella2.cistellaCostTotal() <= 4.30))
                                nota_correccio += 2;
                                else
                                Console.WriteLine("Cost incorrecte");

                            //Modificar Producte

                            botiga2.ModificarProducte(producte1, "Pera", 5, 16);
                            if (botiga2.ProductesBotiga[0].Nom == "Pera")
                                nota_correccio+=1;
                            else
                                Console.WriteLine("No s'ha pogut cambiar el producte.");

                            //Esborrar Producte

                            botiga2.EsborrarProducte(producte1);
                            if (botiga2.ProductesBotiga[0] == null)
                                nota_correccio += 1;
                            else
                                Console.WriteLine("No s'ha pogut borrar el producte");


                            //int b = 0;
                            //int a = 3 / b;

                            botiga2.ProductesBotiga[0] = producte1;
                            botiga2.ProductesBotiga[1] = producte2;

                            

                            if (botiga2.PrestatgeLLiure() == 2)
                            {
                                Console.WriteLine($"Prestatge lliure trobat a la posicio: {botiga2.PrestatgeLLiure()}");
                                nota_correccio++;

                            }
                            
                            





                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Excepció:\r\n" + ex.ToString());
                        }

                        Console.WriteLine("La teva nota és: " + nota_correccio);

                        Console.WriteLine("Presiona una tecla per continuar");
                        Console.ReadLine();

                        break;
                   
                }
                menu.MostrarMenu();
                seleccio = menu.seleccio();

            }
            Console.WriteLine("Goodbye");



    

            //static string Menu3()




            //Console.WriteLine(cistella.CistellaText());
        }
    }
}
