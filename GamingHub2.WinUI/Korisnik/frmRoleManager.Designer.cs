
namespace GamingHub2.WinUI.Korisnik
{
    partial class frmRoleManager
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUloge = new System.Windows.Forms.DataGridView();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.btnDodajUlogu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUloge)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodajUlogu);
            this.groupBox1.Controls.Add(this.txtNaziv);
            this.groupBox1.Location = new System.Drawing.Point(40, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Role Manager";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUloge);
            this.groupBox2.Location = new System.Drawing.Point(40, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 188);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uloge";
            // 
            // dgvUloge
            // 
            this.dgvUloge.AllowUserToAddRows = false;
            this.dgvUloge.AllowUserToDeleteRows = false;
            this.dgvUloge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUloge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUloge.Location = new System.Drawing.Point(3, 16);
            this.dgvUloge.Name = "dgvUloge";
            this.dgvUloge.ReadOnly = true;
            this.dgvUloge.Size = new System.Drawing.Size(501, 169);
            this.dgvUloge.TabIndex = 0;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(33, 37);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(181, 20);
            this.txtNaziv.TabIndex = 0;
            // 
            // btnDodajUlogu
            // 
            this.btnDodajUlogu.Location = new System.Drawing.Point(367, 37);
            this.btnDodajUlogu.Name = "btnDodajUlogu";
            this.btnDodajUlogu.Size = new System.Drawing.Size(75, 23);
            this.btnDodajUlogu.TabIndex = 1;
            this.btnDodajUlogu.Text = "Dodaj ulogu";
            this.btnDodajUlogu.UseVisualStyleBackColor = true;
            // 
            // frmRoleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRoleManager";
            this.Text = "frmRoleManager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUloge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUloge;
        private System.Windows.Forms.Button btnDodajUlogu;
        private System.Windows.Forms.TextBox txtNaziv;
    }
}