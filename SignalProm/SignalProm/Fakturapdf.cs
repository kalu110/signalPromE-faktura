using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Paragraph = iTextSharp.text.Paragraph;

namespace SignalProm
{
    public partial class Fakturapdf : Form
    {


        private static String[] units = { "nula", "jedna", "dve", "tri", "četiri", "pet", "šest", "sedam", "osam", "devet", "deset", "jedanaest", "dvanaest", "trinaest", "četrnaest", "petnaest", "šesnaest", "sedamnaest", "osamnaest", "devetnaest" };
        private static String[] tens = { "", "", "dvadeset", "trideset", "četrdeset", "pedeset", "šezdeset", "sedamdeset", "osamdeset", "devedeset" };
        List<klijentSkr> lista2;
        public Fakturapdf(object sender)
        {

            InitializeComponent();
            lista2 = (List<klijentSkr>)sender;
        }



        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string usluga = "";
        public static string jedmere = "";
        public static string kol = "";
        public static string cena = "";


        private void label8_Click(object sender, EventArgs e)
        {

        }
        double sumabezPDV = 0;
        double sumasaPDV = 0;
        double PDV = 0;
        string slovimaBroj;
        private void Fakturapdf_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.SetValueForText1;
            label3.Text = Form1.SetValueForText2;
            label4.Text = Form1.SetValueForText3;
            NapomenaFaktura.Text = KlijentAddUslugeForm.napomena;
            brojFiskalnogRacuna.Text = KlijentAddUslugeForm.brojFiskalnogRacuna;
            fakturaNacinPlacanja.Text = KlijentAddUslugeForm.NacinPlacanja;
            valutaplacanja.Text = KlijentAddUslugeForm.valutaPlacanjaa;
            fakturaMjestoIzvodjenjaradova.Text = KlijentAddUslugeForm.MjestoIzvodjenjaRadva;
            DatumFakturisanja.Text = KlijentAddUslugeForm.datumFakturisanja;
            faturaZiroRacun.Text = KlijentAddUslugeForm.ZiroRacunUplata;
            brUgovoraDatum.Text = KlijentAddUslugeForm.ugovorNarudzbenice;







            DataTable qwe = new DataTable();
            qwe.Clear();
            qwe.Columns.Add("BR");
            qwe.Columns.Add("USLUGA");
            qwe.Columns.Add("JED. MJERE");
            qwe.Columns.Add("KOL");
            qwe.Columns.Add("CENA");
            qwe.Columns.Add("UKUPNO BEZ PDV-a");
            qwe.Columns.Add("CIJENA SA PDV-om");
            qwe.Columns.Add("Ukupan iznos sa PDV-om");
            for (var i = 0; i < lista2.Count; i++)
            {
                var cena1 = (double.Parse(lista2[i].cena) * double.Parse(lista2[i].kol)).ToString("0.00") + '\n';
                var cena2 = (double.Parse(cena1) * 17 / 100).ToString("0.00") + '\n';
                var cena3 = (double.Parse(cena2) + double.Parse(cena1)).ToString("0.00") + '\n';

                DataRow _ravi = qwe.NewRow();
                _ravi["BR"] = (i + 1).ToString();
                _ravi["USLUGA"] = lista2[i].usluga.Trim();
                _ravi["JED. MJERE"] = lista2[i].jedmere;
                _ravi["KOL"] = lista2[i].kol;
                _ravi["CENA"] = lista2[i].cena;
                _ravi["UKUPNO BEZ PDV-a"] = cena1;
                _ravi["CIJENA SA PDV-om"] = cena2;
                _ravi["Ukupan iznos sa PDV-om"] = cena3;

                qwe.Rows.Add(_ravi);


            }
            dataGridView1.DataSource = qwe;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;


