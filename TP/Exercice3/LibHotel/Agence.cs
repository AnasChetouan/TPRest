using System;
using System.Collections.Generic;
using System.Text;

namespace LibHotel
{
    public class Agence
    {
        private string _identifiant;
        private string _nom;
        private Dictionary<string, Partenariat> _partenariats;

        public string Id { get => _identifiant; set => _identifiant = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public Dictionary<string, Partenariat> Partenariats { get => _partenariats; set => _partenariats = value; }

        public Agence()
        {
            Partenariats = new Dictionary<string, Partenariat>();
        }

        public Agence(string nom)
        {
            this.Id = Guid.NewGuid().ToString("N");
            // générer un identifiant unique par rapport à cette instance d'agence
            // car on ne peut pas garantir l'unicité du nom de l'agence

            Nom = nom;
            Partenariats = new Dictionary<string, Partenariat>();
        }

        public Agence(string id, string nom)
        {
            Id = id;
            Nom = nom;
            Partenariats = new Dictionary<string, Partenariat>();
        }

        public Agence(string nom, Dictionary<string, Partenariat> partenariats) : this(nom)
        {
            Partenariats = partenariats;
        }

        public void AjouterPartenariat(string idHotel, string nomHotel, Partenariat P)
        {
            Partenariats.Add(idHotel+"|"+nomHotel, P);
        }

        public void RetirerPartenariat(string idHotel, string nomHotel)
        {
            Partenariats.Remove(idHotel + "|" + nomHotel);
        }


        public override string ToString()
        {
            return "Agence " + Nom;
        }


    }
}
