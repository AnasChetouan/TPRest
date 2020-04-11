using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBooking
{
    public partial class Offres : Form
    {
        List<Offre> _offres;
        DateTime _arr;
        DateTime _dep;
        int _nbClients;
        List<String> _dataOffres;

        public List<Offre> ListeOffres { get => _offres; set => _offres = value; }
        public DateTime Arr { get => _arr; set => _arr = value; }
        public DateTime Dep { get => _dep; set => _dep = value; }
        public int NbClients { get => _nbClients; set => _nbClients = value; }
        public List<string> DataOffres { get => _dataOffres; set => _dataOffres = value; }

        public Offres(List<Offre> l, DateTime arr, DateTime dep, int nbClients)
        {
            ListeOffres = l;
            Arr = arr;
            Dep = dep;
            NbClients = nbClients;
            InitializeComponent();
        }



        private void Offres_Load(object sender, EventArgs e)
        {
            if (ListeOffres != null)
            {

                foreach (Offre o in ListeOffres)
                {
                    this.listBox1.Items.Add("Offre n°" + o.IdOffre + ": Chambre à " + o.NbLits + " lit(s). Tarif proposé : " + o.Prix + " euros.");
                }
            }
            else
                this.listBox1.Items.Add("Aucune offre pour cet hôtel");
            this.listBox2.Items.Add("Aucune offre pour cet hôtel");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void arrayOfStringBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox2.ClearSelected();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*string text = listBox1.GetItemText(listBox1.SelectedItem);
            string idOffre = text.Split(':')[0];

            string[] split = DataOffres.ElementAt(int.Parse(idOffre)).Split('|');
            //int nbPlaces = int.Parse(split[0]);
            //int nbLits = int.Parse(split[1]);
            float prixIbis = float.Parse(split[2]);
            string idChambre = split[3];
            string nomHotel = split[4];
            string idRef = idChambre + "|" + nomHotel;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Vous voulez réserver la chambre numéro " + idOffre, "Confirmation", buttons);
            if (result == DialogResult.Yes)
            {
               // Booking.BookingSoapClient Booking = new Booking.BookingSoapClient();

               // On aurait pu rajouter un formulaire pour demander au client d'ajouter ses informations avant de réserver mais pour les besoins du TP, on met des valeurs arbitraires :
               // string msg = Booking.ReserverChambre(idRef, "123", "123", new DateTime(2020, 5, 5, 0, 0, 0), "nomClient", "prenomClient", prixIbis, Arr, Dep, NbClients);

                  //  MessageBox.Show("Voici la réponse de "+ nomHotel + " : " +msg);

            }
            else
            {
                // Do something  
            }*/
          

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox1.ClearSelected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }
    }
}
