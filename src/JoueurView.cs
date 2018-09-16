using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MahJong {
    /// <summary>
    /// Permet la représentation graphique du jeu d'un joueur
    /// </summary>
    public class JoueurView {
        #region Declaration
        private Joueur m_oJoueur;
        private PictureBox[] m_pbCombi = new PictureBox[24];
        private PictureBox[] m_pbMain = new PictureBox[14];
        private PictureBox m_pbVent = new PictureBox();
        #endregion

        #region Proprietes
        /// <summary>Label représentant le vent</summary>
        public PictureBox PictureBoxVent {
            get { return m_pbVent; }
            set { m_pbVent = value; }
        }
        /// <summary>Labels représentant la main</summary>
        public PictureBox[] PictureBoxMain {
            get { return m_pbMain; }
            set { m_pbMain = value; }
        }
        /// <summary>Labels représentant les combinaisons</summary>
        public PictureBox[] PictureBoxCombi {
            get { return m_pbCombi; }
            set { m_pbCombi = value; }
        }
        #endregion

        #region Contructeur
        /// <summary>
        /// Constructeur de la vue
        /// </summary>
        /// <param name="oJoueur">Le joueur à représenter</param>
        public JoueurView(Joueur oJoueur) {
            m_oJoueur = oJoueur;
            for (int j = 0; j < 14; j++) {
                m_pbMain[j] = new PictureBox();
            }
            for (int j = 0; j < 24; j++) {
                m_pbCombi[j] = new PictureBox();
            }
        }
        #endregion

        #region m�thodes
        public void Affiche() {
            Tri();
            AfficheJeu();
            AfficheCombinaisons();
            AfficheVent();
        }

        /// <summary> Petit tri à bulle d'un main</summary>
        public void Tri() {
            Tuile temp = new Tuile();
            int i = 0;
            while (i < 13) {
                if (((m_oJoueur.Main[i].Couleur == 0) && (m_oJoueur.Main[i + 1].Couleur != 0)) || (m_oJoueur.Main[i].Couleur < m_oJoueur.Main[i + 1].Couleur) || (m_oJoueur.Main[i].Couleur == m_oJoueur.Main[i + 1].Couleur && m_oJoueur.Main[i].Chiffre < m_oJoueur.Main[i + 1].Chiffre))
                // ou couleur identique et chiffre supérieur
			    {
                    // intervertion des tuiles
                    temp = m_oJoueur.Main[i];
                    m_oJoueur.Main[i] = m_oJoueur.Main[i + 1];
                    m_oJoueur.Main[i + 1] = temp;
                    i = 0;
                } else {
                    i++;
                }
            }
        }

        /// <summary>Affiche le jeu du joueur</summary>
        private void AfficheJeu() {
            for (int i = 0; i < 14; i++) {
                if (m_oJoueur.Main[i].Chiffre != 0) {
                    switch (m_oJoueur.Numero) {

                        case (0):
                            m_pbMain[i].Image = m_oJoueur.Main[i].donneIcon();
                            break;

                        case (1):
                            if (Options.GetOptions().MontreJeu) {
                                m_pbMain[i].Image = RessourceManager.rotationIcon(m_oJoueur.Main[i].donneIcon(), -90);
                            } else {
                                m_pbMain[i].Image = Tuile.donneFond270();
                            }
                            break;

                        case (2):
                            if (Options.GetOptions().MontreJeu) {
                                m_pbMain[i].Image = m_oJoueur.Main[i].donneIcon();
                            } else {
                                m_pbMain[i].Image = Tuile.donneFond();
                            }
                            break;

                        case (3):
                            if (Options.GetOptions().MontreJeu) {
                                m_pbMain[i].Image = RessourceManager.rotationIcon(m_oJoueur.Main[i].donneIcon(), 90);
                            } else {
                                m_pbMain[i].Image = Tuile.donneFond90();
                            }
                            break;
                    }
                } else {
                    m_pbMain[i].Image = null;
                }
            }
        }
        /// <summary>Affiche le jeu du joueur en fin de partie</summary>
        public void AfficheJeuFinPartie() {
            for (int i = 0; i < 14; i++) {
                if (m_oJoueur.Main[i].Chiffre != 0) {
                    switch (m_oJoueur.Numero) {
                        case (0):
                            m_pbMain[i].Image = m_oJoueur.Main[i].donneIcon();
                            break;
                        case (1):
                            m_pbMain[i].Image = RessourceManager.rotationIcon(m_oJoueur.Main[i].donneIcon(), -90);
                            break;
                        case (2):
                            m_pbMain[i].Image = m_oJoueur.Main[i].donneIcon();
                            break;
                        case (3):
                            m_pbMain[i].Image = RessourceManager.rotationIcon(m_oJoueur.Main[i].donneIcon(), 90);
                            break;
                    }
                } else {
                    m_pbMain[i].Image = null;
                }
            }
        }
        /// <summary>Affiche le vent du joueur</summary>
        private void AfficheVent() {
            System.Drawing.Image oImage = System.Drawing.Image.FromHbitmap(RessourceManager.GetImage((m_oJoueur.Vent + 1) + "v").GetHbitmap());

            switch (m_oJoueur.Numero) {
                case (0):
                case (2):
                    m_pbVent.Image = oImage;
                    break;
                case (1):
                    m_pbVent.Image = RessourceManager.rotationIcon(oImage, -90);
                    break;
                case (3):
                    m_pbVent.Image = RessourceManager.rotationIcon(oImage, 90);
                    break;
            }
        }
        /// <summary>Affiche les combinaisons du joueur</summary>
        private void AfficheCombinaisons() {
            for (int i = 0; i < 24; i++) {
                if (m_oJoueur.Combinaison[i].Couleur != 0) {
                    switch (m_oJoueur.Numero) {

                        case (0):
                            m_pbCombi[i].Image = m_oJoueur.Combinaison[i].donneIcon();
                            break;

                        case (1):
                            m_pbCombi[i].Image = RessourceManager.rotationIcon(m_oJoueur.Combinaison[i].donneIcon(), -90);
                            break;

                        case (2):
                            m_pbCombi[i].Image = m_oJoueur.Combinaison[i].donneIcon();
                            break;

                        case (3):
                            m_pbCombi[i].Image = RessourceManager.rotationIcon(m_oJoueur.Combinaison[i].donneIcon(), 90);
                            break;
                    }
                } else {
                    m_pbCombi[i].Image = null;
                }
            }
        }
        #endregion
    }
}
