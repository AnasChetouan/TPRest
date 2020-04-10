using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHotel
{
    public class Chambre
    {
        private string _id;
        private int _nbLits;
        private int _nbPlaces;
        private float _prixBase;

        public int NbLits { get => _nbLits; set => _nbLits = value; }
        public int NbPlaces { get => _nbPlaces; set => _nbPlaces = value; }
        public float PrixBase { get => _prixBase; set => _prixBase = value; }
        public string Id { get => _id; set => _id = value; }

        public Chambre()
        {
        }

        public Chambre(int nbLits, int nbPlaces, float prixBase)
        {
            this.Id = Guid.NewGuid().ToString("N");
            NbLits = nbLits;
            NbPlaces = nbPlaces;
            PrixBase = prixBase;
        }

        public Chambre(string id, int nbLits, int nbPlaces, float prixBase)
        {
            Id = id;
            NbLits = nbLits;
            NbPlaces = nbPlaces;
            PrixBase = prixBase;
        }

        public override string ToString()
        {
            return "Cette chambre comporte " + NbLits + " lits pour " + NbPlaces + " places. Le prix est de "+PrixBase+" euros.";
        }
    }
}
