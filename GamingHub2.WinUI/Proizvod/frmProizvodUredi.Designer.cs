
namespace GamingHub2.WinUI.Proizvod
{
    partial class frmProizvodUredi
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
            this.chbStatus = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.numPopust = new System.Windows.Forms.NumericUpDown();
            this.numCijena = new System.Windows.Forms.NumericUpDown();
            this.txtNazivProizvoda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPopust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCijena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbStatus);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.numPopust);
            this.groupBox1.Controls.Add(this.numCijena);
            this.groupBox1.Controls.Add(this.txtNazivProizvoda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uredjivanje proizvoda";
            // 
            // chbStatus
            // 
            this.chbStatus.AutoSize = true;
            this.chbStatus.Checked = true;
            this.chbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbStatus.Location = new System.Drawing.Point(24, 198);
            this.chbStatus.Name = "chbStatus";
            this.chbStatus.Size = new System.Drawing.Size(62, 17);
            this.chbStatus.TabIndex = 56;
            this.chbStatus.Text = "Aktivan";
            this.chbStatus.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(130, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numPopust
            // 
            this.numPopust.DecimalPlaces = 2;
            this.numPopust.Location = new System.Drawing.Point(21, 147);
            this.numPopust.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPopust.Name = "numPopust";
            this.numPopust.Size = new System.Drawing.Size(195, 20);
            this.numPopust.TabIndex = 54;
            this.numPopust.Validating += new System.ComponentModel.CancelEventHandler(this.numPopust_Validating);
            // 
            // numCijena
            // 
            this.numCijena.DecimalPlaces = 2;
            this.numCijena.Location = new System.Drawing.Point(21, 94);
            this.numCijena.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCijena.Name = "numCijena";
            this.numCijena.Size = new System.Drawing.Size(195, 20);
            this.numCijena.TabIndex = 53;
            this.numCijena.Validating += new System.ComponentModel.CancelEventHandler(this.numCijena_Validating);
            // 
            // txtNazivProizvoda
            // 
            this.txtNazivProizvoda.Location = new System.Drawing.Point(21, 47);
            this.txtNazivProizvoda.Name = "txtNazivProizvoda";
            this.txtNazivProizvoda.ReadOnly = true;
            this.txtNazivProizvoda.Size = new System.Drawing.Size(198, 20);
            this.txtNazivProizvoda.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Popust";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Cijena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Naziv";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmProizvodUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 293);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProizvodUredi";
            this.Text = "frmProizvodUredi";
            this.Load += new System.EventHandler(this.frmProizvodUredi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPopust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCijena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNazivProizvoda;
        private System.Windows.Forms.NumericUpDown numPopust;
        private System.Windows.Forms.NumericUpDown numCijena;
        private System.Windows.Forms.CheckBox chbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}