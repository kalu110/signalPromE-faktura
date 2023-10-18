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
    public partial class DodajUslugu : Form
    {
        public DodajUslugu()
        {
            InitializeComponent();
        }

        private void btnDodajUsluguBtn_Click(object sender, EventArgs e)
        {
            if (UslugaNaziv.Text.Length == 0)
            {
                MessageBox.Show("Morate dodati naziv usluge!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into usluga values(@nazivusluge)", con);

                cmd.Parameters.AddWithValue("@nazivusluge", UslugaNaziv.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd2 = new SqlCommand("Select nazivUsluga from usluga", con);
                MessageBox.Show("Uspešno ste dodali novu uslugu!");
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
              
                prikazUsluge.DataSource = dt;
            }
        }

        private void DodajUslugu_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            SqlCommand cmd = new SqlCommand("Select nazivUsluga from usluga", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGridViewButtonColumn buttoncolumn = new DataGridViewButtonColumn();
            prikazUsluge.DataSource = dt;
            prikazUsluge.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            prikazUsluge.Columns[0].HeaderText = "Naziv usluge";
            prikazUsluge.Columns.Insert(1, buttoncolumn);
            buttoncolumn.HeaderText = "Delete Row";
            buttoncolumn.Width = 100;
            buttoncolumn.Text = "Delete";
            buttoncolumn.UseColumnTextForButtonValue = true;
            prikazUsluge.AllowUserToAddRows = false;

        }

        private void prikazUsluge_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-7PH5CRCR\\SQLEXPRESS;Initial Catalog=signalprom;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = prikazUsluge.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Da li želite da izbrišete ovaj red?", row.Cells[0].Value), "Potvrda", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("Delete  from usluga where nazivUsluga=@nazivUsluga", con);
                    cmd.Parameters.AddWithValue("nazivUsluga", row.Cells[0].Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
