
namespace GamingHub2.WinUI.Recenzija
{
    partial class frmPrikazRecenzija
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
            this.cmbKorisnici = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNaslov = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.cmbIgre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRecenzije = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naslov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Igra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumObjave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sadrzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slika = new System.Windows.Forms.DataGridViewImageColumn();
            this.VideoRecenzija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecenzije)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKorisnici
            // 
            this.cmbKorisnici.FormattingEnabled = true;
            this.cmbKorisnici.Location = new System.Drawing.Point(369, 45);
            this.cmbKorisnici.Name = "cmbKorisnici";
            this.cmbKorisnici.Size = new System.Drawing.Size(183, 21);
            this.cmbKorisnici.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Korisnik";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Naslov";
            // 
            // txtNaslov
            // 
            this.txtNaslov.Location = new System.Drawing.Point(6, 46);
            this.txtNaslov.Name = "txtNaslov";
            this.txtNaslov.Size = new System.Drawing.Size(299, 20);
            this.txtNaslov.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrikazi);
            this.groupBox1.Controls.Add(this.cmbIgre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNaslov);
            this.groupBox1.Controls.Add(this.cmbKorisnici);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(977, 100);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga";
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(881, 43);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(75, 23);
            this.btnPrikazi.TabIndex = 39;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // cmbIgre
            // 
            this.cmbIgre.FormattingEnabled = true;
            this.cmbIgre.Location = new System.Drawing.Point(618, 46);
            this.cmbIgre.Name = "cmbIgre";
            this.cmbIgre.Size = new System.Drawing.Size(187, 21);
            this.cmbIgre.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Igra";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRecenzije);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(980, 276);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recenzije";
            // 
            // dgvRecenzije
            // 
            this.dgvRecenzije.AllowUserToAddRows = false;
            this.dgvRecenzije.AllowUserToDeleteRows = false;
            this.dgvRecenzije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecenzije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecenzije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Korisnik,
            this.Naslov,
            this.Igra,
            this.DatumObjave,
            this.Sadrzaj,
            this.Slika,
            this.VideoRecenzija});
            this.dgvRecenzije.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecenzije.Location = new System.Drawing.Point(3, 16);
            this.dgvRecenzije.Name = "dgvRecenzije";
            this.dgvRecenzije.ReadOnly = true;
            this.dgvRecenzije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecenzije.Size = new System.Drawing.Size(974, 257);
            this.dgvRecenzije.TabIndex = 0;
            this.dgvRecenzije.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRecenzije_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "KorisnikNaziv";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            // 
            // Naslov
            // 
            this.Naslov.DataPropertyName = "Naslov";
            this.Naslov.HeaderText = "Naslov";
            this.Naslov.Name = "Naslov";
            this.Naslov.ReadOnly = true;
            // 
            // Igra
            // 
            this.Igra.DataPropertyName = "IgraNaziv";
            this.Igra.HeaderText = "Igra";
            this.Igra.Name = "Igra";
            this.Igra.ReadOnly = true;
            // 
            // DatumObjave
            // 
            this.DatumObjave.DataPropertyName = "DatumObjave";
            this.DatumObjave.HeaderText = "DatumObjave";
            this.DatumObjave.Name = "DatumObjave";
            this.DatumObjave.ReadOnly = true;
            // 
            // Sadrzaj
            // 
            this.Sadrzaj.DataPropertyName = "Sadrzaj";
            this.Sadrzaj.HeaderText = "Sadrzaj";
            this.Sadrzaj.Name = "Sadrzaj";
            this.Sadrzaj.ReadOnly = true;
            // 
            // Slika
            // 
            this.Slika.DataPropertyName = "Slika";
            this.Slika.HeaderText = "Slika";
            this.Slika.Name = "Slika";
            this.Slika.ReadOnly = true;
            // 
            // VideoRecenzija
            // 
            this.VideoRecenzija.DataPropertyName = "VideoRecenzija";
            this.VideoRecenzija.HeaderText = "VideoRecenzija";
            this.VideoRecenzija.Name = "VideoRecenzija";
            this.VideoRecenzija.ReadOnly = true;
            // 
            // frmPrikazRecenzija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrikazRecenzija";
            this.Text = "frmPrikazRecenzija";
            this.Load += new System.EventHandler(this.frmPrikazRecenzija_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecenzije)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKorisnici;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNaslov;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbIgre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRecenzije;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naslov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Igra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumObjave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sadrzaj;
        private System.Windows.Forms.DataGridViewImageColumn Slika;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoRecenzija;
    }
}