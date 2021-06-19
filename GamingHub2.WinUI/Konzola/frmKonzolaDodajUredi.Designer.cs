
namespace GamingHub2.WinUI.Konzola
{
    partial class frmKonzolaDodajUredi
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
            this.btnSnimi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbDetalji = new System.Windows.Forms.RichTextBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(162, 219);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(64, 20);
            this.btnSnimi.TabIndex = 10;
            this.btnSnimi.TabStop = false;
            this.btnSnimi.Text = "Snimi";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Detalji";
            // 
            // rtbDetalji
            // 
            this.rtbDetalji.Location = new System.Drawing.Point(49, 105);
            this.rtbDetalji.Name = "rtbDetalji";
            this.rtbDetalji.Size = new System.Drawing.Size(179, 84);
            this.rtbDetalji.TabIndex = 8;
            this.rtbDetalji.Text = "";
            this.rtbDetalji.Validating += new System.ComponentModel.CancelEventHandler(this.rtbDetalji_Validating);
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(49, 50);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(179, 20);
            this.txtNaziv.TabIndex = 7;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Naziv";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmKonzolaDodajUredi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 267);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbDetalji);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.label1);
            this.Name = "frmKonzolaDodajUredi";
            this.Text = "frmKonzolaDodajUredi";
            this.Load += new System.EventHandler(this.frmKonzolaDodajUredi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbDetalji;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}