            foreach (DataGridViewRow dt in dataGridView1.Rows)
            {
                sumabezPDV += double.Parse(dt.Cells[5].Value.ToString());
                sumasaPDV += double.Parse(dt.Cells[7].Value.ToString());
                PDV += double.Parse(dt.Cells[6].Value.ToString());
            }

            label45.Text = sumabezPDV.ToString("0.000");
            label47.Text = PDV.ToString("0.000");
            label48.Text = sumasaPDV.ToString("0.000");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Morate upisati ukupan iznos slovima!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                slovimaBroj = textBox1.Text;
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
                        try
                        {
                            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                            doc.Open();


                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false);
                            Font titleFont = new Font(bf, 16);
                            Font infoFont = new Font(bf, 7);
                            Font mediumFont = new Font(bf, 12);
                            Font tenFont = new Font(bf, 10);
                            System.Drawing.Image pImage = System.Drawing.Image.FromFile("C:\\Users\\Public\\signalPromE-faktura-main\\SignalProm\\SignalProm\\image\\logo.png");
                            iTextSharp.text.Image iTextImage = iTextSharp.text.Image.GetInstance(pImage, System.Drawing.Imaging.ImageFormat.Gif);
                            iTextImage.Alignment = Element.ALIGN_LEFT;
                            iTextImage.ScaleAbsolute(100f, 100f);

                            string text = "Društvo sa ograničenom odgovornošću za proizvodnju, promet i ugradnju saobraćajne opreme \n" +

                             "";
                            Paragraph p = new Paragraph(text);
                            p.Alignment = Element.ALIGN_CENTER;

                            p.Font = infoFont;
                            string text2 = "SIGNAL PROM d.o.o. Zvornik";
                            Paragraph p2 = new Paragraph(text2);
                            p2.Alignment = Element.ALIGN_CENTER;

                            p2.Font = titleFont;

                            string text3 = "Ekonomija, ul. Četvrta. br22";
                            Paragraph p3 = new Paragraph(text3);
                            p3.Alignment = Element.ALIGN_CENTER;

                            p3.Font = mediumFont;



                            string text4 = "Tel/fax: 056/213-656; Mob: 065/704-931  \n " +
                                "email: signalpromdoo@gmail.com \n " +
                                "JIB: 4403982360007  \n PIB: 403982360007";
                            Paragraph p4 = new Paragraph(text4);
                            p4.Alignment = Element.ALIGN_LEFT;

                            p4.Font = infoFont;
                            string text5 = " ŽIRO RAČUNI: \n " +
                               "552-0001656237815 Adiko banka \n " +
                               "555-4000027600489 Nova banka \n" +
                               "572-2860000213505 MF banka";
                            Paragraph p5 = new Paragraph(text5);
                            p5.Alignment = Element.ALIGN_LEFT;

                            p5.Font = infoFont;
                            string text6 = "Reg. Sud: Okružni privredni sud Bijeljina, Matični broj: 11140220 Iznos upisanog kapitala odgovara iznosu utvrđenom u rješenju suda.";
                            Paragraph pfooterheader = new Paragraph(text6);
                            pfooterheader.Alignment = Element.ALIGN_LEFT;

                            pfooterheader.Font.Size = 6;

                            var table = new PdfPTable(4);
                            var cell = new PdfPCell { PaddingLeft = 5, PaddingTop = 5, PaddingBottom = 5, PaddingRight = 5 };
                            var cell2 = new PdfPCell { PaddingLeft = 5, PaddingTop = 0, PaddingBottom = 5, PaddingRight = 5 };

                            var tablesmall = new PdfPTable(2);
                            var cellsmall = new PdfPCell { PaddingLeft = 5, PaddingTop = 5, PaddingBottom = 5, PaddingRight = 5 };
                            var cell2small = new PdfPCell { PaddingLeft = 5, PaddingTop = 0, PaddingBottom = 5, PaddingRight = 5 };
                            cell2small.BorderWidthTop = 0;
                            cell2small.BorderWidthBottom = 0;
                            cellsmall.BorderWidthTop = 0;
                            cellsmall.BorderWidthBottom = 0;
                            cell2small.BorderWidthLeft = 0;
                            cell2small.BorderWidthRight = 0;
                            cellsmall.BorderWidthRight = 0;
                            cellsmall.BorderWidthLeft = 0;

