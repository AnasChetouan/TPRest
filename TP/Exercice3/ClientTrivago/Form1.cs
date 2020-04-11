using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTrivago
{
    public partial class Form1 : Form
    {
        static readonly HttpClient clientBooking = new HttpClient();
        static readonly HttpClient clientIbis = new HttpClient();

        public Form1()
        {
            clientBooking.BaseAddress = new Uri("https://localhost:44339/");
            clientBooking.DefaultRequestHeaders.Accept.Clear();
            clientBooking.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            clientIbis.BaseAddress = new Uri("https://localhost:44348/");
            clientIbis.DefaultRequestHeaders.Accept.Clear();
            clientIbis.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

            private async void button1_Click(object sender, EventArgs e)
            {


            int nbEtoiles = -1;

            if (radioButton2.Checked)
                nbEtoiles = 1;
            else if (radioButton3.Checked)
                nbEtoiles = 2;
            else if (radioButton4.Checked)
                nbEtoiles = 3;
            else if (radioButton5.Checked)
                nbEtoiles = 4;
            else if (radioButton6.Checked)
                nbEtoiles = 5;

            DateTime arr = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, this.dateTimePicker1.Value.Day, 0, 0, 0);
            DateTime dep = new DateTime(this.dateTimePicker2.Value.Year, this.dateTimePicker2.Value.Month, this.dateTimePicker2.Value.Day, 0, 0, 0);



            float prixMin = float.Parse(textBox3.Text);
            float prixMax = float.Parse(textBox4.Text);

            string ville = this.textBox1.Text;
            int nbClients = int.Parse(this.textBox2.Text);

            //MessageBox.Show(dep.ToString() + " - " + arr.ToString() + ville + nbEtoiles + prixMax + prixMax + nbClients);

            //ArrayOfString[] listOffers;
            //listOffers = Booking.RecevoirOffres(ville, arr, dep, prixMin, prixMax, nbEtoiles, nbClients);

            string dateArr = arr.Day + "-" + arr.Month + "-" + arr.Year;
            string dateDep = dep.Day + "-" + dep.Month + "-" + dep.Year;

            string path = "/api/Booking/" + ville + "/" + dateArr + "/" + dateDep + "/" + prixMin + "/" + prixMax + "/" + nbEtoiles + "/" + nbClients;
            List<Offre> offres = new List<Offre>();
            Dictionary<int, string> imagesChambres = new Dictionary<int, string>();

            HttpResponseMessage response = await clientBooking.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                offres = await response.Content.ReadAsAsync<List<Offre>>();
            }
            else
                offres = null;

            // Télécharger l'image d'une chambre d'après son ID :

            // https://localhost:44348/api/Chambres/1/GetImage

            foreach (Offre o in offres) {
                int idChambre = o.IdChambre;
                path = "api/Chambres/" + idChambre + "/GetImage";
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(System.Net.Mime.MediaTypeNames.Application.Octet));// header
                response = await clientIbis.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    //System.Net.Mime.MediaTypeNames.Application.Octet
                    // var image = await response.Content.ReadAsAsync<FileResult>();
                    byte[] imageBytes = await clientIbis.GetByteArrayAsync(path);

                    string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                    string dossierImagePath = Path.Combine(wanted_path, "ImagesDownload");

                    string localFilename = "chambre-" + idChambre + ".jpg";
                    string localPath = Path.Combine(dossierImagePath, localFilename);
                    File.WriteAllBytes(localPath, imageBytes);

                    imagesChambres.Add(idChambre, localPath);
                }
                    //this.label4.Text = "Le chargement de l'image a échoué!";
            }

            Offres offresForm = new Offres(offres, imagesChambres, dateArr, dateDep, nbClients);
            offresForm.Tag = this;
            offresForm.Show(this);
            Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
