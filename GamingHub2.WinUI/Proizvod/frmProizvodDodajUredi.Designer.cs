
namespace GamingHub2.WinUI.Proizvod
{
    partial class frmProizvodDodajUredi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIgraKonzola = new System.Windows.Forms.ComboBox();
            this.numCijena = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPopust = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chbStatus = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopust)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbStatus);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numPopust);
            this.groupBox1.Controls.Add(this.numCijena);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbIgraKonzola);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 253);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proizvodi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Naziv";
            // 
            // cmbIgraKonzola
            // 
            this.cmbIgraKonzola.FormattingEnabled = true;
            this.cmbIgraKonzola.Location = new System.Drawing.Point(22, 48);
            this.cmbIgraKonzola.Name = "cmbIgraKonzola";
            this.cmbIgraKonzola.Size = new System.Drawing.Size(195, 21);
            this.cmbIgraKonzola.TabIndex = 41;
            // 
            // numCijena
            // 
            this.numCijena.DecimalPlaces = 2;
            this.numCijena.Location = new System.Drawing.Point(22, 100);
            this.numCijena.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCijena.Name = "numCijena";
            this.numCijena.Size = new System.Drawing.Size(195, 20);
            this.numCijena.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Cijena";
            // 
            // numPopust
            // 
            this.numPopust.DecimalPlaces = 2;
            this.numPopust.Location = new System.Drawing.Point(22, 152);
            this.numPopust.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPopust.Name = "numPopust";
            this.numPopust.Size = new System.Drawing.Size(195, 20);
            this.numPopust.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Popust";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(128, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chbStatus
            // 
            this.chbStatus.AutoSize = true;
            this.chbStatus.Checked = true;
            this.chbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbStatus.Location = new System.Drawing.Point(22, 190);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.Size = new System.Drawing.Size(62, 17);
            this.chbStatus.TabIndex = 52;
            this.chbStatus.Text = "Aktivan";
            this.chbStatus.UseVisualStyleBackColor = true;
            // 
            // frmProizvodDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 303);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProizvodDodajUredi";
            this.Text = "frmProizvodDodajUredi";
            this.Load += new System.EventHandler(this.frmProizvodDodajUredi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopust)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPopust;
        private System.Windows.Forms.NumericUpDown numCijena;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIgraKonzola;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chbStatus;
    }
}