                            cellsmall.AddElement(p4);
                            cell2small.AddElement(p5);

                            tablesmall.AddCell(cellsmall);
                            tablesmall.AddCell(cell2small);


                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.AddElement(iTextImage);
                            table.WidthPercentage = 100;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.AddElement(p);
                            cell2.AddElement(p2);
                            cell2.AddElement(p3);
                            cell2.AddElement(tablesmall);
                            cell2.AddElement(pfooterheader);
                            cell2.Colspan = 3;
                            cell2.BorderWidthLeft = 0;
                            cell2.BorderWidthRight = 0;
                            cell.BorderWidthRight = 0;
                            cell.BorderWidthLeft = 0;
                            table.AddCell(cell);
                            table.AddCell(cell2);
                            //image.ScaleToFit(JpgBg.Width, JpgBg.Height
                            iTextImage.Alignment = iTextSharp.text.Image.UNDERLYING;


                            doc.Add(table);

                            var tablenar = new PdfPTable(2);
                            tablenar.WidthPercentage = 100;
                            var cellnar = new PdfPCell { PaddingLeft = 5, PaddingTop = 50, PaddingBottom = 70, PaddingRight = 30 };
                            var cell2nar = new PdfPCell { PaddingLeft = 30, PaddingTop = 50, PaddingBottom = 70, PaddingRight = 5 };
                            cell2nar.BorderWidthTop = 0;
                            cell2nar.BorderWidthBottom = 0;
                            cellnar.BorderWidthTop = 0;
                            cellnar.BorderWidthBottom = 0;
                            cell2nar.BorderWidthLeft = 0;
                            cell2nar.BorderWidthRight = 0;
                            cellnar.BorderWidthRight = 0;
                            cellnar.BorderWidthLeft = 0;
                            cellnar.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell2nar.HorizontalAlignment = Element.ALIGN_RIGHT;
                            string pnart = "Ugovor - Narudžbenica \n " + KlijentAddUslugeForm.ugovorNarudzbenice;
                            Paragraph pnar = new Paragraph(pnart);
                            pnar.Alignment = Element.ALIGN_CENTER;
                            pnar.Font = mediumFont;
                            cellnar.AddElement(pnar);

                            string pnart2 = Form1.SetValueForText1;
                            Paragraph pnar2 = new Paragraph(pnart2);
                            pnar2.Alignment = Element.ALIGN_CENTER;
                            pnar2.Font = titleFont;

                            string pnart3 = Form1.SetValueForText2;
                            Paragraph pnar3 = new Paragraph(pnart3);
                            pnar3.Alignment = Element.ALIGN_CENTER;
                            pnar3.Font = mediumFont;

                            string pnart4 = "PIB:" + Form1.SetValueForText3;
                            Paragraph pnar4 = new Paragraph(pnart4);
                            pnar4.Alignment = Element.ALIGN_CENTER;
                            pnar4.Font = mediumFont;

                            cell2nar.AddElement(pnar2);
                            cell2nar.AddElement(pnar3);
                            cell2nar.AddElement(pnar4);
                            tablenar.AddCell(cellnar);
                            tablenar.AddCell(cell2nar);


                            doc.Add(tablenar);

                            string msizdt = "Mesto izdavanja: Zvornik";
                            Paragraph msizd = new Paragraph(msizdt);
                            msizd.PaddingTop = 20;
                            msizd.Alignment = Element.ALIGN_LEFT;
                            msizd.Alignment = Element.ALIGN_BOTTOM;
                            msizd.Font.Size = 10;
                            doc.Add(msizd);

