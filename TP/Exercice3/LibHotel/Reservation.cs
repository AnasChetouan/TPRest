using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHotel
{
    public class Reservation
    {
        private ClientPrincipal _client;
        private Chambre _chambre;
        private float _tarif;
        private DateTime _dateArrivee;
        private DateTime _dateDepart;
        private int _nbClients;

        public ClientPrincipal Client { get => _client; set => _client = value; }
        public Chambre Chambre { get => _chambre; set => _chambre = value; }
        public float Tarif { get => _tarif; set => _tarif = value; }
        public DateTime DateArrivee { get => _dateArrivee; set => _dateArrivee = value; }
        public DateTime DateDepart { get => _dateDepart; set => _dateDepart = value; }
        public int NbClients { get => _nbClients; set => _nbClients = value; }

        public Reservation()
        {
        }

        public Reservation(ClientPrincipal client, Chambre chambre, float tarif, DateTime dateArrivee, DateTime dateDepart, int nbClients)
        {
            Client = client;
            Chambre = chambre;
            Tarif = tarif;
            DateArrivee = dateArrivee;
            DateDepart = dateDepart;
            NbClients = nbClients;
        }
    }
}
