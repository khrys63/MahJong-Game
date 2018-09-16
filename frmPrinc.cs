using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MahJong {
    public partial class frmPrinc : Form, IMahjong, IDefausse {
        #region Declaration
        private Mahjong m_oMahjong;
        #endregion

        public frmPrinc() {
            InitializeComponent();
            try {
                m_oMahjong = new Mahjong(this,this.timer1);
                Defausse.getDefausse().Vue = this;
            
                this.BackColor = System.Drawing.Color.FromArgb(20, 140, 20);
                this.lblDiscard.BackColor = System.Drawing.Color.FromArgb(20, 140, 20);
                this.lblJoueur1.BackColor = System.Drawing.Color.FromArgb(20, 140, 20);
                this.lblJoueur2.BackColor = System.Drawing.Color.FromArgb(20, 140, 20);
                this.lblJoueur3.BackColor = System.Drawing.Color.FromArgb(20, 140, 20);
                this.lblJoueur4.BackColor = System.Drawing.Color.FromArgb(20, 140, 20);
                this.lblReste.BackColor = System.Drawing.Color.FromArgb(20, 140, 20);

                AffichageDesNomsJoueurs();


                for (int i = 0; i < 14; i++) {
                    System.Windows.Forms.PictureBox pbJoueur1;
                    System.Windows.Forms.PictureBox pbJoueur2;
                    System.Windows.Forms.PictureBox pbJoueur3;
                    System.Windows.Forms.PictureBox pbJoueur4;

                    pbJoueur1 = new System.Windows.Forms.PictureBox();
                    pbJoueur1.Image = Tuile.donneFond();
                    m_oMahjong.RepresentationJoueur[0].PictureBoxMain[i] = pbJoueur1;
                    pbJoueur2 = new System.Windows.Forms.PictureBox();
                    pbJoueur2.Image = Tuile.donneFond270();
                    m_oMahjong.RepresentationJoueur[1].PictureBoxMain[i] = pbJoueur2;
                    pbJoueur3 = new System.Windows.Forms.PictureBox();
                    pbJoueur3.Image = Tuile.donneFond();
                    m_oMahjong.RepresentationJoueur[2].PictureBoxMain[i] = pbJoueur3;
                    pbJoueur4 = new System.Windows.Forms.PictureBox();
                    pbJoueur4.Image = Tuile.donneFond90();
                    m_oMahjong.RepresentationJoueur[3].PictureBoxMain[i] = pbJoueur4;

                    m_oMahjong.RepresentationJoueur[0].PictureBoxMain[i].SetBounds(Constantes.X + (i * 40), Constantes.Y, 40, 50);
                    m_oMahjong.RepresentationJoueur[1].PictureBoxMain[i].SetBounds(Constantes.X + 700, Constantes.Y - 550 + (i * 40), 50, 40);
                    m_oMahjong.RepresentationJoueur[2].PictureBoxMain[i].SetBounds(Constantes.X + (i * 40), Constantes.Y - 610, 40, 50);
                    m_oMahjong.RepresentationJoueur[3].PictureBoxMain[i].SetBounds(Constantes.X - 150, Constantes.Y - 550 + (i * 40), 50, 40);

                    m_oMahjong.RepresentationJoueur[0].PictureBoxMain[i].MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblMouseClick);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[0].PictureBoxMain[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[1].PictureBoxMain[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[2].PictureBoxMain[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[3].PictureBoxMain[i]);
                    pbJoueur1 = null;
                    pbJoueur2 = null;
                    pbJoueur3 = null;
                    pbJoueur4 = null;
                }

                for (int i = 0; i < 14; i++) {
                    m_oMahjong.RepresentationJoueur[0].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();
                    m_oMahjong.RepresentationJoueur[1].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();
                    m_oMahjong.RepresentationJoueur[2].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();
                    m_oMahjong.RepresentationJoueur[3].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();

                    m_oMahjong.RepresentationJoueur[0].PictureBoxCombi[i].SetBounds(Constantes.X + (i * 40), Constantes.Y - 55, 40, 50);
                    m_oMahjong.RepresentationJoueur[1].PictureBoxCombi[i].SetBounds(Constantes.X + 700 - 55, Constantes.Y - 550 + (i * 40), 50, 40);
                    m_oMahjong.RepresentationJoueur[2].PictureBoxCombi[i].SetBounds(Constantes.X + (i * 40), Constantes.Y - 610 + 55, 40, 50);
                    m_oMahjong.RepresentationJoueur[3].PictureBoxCombi[i].SetBounds(Constantes.X - 150 + 55, Constantes.Y - 550 + (i * 40), 50, 40);

                    this.Controls.Add(m_oMahjong.RepresentationJoueur[0].PictureBoxCombi[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[1].PictureBoxCombi[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[2].PictureBoxCombi[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[3].PictureBoxCombi[i]);
                }
                for (int i = 14; i < 24; i++) {
                    m_oMahjong.RepresentationJoueur[0].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();
                    m_oMahjong.RepresentationJoueur[1].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();
                    m_oMahjong.RepresentationJoueur[2].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();
                    m_oMahjong.RepresentationJoueur[3].PictureBoxCombi[i] = new System.Windows.Forms.PictureBox();

                    m_oMahjong.RepresentationJoueur[0].PictureBoxCombi[i].SetBounds(Constantes.X + ((i - 14) * 40), Constantes.Y - 108, 40, 50);
                    m_oMahjong.RepresentationJoueur[1].PictureBoxCombi[i].SetBounds(Constantes.X - 150 + 108, Constantes.Y - 550 + ((i - 14) * 40), 50, 40);
                    m_oMahjong.RepresentationJoueur[2].PictureBoxCombi[i].SetBounds(Constantes.X + ((i - 14) * 40), Constantes.Y - 630 + 108, 40, 50);
                    m_oMahjong.RepresentationJoueur[3].PictureBoxCombi[i].SetBounds(Constantes.X + 700 - 108, Constantes.Y - 550 + ((i - 14) * 40), 50, 40);

                    this.Controls.Add(m_oMahjong.RepresentationJoueur[0].PictureBoxCombi[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[1].PictureBoxCombi[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[2].PictureBoxCombi[i]);
                    this.Controls.Add(m_oMahjong.RepresentationJoueur[3].PictureBoxCombi[i]);
                }

                /* initialisation des label pour le Vent des joueurs */
                m_oMahjong.RepresentationJoueur[0].PictureBoxVent.SetBounds(750, 650, 40, 50);
                m_oMahjong.RepresentationJoueur[1].PictureBoxVent.SetBounds(880, 50, 50, 40);
                m_oMahjong.RepresentationJoueur[2].PictureBoxVent.SetBounds(130, 40, 40, 50);
                m_oMahjong.RepresentationJoueur[3].PictureBoxVent.SetBounds(30, 50, 50, 40);


                this.Controls.Add(m_oMahjong.RepresentationJoueur[0].PictureBoxVent);
                this.Controls.Add(m_oMahjong.RepresentationJoueur[1].PictureBoxVent);
                this.Controls.Add(m_oMahjong.RepresentationJoueur[2].PictureBoxVent);
                this.Controls.Add(m_oMahjong.RepresentationJoueur[3].PictureBoxVent);
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message+"\n\n"+ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Evenements
        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                m_oMahjong.NouveauJeu();
                MontreAQuiDeJouer();
                /* c'est au joueur de jouer */
                if (m_oMahjong.AQuiDeJouer == 0) {
                    if (m_oMahjong.LesJoueurs[0].aKong() > 0 || m_oMahjong.LesJoueurs[0].aMahjong()) {
                        btnDeclarer.Enabled = true;
                    }
                    lblDiscard.Image = null;
                    btnJouer.Text = "Jouer";
                }
                btnJouer.Enabled = true;
            }
            catch (Exception ex){
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                RetourOptions();
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Environment.Exit(0);
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Windows.Forms.MessageBox.Show("Mah-Jong par Khrys63.\nhttps://github.com/khrys63/MahJong-Game", "A Propos...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnJouer_Click(object sender, EventArgs e) {
            try {
                m_oMahjong.Jouer();
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeclarer_Click(object sender, EventArgs e) {
            try {
                m_oMahjong.Declarer();
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrendre_Click(object sender, EventArgs e) {
            try {
                m_oMahjong.Prendre();
            }
            catch (Exception ex){
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            try {
                m_oMahjong.Tick();
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblMouseClick(object sender, MouseEventArgs e) {
            try {
                mouse_clic(sender, e);
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary> Gère les clics de la souris</summary>
        private void mouse_clic(System.Object event_sender, System.EventArgs evt) {
            int x = ((System.Windows.Forms.MouseEventArgs)evt).X + ((PictureBox)event_sender).Left;
            int y = ((System.Windows.Forms.MouseEventArgs)evt).Y + ((PictureBox)event_sender).Top;
            int temp = m_oMahjong.LesJoueurs[0].TuileSelect;

            if (m_oMahjong.AQuiDeJouer == 0) {
                for (int i = 0; i < 14; i++) {
                    /* le clique est-il sur une tuile? */
                    if ((x > (Constantes.X + i * 40)) && (x < (Constantes.X + (i + 1) * 40)) && (y > (Constantes.Y )) && (y < (Constantes.Y + 50))) {//&& (y > (Constantes.Y + 50)) && (y < (Constantes.Y + 99))) {
                        if (m_oMahjong.LesJoueurs[0].Main[i].Couleur != 0) {
                            // test si la tuile existe

                            if (temp < 0) {
                                // aucune tuile n'avait été séléctioné avant 
                                m_oMahjong.RepresentationJoueur[0].PictureBoxMain[i].SetBounds(Constantes.X + 40 * i, Constantes.Y - 10, 40, 50); //décalage vers le haut
                                m_oMahjong.LesJoueurs[0].TuileSelect = i; //mémorisation de la tuile
                            } else {
                                //une tuile avait déjà été séléctionée
                                m_oMahjong.RepresentationJoueur[0].PictureBoxMain[temp].SetBounds(Constantes.X + 40 * temp, Constantes.Y, 40, 50); //on remet la tuile d'avant en place

                                if (m_oMahjong.LesJoueurs[0].TuileSelect != i) {
                                    //la tuile séléctionée n'est pas la même qu'avant
                                    m_oMahjong.RepresentationJoueur[0].PictureBoxMain[i].SetBounds(Constantes.X + 40 * i, Constantes.Y - 10, 40, 50); //décalage vers le haut
                                    m_oMahjong.LesJoueurs[0].TuileSelect = i; //mémorisation de la tuile
                                } else {
                                    //la même tuile est séléctionée
                                    m_oMahjong.LesJoueurs[0].TuileSelect = -1; //aucune tuile n'est séléctionée
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void RetourOptions() {
            frmOption frm = new frmOption();
            frm.ShowDialog(this);

            for (int i = 0; i < 4; i++) {
                m_oMahjong.RepresentationJoueur[i].Affiche();
            }
            AffichageDesNomsJoueurs();
        }

        private void AffichageDesNomsJoueurs(){
            m_oMahjong.LesJoueurs[0].Nom = Options.GetOptions().NomJoueur1;
            m_oMahjong.LesJoueurs[1].Nom = Options.GetOptions().NomJoueur2;
            m_oMahjong.LesJoueurs[2].Nom = Options.GetOptions().NomJoueur3;
            m_oMahjong.LesJoueurs[3].Nom = Options.GetOptions().NomJoueur4;

            this.lblJoueur1.Text = m_oMahjong.LesJoueurs[0].Nom;
            this.lblJoueur2.Text = m_oMahjong.LesJoueurs[1].Nom;
            this.lblJoueur3.Text = m_oMahjong.LesJoueurs[2].Nom;
            this.lblJoueur4.Text = m_oMahjong.LesJoueurs[3].Nom;
        }
        
        #region Implémentation de l'interface IMahjong
        /// <summary>une tuile a été piochée</summary>
        public void TuilePiochee() {
            lblReste.Text = "Tuiles restantes: " + (144 - m_oMahjong.IndexPioche).ToString();   
        }
        /// <summary>Une tuile a été défaussé il faut l'afficher</summary>
        /// <param name="img">Image de la tuile</param>
        public void MontrerTuileDefaussee(Image img) {
            lblDiscard.Image = img;
            lblDiscard.Visible = true;
        }
        /// <summary>Il faut montrer qui doit jouer</summary>
        public void MontreAQuiDeJouer() {
            lblJoueur1.ForeColor = Color.Black;
            lblJoueur2.ForeColor = Color.Black;
            lblJoueur3.ForeColor = Color.Black;
            lblJoueur4.ForeColor = Color.Black;

            if (m_oMahjong.AQuiDeJouer == 0) {
                lblJoueur1.ForeColor = Color.Red;
            } else if (m_oMahjong.AQuiDeJouer == 1) {
                lblJoueur2.ForeColor = Color.Red;
            } else if (m_oMahjong.AQuiDeJouer == 2) {
                lblJoueur3.ForeColor = Color.Red;
            } else {
                lblJoueur4.ForeColor = Color.Red;
            }
        }
        /// <summary>Retourne le bouton Jouer</summary>
        public Button BtnJouer {
            get { return btnJouer; }
        }
        /// <summary>Retourne le bouton Declarer</summary>
        public Button BtnDeclarer {
            get { return btnDeclarer; }
        }
        /// <summary>Retourne le bouton Prendre</summary>
        public Button BtnPrendre {
            get { return btnPrendre; }
        }
        #endregion

        #region Implementation de l'interface IDefausse
        public void AfficherTuilesDefaussees() {
            lbl1b.Text = Defausse.getDefausse().nbJet(1, 'b').ToString();
            lbl2b.Text = Defausse.getDefausse().nbJet(2, 'b').ToString();
            lbl3b.Text = Defausse.getDefausse().nbJet(3, 'b').ToString();
            lbl4b.Text = Defausse.getDefausse().nbJet(4, 'b').ToString();
            lbl5b.Text = Defausse.getDefausse().nbJet(5, 'b').ToString();
            lbl6b.Text = Defausse.getDefausse().nbJet(6, 'b').ToString();
            lbl7b.Text = Defausse.getDefausse().nbJet(7, 'b').ToString();
            lbl8b.Text = Defausse.getDefausse().nbJet(8, 'b').ToString();
            lbl9b.Text = Defausse.getDefausse().nbJet(9, 'b').ToString();
            lbl1c.Text = Defausse.getDefausse().nbJet(1, 'c').ToString();
            lbl2c.Text = Defausse.getDefausse().nbJet(2, 'c').ToString();
            lbl3c.Text = Defausse.getDefausse().nbJet(3, 'c').ToString();
            lbl4c.Text = Defausse.getDefausse().nbJet(4, 'c').ToString();
            lbl5c.Text = Defausse.getDefausse().nbJet(5, 'c').ToString();
            lbl6c.Text = Defausse.getDefausse().nbJet(6, 'c').ToString();
            lbl7c.Text = Defausse.getDefausse().nbJet(7, 'c').ToString();
            lbl8c.Text = Defausse.getDefausse().nbJet(8, 'c').ToString();
            lbl9c.Text = Defausse.getDefausse().nbJet(9, 'c').ToString();
            lbl1r.Text = Defausse.getDefausse().nbJet(1, 'r').ToString();
            lbl2r.Text = Defausse.getDefausse().nbJet(2, 'r').ToString();
            lbl3r.Text = Defausse.getDefausse().nbJet(3, 'r').ToString();
            lbl4r.Text = Defausse.getDefausse().nbJet(4, 'r').ToString();
            lbl5r.Text = Defausse.getDefausse().nbJet(5, 'r').ToString();
            lbl6r.Text = Defausse.getDefausse().nbJet(6, 'r').ToString();
            lbl7r.Text = Defausse.getDefausse().nbJet(7, 'r').ToString();
            lbl8r.Text = Defausse.getDefausse().nbJet(8, 'r').ToString();
            lbl9r.Text = Defausse.getDefausse().nbJet(9, 'r').ToString();
            lbl1v.Text = Defausse.getDefausse().nbJet(1, 'v').ToString();
            lbl2v.Text = Defausse.getDefausse().nbJet(2, 'v').ToString();
            lbl3v.Text = Defausse.getDefausse().nbJet(3, 'v').ToString();
            lbl4v.Text = Defausse.getDefausse().nbJet(4, 'v').ToString();
            lbl1d.Text = Defausse.getDefausse().nbJet(1, 'd').ToString();
            lbl2d.Text = Defausse.getDefausse().nbJet(2, 'd').ToString();
            lbl3d.Text = Defausse.getDefausse().nbJet(3, 'd').ToString();
        }
        #endregion
    }
}