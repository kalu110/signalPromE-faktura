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
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office.Word;

namespace SignalProm
{
    public partial class DodajKlijenta : Form
    {

       
        public DodajKlijenta()
        {
            InitializeComponent();
        }
        Form1 frm = new Form1();
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDodajKlijentaBtn_Click(object sender, EventArgs e)
        {
            if (klijentIme.Text.Length == 0 || klijentAdresa.Text.Length == 0 || klijentPIB.Text.Length == 0 || klijentRacun.Text.Length == 0 || klijentTel.Text.Length == 0 || klijentFaks.Text.Length == 0)
            {
                MessageBox.Show("Sva polja su obavezna!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO klijent VALUES(@ime,@adresa,@pib,@racun,@tel,@faks)", con);

                cmd.Parameters.AddWithValue("@ime", klijentIme.Text);
                cmd.Parameters.AddWithValue("@adresa", klijentAdresa.Text);
                cmd.Parameters.AddWithValue("@pib", klijentPIB.Text);
                cmd.Parameters.AddWithValue("@racun", klijentRacun.Text);
                cmd.Parameters.AddWithValue("@tel", klijentTel.Text);
                cmd.Parameters.AddWithValue("@faks", klijentFaks.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Uspešno ste dodali klijenta!");

                
                SqlCommand cmd2 = new SqlCommand("SELECT imeKlijent,adresaKlijent,PIBKlijent,racunKlijent,telKlijent,faksKlijent FROM klijent", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
             
                
               


            }

        }

        private void DodajKlijenta_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            SqlCommand cmd = new SqlCommand("SELECT imeKlijent,adresaKlijent,PIBKlijent,racunKlijent,telKlijent,faksKlijent FROM klijent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewButtonColumn buttoncolumn = new DataGridViewButtonColumn();
           
            dataGridView1.Columns.Insert(6, buttoncolumn);
            buttoncolumn.HeaderText = "Delete Row";
            buttoncolumn.Width = 100;
            buttoncolumn.Text = "Delete";
            buttoncolumn.UseColumnTextForButtonValue = true;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            if (e.ColumnIndex == 6) {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Da li želite da izbrišete ovaj red?", row.Cells[2].Value), "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("Delete  from klijent where PIBKlijent=@PIBKlijent", con);
                    cmd.Parameters.AddWithValue("PIBKlijent", row.Cells[2].Value);
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();


                    
                }
            }

            
           

        }

        private void DodajKlijenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void DodajKlijenta_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