                            string rct = "RAČUN br: ";
                            Paragraph rc = new Paragraph(rct);
                            rc.Alignment = Element.ALIGN_CENTER;
                            rc.Font = titleFont;

                            doc.Add(rc);
                            var s = new PdfPTable(8);


                            s.SetTotalWidth(new float[] { 10f, 160f, 35f, 30f, 30f, 45f, 45f, 45f });
                            var cs = new PdfPCell { PaddingLeft = 5, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 5 };
                            var cs2 = new PdfPCell { PaddingLeft = 50, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 50 };
                            var cs3 = new PdfPCell { PaddingLeft = 5, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 5 };
                            var cs4 = new PdfPCell { PaddingLeft = 5, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 5 };
                            var cs5 = new PdfPCell { PaddingLeft = 5, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 5 };
                            var cs6 = new PdfPCell { PaddingLeft = 5, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 5 };
                            var cs7 = new PdfPCell { PaddingLeft = 5, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 5 };
                            var cs8 = new PdfPCell { PaddingLeft = 5, PaddingTop = 15, PaddingBottom = 5, PaddingRight = 5 };
                            cs.BorderWidth = 0;
                            cs2.BorderWidth = 0;
                            cs3.BorderWidth = 0;
                            cs5.BorderWidth = 0;
                            cs4.BorderWidth = 0;
                            cs6.BorderWidth = 0;
                            cs7.BorderWidth = 0;
                            cs8.BorderWidth = 0;
                            cs.BorderWidthBottom = 1;
                            cs2.BorderWidthBottom = 1;
                            cs3.BorderWidthBottom = 1;
                            cs5.BorderWidthBottom = 1;
                            cs4.BorderWidthBottom = 1;
                            cs6.BorderWidthBottom = 1;
                            cs7.BorderWidthBottom = 1;
                            cs8.BorderWidthBottom = 1;
                            string tr = " ";
                            Paragraph tsr = new Paragraph(tr);
                            tsr.Alignment = Element.ALIGN_CENTER;
                            tsr.Font.Size = 7;
                            string tr2 = "USLUGA";
                            Paragraph tsr2 = new Paragraph(tr2);
                            tsr2.Alignment = Element.ALIGN_CENTER;
                            tsr2.Font.Size = 7;
                            string tr3 = "JED. MJERE";
                            Paragraph tsr3 = new Paragraph(tr3);
                            tsr3.Alignment = Element.ALIGN_CENTER;
                            tsr3.Font.Size = 7;
                            string tr4 = "KOL";
                            Paragraph tsr4 = new Paragraph(tr4);
                            tsr4.Alignment = Element.ALIGN_CENTER;
                            tsr4.Font.Size = 7;
                            string tr5 = "CENA";
                            Paragraph tsr5 = new Paragraph(tr5);
                            tsr5.Alignment = Element.ALIGN_CENTER;
                            tsr5.Font.Size = 7;
                            string tr6 = "UKUPNO BEZ PDV-a";
                            Paragraph tsr6 = new Paragraph(tr6);
                            tsr6.Alignment = Element.ALIGN_CENTER;
                            tsr6.Font.Size = 7;
                            string tr7 = "CIJENA SA PDV";
                            Paragraph tsr7 = new Paragraph(tr7);
                            tsr7.Alignment = Element.ALIGN_CENTER;
                            tsr7.Font.Size = 7;
                            string tr8 = "UKUPAN IZNOS SA PDV-om";
                            Paragraph tsr8 = new Paragraph(tr8);
                            tsr8.Alignment = Element.ALIGN_CENTER;
                            tsr8.Font.Size = 7;


                            cs.AddElement(tsr);
                            cs2.AddElement(tsr2);
                            cs3.AddElement(tsr3);
                            cs4.AddElement(tsr4);
                            cs5.AddElement(tsr5);
                            cs6.AddElement(tsr6);
                            cs7.AddElement(tsr7);
                            cs8.AddElement(tsr8);

