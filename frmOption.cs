using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MahJong {
    public partial class frmOption : Form {
        public frmOption() {
            InitializeComponent();
            chkOption.Checked = Options.GetOptions().MontreJeu;
            txtNom1.Text = Options.GetOptions().NomJoueur1;
            txtNom2.Text = Options.GetOptions().NomJoueur2;
            txtNom3.Text = Options.GetOptions().NomJoueur3;
            txtNom4.Text = Options.GetOptions().NomJoueur4;
        }

        private void chkOption_CheckedChanged(object sender, EventArgs e) {

        }

        private void btnOk_Click(object sender, EventArgs e) {
            Options.GetOptions().MontreJeu = chkOption.Checked;
            Options.GetOptions().NomJoueur1 = txtNom1.Text;
            Options.GetOptions().NomJoueur2 = txtNom2.Text;
            Options.GetOptions().NomJoueur3 = txtNom3.Text;
            Options.GetOptions().NomJoueur4 = txtNom4.Text;
            this.Close();
        }
    }
}