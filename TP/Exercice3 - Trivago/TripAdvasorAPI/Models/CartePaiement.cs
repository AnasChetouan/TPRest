using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvasorAPI.Models
{
    public class CartePaiement
    {
        private int _IDcarte;
        private string _numero;
        private string _ccv;
        private DateTime _dateExpiration;
        private string _nomProprio;
        private string _prenomProprio;

        [Key]
        public int IDcarte { get => _IDcarte; set => _IDcarte = value; }
        public string Numero { get => _numero; set => _numero = value; }
        public string Ccv { get => _ccv; set => _ccv = value; }
        public DateTime DateExpiration { get => _dateExpiration; set => _dateExpiration = value; }
        public string NomProprio { get => _nomProprio; set => _nomProprio = value; }
        public string PrenomProprio { get => _prenomProprio; set => _prenomProprio = value; }


        public CartePaiement()
        {
        }

        public CartePaiement(int id, string numero, string ccv, DateTime dateExpiration, string nomProprio, string prenomProprio)
        {
            IDcarte = id;
            Numero = numero;
            Ccv = ccv;
            DateExpiration = dateExpiration;
            NomProprio = nomProprio;
            PrenomProprio = prenomProprio;
        }

        public override string ToString()
        {
            return "Cette carte appartient à " + PrenomProprio + " _ " + NomProprio;
        }
    }
}