                            s.AddCell(cs);
                            s.AddCell(cs2);
                            s.AddCell(cs3);
                            s.AddCell(cs4);
                            s.AddCell(cs5);
                            s.AddCell(cs6);
                            s.AddCell(cs7);
                            s.AddCell(cs8);





                            var c = new PdfPCell { };
                            var c2 = new PdfPCell { };
                            var c3 = new PdfPCell { };
                            var c4 = new PdfPCell { };
                            var c5 = new PdfPCell { };
                            var c6 = new PdfPCell { };
                            var c7 = new PdfPCell { };
                            var c8 = new PdfPCell { };
                            c.BorderWidth = 0;
                            c2.BorderWidth = 0;
                            c3.BorderWidth = 0;
                            c5.BorderWidth = 0;
                            c4.BorderWidth = 0;
                            c6.BorderWidth = 0;
                            c7.BorderWidth = 0;
                            c8.BorderWidth = 0;
                            c.VerticalAlignment = Element.ALIGN_CENTER;
                            c.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c2.VerticalAlignment = Element.ALIGN_CENTER;
                            c2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c3.VerticalAlignment = Element.ALIGN_CENTER;
                            c3.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c4.VerticalAlignment = Element.ALIGN_CENTER;
                            c4.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c5.VerticalAlignment = Element.ALIGN_CENTER;
                            c5.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c6.VerticalAlignment = Element.ALIGN_CENTER;
                            c6.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c7.VerticalAlignment = Element.ALIGN_CENTER;
                            c7.VerticalAlignment = Element.ALIGN_MIDDLE;
                            c8.VerticalAlignment = Element.ALIGN_CENTER;
                            c8.VerticalAlignment = Element.ALIGN_MIDDLE;

