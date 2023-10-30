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
    public partial class KlijentAddUslugeForm : Form
    {
        public KlijentAddUslugeForm()
        {
            InitializeComponent();
        }

        
        
    
        public static string usluga = "";
        public static string jedmere = "";
        public static string kol = "";
        public static string cena = "";
        public static string ugovorNarudzbenice = "";
        public static string racunBr = "";
        public static string napomena = "";
        public static string MjestoIzvodjenjaRadva = "";
        public static string datumFakturisanja = "";
        public static string ZiroRacunUplata = "";
        public static string NacinPlacanja = "";
        public static string brojFiskalnogRacuna = "";
        public static string valutaPlacanjaa = "";

        List<klijentSkr> lista = new List<klijentSkr>();

        public Form1 form1;
        Fakturapdf fakturapdf;
        DodajUslugu dodajUslugu;
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                if (radioButton1.Checked != false || radioButton2.Checked != false)
                {
                    if (kolTxt.Text != string.Empty)
                    {
                        if (cenaTxt.Text != string.Empty)
                        {
                            
                            
                            usluga = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                            if (radioButton1.Checked == true)
                            {
                                jedmere = radioButton1.Text;
                            }
                            else
                            {
                                jedmere = radioButton2.Text;
                            }
                            kol = kolTxt.Text;
                            cena = cenaTxt.Text;
                            lista.Add(new klijentSkr(usluga, jedmere, kol, cena));
                            klijentSkr k = new klijentSkr(usluga,jedmere,kol,cena);
                            k.AddKlijent(usluga, jedmere, kol, cena);
                            MessageBox.Show("Uspešno ste dodali uslugu na fakturu!");
                        }
                        else
                        {
                            MessageBox.Show("Polje cena je obavezno!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Polje količina je obavezno!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Morate izabrati mernu jedinicu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati uslugu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MyCodes(object sender, FormClosingEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Public\\signalPromE-faktura-main\\SignalProm\\SignalProm\\signalprom.mdf;Integrated Security=True");

            SqlCommand cmd2 = new SqlCommand("Select nazivUsluga from usluga", con);
            SqlDataAdapter da2 = new SqlDataAdapter();
            da2.SelectCommand = cmd2;
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].HeaderText = "Naziv usluge";
            MjestoIzvodjenjaRadovaKlijentAdd.Text = Form1.SetValueForText2;
            dataGridView2.AllowUserToAddRows = false;
        }
        private void KlijentAddUslugeForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Public\\signalPromE-faktura-main\\SignalProm\\SignalProm\\signalprom.mdf;Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand("Select nazivUsluga from usluga", con);
            SqlDataAdapter da2 = new SqlDataAdapter();
            da2.SelectCommand = cmd2;
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].HeaderText = "Naziv usluge";
            MjestoIzvodjenjaRadovaKlijentAdd.Text = Form1.SetValueForText2;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void cenaTxt_TextChanged(object sender, EventArgs e)
        {
            double kol;
            double cena;
            if (cenaTxt.Text.Length == 0)
            {
                cena = 0;
            }
            else {
                cena = double.Parse(cenaTxt.Text);
            }
            if (kolTxt.Text.Length == 0)
            {
                kol = 0;

            }
            else {
                kol = double.Parse(kolTxt.Text);
            }
          
          
            cenabezPDV.Text = (cena * double.Parse(kolTxt.Text)).ToString("0.000");
            cenasaPDV.Text = (double.Parse(cenabezPDV.Text) * 17 / 100).ToString("0.000");
            ukupnosaPDV.Text = (double.Parse(cenasaPDV.Text) + double.Parse(cenabezPDV.Text)).ToString("0.000");
        }

        private void generisifakturu_Click(object sender, EventArgs e)
        {
            string[] a = new string[dateTimePicker2.Text.ToString().Split('/').Length ];
            a = dateTimePicker2.Text.ToString().Split('/');
            ugovorNarudzbenice = textBox2.Text + " od " + a[1] + "." + a[0] + "." + a[2] + "  god.";
            napomena = textBox3.Text.Trim();
            racunBr = textBox1.Text.ToString();
            MjestoIzvodjenjaRadva = MjestoIzvodjenjaRadovaKlijentAdd.Text.ToString();
            datumFakturisanja = dateTimePicker1.Text.ToString();
            valutaPlacanjaa = valutaplacanja.Text.ToString();
            ZiroRacunUplata = textBox7.Text.ToString();
            NacinPlacanja = textBox8.Text.ToString();
            brojFiskalnogRacuna = textBox9.Text.ToString();
            if (lista.Count == 0)
            {
                MessageBox.Show("Morate dodati uslugu na fakturu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ugovorNarudzbenice.Length == 0)
            {
                MessageBox.Show("Niste dodali broj ugovora narudzbenice", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (racunBr.Length == 0)
            {
                MessageBox.Show("Niste dodali broj racuna!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (napomena.Length == 0)
            {
                MessageBox.Show("Niste dodali napomenu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MjestoIzvodjenjaRadovaKlijentAdd.Text == "")
            {
                MessageBox.Show("Niste dodali mesto izvodjenja radova!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NacinPlacanja.Length == 0)
            {
                MessageBox.Show("Niste dodali nacin placanja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (valutaplacanja.Text == "")
            {
                MessageBox.Show("Niste dodali valutu placanja!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ZiroRacunUplata.Length == 0)
            {
                MessageBox.Show("Niste dodali ziro racun!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (brojFiskalnogRacuna.Length == 0)
            {
                MessageBox.Show("Niste dodali broj fiskalnog racuna!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fakturapdf = new Fakturapdf(lista);
                fakturapdf.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dodajUslugu = new DodajUslugu();
            dodajUslugu.FormClosing += new FormClosingEventHandler(MyCodes);
            dodajUslugu.Show();

        }

        private void kolTxt_TextChanged(object sender, EventArgs e)
        {
            double cena;
            double kol;
            if (cenaTxt.Text.Length != 0)
            {
                cena = double.Parse(cenaTxt.Text);
            }
            else
            {
                cena = 0;
            }
            if (cenaTxt.Text.Length == 0)
            {
                cena = 0;
            }
            if (kolTxt.Text.Length == 0)
            {
                kol = 0;
            }
            else {
                kol = double.Parse(kolTxt.Text);
            }
          
            cenabezPDV.Text = (cena * kol).ToString();
            cenasaPDV.Text = (double.Parse(cenabezPDV.Text) * 17 / 100).ToString("0.000");
            ukupnosaPDV.Text = (double.Parse(cenasaPDV.Text) + double.Parse(cenabezPDV.Text)).ToString("0.000");
        }
    }
}
