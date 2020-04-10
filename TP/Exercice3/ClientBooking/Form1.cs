using Client.Booking;
using LibHotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking.BookingSoapClient Booking = new Booking.BookingSoapClient();

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

            ArrayOfString[] listOffers;
            listOffers = Booking.RecevoirOffres(ville, arr, dep, prixMin, prixMax, nbEtoiles, nbClients);

            Offres offresForm = new Offres(listOffers, arr, dep, nbClients);
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