                            for (var i = 0; i < lista2.Count; i++)
                            {

                                if (i > 0)
                                {
                                    c.PaddingTop = 5;
                                    c2.PaddingTop = 5;
                                    c3.PaddingTop = 5;
                                    c4.PaddingTop = 5;
                                    c5.PaddingTop = 5;
                                    c6.PaddingTop = 5;
                                    c7.PaddingTop = 5;
                                    c8.PaddingTop = 5;
                                }


                                string t = "";
                                string t2 = "";
                                string t3 = "";
                                string t4 = "";
                                string t5 = "";
                                string t6 = "";
                                string t7 = "";
                                string t8 = "";




                                t = (i + 1).ToString();
                                Paragraph ts = new Paragraph(t);
                                ts.Alignment = Element.ALIGN_CENTER;
                                ts.Font.Size = 7;


                                t2 = lista2[i].Usluga.Trim();
                                Paragraph ts2 = new Paragraph(t2);
                                ts2.Alignment = Element.ALIGN_CENTER;
                                ts2.Font.Size = 7;

                                t3 = lista2[i].Jedmere;
                                Paragraph ts3 = new Paragraph(t3);
                                ts3.Alignment = Element.ALIGN_CENTER;
                                ts3.Font.Size = 7;

                                t4 = lista2[i].Kol;
                                Paragraph ts4 = new Paragraph(t4);
                                ts4.Alignment = Element.ALIGN_CENTER;
                                ts4.Font.Size = 7;

                                t5 = lista2[i].Cena;
                                Paragraph ts5 = new Paragraph(t5);
                                ts5.Alignment = Element.ALIGN_CENTER;
                                ts5.Font.Size = 7;


                                t6 = (double.Parse(lista2[i].Cena) * double.Parse(lista2[i].Kol)).ToString("0.000");
                                Paragraph ts6 = new Paragraph(t6);
                                ts6.Alignment = Element.ALIGN_CENTER;
                                ts6.Font.Size = 7;


                                t7 = ((double.Parse(lista2[i].Cena) * double.Parse(lista2[i].Kol)) * 17 / 100).ToString("0.000");
                                Paragraph ts7 = new Paragraph(t7);
                                ts7.Alignment = Element.ALIGN_CENTER;
                                ts7.Font.Size = 7;


                                t8 = (((double.Parse(lista2[i].Cena) * double.Parse(lista2[i].Kol)) * 17 / 100) + (double.Parse(lista2[i].Cena) * double.Parse(lista2[i].Kol))).ToString("0.000");
                                Paragraph ts8 = new Paragraph(t8);
                                ts8.Alignment = Element.ALIGN_CENTER;
                                ts8.Font.Size = 7;

                                if (i == 0)
                                {
                                    c.AddElement(ts);
                                    c2.AddElement(ts2);
                                    c3.AddElement(ts3);
                                    c4.AddElement(ts4);
                                    c5.AddElement(ts5);
                                    c6.AddElement(ts6);
                                    c7.AddElement(ts7);
                                    c8.AddElement(ts8);
                                }
                                else
                                {


                                    c.Column.SetText(ts);

                                    c2.Column.SetText(ts2);
                                    c3.Column.SetText(ts3);
                                    c4.Column.SetText(ts4);
                                    c5.Column.SetText(ts5);
                                    c6.Column.SetText(ts6);
                                    c7.Column.SetText(ts7);
                                    c8.Column.SetText(ts8);
                                    c.HorizontalAlignment = Element.ALIGN_CENTER;
                                    c2.HorizontalAlignment = Element.ALIGN_CENTER;
                                    c3.HorizontalAlignment = Element.ALIGN_CENTER;
                                    c4.HorizontalAlignment = Element.ALIGN_CENTER;
                                    c5.HorizontalAlignment = Element.ALIGN_CENTER;
                                    c6.HorizontalAlignment = Element.ALIGN_CENTER;
                                    c7.HorizontalAlignment = Element.ALIGN_CENTER;
                                    c8.HorizontalAlignment = Element.ALIGN_CENTER;
                                }

                                s.AddCell(c);
                                s.AddCell(c2);
                                s.AddCell(c3);
                                s.AddCell(c4);
                                s.AddCell(c5);
                                s.AddCell(c6);
                                s.AddCell(c7);
                                s.AddCell(c8);


                            }

                            doc.Add(s);

                            var d = new PdfPTable(2);
                            d.PaddingTop = 100f;
                            var cd = new PdfPCell { PaddingLeft = 5, PaddingTop = 50, PaddingBottom = 5, PaddingRight = 5 };
                            var cd2 = new PdfPCell { PaddingLeft = 5, PaddingTop = 50, PaddingBottom = 5, PaddingRight = 5 };

                            cd.HorizontalAlignment = Element.ALIGN_LEFT;
                            cd.BorderWidth = 0;
                            cd2.BorderWidth = 0;
                            cd2.HorizontalAlignment = Element.ALIGN_RIGHT;
                            string fdt = "Napomena o poreskom oslobađanju: " + KlijentAddUslugeForm.napomena;
                            Paragraph fd = new Paragraph(fdt);
                            fd.Alignment = Element.ALIGN_LEFT;
                            fd.Font.Size = 7;
                            string fdt2 = "Mjesto izvođenja radova: " + KlijentAddUslugeForm.MjestoIzvodjenjaRadva;
                            Paragraph fd2 = new Paragraph(fdt2);
                            fd2.Alignment = Element.ALIGN_LEFT;
                            fd2.Font.Size = 7;
                            string fdt3 = "Datum fakturisanja:" + KlijentAddUslugeForm.datumFakturisanja;
                            Paragraph fd3 = new Paragraph(fdt3);
                            fd3.Alignment = Element.ALIGN_LEFT;
                            fd3.Font.Size = 7;
                            string fdt4 = "Uplatu izvršiti na račun: " + KlijentAddUslugeForm.ZiroRacunUplata;
                            Paragraph fd4 = new Paragraph(fdt4);
                            fd4.Alignment = Element.ALIGN_LEFT;
                            fd4.Font.Size = 7;
                            string fdt5 = "Način plaćanja: " + KlijentAddUslugeForm.NacinPlacanja;
                            Paragraph fd5 = new Paragraph(fdt5);
                            fd5.Alignment = Element.ALIGN_LEFT;
                            fd5.Font.Size = 7;
                            string fdt6 = "Valuta plaćanja: " + KlijentAddUslugeForm.valutaPlacanjaa;
                            Paragraph fd6 = new Paragraph(fdt6);
                            fd6.Alignment = Element.ALIGN_LEFT;
                            fd6.Font.Size = 7;
                            string fdt7 = "Broj fiskalnog računa: " + KlijentAddUslugeForm.brojFiskalnogRacuna;
                            Paragraph fd7 = new Paragraph(fdt7);
                            fd7.Alignment = Element.ALIGN_LEFT;
                            fd7.Font.Size = 7;


