using System;
using System.Collections.Generic;
using System.Text;

namespace BookingAPI.Models
{
    public class Agence
    {
        private string _identifiant;
        private string _nom;

        public string Id { get => _identifiant; set => _identifiant = value; }
        public string Nom { get => _nom; set => _nom = value; }

        public Agence()
        {
        }

        public Agence(string id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public override string ToString()
        {
            return "Agence " + Nom;
        }


    }
}
