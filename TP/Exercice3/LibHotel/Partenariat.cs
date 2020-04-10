using System;
using System.Collections.Generic;
using System.Text;

namespace LibHotel
{
    public class Partenariat
    {
        private string _login;
        private string _motdepasse;
        private float _part;

        public string Login { get => _login; set => _login = value; }
        public string Motdepasse { get => _motdepasse; set => _motdepasse = value; }
        public float Part { get => _part; set => _part = value; }

        public Partenariat()
        {
        }

        public Partenariat(string login, string motdepasse, float part)
        {
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
