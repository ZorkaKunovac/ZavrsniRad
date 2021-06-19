
namespace GamingHub2.WinUI.Igra
{
    partial class frmIgraDodajUredi
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbZanrovi = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clbKonzole = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSlika = new System.Windows.Forms.TextBox();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDatumIzlaska = new System.Windows.Forms.DateTimePicker();
            this.txtVideoLink = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIzdavac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeveloper = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbZanrovi);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.clbKonzole);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSlika);
            this.groupBox1.Controls.Add(this.btnAddPicture);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.pbSlika);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpDatumIzlaska);
            this.groupBox1.Controls.Add(this.txtVideoLink);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIzdavac);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDeveloper);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNaziv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 406);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dodavanje/uredjivanje igara";
            // 
            // clbZanrovi
            // 
            this.clbZanrovi.FormattingEnabled = true;
            this.clbZanrovi.Location = new System.Drawing.Point(104, 291);
            this.clbZanrovi.Name = "clbZanrovi";
            this.clbZanrovi.Size = new System.Drawing.Size(175, 94);
            this.clbZanrovi.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Zanrovi:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Konzole:";
            // 
            // clbKonzole
            // 
            this.clbKonzole.FormattingEnabled = true;
            this.clbKonzole.Location = new System.Drawing.Point(104, 204);
            this.clbKonzole.Name = "clbKonzole";
            this.clbKonzole.Size = new System.Drawing.Size(175, 79);
            this.clbKonzole.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Slika";
            // 
            // txtSlika
            // 
            this.txtSlika.Location = new System.Drawing.Point(104, 175);
            this.txtSlika.Name = "txtSlika";
            this.txtSlika.Size = new System.Drawing.Size(175, 20);
            this.txtSlika.TabIndex = 13;
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(320, 173);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(141, 23);
            this.btnAddPicture.TabIndex = 12;
            this.btnAddPicture.Text = "Dodaj sliku";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(372, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 33);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbSlika
            // 
            this.pbSlika.Location = new System.Drawing.Point(320, 31);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(141, 135);
            this.pbSlika.TabIndex = 10;
            this.pbSlika.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Video Link";
            // 
            // dtpDatumIzlaska
            // 
            this.dtpDatumIzlaska.Location = new System.Drawing.Point(104, 117);
            this.dtpDatumIzlaska.Name = "dtpDatumIzlaska";
            this.dtpDatumIzlaska.Size = new System.Drawing.Size(175, 20);
            this.dtpDatumIzlaska.TabIndex = 8;
            // 
            // txtVideoLink
            // 
            this.txtVideoLink.Location = new System.Drawing.Point(104, 146);
            this.txtVideoLink.Name = "txtVideoLink";
            this.txtVideoLink.Size = new System.Drawing.Size(175, 20);
            this.txtVideoLink.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Datum izlaska";
            // 
            // txtIzdavac
            // 
            this.txtIzdavac.Location = new System.Drawing.Point(104, 90);
            this.txtIzdavac.Name = "txtIzdavac";
            this.txtIzdavac.Size = new System.Drawing.Size(175, 20);
            this.txtIzdavac.TabIndex = 5;
            this.txtIzdavac.Validating += new System.ComponentModel.CancelEventHandler(this.txtIzdavac_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Izdavac";
            // 
            // txtDeveloper
            // 
            this.txtDeveloper.Location = new System.Drawing.Point(104, 62);
            this.txtDeveloper.Name = "txtDeveloper";
            this.txtDeveloper.Size = new System.Drawing.Size(175, 20);
            this.txtDeveloper.TabIndex = 3;
            this.txtDeveloper.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeveloper_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Developer";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(104, 35);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(175, 20);
            this.txtNaziv.TabIndex = 1;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // frmIgraDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 444);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmIgraDodajUredi";
            this.Text = "frmIgraDodajUredi";
            this.Load += new System.EventHandler(this.frmIgraDodajUredi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clbZanrovi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox clbKonzole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSlika;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDatumIzlaska;
        private System.Windows.Forms.TextBox txtVideoLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIzdavac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeveloper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}