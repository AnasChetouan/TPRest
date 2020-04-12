using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripAdvasorAPI.Models
{
    public class Offre
    {
        public static int idsCompteur = 0;
        private int _idOffre;
        private int _idChambre;
        private int _nbLits;
        private float _prix;
        //private string _dateDispo;

        [Key]
        public int IdOffre { get => _idOffre; set => _idOffre = value; }
        public int IdChambre { get => _idChambre; set => _idChambre = value; }
        public float Prix { get => _prix; set => _prix = value; }
        //public string DateDispo { get => _dateDispo; set => _dateDispo = value; }
        public int NbLits { get => _nbLits; set => _nbLits = value; }

        public Offre()
        {
            this.IdOffre = System.Threading.Interlocked.Increment(ref idsCompteur);
        }

        public Offre(int idChambre, float prix, int nbLits)
        {
            this.IdOffre = System.Threading.Interlocked.Increment(ref idsCompteur);
            _idChambre = idChambre;
            _prix = prix;
            NbLits = nbLits;
            //_dateDispo = dateDispo;
        }
    }
}
