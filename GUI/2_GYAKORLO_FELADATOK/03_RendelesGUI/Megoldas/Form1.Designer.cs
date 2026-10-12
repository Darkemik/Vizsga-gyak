namespace RendelesGUI
{
    // =====================================================================
    // EZT A FÁJLT A DESIGNER ÍRJA, amikor az ablakot rajzolod. Kézzel NEM kell írni!
    //
    // A vezérlők nevei ((Name) a Properties ablakban):
    //   chkLaktozmentes, chkCukormentes   CheckBox     szűrés
    //   lbKinalat         ListBox        a termékek (szűrve)
    //   lblValasztott     Label          a kiválasztott termék
    //   numDarab          NumericUpDown  darabszám (Minimum 1, Maximum 10)
    //   btnKosarba        Button         "Kosárba"
    //   rtbKosar          RichTextBox    a kosár tartalma (ReadOnly = True)
    //   lblReszosszeg, lblSzallitas, lblVegosszeg   Label   az összegek
    //   btnRendeles       Button         "Rendelés leadása"
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
            this.lblKinalatCim = new System.Windows.Forms.Label();
            this.chkLaktozmentes = new System.Windows.Forms.CheckBox();
            this.chkCukormentes = new System.Windows.Forms.CheckBox();
            this.lbKinalat = new System.Windows.Forms.ListBox();
            this.lblValasztottCim = new System.Windows.Forms.Label();
            this.lblValasztott = new System.Windows.Forms.Label();
            this.lblDarabCim = new System.Windows.Forms.Label();
            this.numDarab = new System.Windows.Forms.NumericUpDown();
            this.btnKosarba = new System.Windows.Forms.Button();
            this.lblKosarCim = new System.Windows.Forms.Label();
            this.rtbKosar = new System.Windows.Forms.RichTextBox();
            this.lblReszCim = new System.Windows.Forms.Label();
            this.lblReszosszeg = new System.Windows.Forms.Label();
            this.lblSzallCim = new System.Windows.Forms.Label();
            this.lblSzallitas = new System.Windows.Forms.Label();
            this.lblVegCim = new System.Windows.Forms.Label();
            this.lblVegosszeg = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRendeles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDarab)).BeginInit();
            this.SuspendLayout();
            //
            // lblKinalatCim
            //
            this.lblKinalatCim.AutoSize = true;
            this.lblKinalatCim.Location = new System.Drawing.Point(12, 12);
            this.lblKinalatCim.Name = "lblKinalatCim";
            this.lblKinalatCim.Text = "Kínálatunk";
            //
            // chkLaktozmentes
            //
            this.chkLaktozmentes.AutoSize = true;
            this.chkLaktozmentes.Location = new System.Drawing.Point(12, 35);
            this.chkLaktozmentes.Name = "chkLaktozmentes";
            this.chkLaktozmentes.TabIndex = 1;
            this.chkLaktozmentes.Text = "Laktózmentes";
            //
            // chkCukormentes
            //
            this.chkCukormentes.AutoSize = true;
            this.chkCukormentes.Location = new System.Drawing.Point(150, 35);
            this.chkCukormentes.Name = "chkCukormentes";
            this.chkCukormentes.TabIndex = 2;
            this.chkCukormentes.Text = "Cukormentes";
            //
            // lbKinalat
            //
            this.lbKinalat.FormattingEnabled = true;
            this.lbKinalat.ItemHeight = 15;
            this.lbKinalat.Location = new System.Drawing.Point(12, 65);
            this.lbKinalat.Name = "lbKinalat";
            this.lbKinalat.Size = new System.Drawing.Size(300, 259);
            this.lbKinalat.TabIndex = 0;
            //
            // lblValasztottCim
            //
            this.lblValasztottCim.AutoSize = true;
            this.lblValasztottCim.Location = new System.Drawing.Point(12, 340);
            this.lblValasztottCim.Name = "lblValasztottCim";
            this.lblValasztottCim.Text = "Kiválasztott:";
            //
            // lblValasztott
            //
            this.lblValasztott.AutoSize = true;
            this.lblValasztott.Location = new System.Drawing.Point(100, 340);
            this.lblValasztott.Name = "lblValasztott";
            this.lblValasztott.Text = "-";
            //
            // lblDarabCim
            //
            this.lblDarabCim.AutoSize = true;
            this.lblDarabCim.Location = new System.Drawing.Point(12, 375);
            this.lblDarabCim.Name = "lblDarabCim";
            this.lblDarabCim.Text = "Darab:";
            //
            // numDarab
            //
            this.numDarab.Location = new System.Drawing.Point(100, 372);
            this.numDarab.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDarab.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDarab.Name = "numDarab";
            this.numDarab.Size = new System.Drawing.Size(60, 23);
            this.numDarab.TabIndex = 3;
            this.numDarab.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // btnKosarba
            //
            this.btnKosarba.Location = new System.Drawing.Point(192, 365);
            this.btnKosarba.Name = "btnKosarba";
            this.btnKosarba.Size = new System.Drawing.Size(120, 36);
            this.btnKosarba.TabIndex = 4;
            this.btnKosarba.Text = "Kosárba";
            this.btnKosarba.UseVisualStyleBackColor = true;
            //
            // lblKosarCim
            //
            this.lblKosarCim.AutoSize = true;
            this.lblKosarCim.Location = new System.Drawing.Point(340, 12);
            this.lblKosarCim.Name = "lblKosarCim";
            this.lblKosarCim.Text = "Kosár";
            //
            // rtbKosar
            //
            this.rtbKosar.Location = new System.Drawing.Point(340, 35);
            this.rtbKosar.Name = "rtbKosar";
            this.rtbKosar.ReadOnly = true;
            this.rtbKosar.Size = new System.Drawing.Size(300, 260);
            this.rtbKosar.TabIndex = 5;
            this.rtbKosar.Text = "";
            //
            // lblReszCim
            //
            this.lblReszCim.AutoSize = true;
            this.lblReszCim.Location = new System.Drawing.Point(340, 310);
            this.lblReszCim.Name = "lblReszCim";
            this.lblReszCim.Text = "Részösszeg:";
            //
            // lblReszosszeg
            //
            this.lblReszosszeg.AutoSize = true;
            this.lblReszosszeg.Location = new System.Drawing.Point(450, 310);
            this.lblReszosszeg.Name = "lblReszosszeg";
            this.lblReszosszeg.Text = "0 Ft";
            //
            // lblSzallCim
            //
            this.lblSzallCim.AutoSize = true;
            this.lblSzallCim.Location = new System.Drawing.Point(340, 335);
            this.lblSzallCim.Name = "lblSzallCim";
            this.lblSzallCim.Text = "Kiszállítás:";
            //
            // lblSzallitas
            //
            this.lblSzallitas.AutoSize = true;
            this.lblSzallitas.Location = new System.Drawing.Point(450, 335);
            this.lblSzallitas.Name = "lblSzallitas";
            this.lblSzallitas.Text = "0 Ft";
            //
            // lblVegCim
            //
            this.lblVegCim.AutoSize = true;
            this.lblVegCim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVegCim.Location = new System.Drawing.Point(340, 360);
            this.lblVegCim.Name = "lblVegCim";
            this.lblVegCim.Text = "Végösszeg:";
            //
            // lblVegosszeg
            //
            this.lblVegosszeg.AutoSize = true;
            this.lblVegosszeg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVegosszeg.Location = new System.Drawing.Point(450, 360);
            this.lblVegosszeg.Name = "lblVegosszeg";
            this.lblVegosszeg.Text = "0 Ft";
            //
            // lblInfo
            //
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(340, 395);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Text = "5000 Ft-tól ingyenes kiszállítás!";
            //
            // btnRendeles
            //
            this.btnRendeles.Location = new System.Drawing.Point(520, 385);
            this.btnRendeles.Name = "btnRendeles";
            this.btnRendeles.Size = new System.Drawing.Size(120, 40);
            this.btnRendeles.TabIndex = 6;
            this.btnRendeles.Text = "Rendelés leadása";
            this.btnRendeles.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 440);
            this.Controls.Add(this.lblKinalatCim);
            this.Controls.Add(this.chkLaktozmentes);
            this.Controls.Add(this.chkCukormentes);
            this.Controls.Add(this.lbKinalat);
            this.Controls.Add(this.lblValasztottCim);
            this.Controls.Add(this.lblValasztott);
            this.Controls.Add(this.lblDarabCim);
            this.Controls.Add(this.numDarab);
            this.Controls.Add(this.btnKosarba);
            this.Controls.Add(this.lblKosarCim);
            this.Controls.Add(this.rtbKosar);
            this.Controls.Add(this.lblReszCim);
            this.Controls.Add(this.lblReszosszeg);
            this.Controls.Add(this.lblSzallCim);
            this.Controls.Add(this.lblSzallitas);
            this.Controls.Add(this.lblVegCim);
            this.Controls.Add(this.lblVegosszeg);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnRendeles);
            this.Name = "Form1";
            this.Text = "Kávézó – rendelés";
            ((System.ComponentModel.ISupportInitialize)(this.numDarab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblKinalatCim;
        private System.Windows.Forms.CheckBox chkLaktozmentes;
        private System.Windows.Forms.CheckBox chkCukormentes;
        private System.Windows.Forms.ListBox lbKinalat;
        private System.Windows.Forms.Label lblValasztottCim;
        private System.Windows.Forms.Label lblValasztott;
        private System.Windows.Forms.Label lblDarabCim;
        private System.Windows.Forms.NumericUpDown numDarab;
        private System.Windows.Forms.Button btnKosarba;
        private System.Windows.Forms.Label lblKosarCim;
        private System.Windows.Forms.RichTextBox rtbKosar;
        private System.Windows.Forms.Label lblReszCim;
        private System.Windows.Forms.Label lblReszosszeg;
        private System.Windows.Forms.Label lblSzallCim;
        private System.Windows.Forms.Label lblSzallitas;
        private System.Windows.Forms.Label lblVegCim;
        private System.Windows.Forms.Label lblVegosszeg;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnRendeles;
    }
}
