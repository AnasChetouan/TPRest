using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHotel
{
    public class Hotel
    {
        private string _id;
        private string _nom;
        private int _nbEtoiles;
        private Adresse _adresse;
        private List<Chambre> _chambres;
        private List<Reservation> _reservations;
        private Dictionary<string, Partenariat> _partenariats;

        public string Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int NbEtoiles { get => _nbEtoiles; set => _nbEtoiles = value; }
        public Adresse Adresse { get => _adresse; set => _adresse = value; }
        public List<Chambre> Chambres { get => _chambres; set => _chambres = value; }
        public List<Reservation> Reservations { get => _reservations; set => _reservations = value; }
        public Dictionary<string, Partenariat> Partenariats { get => _partenariats; set => _partenariats = value; }


        public Hotel()
        {
            Chambres = new List<Chambre>();
            Reservations = new List<Reservation>();
            Partenariats = new Dictionary<string, Partenariat>();
        }

        public Hotel(string nom, int nbEtoiles)
        {
            this.Id = Guid.NewGuid().ToString("N");
            // générer un identifiant unique par rapport à cette instance d'hotel
            // car on ne peut pas garantir l'unicité du nom de l'hotel

            Nom = nom;
            NbEtoiles = nbEtoiles;
            Chambres = new List<Chambre>();
            Reservations = new List<Reservation>();
            Partenariats = new Dictionary<string, Partenariat>();
        }

        public Hotel(string id, string nom, int nbEtoiles)
        {
            Id = id;
            Nom = nom;
            NbEtoiles = nbEtoiles;
            Chambres = new List<Chambre>();
            Reservations = new List<Reservation>();
            Partenariats = new Dictionary<string, Partenariat>();
        }

        public Hotel(string id, string nom, int nbEtoiles, Adresse adresse) : this(id, nom, nbEtoiles)
        {
            Adresse = adresse;
        }

        public Hotel(string nom, int nbEtoiles, Adresse adresse) : this(nom, nbEtoiles)
        {
            Adresse = adresse;
        }

        public Hotel(string nom, int nbEtoiles, List<Chambre> chambres) : this(nom, nbEtoiles)
        {
            Chambres = chambres;
        }

        public void AjouterChambre(Chambre c)
        {
            Chambres.Add(c);
        }

        public void RetirerChambre(Chambre cSupp)
        {
            foreach (Chambre c in Chambres)
            {
                if (c == cSupp)
                    Chambres.Remove(c);
            }
        }

        public void AjouterReservation(Reservation R)
        {
            Reservations.Add(R);
        }

        public void RetirerReservation(Reservation rSupp)
        {
            foreach (Reservation r in Reservations)
            {
                if (r == rSupp)
                    Reservations.Remove(r);
            }
        }

        public void AjouterPartenariat(string idAgence, string nomAgence, Partenariat P)
        {
            Partenariats.Add(idAgence + "|" + nomAgence, P);
        }

        public void RetirerPartenariat(string idHotel, string nomAgence)
        {
            Partenariats.Remove(idHotel + "|" + nomAgence);
        }




    }
}
