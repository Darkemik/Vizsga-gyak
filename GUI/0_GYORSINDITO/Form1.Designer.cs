namespace Gyorsindito
{
    // =====================================================================
    // EZT A FÁJLT A DESIGNER ÍRJA. Itt csak a vezérlők nevéért érdemes belenézni:
    //
    //   [F] txtSzuro        TextBox        név szerinti szűrés gépelésre
    //   [C] cbKategoria     ComboBox       kategória választó (DropDownList)
    //   [G] chkCsakAktiv    CheckBox       "Csak aktív"
    //   [G] grpRendezes     GroupBox       benne: rbNovekvo, rbCsokkeno (RadioButton)
    //   [B] lbElemek        ListBox        a (szűrt) elemek
    //   [D] lblNev          Label          a kiválasztott elem neve (félkövér)
    //   [D] rtbReszletek    RichTextBox    a kiválasztott elem adatai (ReadOnly)
    //   [H] numDarab        NumericUpDown  darabszám 1-10
    //   [H] txtKedvezmeny   TextBox        kedvezmény %, ellenőrizni kell (TryParse)
    //   [J] btnKosarba      Button         "Kosárba"
    //   [J] lblOsszeg       Label          "Összesen: 0 Ft"
    //   [I] btnMentes       Button         "Mentés fájlba"
    //   [K] btnKilepes      Button         "Kilépés"
    //   [E] dgvElemek       DataGridView   alul: ugyanazok az elemek táblázatban
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
            this.lblSzuroCim = new System.Windows.Forms.Label();
            this.txtSzuro = new System.Windows.Forms.TextBox();
            this.lblKategoriaCim = new System.Windows.Forms.Label();
            this.cbKategoria = new System.Windows.Forms.ComboBox();
            this.chkCsakAktiv = new System.Windows.Forms.CheckBox();
            this.grpRendezes = new System.Windows.Forms.GroupBox();
            this.rbNovekvo = new System.Windows.Forms.RadioButton();
            this.rbCsokkeno = new System.Windows.Forms.RadioButton();
            this.lbElemek = new System.Windows.Forms.ListBox();
            this.lblNev = new System.Windows.Forms.Label();
            this.rtbReszletek = new System.Windows.Forms.RichTextBox();
            this.lblDarabCim = new System.Windows.Forms.Label();
            this.numDarab = new System.Windows.Forms.NumericUpDown();
            this.lblKedvezmenyCim = new System.Windows.Forms.Label();
            this.txtKedvezmeny = new System.Windows.Forms.TextBox();
            this.btnKosarba = new System.Windows.Forms.Button();
            this.lblOsszeg = new System.Windows.Forms.Label();
            this.btnMentes = new System.Windows.Forms.Button();
            this.btnKilepes = new System.Windows.Forms.Button();
            this.dgvElemek = new System.Windows.Forms.DataGridView();
            this.grpRendezes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDarab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElemek)).BeginInit();
            this.SuspendLayout();
            //
            // lblSzuroCim
            //
            this.lblSzuroCim.AutoSize = true;
            this.lblSzuroCim.Location = new System.Drawing.Point(12, 22);
            this.lblSzuroCim.Name = "lblSzuroCim";
            this.lblSzuroCim.Text = "Név kezdete:";
            //
            // txtSzuro
            //
            this.txtSzuro.Location = new System.Drawing.Point(100, 19);
            this.txtSzuro.Name = "txtSzuro";
            this.txtSzuro.Size = new System.Drawing.Size(150, 23);
            this.txtSzuro.TabIndex = 0;
            //
            // lblKategoriaCim
            //
            this.lblKategoriaCim.AutoSize = true;
            this.lblKategoriaCim.Location = new System.Drawing.Point(270, 22);
            this.lblKategoriaCim.Name = "lblKategoriaCim";
            this.lblKategoriaCim.Text = "Kategória:";
            //
            // cbKategoria
            //
            this.cbKategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKategoria.FormattingEnabled = true;
            this.cbKategoria.Location = new System.Drawing.Point(345, 19);
            this.cbKategoria.Name = "cbKategoria";
            this.cbKategoria.Size = new System.Drawing.Size(150, 23);
            this.cbKategoria.TabIndex = 1;
            //
            // chkCsakAktiv
            //
            this.chkCsakAktiv.AutoSize = true;
            this.chkCsakAktiv.Location = new System.Drawing.Point(515, 21);
            this.chkCsakAktiv.Name = "chkCsakAktiv";
            this.chkCsakAktiv.TabIndex = 2;
            this.chkCsakAktiv.Text = "Csak aktív";
            //
            // grpRendezes
            //
            this.grpRendezes.Controls.Add(this.rbNovekvo);
            this.grpRendezes.Controls.Add(this.rbCsokkeno);
            this.grpRendezes.Location = new System.Drawing.Point(620, 4);
            this.grpRendezes.Name = "grpRendezes";
            this.grpRendezes.Size = new System.Drawing.Size(268, 46);
            this.grpRendezes.TabIndex = 3;
            this.grpRendezes.TabStop = false;
            this.grpRendezes.Text = "Rendezés ár szerint";
            //
            // rbNovekvo
            //
            this.rbNovekvo.AutoSize = true;
            this.rbNovekvo.Location = new System.Drawing.Point(15, 19);
            this.rbNovekvo.Name = "rbNovekvo";
            this.rbNovekvo.Text = "Növekvő";
            //
            // rbCsokkeno
            //
            this.rbCsokkeno.AutoSize = true;
            this.rbCsokkeno.Location = new System.Drawing.Point(130, 19);
            this.rbCsokkeno.Name = "rbCsokkeno";
            this.rbCsokkeno.Text = "Csökkenő";
            //
            // lbElemek
            //
            this.lbElemek.FormattingEnabled = true;
            this.lbElemek.ItemHeight = 15;
            this.lbElemek.Location = new System.Drawing.Point(12, 62);
            this.lbElemek.Name = "lbElemek";
            this.lbElemek.Size = new System.Drawing.Size(300, 199);
            this.lbElemek.TabIndex = 4;
            //
            // lblNev
            //
            this.lblNev.AutoSize = true;
            this.lblNev.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNev.Location = new System.Drawing.Point(330, 62);
            this.lblNev.Name = "lblNev";
            this.lblNev.Text = "-";
            //
            // rtbReszletek
            //
            this.rtbReszletek.Location = new System.Drawing.Point(330, 92);
            this.rtbReszletek.Name = "rtbReszletek";
            this.rtbReszletek.ReadOnly = true;
            this.rtbReszletek.Size = new System.Drawing.Size(270, 169);
            this.rtbReszletek.TabIndex = 5;
            this.rtbReszletek.Text = "";
            //
            // lblDarabCim
            //
            this.lblDarabCim.AutoSize = true;
            this.lblDarabCim.Location = new System.Drawing.Point(620, 65);
            this.lblDarabCim.Name = "lblDarabCim";
            this.lblDarabCim.Text = "Darab:";
            //
            // numDarab
            //
            this.numDarab.Location = new System.Drawing.Point(730, 62);
            this.numDarab.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDarab.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDarab.Name = "numDarab";
            this.numDarab.Size = new System.Drawing.Size(60, 23);
            this.numDarab.TabIndex = 6;
            this.numDarab.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // lblKedvezmenyCim
            //
            this.lblKedvezmenyCim.AutoSize = true;
            this.lblKedvezmenyCim.Location = new System.Drawing.Point(620, 97);
            this.lblKedvezmenyCim.Name = "lblKedvezmenyCim";
            this.lblKedvezmenyCim.Text = "Kedvezmény %:";
            //
            // txtKedvezmeny
            //
            this.txtKedvezmeny.Location = new System.Drawing.Point(730, 94);
            this.txtKedvezmeny.Name = "txtKedvezmeny";
            this.txtKedvezmeny.Size = new System.Drawing.Size(60, 23);
            this.txtKedvezmeny.TabIndex = 7;
            this.txtKedvezmeny.Text = "0";
            //
            // btnKosarba
            //
            this.btnKosarba.Location = new System.Drawing.Point(620, 128);
            this.btnKosarba.Name = "btnKosarba";
            this.btnKosarba.Size = new System.Drawing.Size(170, 32);
            this.btnKosarba.TabIndex = 8;
            this.btnKosarba.Text = "Kosárba";
            this.btnKosarba.UseVisualStyleBackColor = true;
            //
            // lblOsszeg
            //
            this.lblOsszeg.AutoSize = true;
            this.lblOsszeg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOsszeg.Location = new System.Drawing.Point(620, 170);
            this.lblOsszeg.Name = "lblOsszeg";
            this.lblOsszeg.Text = "Összesen: 0 Ft";
            //
            // btnMentes
            //
            this.btnMentes.Location = new System.Drawing.Point(620, 200);
            this.btnMentes.Name = "btnMentes";
            this.btnMentes.Size = new System.Drawing.Size(130, 61);
            this.btnMentes.TabIndex = 9;
            this.btnMentes.Text = "Mentés fájlba";
            this.btnMentes.UseVisualStyleBackColor = true;
            //
            // btnKilepes
            //
            this.btnKilepes.Location = new System.Drawing.Point(758, 200);
            this.btnKilepes.Name = "btnKilepes";
            this.btnKilepes.Size = new System.Drawing.Size(130, 61);
            this.btnKilepes.TabIndex = 10;
            this.btnKilepes.Text = "Kilépés";
            this.btnKilepes.UseVisualStyleBackColor = true;
            //
            // dgvElemek
            //
            this.dgvElemek.AllowUserToAddRows = false;
            this.dgvElemek.AllowUserToDeleteRows = false;
            this.dgvElemek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvElemek.Location = new System.Drawing.Point(12, 275);
            this.dgvElemek.MultiSelect = false;
            this.dgvElemek.Name = "dgvElemek";
            this.dgvElemek.ReadOnly = true;
            this.dgvElemek.RowHeadersVisible = false;
            this.dgvElemek.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvElemek.Size = new System.Drawing.Size(876, 220);
            this.dgvElemek.TabIndex = 11;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 507);
            this.Controls.Add(this.lblSzuroCim);
            this.Controls.Add(this.txtSzuro);
            this.Controls.Add(this.lblKategoriaCim);
            this.Controls.Add(this.cbKategoria);
            this.Controls.Add(this.chkCsakAktiv);
            this.Controls.Add(this.grpRendezes);
            this.Controls.Add(this.lbElemek);
            this.Controls.Add(this.lblNev);
            this.Controls.Add(this.rtbReszletek);
            this.Controls.Add(this.lblDarabCim);
            this.Controls.Add(this.numDarab);
            this.Controls.Add(this.lblKedvezmenyCim);
            this.Controls.Add(this.txtKedvezmeny);
            this.Controls.Add(this.btnKosarba);
            this.Controls.Add(this.lblOsszeg);
            this.Controls.Add(this.btnMentes);
            this.Controls.Add(this.btnKilepes);
            this.Controls.Add(this.dgvElemek);
            this.Name = "Form1";
            this.Text = "Gyorsindító – minden gyakori vezérlő";
            this.grpRendezes.ResumeLayout(false);
            this.grpRendezes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDarab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElemek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSzuroCim;
        private System.Windows.Forms.TextBox txtSzuro;
        private System.Windows.Forms.Label lblKategoriaCim;
        private System.Windows.Forms.ComboBox cbKategoria;
        private System.Windows.Forms.CheckBox chkCsakAktiv;
        private System.Windows.Forms.GroupBox grpRendezes;
        private System.Windows.Forms.RadioButton rbNovekvo;
        private System.Windows.Forms.RadioButton rbCsokkeno;
        private System.Windows.Forms.ListBox lbElemek;
        private System.Windows.Forms.Label lblNev;
        private System.Windows.Forms.RichTextBox rtbReszletek;
        private System.Windows.Forms.Label lblDarabCim;
        private System.Windows.Forms.NumericUpDown numDarab;
        private System.Windows.Forms.Label lblKedvezmenyCim;
        private System.Windows.Forms.TextBox txtKedvezmeny;
        private System.Windows.Forms.Button btnKosarba;
        private System.Windows.Forms.Label lblOsszeg;
        private System.Windows.Forms.Button btnMentes;
        private System.Windows.Forms.Button btnKilepes;
        private System.Windows.Forms.DataGridView dgvElemek;
    }
}
