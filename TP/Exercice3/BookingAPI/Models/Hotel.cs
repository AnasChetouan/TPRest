using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingAPI.Models
{
    public class Hotel
    {
        private int _id;
        private string _nom;
        private int _nbEtoiles;
        private int _IDadresse;
        private Adresse adresse;

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int NbEtoiles { get => _nbEtoiles; set => _nbEtoiles = value; }
        public int IDAdresse { get => _IDadresse; set => _IDadresse = value; }
        public Adresse Adresse { get => adresse; set => adresse = value; }

        public Hotel()
        {
        }

        public Hotel(int id, string nom, int nbEtoiles, Adresse adresse)
        {
            Id = id;
            Nom = nom;
            NbEtoiles = nbEtoiles;
            Adresse = adresse;
        }

       /* public Hotel(int id, string nom, int nbEtoiles, int adresse) : this(id, nom, nbEtoiles)
        {
            IDAdresse = adresse;
        }*/

    }
}