                            string ty = "Ukupno bez PDV-a: " + sumabezPDV.ToString();
                            Paragraph tyt = new Paragraph(ty);
                            tyt.Alignment = Element.ALIGN_RIGHT;
                            tyt.Font.Size = 9;
                            string ty2 = "PDV 17%: " + PDV.ToString();
                            Paragraph tyt2 = new Paragraph(ty2);
                            tyt2.Alignment = Element.ALIGN_RIGHT;
                            tyt2.Font.Size = 9;
                            string ty3 = "Ukupno sa PDV-om: " + sumasaPDV.ToString();
                            Paragraph tyt3 = new Paragraph(ty3);
                            tyt3.Alignment = Element.ALIGN_RIGHT;
                            tyt3.Font.Size = 9;

                            string ty4 = "Slovima: " + slovimaBroj;
                            Paragraph tyt4 = new Paragraph(ty4);
                            tyt4.Alignment = Element.ALIGN_RIGHT;
                            tyt4.Font.Size = 9;



                            cd.AddElement(fd);
                            cd.AddElement(fd2);
                            cd.AddElement(fd3);
                            cd.AddElement(fd4);
                            cd.AddElement(fd5);
                            cd.AddElement(fd6);
                            cd.AddElement(fd7);
                            cd2.AddElement(tyt);
                            cd2.AddElement(tyt2);
                            cd2.AddElement(tyt3);
                            cd2.AddElement(tyt4);

                            d.AddCell(cd);
                            d.AddCell(cd2);
                            doc.Add(d);


                            var d2 = new PdfPTable(2);
                            d2.PaddingTop = 100f;
                            d2.SetWidths(new float[] { 120f, 120f });
                            var cdd = new PdfPCell { PaddingLeft = 5, PaddingTop = 10, PaddingBottom = 5, PaddingRight = 110 };
                            var cdd2 = new PdfPCell { PaddingLeft = 110, PaddingTop = 10, PaddingBottom = 5, PaddingRight = 5 };

                            cdd.HorizontalAlignment = Element.ALIGN_LEFT;
                            cdd.BorderWidth = 0;
                            cdd2.BorderWidth = 0;
                            cdd2.HorizontalAlignment = Element.ALIGN_RIGHT;
                            string fdtd = "Za investitora \n\n\n __________________";
                            Paragraph fdd = new Paragraph(fdtd);
                            fdd.Alignment = Element.ALIGN_CENTER;
                            fdd.Font.Size = 9;
                            string fdtd2 = "Direktor \n\n\n __________________";
                            Paragraph fdd2 = new Paragraph(fdtd2);
                            fdd2.Alignment = Element.ALIGN_CENTER;
                            fdd2.Font.Size = 9;

                            cdd.AddElement(fdd);
                            cdd2.AddElement(fdd2);

                            d2.AddCell(cdd);
                            d2.AddCell(cdd2);

                            doc.Add(d2);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }
    }
}

