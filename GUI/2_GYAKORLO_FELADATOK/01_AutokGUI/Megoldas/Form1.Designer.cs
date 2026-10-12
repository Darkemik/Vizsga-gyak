namespace AutoGUI
{
    // =====================================================================
    // EZT A FÁJLT A DESIGNER ÍRJA, amikor az ablakot rajzolod. Kézzel NEM kell írni!
    // Azért van itt, hogy lásd: melyik vezérlő milyen NEVET (Name) és FELIRATOT (Text) kapott.
    //
    // A vezérlők nevei (ezeket állítsd be a Properties ablakban: (Name)):
    //   lbGyartok      ListBox       bal fent: a gyártók
    //   cbKarosszeria  ComboBox      karosszéria típusa
    //   cbValto        ComboBox      váltó típusa
    //   grpAjtok       GroupBox      "Ajtók száma" keret, benne: rb2, rb3, rb4, rb5 (RadioButton)
    //   txtKorTol      TextBox       évek száma: tól
    //   txtKorIg       TextBox       évek száma: ig
    //   btnKereses     Button        "Keresés"
    //   lbTalalatok    ListBox       jobb oldalt: a találatok
    //   (a többi Label csak felirat, azoknak a neve mindegy)
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
            this.lblGyartok = new System.Windows.Forms.Label();
            this.lbGyartok = new System.Windows.Forms.ListBox();
            this.lblKarosszeria = new System.Windows.Forms.Label();
            this.cbKarosszeria = new System.Windows.Forms.ComboBox();
            this.lblValto = new System.Windows.Forms.Label();
            this.cbValto = new System.Windows.Forms.ComboBox();
            this.grpAjtok = new System.Windows.Forms.GroupBox();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.lblEvek = new System.Windows.Forms.Label();
            this.txtKorTol = new System.Windows.Forms.TextBox();
            this.lblKotojel = new System.Windows.Forms.Label();
            this.txtKorIg = new System.Windows.Forms.TextBox();
            this.btnKereses = new System.Windows.Forms.Button();
            this.lblTalalatok = new System.Windows.Forms.Label();
            this.lbTalalatok = new System.Windows.Forms.ListBox();
            this.grpAjtok.SuspendLayout();
            this.SuspendLayout();
            //
            // lblGyartok
            //
            this.lblGyartok.AutoSize = true;
            this.lblGyartok.Location = new System.Drawing.Point(12, 24);
            this.lblGyartok.Name = "lblGyartok";
            this.lblGyartok.Text = "Autó gyártók";
            //
            // lbGyartok
            //
            this.lbGyartok.FormattingEnabled = true;
            this.lbGyartok.ItemHeight = 15;
            this.lbGyartok.Location = new System.Drawing.Point(12, 58);
            this.lbGyartok.Name = "lbGyartok";
            this.lbGyartok.Size = new System.Drawing.Size(281, 184);
            this.lbGyartok.TabIndex = 0;
            //
            // lblKarosszeria
            //
            this.lblKarosszeria.AutoSize = true;
            this.lblKarosszeria.Location = new System.Drawing.Point(24, 265);
            this.lblKarosszeria.Name = "lblKarosszeria";
            this.lblKarosszeria.Text = "Karosszéria típusa";
            //
            // cbKarosszeria
            //
            this.cbKarosszeria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKarosszeria.FormattingEnabled = true;
            this.cbKarosszeria.Location = new System.Drawing.Point(24, 290);
            this.cbKarosszeria.Name = "cbKarosszeria";
            this.cbKarosszeria.Size = new System.Drawing.Size(160, 23);
            this.cbKarosszeria.TabIndex = 1;
            //
            // lblValto
            //
            this.lblValto.AutoSize = true;
            this.lblValto.Location = new System.Drawing.Point(24, 335);
            this.lblValto.Name = "lblValto";
            this.lblValto.Text = "Váltó típusa";
            //
            // cbValto
            //
            this.cbValto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValto.FormattingEnabled = true;
            this.cbValto.Location = new System.Drawing.Point(24, 360);
            this.cbValto.Name = "cbValto";
            this.cbValto.Size = new System.Drawing.Size(220, 23);
            this.cbValto.TabIndex = 2;
            //
            // grpAjtok
            //
            this.grpAjtok.Controls.Add(this.rb2);
            this.grpAjtok.Controls.Add(this.rb3);
            this.grpAjtok.Controls.Add(this.rb4);
            this.grpAjtok.Controls.Add(this.rb5);
            this.grpAjtok.Location = new System.Drawing.Point(330, 58);
            this.grpAjtok.Name = "grpAjtok";
            this.grpAjtok.Size = new System.Drawing.Size(110, 143);
            this.grpAjtok.TabIndex = 3;
            this.grpAjtok.TabStop = false;
            this.grpAjtok.Text = "Ajtók száma";
            //
            // rb2
            //
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(15, 25);
            this.rb2.Name = "rb2";
            this.rb2.Text = "2";
            //
            // rb3
            //
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(15, 52);
            this.rb3.Name = "rb3";
            this.rb3.Text = "3";
            //
            // rb4
            //
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(15, 79);
            this.rb4.Name = "rb4";
            this.rb4.Text = "4";
            //
            // rb5
            //
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(15, 106);
            this.rb5.Name = "rb5";
            this.rb5.Text = "5";
            //
            // lblEvek
            //
            this.lblEvek.AutoSize = true;
            this.lblEvek.Location = new System.Drawing.Point(330, 225);
            this.lblEvek.Name = "lblEvek";
            this.lblEvek.Text = "Évek száma";
            //
            // txtKorTol
            //
            this.txtKorTol.Location = new System.Drawing.Point(330, 250);
            this.txtKorTol.Name = "txtKorTol";
            this.txtKorTol.Size = new System.Drawing.Size(45, 23);
            this.txtKorTol.TabIndex = 4;
            //
            // lblKotojel
            //
            this.lblKotojel.AutoSize = true;
            this.lblKotojel.Location = new System.Drawing.Point(380, 253);
            this.lblKotojel.Name = "lblKotojel";
            this.lblKotojel.Text = "-";
            //
            // txtKorIg
            //
            this.txtKorIg.Location = new System.Drawing.Point(395, 250);
            this.txtKorIg.Name = "txtKorIg";
            this.txtKorIg.Size = new System.Drawing.Size(45, 23);
            this.txtKorIg.TabIndex = 5;
            //
            // btnKereses
            //
            this.btnKereses.Location = new System.Drawing.Point(300, 320);
            this.btnKereses.Name = "btnKereses";
            this.btnKereses.Size = new System.Drawing.Size(167, 69);
            this.btnKereses.TabIndex = 6;
            this.btnKereses.Text = "Keresés";
            this.btnKereses.UseVisualStyleBackColor = true;
            //
            // lblTalalatok
            //
            this.lblTalalatok.AutoSize = true;
            this.lblTalalatok.Location = new System.Drawing.Point(495, 24);
            this.lblTalalatok.Name = "lblTalalatok";
            this.lblTalalatok.Text = "A keresésnek megfelelő autók";
            //
            // lbTalalatok
            //
            this.lbTalalatok.FormattingEnabled = true;
            this.lbTalalatok.ItemHeight = 15;
            this.lbTalalatok.Location = new System.Drawing.Point(495, 58);
            this.lbTalalatok.Name = "lbTalalatok";
            this.lbTalalatok.Size = new System.Drawing.Size(380, 334);
            this.lbTalalatok.TabIndex = 7;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 410);
            this.Controls.Add(this.lblGyartok);
            this.Controls.Add(this.lbGyartok);
            this.Controls.Add(this.lblKarosszeria);
            this.Controls.Add(this.cbKarosszeria);
            this.Controls.Add(this.lblValto);
            this.Controls.Add(this.cbValto);
            this.Controls.Add(this.grpAjtok);
            this.Controls.Add(this.lblEvek);
            this.Controls.Add(this.txtKorTol);
            this.Controls.Add(this.lblKotojel);
            this.Controls.Add(this.txtKorIg);
            this.Controls.Add(this.btnKereses);
            this.Controls.Add(this.lblTalalatok);
            this.Controls.Add(this.lbTalalatok);
            this.Name = "Form1";
            this.Text = "Használt autók";
            this.grpAjtok.ResumeLayout(false);
            this.grpAjtok.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblGyartok;
        private System.Windows.Forms.ListBox lbGyartok;
        private System.Windows.Forms.Label lblKarosszeria;
        private System.Windows.Forms.ComboBox cbKarosszeria;
        private System.Windows.Forms.Label lblValto;
        private System.Windows.Forms.ComboBox cbValto;
        private System.Windows.Forms.GroupBox grpAjtok;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Label lblEvek;
        private System.Windows.Forms.TextBox txtKorTol;
        private System.Windows.Forms.Label lblKotojel;
        private System.Windows.Forms.TextBox txtKorIg;
        private System.Windows.Forms.Button btnKereses;
        private System.Windows.Forms.Label lblTalalatok;
        private System.Windows.Forms.ListBox lbTalalatok;
    }
}
