using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHotel
{
    public class ClientPrincipal
    {
        private string _prenom;
        private string _nom;
        private List<CartePaiement> cartesPaiement;

        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public List<CartePaiement> CartesPaiement { get => cartesPaiement; set => cartesPaiement = value; }


        public ClientPrincipal()
        {
            this.Prenom = "Inconnu";
            this.Nom = "Inconnu";
        }


        public ClientPrincipal(string p, string n)
        {
            this.Prenom = p;
            this.Nom = n;
            this.CartesPaiement = new List<CartePaiement>();
        }

        public ClientPrincipal(string prenom, string nom, List<CartePaiement> cartesPaiement) : this(prenom, nom)
        {
            CartesPaiement = cartesPaiement;
        }

        public void AjouterCarte(CartePaiement c)
        {
                this.CartesPaiement.Add(c);         
        }

        public void RetirerCarte(CartePaiement aSupp)
        {
            foreach (CartePaiement c in CartesPaiement)
            {
                if (c == aSupp)
                    CartesPaiement.Remove(c);
            }
        }

        override
        public string ToString()
        {
            return this.Prenom + " " + this.Nom;
        }

    }
}
