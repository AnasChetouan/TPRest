using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IbisAPI.Models
{
    public class Chambre
    {

        private int _id;
        private int _nbLits;
        private int _nbPlaces;
        private float _prixBase;

        public int NbLits { get => _nbLits; set => _nbLits = value; }
        public int NbPlaces { get => _nbPlaces; set => _nbPlaces = value; }
        public float PrixBase { get => _prixBase; set => _prixBase = value; }
        [Key]
        public int IDchambre { get => _id; set => _id = value; }

        public Chambre()
        {
        }

        public Chambre(int nbLits, int nbPlaces, float prixBase)
        {
            //this.Id = Guid.NewGuid().ToString("N");
            NbLits = nbLits;
            NbPlaces = nbPlaces;
            PrixBase = prixBase;
        }

        public Chambre(int id, int nbLits, int nbPlaces, float prixBase)
        {
            IDchambre = id;
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
