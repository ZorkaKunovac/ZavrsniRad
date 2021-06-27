
namespace GamingHub2.WinUI.Konzola
{
    partial class frmPrikazKonzola
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
            this.dgvKonzole = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodajKonzolu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKonzole)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKonzole);
            this.groupBox1.Location = new System.Drawing.Point(11, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 206);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Konzole";
            // 
            // dgvKonzole
            // 
            this.dgvKonzole.AllowUserToAddRows = false;
            this.dgvKonzole.AllowUserToDeleteRows = false;
            this.dgvKonzole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKonzole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKonzole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Naziv,
            this.Detalji});
            this.dgvKonzole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKonzole.Location = new System.Drawing.Point(3, 16);
            this.dgvKonzole.Name = "dgvKonzole";
            this.dgvKonzole.ReadOnly = true;
            this.dgvKonzole.RowTemplate.Height = 25;
            this.dgvKonzole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKonzole.Size = new System.Drawing.Size(386, 187);
            this.dgvKonzole.TabIndex = 0;
            this.dgvKonzole.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKonzole_MouseDoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.DataPropertyName = "Detalji";
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            // 
            // btnDodajKonzolu
            // 
            this.btnDodajKonzolu.Location = new System.Drawing.Point(289, 26);
            this.btnDodajKonzolu.Name = "btnDodajKonzolu";
            this.btnDodajKonzolu.Size = new System.Drawing.Size(99, 23);
            this.btnDodajKonzolu.TabIndex = 5;
            this.btnDodajKonzolu.Text = "Dodaj konzolu";
            this.btnDodajKonzolu.UseVisualStyleBackColor = true;
            this.btnDodajKonzolu.Click += new System.EventHandler(this.btnDodajKonzolu_Click);
            // 
            // frmPrikazKonzola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 299);
            this.Controls.Add(this.btnDodajKonzolu);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPrikazKonzola";
            this.Text = "frmPrikazKonzola";
            this.Load += new System.EventHandler(this.frmPrikazKonzola_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKonzole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKonzole;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalji;
        private System.Windows.Forms.Button btnDodajKonzolu;
    }
}