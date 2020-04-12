using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingAPI.Models
{
    public class Adresse
    {
        private int _idAdresse;
        private string _pays;
        private string _ville;
        private string _rue;
        private string _numero;
        private string _codePostal;
        private float _latitude;
        private float _longitude;

        public string Pays { get => _pays; set => _pays = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public string Rue { get => _rue; set => _rue = value; }
        public string Numero { get => _numero; set => _numero = value; }
        public string CodePostal { get => _codePostal; set => _codePostal = value; }
        public float Latitude { get => _latitude; set => _latitude = value; }
        public float Longitude { get => _longitude; set => _longitude = value; }
        [Key]
        public int IdAdresse { get => _idAdresse; set => _idAdresse = value; }

        public Adresse()
        {
        }

        public Adresse(int id, string pays, string ville, string rue, string numero, string codePostal)
        {
            IdAdresse = id;
            Pays = pays;
            Ville = ville;
            Rue = rue;
            Numero = numero;
            CodePostal = codePostal;
        }

        public Adresse(int id, string pays, string ville, string rue, string numero, string lieuDit, float latitude, float longitude) : this(id, pays, ville, rue, numero, lieuDit)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return Numero + " "+ Rue + " " + CodePostal + " " + Ville + " " + Pays; 
        }
    }
}
