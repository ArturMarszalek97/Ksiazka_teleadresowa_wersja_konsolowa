using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Kontrahenci> lista = new List<Kontrahenci>();

            WczytajDane(lista);
            Menu.StartMenu(lista);
        }

        public static void WczytajDane(List<Kontrahenci> lista)
        {
            string path = @"Kontrahenci.txt";
            StreamReader sr = new StreamReader(path);
            string imie;
            string nazwisko;
            int telefon;
            string miejscowosc;
            string opis;

            while (true)
            {
                imie = sr.ReadLine();
                if (imie == null)
                {
                    break;
                }
                nazwisko = sr.ReadLine();
                telefon = Convert.ToInt32(sr.ReadLine());
                miejscowosc = sr.ReadLine();
                opis = sr.ReadLine();

                Kontrahenci nowy = new Kontrahenci(imie, nazwisko, telefon, miejscowosc, opis);

                lista.Add(nowy);

            }

            sr.Close();
        }
    }
}
