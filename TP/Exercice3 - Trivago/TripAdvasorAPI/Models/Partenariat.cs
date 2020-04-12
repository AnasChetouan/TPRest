using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TripAdvasorAPI.Models
{
    public class Partenariat
    {
        private int _idPartenariat;
        private int _idAgence;
        private int _idHotel;
        private string _nomAgence;
        private string _nomHotel;
        private string _login;
        private string _motdepasse;
        private float _part;

        [Key]
        public int IdPartenariat { get => _idPartenariat; set => _idPartenariat = value; }
        public string Login { get => _login; set => _login = value; }
        public string Motdepasse { get => _motdepasse; set => _motdepasse = value; }
        public float Part { get => _part; set => _part = value; }
        public int IdAgence { get => _idAgence; set => _idAgence = value; }
        public int IdHotel { get => _idHotel; set => _idHotel = value; }
        public string NomAgence { get => _nomAgence; set => _nomAgence = value; }
        public string NomHotel { get => _nomHotel; set => _nomHotel = value; }

        public Partenariat()
        {
        }

        public Partenariat(int idP, int idA, int idH, string nomA, string nomH, string login, string motdepasse, float part)
        {
            IdPartenariat = idP;
            NomAgence = nomA;
            NomHotel = nomH;
            IdAgence = idA;
            IdHotel = idH;
            Login = login;
            Motdepasse = motdepasse;
            Part = part;
        }

        public override string ToString()
        {
            return Login + "|" + Motdepasse + "|"+ Part;
        }
    }
}
