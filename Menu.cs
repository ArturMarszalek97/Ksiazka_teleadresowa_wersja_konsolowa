using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;

namespace Projekt1
{
    static class Menu
    {
        static string[] pozycje_menu = { "    Dodaj Kontrahenta     ", "     Usuń Kontrahenta     ", "    Edytuj Kontrahenta    ", "    Filtruj po imieniu    ", "    Zapisz    "};

        static int aktywnaPozycja = 0;
        static int aktywnaPozycja2 = 0;
        static int aktywnaPozycja3 = 0;
        static int aktywnaPozycja4 = 0;



        public static void StartMenu(List<Kontrahenci> list)
        {
            Console.Title = "Książka teleadresowa Kontrahentów";
            Console.CursorVisible = false;

            while(true)
            {
                PokazMenu(list);
                WybieranieOpcji(list);
                UruchomOpcje(list);
            }
        }

        static void PokazMenu(List<Kontrahenci> list)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Witaj! Aby rozpocząć interakcję z programem wybierz jedną z opcji dostępnych w menu.");
            Console.WriteLine();

            for(int i = 0; i < pozycje_menu.Length; i++)
            {
                if(i == aktywnaPozycja)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("{0, -26}", pozycje_menu[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(pozycje_menu[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   ---------------------------------------------------------------------------------------------------");
            Console.Write("        Imie        ");
            Console.Write("      Nazwisko      ");
            Console.Write("       Telefon      ");
            Console.Write("     Miejscowość    ");
            Console.Write("        Opis        ");
            Console.WriteLine();
            Console.WriteLine("   ---------------------------------------------------------------------------------------------------");

            int kolor = 1;

            foreach(Kontrahenci k in list)
            {
                if(kolor % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                int liczba_znakow = k.GetImie().Length;
                int liczba_spacji = (20 - 6 - liczba_znakow);
                Console.Write("      " + k.GetImie());
                for (int i = 0; i < liczba_spacji; i++)
                {
                    Console.Write(" ");
                }
                liczba_znakow = k.GetNazwisko().Length;
                liczba_spacji = (20 - 6 - liczba_znakow);
                Console.Write("      " + k.GetNazwisko());
                for (int i = 0; i < liczba_spacji; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("      "+k.GetTelefon() + "      ");
                Console.Write("    " + k.GetMiejscowosc());
                liczba_znakow = k.GetMiejscowosc().Length;
                liczba_spacji = (20 - 4 - liczba_znakow);
                for (int i = 0; i < liczba_spacji; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(k.GetOpis());
                Console.WriteLine();
                kolor++;

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Aktualna liczba Kontrahentów: " + list.Count);
        }

        static void WybieranieOpcji(List<Kontrahenci> list)
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.LeftArrow) // strzałka w góre
                {
                    aktywnaPozycja = (aktywnaPozycja > 0) ? aktywnaPozycja - 1 : pozycje_menu.Length - 1;
                    PokazMenu(list);
                }
                else if (klawisz.Key == ConsoleKey.RightArrow) //strzałka w dół
                {
                    aktywnaPozycja = (aktywnaPozycja + 1) % pozycje_menu.Length;
                    PokazMenu(list);
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if(klawisz.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);
        }

        static void UruchomOpcje(List<Kontrahenci> lista)
        {
            switch(aktywnaPozycja)
            {
                case 0: Console.Clear(); Dodaj(lista); break;
                case 1: Console.Clear(); Usun(lista); break;
                case 2: Console.Clear(); Edytuj(lista); break;
                case 3: Console.Clear(); Filtruj(lista); break;
                case 4: Console.Clear(); Zapisz(lista); break;
            }
        }

        static void Dodaj(List<Kontrahenci> lista)
        {
            string imie;
            string nazwisko;
            int telefon;
            string miejscowosc;
            string opis;
            string napis = @" 
 _____              _         _      _  __              _                _                   _         
|  __ \            | |       (_)    | |/ /             | |              | |                 | |        
| |  | |  ___    __| |  __ _  _     | ' /  ___   _ __  | |_  _ __  __ _ | |__    ___  _ __  | |_  __ _ 
| |  | | / _ \  / _` | / _` || |    |  <  / _ \ | '_ \ | __|| '__|/ _` || '_ \  / _ \| '_ \ | __|/ _` |
| |__| || (_) || (_| || (_| || |    | . \| (_) || | | || |_ | |  | (_| || | | ||  __/| | | || |_| (_| |
|_____/  \___/  \__,_| \__,_|| |    |_|\_\\___/ |_| |_| \__||_|   \__,_||_| |_| \___||_| |_| \__|\__,_|
                            _/ |                                                                    
                           |__/     ";


            Console.WriteLine(napis);

            Console.WriteLine();
            Console.WriteLine("Jeśli się pomyliłeś i nie chciałeś tutaj wejść naciśnij ESC, w przeciwnym wypadku naciśnij ENTER.");
            ConsoleKeyInfo klawisz = Console.ReadKey();

            if(klawisz.Key == ConsoleKey.Escape)
            {
                StartMenu(lista);
            }

            Console.Clear();
            Console.WriteLine(napis);
            Console.WriteLine();
            Console.Write("Podaj imie: ");
            imie = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Podaj nazwisko: ");
            nazwisko = Console.ReadLine();
            Console.WriteLine();
            while(true)
            {
                Console.Write("Podaj telefon: ");
                string pomoc = Console.ReadLine();

                
                telefon = Convert.ToInt32(pomoc);

                if (telefon > 100000000 && telefon < 999999999)
                {
                    break;
                }

                Console.WriteLine("Telefon musi zawierać 9 cyfr!");
                Console.WriteLine("Spróbuj jeszcze raz.");
            }
            Console.WriteLine();
            Console.Write("Podaj miejscowosc: ");
            miejscowosc = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Podaj opis: ");
            opis = Console.ReadLine();

            Kontrahenci nowy = new Kontrahenci(imie, nazwisko, telefon, miejscowosc, opis);

            lista.Add(nowy);

            string nowynapis = @"
 _____              _                               _             _  _       _          
|  __ \            | |                             | |           | |(_)     | |         
| |  | |  ___    __| |  __ _  _ __    ___        __| |  ___      | | _  ___ | |_  _   _ 
| |  | | / _ \  / _` | / _` || '_ \  / _ \      / _` | / _ \     | || |/ __|| __|| | | |
| |__| || (_) || (_| || (_| || | | || (_) |    | (_| || (_) |    | || |\__ \| |_ | |_| |
|_____/  \___/  \__,_| \__,_||_| |_| \___/      \__,_| \___/     |_||_||___/ \__| \__, |
                                                                                   __/ |
                                                                                  |___/ ";

            Console.Clear();
            Console.WriteLine(nowynapis);
            Thread.Sleep(1000);
        }

        static void wyjscie(List<Kontrahenci> lista)
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.Enter)
                {
                    StartMenu(lista);
                }
            } while (true);
        }

        static void WybieranieOpcji2(List<Kontrahenci> list)
        {
            int index = 0;
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow) // strzałka w góre
                {
                    aktywnaPozycja2 = (aktywnaPozycja2 > 0) ? aktywnaPozycja2 - 1 : list.Count - 1; //pozycje_menu.Length - 1;
                    //Console.WriteLine(aktywnaPozycja2);
                    Usun(list);
                }
                else if (klawisz.Key == ConsoleKey.DownArrow) //strzałka w dół
                {
                    aktywnaPozycja2 = (aktywnaPozycja2 + 1) % list.Count;//pozycje_menu.Length;
                    Usun(list);
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);
        }

        static void Usuwanie(List<Kontrahenci> lista)
        {
            lista.RemoveAt(aktywnaPozycja2);

            string napis = @"
 _    _                     _        _                       _  _       _          
| |  | |                   (_)      | |                     | |(_)     | |         
| |  | | ___  _   _  _ __   _   ___ | |_  ___       ____    | | _  ___ | |_  _   _ 
| |  | |/ __|| | | || '_ \ | | / _ \| __|/ _ \     |_  /    | || |/ __|| __|| | | |
| |__| |\__ \| |_| || | | || ||  __/| |_| (_) |     / /     | || |\__ \| |_ | |_| |
 \____/ |___/ \__,_||_| |_||_| \___| \__|\___/     /___|    |_||_||___/ \__| \__, |
                                                                              __/ |
                                                                             |___/ ";
            Console.Clear();
            Console.WriteLine(napis);
            Thread.Sleep(1000);
            StartMenu(lista);
        }

        static void Usun(List<Kontrahenci> lista)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string napis = @"
 _    _                         _  __              _                _                   _         
| |  | |                       | |/ /             | |              | |                 | |        
| |  | | ___  _   _  _ __      | ' /  ___   _ __  | |_  _ __  __ _ | |__    ___  _ __  | |_  __ _ 
| |  | |/ __|| | | || '_ \     |  <  / _ \ | '_ \ | __|| '__|/ _` || '_ \  / _ \| '_ \ | __|/ _` |
| |__| |\__ \| |_| || | | |    | . \| (_) || | | || |_ | |  | (_| || | | ||  __/| | | || |_| (_| |
 \____/ |___/ \__,_||_| |_|    |_|\_\\___/ |_| |_| \__||_|   \__,_||_| |_| \___||_| |_| \__|\__,_|";

            Console.WriteLine(napis);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Jeśli się pomyliłeś i nie chciałeś tutaj wejść naciśnij ESC, w przeciwnym wypadku naciśnij ENTER.");
            ConsoleKeyInfo klawisz = Console.ReadKey();

            if (klawisz.Key == ConsoleKey.Escape)
            {
                StartMenu(lista);
            }

            Console.Clear();
            Console.WriteLine(napis);

            Console.WriteLine();
            Console.WriteLine("Wybierz osobę do usunięcia: ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Kontrahenci[] tablica = new Kontrahenci[lista.Count];
            int i = 0;
            //int aktywnapozycja = 0;

            foreach (Kontrahenci o in lista)
            {
                tablica[i] = o;
                i++;
            }

            for (int j = 0; j < tablica.Length; j++)
            {
                if (j == aktywnaPozycja2)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("{0, -35}", tablica[j].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(tablica[j].ToString());
                    Console.WriteLine();
                }
            }
            WybieranieOpcji2(lista);
            Usuwanie(lista);
            Console.ReadKey();

        }

        static string[] menu = { "Imie", "Nazwisko", "Telefon", "Miejscowość", "Opis" };

        static void WybieranieOpcji4(List<Kontrahenci> list)
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow) // strzałka w góre
                {
                    aktywnaPozycja4 = (aktywnaPozycja4 > 0) ? aktywnaPozycja4 - 1 : pozycje_menu.Length - 1;
                    edytowanie(list);
                }
                else if (klawisz.Key == ConsoleKey.DownArrow) //strzałka w dół
                {
                    aktywnaPozycja4 = (aktywnaPozycja4 + 1) % pozycje_menu.Length;
                    edytowanie(list);
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);
        }

        static string edycja = @"
 ______     _               _             _  __              _                _                   _         
|  ____|   | |             (_)           | |/ /             | |              | |                 | |        
| |__    __| | _   _   ___  _   __ _     | ' /  ___   _ __  | |_  _ __  __ _ | |__    ___  _ __  | |_  __ _ 
|  __|  / _` || | | | / __|| | / _` |    |  <  / _ \ | '_ \ | __|| '__|/ _` || '_ \  / _ \| '_ \ | __|/ _` |
| |____| (_| || |_| || (__ | || (_| |    | . \| (_) || | | || |_ | |  | (_| || | | ||  __/| | | || |_| (_| |
|______|\__,_| \__, | \___|| | \__,_|    |_|\_\\___/ |_| |_| \__||_|   \__,_||_| |_| \___||_| |_| \__|\__,_|
                __/ |     _/ |                                                                           
               |___/     |__/                                                                            ";

        static string zedytowano = @"
 ______          _         _                                                                                _         _       
|___  /         | |       | |                                                                              | |       (_)      
   / /  ___   __| | _   _ | |_  ___ __      __ __ _  _ __    ___       _ __    ___   _ __ ___   _   _  ___ | | _ __   _   ___ 
  / /  / _ \ / _` || | | || __|/ _ \\ \ /\ / // _` || '_ \  / _ \     | '_ \  / _ \ | '_ ` _ \ | | | |/ __|| || '_ \ | | / _ \
 / /__|  __/| (_| || |_| || |_| (_) |\ V  V /| (_| || | | || (_) |    | |_) || (_) || | | | | || |_| |\__ \| || | | || ||  __/
/_____|\___| \__,_| \__, | \__|\___/  \_/\_/  \__,_||_| |_| \___/     | .__/  \___/ |_| |_| |_| \__, ||___/|_||_| |_||_| \___|
                     __/ |                                            | |                        __/ |                        
                    |___/                                             |_|                       |___/                         ";

        static void edytowanie(List<Kontrahenci> lista)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(edycja);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Co byś chciał edytować?");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            for (int j = 0; j < menu.Length; j++)
            {
                if (j == aktywnaPozycja4)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("{0, -25}", menu[j].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(menu[j].ToString());
                    Console.WriteLine();
                }
            }

            WybieranieOpcji4(lista);

            switch(aktywnaPozycja4)
            {
                case 0:
                    {
                        //Console.WriteLine(aktywnaPozycja3);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(edycja);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Podaj nowe imie i naciśnij enter: ");
                        string imie = Console.ReadLine();
                        int licznik = 0;
                        foreach(Kontrahenci o in lista)
                        {
                            if(aktywnaPozycja3 == licznik)
                            {
                                o.Edytuj_imie(imie);
                                break;
                            }
                            licznik++;
                        }

                        Console.Clear();
                        Console.WriteLine(zedytowano);
                        Thread.Sleep(1000);
                    } break;
                case 1:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(edycja);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Podaj nowe nazwisko i naciśnij enter: ");
                        string nazwisko = Console.ReadLine();
                        int licznik = 0;
                        foreach (Kontrahenci o in lista)
                        {
                            if (aktywnaPozycja3 == licznik)
                            {
                                o.Edytuj_nazwisko(nazwisko);
                                break;
                            }
                            licznik++;
                        }

                        Console.Clear();
                        Console.WriteLine(zedytowano);
                        Thread.Sleep(1000);
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(edycja);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Podaj nowy telefon i naciśnij enter: ");
                        int telefon = Convert.ToInt32(Console.ReadLine());
                        int licznik = 0;
                        foreach (Kontrahenci o in lista)
                        {
                            if (aktywnaPozycja3 == licznik)
                            {
                                o.Edytuj_telefon(telefon);
                                break;
                            }
                            licznik++;
                        }

                        Console.Clear();
                        Console.WriteLine(zedytowano);
                        Thread.Sleep(1000);
                    }
                    break;
                case 3:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(edycja);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Podaj nową miejscowość i naciśnij enter: ");
                        string miejscowosc = Console.ReadLine();
                        int licznik = 0;
                        foreach (Kontrahenci o in lista)
                        {
                            if (aktywnaPozycja3 == licznik)
                            {
                                o.Edytuj_miejscowosc(miejscowosc);
                                break;
                            }
                            licznik++;
                        }

                        Console.Clear();
                        Console.WriteLine(zedytowano);
                        Thread.Sleep(1000);
                    }
                    break;
                case 4:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(edycja);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Podaj nowy opis i naciśnij enter: ");
                        string opis = Console.ReadLine();
                        int licznik = 0;
                        foreach (Kontrahenci o in lista)
                        {
                            if (aktywnaPozycja3 == licznik)
                            {
                                o.Edytuj_opis(opis);
                                break;
                            }
                            licznik++;
                        }

                        Console.Clear();
                        Console.WriteLine(zedytowano);
                        Thread.Sleep(1000);
                    }
                    break;
            }
            StartMenu(lista);
        }

        static void WybieranieOpcji3(List<Kontrahenci> list)
        {
            int index = 0;
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow) // strzałka w góre
                {
                    aktywnaPozycja3 = (aktywnaPozycja3 > 0) ? aktywnaPozycja3 - 1 : list.Count - 1; //pozycje_menu.Length - 1;
                    //Console.WriteLine(aktywnaPozycja2);
                    Edytuj(list);
                }
                else if (klawisz.Key == ConsoleKey.DownArrow) //strzałka w dół
                {
                    aktywnaPozycja3 = (aktywnaPozycja3 + 1) % list.Count;//pozycje_menu.Length;
                    Edytuj(list);
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);
        }

        static void Edytuj(List<Kontrahenci> lista)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(edycja);

            Console.WriteLine();
            Console.WriteLine("Jeśli się pomyliłeś i nie chciałeś tutaj wejść naciśnij ESC, w przeciwnym wypadku naciśnij ENTER.");
            ConsoleKeyInfo klawisz = Console.ReadKey();

            if (klawisz.Key == ConsoleKey.Escape)
            {
                StartMenu(lista);
            }

            Console.Clear();
            Console.WriteLine(edycja);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Wybierz osobę do edycji: ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Kontrahenci[] tablica = new Kontrahenci[lista.Count];
            int i = 0;
            //int aktywnapozycja = 0;

            foreach (Kontrahenci o in lista)
            {
                tablica[i] = o;
                i++;
            }

            for (int j = 0; j < tablica.Length; j++)
            {
                if (j == aktywnaPozycja3)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("{0, -35}", tablica[j].ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(tablica[j].ToString());
                    Console.WriteLine();
                }
            }
            WybieranieOpcji3(lista);
            edytowanie(lista);
            //Console.Clear();
            //Dodaj(lista);
            //StartMenu(lista);
            Console.ReadKey();
        }

        static void Filtruj(List<Kontrahenci> lista)
        {
            string napis = @"
+-++-++-++-++-++-++-+ +-++-++-++-++-+
|F||i||l||t||r||u||j| |l||i||s||t||e|
+-++-++-++-++-++-++-+ +-++-++-++-++-+";

            Console.WriteLine(napis);
            Console.WriteLine();
            Console.Write("Podaj imie: ");
            string imie = Console.ReadLine();

            List<Kontrahenci> filtrowana_lista = lista.Where(x => x.GetImie() == imie).ToList();

            Console.WriteLine("   ---------------------------------------------------------------------------------------------------");
            Console.Write("        Imie        ");
            Console.Write("      Nazwisko      ");
            Console.Write("       Telefon      ");
            Console.Write("     Miejscowość    ");
            Console.Write("        Opis        ");
            Console.WriteLine();
            Console.WriteLine("   ---------------------------------------------------------------------------------------------------");

            int kolor = 1;

            foreach (Kontrahenci k in filtrowana_lista)
            {
                if (kolor % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                int liczba_znakow = k.GetImie().Length;
                int liczba_spacji = (20 - 6 - liczba_znakow);
                Console.Write("      " + k.GetImie());
                for (int i = 0; i < liczba_spacji; i++)
                {
                    Console.Write(" ");
                }
                liczba_znakow = k.GetNazwisko().Length;
                liczba_spacji = (20 - 6 - liczba_znakow);
                Console.Write("      " + k.GetNazwisko());
                for (int i = 0; i < liczba_spacji; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("      " + k.GetTelefon() + "      ");
                Console.Write("    " + k.GetMiejscowosc());
                liczba_znakow = k.GetMiejscowosc().Length;
                liczba_spacji = (20 - 4 - liczba_znakow);
                for (int i = 0; i < liczba_spacji; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(k.GetOpis());
                Console.WriteLine();
                kolor++;

            }
            //foreach (Kontrahenci o in filtrowana_lista)
            //{
            //    Console.WriteLine(o.ToString());
            //}

            Console.ReadKey();
        }

        static void Zapisz(List<Kontrahenci> lista)
        {
            string path = @"Kontrahenci.txt";
            StreamWriter sw = new StreamWriter(path);

            Console.Clear();
            string napis = @"
 ______              _                                     _                _                             _     
|___  /             (_)                                   (_)              | |                           | |    
   / /  __ _  _ __   _  ___  _   _ __      __ __ _  _ __   _   ___       __| |  __ _  _ __   _   _   ___ | |__  
  / /  / _` || '_ \ | |/ __|| | | |\ \ /\ / // _` || '_ \ | | / _ \     / _` | / _` || '_ \ | | | | / __|| '_ \ 
 / /__| (_| || |_) || |\__ \| |_| | \ V  V /| (_| || | | || ||  __/    | (_| || (_| || | | || |_| || (__ | | | |
/_____|\__,_|| .__/ |_||___/ \__, |  \_/\_/  \__,_||_| |_||_| \___|     \__,_| \__,_||_| |_| \__, | \___||_| |_|
             | |              __/ |                                                           __/ |             
             |_|             |___/                                                           |___/              ";
            Console.WriteLine(napis);
            Thread.Sleep(2000);

            foreach(Kontrahenci o in lista)
            {
                sw.WriteLine(o.GetImie());
                sw.WriteLine(o.GetNazwisko());
                sw.WriteLine(o.GetTelefon());
                sw.WriteLine(o.GetMiejscowosc());
                sw.WriteLine(o.GetOpis());
            }

            sw.Close();
        }

        static void opcjawbudowie()
        {
            Console.SetCursorPosition(12, 4); //12 kolumna 4 wiersz
            Console.WriteLine("Tu będzie wykonywana opcja");
            Console.ReadKey();
        }
    }
}
