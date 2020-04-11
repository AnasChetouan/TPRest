using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBooking
{

    public partial class Offres : Form
    {
        List<Offre> _offres;
        string _arr;
        string _dep;
        int _nbClients;
        Dictionary<int, int> _dataOffres; // Dictionnaire pour lier l'ID de l'offre à l'ID de l'item dans la ListBox
        Dictionary<int, string> imagesChambres; // Dictionnaire pour lier chaque de chambre à son image téléchargée

        static HttpClient client = new HttpClient();
        public List<Offre> ListeOffres { get => _offres; set => _offres = value; }
        public string Arr { get => _arr; set => _arr = value; }
        public string Dep { get => _dep; set => _dep = value; }
        public int NbClients { get => _nbClients; set => _nbClients = value; }
        public Dictionary<int, int> DataOffres { get => _dataOffres; set => _dataOffres = value; }
        public Dictionary<int, string> ImagesChambres { get => imagesChambres; set => imagesChambres = value; }

        public Offres(List<Offre> l, Dictionary<int, string> imagesChambres, string arr, string dep, int nbClients)
        {
            ListeOffres = l;
            Arr = arr;
            Dep = dep;
            NbClients = nbClients;
            ImagesChambres = imagesChambres;

            client.BaseAddress = new Uri("https://localhost:44348/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
            DataOffres = new Dictionary<int, int>();
            InitializeComponent();
        }



        private void Offres_Load(object sender, EventArgs e)
        {
            if (ListeOffres != null)
            {
                int compteurItems = 0;
                foreach (Offre o in ListeOffres)
                {
                    this.listBox1.Items.Add("Offre n°" + o.IdOffre + ": Chambre à " + o.NbLits + " lit(s). Tarif proposé : " + o.Prix + " euros.");
                    DataOffres.Add(compteurItems, o.IdOffre);
                    compteurItems++;
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

            int indice = listBox1.SelectedIndex;
            int idOffre = DataOffres[indice];
            Offre o = ListeOffres.Find(x => x.IdOffre == idOffre);
            int idChambre = o.IdChambre;

            this.label4.Text = "Image de la chambre numéro "+idChambre+" : ";
            string localpath = imagesChambres[idChambre];
            pictureBox1.Image = Image.FromFile(@localpath);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            int indice = listBox1.SelectedIndex;
            int idOffre = DataOffres[indice];

            //https://localhost:44348/api/Chambres/100/login/mdp/1/Prenom/Nom/01.10.2020/02.10.2020
            string path = "/api/Chambres/" + 100 + "/" + "login" + "/" + "mdp" + "/" + 1 + "/" + "nomClient" + " / " + "prenomClient" + " / " + Arr + "/" + Dep;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Vous voulez réserver la chambre numéro " + idOffre, "Confirmation", buttons);
            if (result == DialogResult.Yes)
            {
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    msg = await response.Content.ReadAsAsync<string>();
                }
                else
                    msg = "La réservation a échoué ! Veuillez ré-essayer.";
            }
            else
                msg = "Vous avez annulé la réservation.";

            MessageBox.Show(msg);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
