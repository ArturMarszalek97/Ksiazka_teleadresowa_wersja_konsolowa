using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    class Kontrahenci
    {
        private string imie;
        private string nazwisko;
        private int telefon;
        private string miejscowosc;
        private string opis;

        public Kontrahenci(string imie, string nazwisko, int telefon, string miejscowosc, string opis)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.telefon = telefon;
            this.miejscowosc = miejscowosc;
            this.opis = opis;
        }

        public void Edytuj_imie(string imie)
        {
            this.imie = imie;
        }

        public void Edytuj_nazwisko(string nazwisko)
        {
            this.nazwisko = nazwisko;
        }

        public void Edytuj_telefon(int telefon)
        {
            this.telefon = telefon;
        }

        public void Edytuj_miejscowosc(string miejscowosc)
        {
            this.miejscowosc = miejscowosc;
        }

        public void Edytuj_opis(string opis)
        {
            this.opis = opis;
        }

        public string GetImie()
        {
            return imie;
        }

        public string GetNazwisko()
        {
            return nazwisko;
        }

        public int GetTelefon()
        {
            return telefon;
        }

        public string GetMiejscowosc()
        {
            return miejscowosc;
        }

        public string GetOpis()
        {
            return opis;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", imie, nazwisko, telefon, miejscowosc);
        }
    }
}
