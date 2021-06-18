﻿
namespace GamingHub2.WinUI
{
    partial class frmPocetna
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikazKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zanroviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikazZanrovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajUrediZanrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.igreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaIgraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisnikToolStripMenuItem,
            this.zanroviToolStripMenuItem,
            this.igreToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisnikToolStripMenuItem
            // 
            this.korisnikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prikazKorisnikaToolStripMenuItem,
            this.noviKorisnikToolStripMenuItem});
            this.korisnikToolStripMenuItem.Name = "korisnikToolStripMenuItem";
            this.korisnikToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.korisnikToolStripMenuItem.Text = "Korisnici";
            // 
            // prikazKorisnikaToolStripMenuItem
            // 
            this.prikazKorisnikaToolStripMenuItem.Name = "prikazKorisnikaToolStripMenuItem";
            this.prikazKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.prikazKorisnikaToolStripMenuItem.Text = "Prikaz korisnika";
            this.prikazKorisnikaToolStripMenuItem.Click += new System.EventHandler(this.prikazKorisnikaToolStripMenuItem_Click);
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // zanroviToolStripMenuItem
            // 
            this.zanroviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prikazZanrovaToolStripMenuItem,
            this.dodajUrediZanrToolStripMenuItem});
            this.zanroviToolStripMenuItem.Name = "zanroviToolStripMenuItem";
            this.zanroviToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.zanroviToolStripMenuItem.Text = "Zanrovi";
            // 
            // prikazZanrovaToolStripMenuItem
            // 
            this.prikazZanrovaToolStripMenuItem.Name = "prikazZanrovaToolStripMenuItem";
            this.prikazZanrovaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.prikazZanrovaToolStripMenuItem.Text = "Prikaz zanrova";
            this.prikazZanrovaToolStripMenuItem.Click += new System.EventHandler(this.prikazZanrovaToolStripMenuItem_Click);
            // 
            // dodajUrediZanrToolStripMenuItem
            // 
            this.dodajUrediZanrToolStripMenuItem.Name = "dodajUrediZanrToolStripMenuItem";
            this.dodajUrediZanrToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.dodajUrediZanrToolStripMenuItem.Text = "Dodaj/Uredi zanr";
            this.dodajUrediZanrToolStripMenuItem.Click += new System.EventHandler(this.dodajUrediZanrToolStripMenuItem_Click);
            // 
            // igreToolStripMenuItem
            // 
            this.igreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prikaToolStripMenuItem,
            this.novaIgraToolStripMenuItem});
            this.igreToolStripMenuItem.Name = "igreToolStripMenuItem";
            this.igreToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.igreToolStripMenuItem.Text = "Igre";
            // 
            // prikaToolStripMenuItem
            // 
            this.prikaToolStripMenuItem.Name = "prikaToolStripMenuItem";
            this.prikaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.prikaToolStripMenuItem.Text = "Prikaz igara";
            this.prikaToolStripMenuItem.Click += new System.EventHandler(this.prikaToolStripMenuItem_Click);
            // 
            // novaIgraToolStripMenuItem
            // 
            this.novaIgraToolStripMenuItem.Name = "novaIgraToolStripMenuItem";
            this.novaIgraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.novaIgraToolStripMenuItem.Text = "Nova igra";
            this.novaIgraToolStripMenuItem.Click += new System.EventHandler(this.novaIgraToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 410);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmPocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 432);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmPocetna";
            this.Text = "frmPocetna";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem korisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikazKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zanroviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikazZanrovaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem igreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaIgraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajUrediZanrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikaToolStripMenuItem;
    }
}



