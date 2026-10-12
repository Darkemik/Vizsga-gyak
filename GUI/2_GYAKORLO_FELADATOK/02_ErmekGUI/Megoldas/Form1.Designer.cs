namespace ErmekGUI
{
    // =====================================================================
    // EZT A FÁJLT A DESIGNER ÍRJA, amikor az ablakot rajzolod. Kézzel NEM kell írni!
    //
    // A vezérlők nevei ((Name) a Properties ablakban):
    //   txtSzuro     TextBox        fent: ide gépel a felhasználó (szűrés)
    //   lblDb        Label          fent jobbra: "Találatok: 24 db"
    //   dgvErmek     DataGridView   középen: az adatrács
    //                  AllowUserToAddRows = False, ReadOnly = True,
    //                  SelectionMode = FullRowSelect, RowHeadersVisible = False,
    //                  AutoSizeColumnsMode = Fill
    //   lblIskola    Label          lent: a kijelölt iskola neve
    //   lblEv        Label          lent: a kijelölt év
    //   txtArany, txtEzust, txtBronz   TextBox   lent: az érmek (módosíthatók)
    //   btnJavaslat  Button         jobbra lent: "Módosítási javaslat"
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
            this.lblDb = new System.Windows.Forms.Label();
            this.dgvErmek = new System.Windows.Forms.DataGridView();
            this.lblIskolaCim = new System.Windows.Forms.Label();
            this.lblIskola = new System.Windows.Forms.Label();
            this.lblEvCim = new System.Windows.Forms.Label();
            this.lblEv = new System.Windows.Forms.Label();
            this.lblAranyCim = new System.Windows.Forms.Label();
            this.txtArany = new System.Windows.Forms.TextBox();
            this.lblEzustCim = new System.Windows.Forms.Label();
            this.txtEzust = new System.Windows.Forms.TextBox();
            this.lblBronzCim = new System.Windows.Forms.Label();
            this.txtBronz = new System.Windows.Forms.TextBox();
            this.btnJavaslat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErmek)).BeginInit();
            this.SuspendLayout();
            //
            // lblSzuroCim
            //
            this.lblSzuroCim.AutoSize = true;
            this.lblSzuroCim.Location = new System.Drawing.Point(12, 15);
            this.lblSzuroCim.Name = "lblSzuroCim";
            this.lblSzuroCim.Text = "Iskola vagy város kezdete:";
            //
            // txtSzuro
            //
            this.txtSzuro.Location = new System.Drawing.Point(190, 12);
            this.txtSzuro.Name = "txtSzuro";
            this.txtSzuro.Size = new System.Drawing.Size(200, 23);
            this.txtSzuro.TabIndex = 0;
            //
            // lblDb
            //
            this.lblDb.AutoSize = true;
            this.lblDb.Location = new System.Drawing.Point(420, 15);
            this.lblDb.Name = "lblDb";
            this.lblDb.Text = "Találatok:";
            //
            // dgvErmek
            //
            this.dgvErmek.AllowUserToAddRows = false;
            this.dgvErmek.AllowUserToDeleteRows = false;
            this.dgvErmek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErmek.Location = new System.Drawing.Point(12, 45);
            this.dgvErmek.MultiSelect = false;
            this.dgvErmek.Name = "dgvErmek";
            this.dgvErmek.ReadOnly = true;
            this.dgvErmek.RowHeadersVisible = false;
            this.dgvErmek.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErmek.Size = new System.Drawing.Size(740, 300);
            this.dgvErmek.TabIndex = 1;
            //
            // lblIskolaCim
            //
            this.lblIskolaCim.AutoSize = true;
            this.lblIskolaCim.Location = new System.Drawing.Point(12, 365);
            this.lblIskolaCim.Name = "lblIskolaCim";
            this.lblIskolaCim.Text = "Iskola:";
            //
            // lblIskola
            //
            this.lblIskola.AutoSize = true;
            this.lblIskola.Location = new System.Drawing.Point(70, 365);
            this.lblIskola.Name = "lblIskola";
            this.lblIskola.Text = "-";
            //
            // lblEvCim
            //
            this.lblEvCim.AutoSize = true;
            this.lblEvCim.Location = new System.Drawing.Point(12, 395);
            this.lblEvCim.Name = "lblEvCim";
            this.lblEvCim.Text = "Év:";
            //
            // lblEv
            //
            this.lblEv.AutoSize = true;
            this.lblEv.Location = new System.Drawing.Point(70, 395);
            this.lblEv.Name = "lblEv";
            this.lblEv.Text = "-";
            //
            // lblAranyCim
            //
            this.lblAranyCim.AutoSize = true;
            this.lblAranyCim.Location = new System.Drawing.Point(320, 365);
            this.lblAranyCim.Name = "lblAranyCim";
            this.lblAranyCim.Text = "Arany:";
            //
            // txtArany
            //
            this.txtArany.Location = new System.Drawing.Point(380, 362);
            this.txtArany.Name = "txtArany";
            this.txtArany.Size = new System.Drawing.Size(50, 23);
            this.txtArany.TabIndex = 2;
            //
            // lblEzustCim
            //
            this.lblEzustCim.AutoSize = true;
            this.lblEzustCim.Location = new System.Drawing.Point(320, 395);
            this.lblEzustCim.Name = "lblEzustCim";
            this.lblEzustCim.Text = "Ezüst:";
            //
            // txtEzust
            //
            this.txtEzust.Location = new System.Drawing.Point(380, 392);
            this.txtEzust.Name = "txtEzust";
            this.txtEzust.Size = new System.Drawing.Size(50, 23);
            this.txtEzust.TabIndex = 3;
            //
            // lblBronzCim
            //
            this.lblBronzCim.AutoSize = true;
            this.lblBronzCim.Location = new System.Drawing.Point(320, 425);
            this.lblBronzCim.Name = "lblBronzCim";
            this.lblBronzCim.Text = "Bronz:";
            //
            // txtBronz
            //
            this.txtBronz.Location = new System.Drawing.Point(380, 422);
            this.txtBronz.Name = "txtBronz";
            this.txtBronz.Size = new System.Drawing.Size(50, 23);
            this.txtBronz.TabIndex = 4;
            //
            // btnJavaslat
            //
            this.btnJavaslat.Location = new System.Drawing.Point(560, 375);
            this.btnJavaslat.Name = "btnJavaslat";
            this.btnJavaslat.Size = new System.Drawing.Size(190, 60);
            this.btnJavaslat.TabIndex = 5;
            this.btnJavaslat.Text = "Módosítási javaslat";
            this.btnJavaslat.UseVisualStyleBackColor = true;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 460);
            this.Controls.Add(this.lblSzuroCim);
            this.Controls.Add(this.txtSzuro);
            this.Controls.Add(this.lblDb);
            this.Controls.Add(this.dgvErmek);
            this.Controls.Add(this.lblIskolaCim);
            this.Controls.Add(this.lblIskola);
            this.Controls.Add(this.lblEvCim);
            this.Controls.Add(this.lblEv);
            this.Controls.Add(this.lblAranyCim);
            this.Controls.Add(this.txtArany);
            this.Controls.Add(this.lblEzustCim);
            this.Controls.Add(this.txtEzust);
            this.Controls.Add(this.lblBronzCim);
            this.Controls.Add(this.txtBronz);
            this.Controls.Add(this.btnJavaslat);
            this.Name = "Form1";
            this.Text = "Diákolimpia – éremtábla";
            ((System.ComponentModel.ISupportInitialize)(this.dgvErmek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSzuroCim;
        private System.Windows.Forms.TextBox txtSzuro;
        private System.Windows.Forms.Label lblDb;
        private System.Windows.Forms.DataGridView dgvErmek;
        private System.Windows.Forms.Label lblIskolaCim;
        private System.Windows.Forms.Label lblIskola;
        private System.Windows.Forms.Label lblEvCim;
        private System.Windows.Forms.Label lblEv;
        private System.Windows.Forms.Label lblAranyCim;
        private System.Windows.Forms.TextBox txtArany;
        private System.Windows.Forms.Label lblEzustCim;
        private System.Windows.Forms.TextBox txtEzust;
        private System.Windows.Forms.Label lblBronzCim;
        private System.Windows.Forms.TextBox txtBronz;
        private System.Windows.Forms.Button btnJavaslat;
    }
}
