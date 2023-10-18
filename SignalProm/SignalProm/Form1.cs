using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SignalProm
{
    public partial class Form1 : Form
    {
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            SqlCommand cmd = new SqlCommand("SELECT imeKlijent,adresaKlijent,PIBKlijent,racunKlijent,telKlijent,faksKlijent FROM klijent", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Ime";
            dataGridView1.Columns[1].HeaderText = "Adresa";
            dataGridView1.Columns[2].HeaderText = "PIB";
            dataGridView1.Columns[3].HeaderText = "Racun";
            dataGridView1.Columns[4].HeaderText = "Telefon";
            dataGridView1.Columns[5].HeaderText = "Faks";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            

        }

        public  void MyCodes(object sender,FormClosingEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            SqlCommand cmd = new SqlCommand("SELECT imeKlijent,adresaKlijent,PIBKlijent,racunKlijent,telKlijent,faksKlijent FROM klijent", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Ime";
            dataGridView1.Columns[1].HeaderText = "Adresa";
            dataGridView1.Columns[2].HeaderText = "PIB";
            dataGridView1.Columns[3].HeaderText = "Racun";
            dataGridView1.Columns[4].HeaderText = "Telefon";
            dataGridView1.Columns[5].HeaderText = "Faks";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        public DodajKlijenta dodajKlijenta;
        public DodajUslugu dodajUslugu;
        public KlijentAddUslugeForm klijendAdd;
        public Fakturapdf fakturapdf;
        private void btnDodajKlijenta_Click(object sender, EventArgs e)
        {
            
            dodajKlijenta = new DodajKlijenta();
            dodajKlijenta.FormClosing += new FormClosingEventHandler(MyCodes);
            dodajKlijenta.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dodajUslugu = new DodajUslugu();
            dodajUslugu.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];

                SetValueForText1 = dr.Cells[0].Value.ToString();
                SetValueForText2 = dr.Cells[1].Value.ToString();
                SetValueForText3 = dr.Cells[2].Value.ToString();
                klijendAdd = new KlijentAddUslugeForm();
                klijendAdd.Show();
              

            }
            else {
                MessageBox.Show("Morate izabrati 1 klijenta!","Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
                }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
            
        }
    }
}
