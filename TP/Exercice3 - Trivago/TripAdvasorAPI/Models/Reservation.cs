using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripAdvasorAPI.Models
{
    public class Reservation
    {
        private int _IDReservation;
        private int _IDclient;
        private int _IDchambre;
        private float _tarif;
        private DateTime _dateArrivee;
        private DateTime _dateDepart;
        private int _nbClients;

        public int Client { get => _IDclient; set => _IDclient = value; }
        public int Chambre { get => _IDchambre; set => _IDchambre = value; }
        public float Tarif { get => _tarif; set => _tarif = value; }
        public DateTime DateArrivee { get => _dateArrivee; set => _dateArrivee = value; }
        public DateTime DateDepart { get => _dateDepart; set => _dateDepart = value; }
        public int NbClients { get => _nbClients; set => _nbClients = value; }
        [Key]
        public int IDReservation { get => _IDReservation; set => _IDReservation = value; }

        public Reservation()
        {
        }

        public Reservation(int idR, int client, int chambre, float tarif, DateTime dateArrivee, DateTime dateDepart, int nbClients)
        {
            IDReservation = idR;
            Client = client;
            Chambre = chambre;
            Tarif = tarif;
            DateArrivee = dateArrivee;
            DateDepart = dateDepart;
            NbClients = nbClients;
        }
    }
}
