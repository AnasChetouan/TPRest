using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbisAPI.Models
{
    public class ClientPrincipal
    {
        private int _IDclient;
        private string _prenom;
        private string _nom;
        private int _IDcartesPaiement;

        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int IDCartePaiement { get => _IDcartesPaiement; set => _IDcartesPaiement = value; }
        [Key]
        public int IDclient { get => _IDclient; set => _IDclient = value; }

        public ClientPrincipal()
        {
            this.Prenom = "Inconnu";
            this.Nom = "Inconnu";
        }


        public ClientPrincipal(int id, string p, string n)
        {
            IDclient = id;
            this.Prenom = p;
            this.Nom = n;
        }

        public ClientPrincipal(int id, string prenom, string nom, int IDcartepaiement) : this(id, prenom, nom)
        {
            IDCartePaiement = IDcartepaiement;
        }

        override
        public string ToString()
        {
            return this.Prenom + " " + this.Nom;
        }

    }
}
