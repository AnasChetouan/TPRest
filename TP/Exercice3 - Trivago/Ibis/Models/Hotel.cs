using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IbisAPI.Models
{
    public class Hotel
    {
        private int _id;
        private string _nom;
        private int _nbEtoiles;
        private int _IDadresse;
        private Adresse adresse;
        private static int _nbOffres;

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int NbEtoiles { get => _nbEtoiles; set => _nbEtoiles = value; }
        public int IDAdresse { get => _IDadresse; set => _IDadresse = value; }
        public Adresse Adresse { get => adresse; set => adresse = value; }
        public int NbOffres { get => _nbOffres; set => _nbOffres = value; }

        public Hotel()
        {
        }

        public Hotel(int id, string nom, int nbEtoiles, Adresse adresse, int nbOffres)
        {
            Id = id;
            Nom = nom;
            NbEtoiles = nbEtoiles;
            Adresse = adresse;
            NbOffres = nbOffres;
        }

       /* public Hotel(int id, string nom, int nbEtoiles, int adresse) : this(id, nom, nbEtoiles)
        {
            IDAdresse = adresse;
        }*/

    }
}
