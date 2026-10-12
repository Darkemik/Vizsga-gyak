namespace KonyvtarGUI
{
    // =====================================================================
    // EZT A FÁJLT A DESIGNER ÍRJA, amikor az ablakot rajzolod. Kézzel NEM kell írni!
    //
    // A vezérlők nevei ((Name) a Properties ablakban):
    //   lblValasztek   Label      fent: "VÁLASSZON 5 MŰFAJ 20 KÖNYVE KÖZÜL!" (Font: félkövér)
    //   cbMufaj        ComboBox   műfaj választó (DropDownStyle = DropDownList)
    //   lbKonyvek      ListBox    a könyvek (a kiválasztott műfaj szerint)
    //   grpReszletek   GroupBox   "A kiválasztott könyv" keret, benne:
    //     lblCim, lblSzerzo, lblMufaj, lblKiadas, lblOldal, lblAllapot   Label (az értékek)
    //   btnKolcsonzes  Button     "Kölcsönzés"
    //   btnKilepes     Button     "Kilépés"
    // =====================================================================
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblValasztek = new System.Windows.Forms.Label();
            this.lblMufajCim = new System.Windows.Forms.Label();
            this.cbMufaj = new System.Windows.Forms.ComboBox();
            this.lbKonyvek = new System.Windows.Forms.ListBox();
            this.grpReszletek = new System.Windows.Forms.GroupBox();
            this.lblCimCim = new System.Windows.Forms.Label();
            this.lblCim = new System.Windows.Forms.Label();
            this.lblSzerzoCim = new System.Windows.Forms.Label();
            this.lblSzerzo = new System.Windows.Forms.Label();
            this.lblMufajCim2 = new System.Windows.Forms.Label();
            this.lblMufaj = new System.Windows.Forms.Label();
            this.lblKiadasCim = new System.Windows.Forms.Label();
            this.lblKiadas = new System.Windows.Forms.Label();
            this.lblOldalCim = new System.Windows.Forms.Label();
            this.lblOldal = new System.Windows.Forms.Label();
            this.lblAllapotCim = new System.Windows.Forms.Label();
            this.lblAllapot = new System.Windows.Forms.Label();
            this.btnKolcsonzes = new System.Windows.Forms.Button();
            this.btnKilepes = new System.Windows.Forms.Button();
            this.grpReszletek.SuspendLayout();
            this.SuspendLayout();
            //
            // lblValasztek
            //
            this.lblValasztek.AutoSize = true;
            this.lblValasztek.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblValasztek.Location = new System.Drawing.Point(12, 10);
            this.lblValasztek.Name = "lblValasztek";
            this.lblValasztek.Text = "VÁLASSZON!";
            //
            // lblMufajCim
            //
            this.lblMufajCim.AutoSize = true;
            this.lblMufajCim.Location = new System.Drawing.Point(12, 48);
            this.lblMufajCim.Name = "lblMufajCim";
            this.lblMufajCim.Text = "Műfaj:";
            //
            // cbMufaj
            //
            this.cbMufaj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMufaj.FormattingEnabled = true;
            this.cbMufaj.Location = new System.Drawing.Point(70, 45);
            this.cbMufaj.Name = "cbMufaj";
            this.cbMufaj.Size = new System.Drawing.Size(200, 23);
            this.cbMufaj.TabIndex = 0;
            //
            // lbKonyvek
            //
            this.lbKonyvek.FormattingEnabled = true;
            this.lbKonyvek.ItemHeight = 15;
            this.lbKonyvek.Location = new System.Drawing.Point(12, 80);
            this.lbKonyvek.Name = "lbKonyvek";
            this.lbKonyvek.Size = new System.Drawing.Size(330, 289);
            this.lbKonyvek.TabIndex = 1;
            //
            // grpReszletek
            //
            this.grpReszletek.Controls.Add(this.lblCimCim);
            this.grpReszletek.Controls.Add(this.lblCim);
            this.grpReszletek.Controls.Add(this.lblSzerzoCim);
            this.grpReszletek.Controls.Add(this.lblSzerzo);
            this.grpReszletek.Controls.Add(this.lblMufajCim2);
            this.grpReszletek.Controls.Add(this.lblMufaj);
            this.grpReszletek.Controls.Add(this.lblKiadasCim);
            this.grpReszletek.Controls.Add(this.lblKiadas);
            this.grpReszletek.Controls.Add(this.lblOldalCim);
            this.grpReszletek.Controls.Add(this.lblOldal);
            this.grpReszletek.Controls.Add(this.lblAllapotCim);
            this.grpReszletek.Controls.Add(this.lblAllapot);
            this.grpReszletek.Location = new System.Drawing.Point(360, 75);
            this.grpReszletek.Name = "grpReszletek";
            this.grpReszletek.Size = new System.Drawing.Size(360, 210);
            this.grpReszletek.TabIndex = 2;
            this.grpReszletek.TabStop = false;
            this.grpReszletek.Text = "A kiválasztott könyv";
            //
            // lblCimCim
            //
            this.lblCimCim.AutoSize = true;
            this.lblCimCim.Location = new System.Drawing.Point(15, 30);
            this.lblCimCim.Name = "lblCimCim";
            this.lblCimCim.Text = "Cím:";
            //
            // lblCim
            //
            this.lblCim.AutoSize = true;
            this.lblCim.Location = new System.Drawing.Point(110, 30);
            this.lblCim.Name = "lblCim";
            this.lblCim.Text = "-";
            //
            // lblSzerzoCim
            //
            this.lblSzerzoCim.AutoSize = true;
            this.lblSzerzoCim.Location = new System.Drawing.Point(15, 58);
            this.lblSzerzoCim.Name = "lblSzerzoCim";
            this.lblSzerzoCim.Text = "Szerző:";
            //
            // lblSzerzo
            //
            this.lblSzerzo.AutoSize = true;
            this.lblSzerzo.Location = new System.Drawing.Point(110, 58);
            this.lblSzerzo.Name = "lblSzerzo";
            this.lblSzerzo.Text = "-";
            //
            // lblMufajCim2
            //
            this.lblMufajCim2.AutoSize = true;
            this.lblMufajCim2.Location = new System.Drawing.Point(15, 86);
            this.lblMufajCim2.Name = "lblMufajCim2";
            this.lblMufajCim2.Text = "Műfaj:";
            //
            // lblMufaj
            //
            this.lblMufaj.AutoSize = true;
            this.lblMufaj.Location = new System.Drawing.Point(110, 86);
            this.lblMufaj.Name = "lblMufaj";
            this.lblMufaj.Text = "-";
            //
            // lblKiadasCim
            //
            this.lblKiadasCim.AutoSize = true;
            this.lblKiadasCim.Location = new System.Drawing.Point(15, 114);
            this.lblKiadasCim.Name = "lblKiadasCim";
            this.lblKiadasCim.Text = "Kiadás éve:";
            //
            // lblKiadas
            //
            this.lblKiadas.AutoSize = true;
            this.lblKiadas.Location = new System.Drawing.Point(110, 114);
            this.lblKiadas.Name = "lblKiadas";
            this.lblKiadas.Text = "-";
            //
            // lblOldalCim
            //
            this.lblOldalCim.AutoSize = true;
            this.lblOldalCim.Location = new System.Drawing.Point(15, 142);
            this.lblOldalCim.Name = "lblOldalCim";
            this.lblOldalCim.Text = "Oldalszám:";
            //
            // lblOldal
            //
            this.lblOldal.AutoSize = true;
            this.lblOldal.Location = new System.Drawing.Point(110, 142);
            this.lblOldal.Name = "lblOldal";
            this.lblOldal.Text = "-";
            //
            // lblAllapotCim
            //
            this.lblAllapotCim.AutoSize = true;
            this.lblAllapotCim.Location = new System.Drawing.Point(15, 170);
            this.lblAllapotCim.Name = "lblAllapotCim";
            this.lblAllapotCim.Text = "Állapot:";
            //
            // lblAllapot
            //
            this.lblAllapot.AutoSize = true;
            this.lblAllapot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAllapot.Location = new System.Drawing.Point(110, 170);
            this.lblAllapot.Name = "lblAllapot";
            this.lblAllapot.Text = "-";
            //
            // btnKolcsonzes
            //
            this.btnKolcsonzes.Location = new System.Drawing.Point(360, 310);
            this.btnKolcsonzes.Name = "btnKolcsonzes";
            this.btnKolcsonzes.Size = new System.Drawing.Size(170, 55);
            this.btnKolcsonzes.TabIndex = 3;
            this.btnKolcsonzes.Text = "Kölcsönzés";
            this.btnKolcsonzes.UseVisualStyleBackColor = true;
            //
            // btnKilepes
            //
            this.btnKilepes.Location = new System.Drawing.Point(550, 310);
            this.btnKilepes.Name = "btnKilepes";
            this.btnKilepes.Size = new System.Drawing.Size(170, 55);
            this.btnKilepes.TabIndex = 4;
            this.btnKilepes.Text = "Kilépés";
            this.btnKilepes.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 385);
            this.Controls.Add(this.lblValasztek);
            this.Controls.Add(this.lblMufajCim);
            this.Controls.Add(this.cbMufaj);
            this.Controls.Add(this.lbKonyvek);
            this.Controls.Add(this.grpReszletek);
            this.Controls.Add(this.btnKolcsonzes);
            this.Controls.Add(this.btnKilepes);
            this.Name = "Form1";
            this.Text = "Iskolai könyvtár";
            this.grpReszletek.ResumeLayout(false);
            this.grpReszletek.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblValasztek;
        private System.Windows.Forms.Label lblMufajCim;
        private System.Windows.Forms.ComboBox cbMufaj;
        private System.Windows.Forms.ListBox lbKonyvek;
        private System.Windows.Forms.GroupBox grpReszletek;
        private System.Windows.Forms.Label lblCimCim;
        private System.Windows.Forms.Label lblCim;
        private System.Windows.Forms.Label lblSzerzoCim;
        private System.Windows.Forms.Label lblSzerzo;
        private System.Windows.Forms.Label lblMufajCim2;
        private System.Windows.Forms.Label lblMufaj;
        private System.Windows.Forms.Label lblKiadasCim;
        private System.Windows.Forms.Label lblKiadas;
        private System.Windows.Forms.Label lblOldalCim;
        private System.Windows.Forms.Label lblOldal;
        private System.Windows.Forms.Label lblAllapotCim;
        private System.Windows.Forms.Label lblAllapot;
        private System.Windows.Forms.Button btnKolcsonzes;
        private System.Windows.Forms.Button btnKilepes;
    }
}
