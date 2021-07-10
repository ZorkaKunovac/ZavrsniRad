
namespace GamingHub2.WinUI.Izvjestaj
{
    partial class frmIzvjestaj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIzvjestaj));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatumOd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPotvrdiDatum = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPrintaj = new System.Windows.Forms.Button();
            this.dtpDatumDo = new System.Windows.Forms.DateTimePicker();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.BrojNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unesite zeljeni period:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum od:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum do:";
            // 
            // dtpDatumOd
            // 
            this.dtpDatumOd.Location = new System.Drawing.Point(27, 84);
            this.dtpDatumOd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDatumOd.Name = "dtpDatumOd";
            this.dtpDatumOd.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumOd.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPotvrdiDatum);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnPrintaj);
            this.groupBox1.Controls.Add(this.dtpDatumDo);
            this.groupBox1.Controls.Add(this.dtpDatumOd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(31, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 404);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Izvjestaj";
            // 
            // btnPotvrdiDatum
            // 
            this.btnPotvrdiDatum.Location = new System.Drawing.Point(128, 187);
            this.btnPotvrdiDatum.Name = "btnPotvrdiDatum";
            this.btnPotvrdiDatum.Size = new System.Drawing.Size(99, 23);
            this.btnPotvrdiDatum.TabIndex = 7;
            this.btnPotvrdiDatum.Text = "Potvrdi datum";
            this.btnPotvrdiDatum.UseVisualStyleBackColor = true;
            this.btnPotvrdiDatum.Click += new System.EventHandler(this.btnProizvodi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(301, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 360);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista narudzbi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrojNarudzbe,
            this.Datum,
            this.Iznos});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(410, 341);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnPrintaj
            // 
            this.btnPrintaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintaj.Location = new System.Drawing.Point(142, 332);
            this.btnPrintaj.Name = "btnPrintaj";
            this.btnPrintaj.Size = new System.Drawing.Size(85, 30);
            this.btnPrintaj.TabIndex = 5;
            this.btnPrintaj.Text = "Printaj";
            this.btnPrintaj.UseVisualStyleBackColor = true;
            this.btnPrintaj.Click += new System.EventHandler(this.btnPrintaj_Click);
            // 
            // dtpDatumDo
            // 
            this.dtpDatumDo.Location = new System.Drawing.Point(27, 139);
            this.dtpDatumDo.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpDatumDo.Name = "dtpDatumDo";
            this.dtpDatumDo.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumDo.TabIndex = 4;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // BrojNarudzbe
            // 
            this.BrojNarudzbe.DataPropertyName = "BrojNarudzbe";
            this.BrojNarudzbe.HeaderText = "Broj narudžbe";
            this.BrojNarudzbe.Name = "BrojNarudzbe";
            this.BrojNarudzbe.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "IznosStr";
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // frmIzvjestaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmIzvjestaj";
            this.Text = "frmIzvjestaj";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatumOd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDatumDo;
        private System.Windows.Forms.Button btnPrintaj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Button btnPotvrdiDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
    }
}