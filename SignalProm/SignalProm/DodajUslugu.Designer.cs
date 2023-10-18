
namespace SignalProm
{
    partial class DodajUslugu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.prikazUsluge = new System.Windows.Forms.DataGridView();
            this.btnDodajUsluguBtn = new System.Windows.Forms.Button();
            this.Ime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UslugaNaziv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.prikazUsluge)).BeginInit();
            this.SuspendLayout();
            // 
            // prikazUsluge
            // 
            this.prikazUsluge.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.prikazUsluge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prikazUsluge.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.prikazUsluge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.prikazUsluge.DefaultCellStyle = dataGridViewCellStyle2;
            this.prikazUsluge.Location = new System.Drawing.Point(134, 81);
            this.prikazUsluge.Name = "prikazUsluge";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prikazUsluge.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.prikazUsluge.RowHeadersVisible = false;
            this.prikazUsluge.Size = new System.Drawing.Size(597, 208);
            this.prikazUsluge.TabIndex = 30;
            this.prikazUsluge.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.prikazUsluge_CellContentClick);
            // 
            // btnDodajUsluguBtn
            // 
            this.btnDodajUsluguBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDodajUsluguBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodajUsluguBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajUsluguBtn.ForeColor = System.Drawing.Color.White;
            this.btnDodajUsluguBtn.Location = new System.Drawing.Point(648, 484);
            this.btnDodajUsluguBtn.Name = "btnDodajUsluguBtn";
            this.btnDodajUsluguBtn.Size = new System.Drawing.Size(83, 38);
            this.btnDodajUsluguBtn.TabIndex = 29;
            this.btnDodajUsluguBtn.Text = "Dodaj";
            this.btnDodajUsluguBtn.UseVisualStyleBackColor = false;
            this.btnDodajUsluguBtn.Click += new System.EventHandler(this.btnDodajUsluguBtn_Click);
            // 
            // Ime
            // 
            this.Ime.AutoSize = true;
            this.Ime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ime.Location = new System.Drawing.Point(130, 339);
            this.Ime.Name = "Ime";
            this.Ime.Size = new System.Drawing.Size(98, 20);
            this.Ime.TabIndex = 23;
            this.Ime.Text = "Naziv usluge";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "Dodaj novu uslugu";
            // 
            // UslugaNaziv
            // 
            this.UslugaNaziv.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.UslugaNaziv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UslugaNaziv.Location = new System.Drawing.Point(134, 373);
            this.UslugaNaziv.Multiline = true;
            this.UslugaNaziv.Name = "UslugaNaziv";
            this.UslugaNaziv.Size = new System.Drawing.Size(597, 91);
            this.UslugaNaziv.TabIndex = 16;
            // 
            // DodajUslugu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(860, 604);
            this.Controls.Add(this.prikazUsluge);
            this.Controls.Add(this.btnDodajUsluguBtn);
            this.Controls.Add(this.Ime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UslugaNaziv);
            this.Name = "DodajUslugu";
            this.Text = "DodajUslugu";
            this.Load += new System.EventHandler(this.DodajUslugu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prikazUsluge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView prikazUsluge;
        private System.Windows.Forms.Button btnDodajUsluguBtn;
        private System.Windows.Forms.Label Ime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UslugaNaziv;
    }
}