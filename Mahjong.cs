using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MahJong {
    public class Mahjong {
        #region Declaration
        private List<Tuile> m_oTuilesPioche=new List<Tuile>();
        private List<Joueur> m_oLesJoueurs = new List<Joueur>();
        private List<JoueurView> m_oRepresentationJoueur = new List<JoueurView>();
        private Tuile m_oTuileDefaussee =new Tuile();
        private Defausse m_oDefausse = Defausse.getDefausse();
        private int m_iIndexPioche=0;
        private int m_iCompteurTimer=0;
        private int m_iAQuiDeJouer=0;

        private IMahjong m_oVuejeu;
        private Timer m_oTimerAttente;
        #endregion

        #region Proprietes
        public List<Joueur> LesJoueurs {
            get { return m_oLesJoueurs; }
            set { m_oLesJoueurs = value; }
        }
        public List<JoueurView> RepresentationJoueur {
            get { return m_oRepresentationJoueur; }
            set { m_oRepresentationJoueur = value; }
        }
        public int IndexPioche {
            get { return m_iIndexPioche; }
            set { m_iIndexPioche = value; }
        }
        public int AQuiDeJouer {
            get { return m_iAQuiDeJouer; }
            set { m_iAQuiDeJouer = value; }
        }
        #endregion

        #region Constructeur
        public Mahjong(IMahjong oVuejeu,Timer oTimer) {
            m_oLesJoueurs.Capacity = 4;
            for (int i = 0; i < 4; i++) {
                m_oLesJoueurs.Add(new Joueur(i));
            }

            m_oRepresentationJoueur.Capacity = 4;
            for (int i = 0; i < 4; i++) {
                m_oRepresentationJoueur.Add(new JoueurView(m_oLesJoueurs[i]));
            }

            m_oVuejeu = oVuejeu;
            m_oTimerAttente = oTimer;
        }
        #endregion

        #region Methodes publiques
        /// <summary> Crée une nouveau jeu</summary>
        public void NouveauJeu() {
            int temp;
            Random rand = new Random();

            m_oTimerAttente.Stop();
                
            /* Initialise */
            initPioche();
            m_iAQuiDeJouer = 3;// rand.Next(4);
            m_oLesJoueurs[m_iAQuiDeJouer].Vent = Constantes.EST;
            m_oLesJoueurs[(m_iAQuiDeJouer + 1) % 4].Vent = Constantes.SUD;
            m_oLesJoueurs[(m_iAQuiDeJouer + 2) % 4].Vent = Constantes.OUEST;
            m_oLesJoueurs[(m_iAQuiDeJouer + 3) % 4].Vent = Constantes.NORD;
            initJoueurs();
            

            m_oTuileDefaussee = null;// new Tuile();
            
            /* initialisation des jeux */
            for (int i = 0; i < 4; i++) {
                do {
                    temp = m_oLesJoueurs[i].DeclareHonneur();
                    piocheTuiles(m_oLesJoueurs[i], temp);
                }
                while (temp > 0);
                m_oRepresentationJoueur[i].Affiche();
            }
            if (m_oLesJoueurs[0].TuileSelect >= 0) {
                m_oRepresentationJoueur[0].PictureBoxMain[m_oLesJoueurs[0].TuileSelect].SetBounds(Constantes.X + 40 * m_oLesJoueurs[0].TuileSelect, Constantes.Y, 40, 50);
                m_oLesJoueurs[0].TuileSelect = -1;
            }
            if (m_iAQuiDeJouer != 0) {
                m_oTimerAttente.Start();
                partie(false);
            }
        }
        /// <summary> Le joueur a appuyé sur le bouton Déclarer </summary>
        public void Declarer() {
            int nb;
            string sNom = "";
            DialogResult oResult = DialogResult.No;
            if (m_oLesJoueurs[0].aMahjong()) {
                oResult = System.Windows.Forms.MessageBox.Show("Vous avez un Mahjong\nVoulez vous le déclarez?", "MAHJONG!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes) {
                    finPartie(0);
                }
            }

            if (oResult != DialogResult.Yes) {
                nb = m_oLesJoueurs[0].aKong(sNom);
                for (int i = 0; i < nb; i++) {
                    oResult = System.Windows.Forms.MessageBox.Show("Vous avez un kong de" + sNom + "\nVoulez vous le déclarez?", "Délaration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oResult == DialogResult.Yes) {
                        m_oLesJoueurs[0].DeclareKong(sNom);
                        if (m_iIndexPioche < 144) {
                            piocheTuiles(m_oLesJoueurs[0], 1);
                            m_oRepresentationJoueur[0].Affiche();
                            //joueurs[0].affiche();
                        } else {
                            finPartie(-1);
                            return;
                        }
                    }
                }
            }
            if (m_oLesJoueurs[0].aKong() > 0 || m_oLesJoueurs[0].aMahjong()) {
                m_oVuejeu.BtnDeclarer.Enabled = true;
            } else {
                m_oVuejeu.BtnDeclarer.Enabled = false;
            }
        }
        /// <summary> Le joueur a appuyé sur le bouton jouer/passer</summary>
        public void Jouer() {
            if (m_oTimerAttente.Enabled) {
                /* le timer tourne dc le joueur a demandé de passer au joueur suivant */
                m_oTimerAttente.Stop();
                m_oVuejeu.BtnJouer.Text = "Jouer";
                m_oVuejeu.MontrerTuileDefaussee(null);
                m_oVuejeu.BtnJouer.Enabled = true;
                m_oVuejeu.BtnPrendre.Enabled = false;

                if (!OrdiFaitMahjong()) {
                    bool bOrdiAPrit = false;
                    for (int i = 1; i < 4; i++) {
                        if (!bOrdiAPrit) {
                            bOrdiAPrit = OrdiPeutPrendre(i);
                        }
                    }
                    /* personne ne peut prendre la tuile */
                    if (!bOrdiAPrit) {
                        m_oDefausse.add(m_oTuileDefaussee);

                        m_iAQuiDeJouer = (m_iAQuiDeJouer + 1) % 4; //joueur suivant
                        partie(true);
                    }
                }
            } else {
                /* le joueur joue */
                Tuile t = new Tuile();
                int i = m_oLesJoueurs[0].TuileSelect;

                if (m_oLesJoueurs[0].TuileSelect != -1) {
                    /*il faut avoir séléctionner une tuile */
                    t = m_oLesJoueurs[0].retireTuile(i);
                    m_oRepresentationJoueur[0].PictureBoxMain[i].SetBounds(Constantes.X + 40 * i, Constantes.Y, 40, 50);
                    m_oRepresentationJoueur[0].Affiche();//on rafraichi le jeu du joueur
                    m_oLesJoueurs[0].TuileSelect = -1;
                    m_oTuileDefaussee = t;
                    m_oVuejeu.MontrerTuileDefaussee(t.donneIcon());
                    m_oVuejeu.BtnJouer.Enabled = false;
                    m_oVuejeu.BtnDeclarer.Enabled = false;
                    m_oVuejeu.BtnPrendre.Enabled = false;

                    m_iCompteurTimer = 2;
                    m_oTimerAttente.Start();
                } else {
                    /* pas de tuile séléctionnée */
                }
            }
        }
        /// <summary> Le joueur a appuyé sur le bouton Prendre </summary>
        public void Prendre() {
            Tuile[] comb = new Tuile[4];
            int cpt = 0;

            m_oTimerAttente.Stop();
            m_oVuejeu.BtnJouer.Text = "Jouer";
            m_oVuejeu.MontrerTuileDefaussee(null);
            m_oVuejeu.BtnJouer.Enabled = true;
            m_oVuejeu.BtnPrendre.Enabled = false;

            System.Console.Out.Write("Vous prenez la tuile\n");
            if (m_oLesJoueurs[0].peutMahjong(m_oTuileDefaussee)) {
                m_oLesJoueurs[0].ajouteTuile(m_oTuileDefaussee);
                m_oRepresentationJoueur[0].Affiche();//on raifraichi le jeu du joueur
                finPartie(0);
            } else {
                comb[cpt++] = new Tuile(m_oTuileDefaussee);
                for (int i = 0; i < 13; i++) {
                    if (m_oLesJoueurs[0].Main[i].Chiffre == m_oTuileDefaussee.Chiffre && m_oLesJoueurs[0].Main[i].Couleur == m_oTuileDefaussee.Couleur) {
                        comb[cpt++] = new Tuile(m_oTuileDefaussee);
                        m_oLesJoueurs[0].Main[i] = new Tuile();
                    }
                }
                m_oLesJoueurs[0].ajouteCombi(comb, cpt);
                m_iAQuiDeJouer = 0;
                m_oTuileDefaussee = null;
                m_oVuejeu.MontrerTuileDefaussee(null);
                if (cpt == 4) {
                    /* c t un kong don le joueur peut piocher */
                    partie(true);
                } else {
                    partie(false);
                }
            }
        }
        /// <summary>Le timer tourne toutes les secondes</summary>
        public void Tick() {
            if (m_iCompteurTimer == 0) {
                m_oTimerAttente.Stop();

                if (!OrdiFaitMahjong()) {
                    bool bOrdiAPrit = false;
                    for (int i = 1; i < 4; i++) {
                        if (!bOrdiAPrit) {
                            bOrdiAPrit = OrdiPeutPrendre(i);
                        }
                    }
                    if (!bOrdiAPrit) {
                        m_oDefausse.add(m_oTuileDefaussee);

                        m_oVuejeu.BtnJouer.Text = "Jouer";
                        m_oVuejeu.MontrerTuileDefaussee(null);
                        m_iAQuiDeJouer = (m_iAQuiDeJouer + 1) % 4; //joueur suivant
                        partie(true);
                    }
                }
            } else if (m_iCompteurTimer > 0) {
                if ((m_oLesJoueurs[0].peutPrendre(m_oTuileDefaussee)) && (m_iAQuiDeJouer != 0)) {
                    m_oVuejeu.BtnPrendre.Enabled = true;
                }
                m_oVuejeu.BtnJouer.Enabled = true;
                m_oVuejeu.BtnJouer.Text = "Passer " + (m_iCompteurTimer);
                m_iCompteurTimer--;
            }
        }
        #endregion

        #region Methodes privees
        /// <summary>Initialise la pioche</summary>
        private void initPioche() {
            System.Random melange = new System.Random();
            Tuile temp = new Tuile();
            int x, y;
            m_oTuilesPioche = new List<Tuile>();
            m_oTuilesPioche.Capacity = 144;
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 9; j++) {
                    m_oTuilesPioche.Add(new Tuile(j + 1, 'c', (j + 1) + " caractère")); //chiffres
                    m_oTuilesPioche.Add(new Tuile(j + 1, 'b', (j + 1) + " bamboo")); //bamboos
                    m_oTuilesPioche.Add(new Tuile(j + 1, 'r', (j + 1) + " rond")); //ronds
                }
                for (int j = 0; j < 3; j++) {
                    m_oTuilesPioche.Add(new Tuile(j + 1, 'd', (j + 1) + " dragon")); //dragons
                }
                for (int j = 0; j < 4; j++) {
                    m_oTuilesPioche.Add(new Tuile(j + 1, 'v', (j + 1) + " Vent")); //vents
                }
                m_oTuilesPioche.Add(new Tuile(i + 1, 'f', (i + 1) + " fleur")); //fleurs
                m_oTuilesPioche.Add(new Tuile(i + 1, 's', (i + 1) + " saison")); //saisons
            }

            /* inverse 400 fois 2 tuiles aléatoires */
            for (int i = 0; i < 400; i++) {
                x = melange.Next(144);
                y = melange.Next(144);
                temp = m_oTuilesPioche[x];
                m_oTuilesPioche[x] = m_oTuilesPioche[y];
                m_oTuilesPioche[y] = temp;
            }
            m_iIndexPioche = 0;

            // on vide la défausse;
            m_oDefausse.init();

            m_oVuejeu.TuilePiochee();
        }
        /// <summary>Initialisation des joueurs</summary>
        private void initJoueurs() {
            for (int j = 0; j < 4; j++) {
                for (int i = 0; i < 14; i++) {
                    m_oRepresentationJoueur[j].PictureBoxMain[i].Image = null;
                    m_oLesJoueurs[j].Main[i] = new Tuile();
                }
                for (int i = 0; i < 24; i++) {
                    m_oRepresentationJoueur[j].PictureBoxCombi[i].Image = null;
                    m_oLesJoueurs[j].Combinaison[i] = new Tuile();
                }
                for (int i = 0; i < 12; i++) {
                    m_oLesJoueurs[j].IndexCombi[i] = 0;
                }
            //    m_oLesJoueurs[j].Vent = j;
                m_oLesJoueurs[j].Numero = j;
                m_oLesJoueurs[j].Score = 0;
            }
            /* 13 tuiles par joueur */
            for (int i = 0; i < 13; i++) {
                for (int j = 0; j < 4; j++) {
                    m_oLesJoueurs[j].Main[i] = m_oTuilesPioche[m_iIndexPioche++];
                }
            }
            /* une tuile de plus pour le joueur de l'est */
            for (int i = 0; i <4; i++) {
                if (m_oLesJoueurs[i].Vent == Constantes.EST) {
                    m_oLesJoueurs[i].Main[13] = m_oTuilesPioche[m_iIndexPioche++];
                } else {
                    m_oLesJoueurs[i].Main[13] = new Tuile();
                }
            }
        }
        /// <summary>
        /// On passe à une nouvelle partie
        /// </summary>
        /// <param name="estGagne">Le vent EST a gagné la précédente?</param>
        private void nouvellePartie(bool estGagne) {
            initPioche();
            for (int j = 0; j < 4; j++) {
                for (int i = 0; i < 24; i++) {
                    m_oRepresentationJoueur[j].PictureBoxCombi[i].Image = null;
                    m_oLesJoueurs[j].Combinaison[i] = new Tuile();
                }
                for (int i = 0; i < 12; i++) {
                    m_oLesJoueurs[j].IndexCombi[i] = 0;
                }
                if (estGagne == false) {
                    /* fait tourner les vents si le Vent d'est n'a pas gagner */
                    m_oLesJoueurs[j].Vent = (m_oLesJoueurs[j].Vent + 3) % 4;
                }
                /* 13 tuiles par joueur */
                for (int i = 0; i < 13; i++) {
                    m_oLesJoueurs[j].Main[i] = m_oTuilesPioche[m_iIndexPioche++];
                }
                /* une tuile de plus pour le joueur de l'est */
                if (m_oLesJoueurs[j].Vent == Constantes.EST) {
                    m_oLesJoueurs[j].Main[13] = m_oTuilesPioche[m_iIndexPioche++];
                } else {
                    m_oLesJoueurs[j].Main[13] = new Tuile();
                }
                m_oRepresentationJoueur[j].Affiche();
            }
            for (int j = 0; j < 4; j++) {
                if (m_oLesJoueurs[j].Vent == Constantes.EST) {
                    m_iAQuiDeJouer = j;
                }
            }

            m_oVuejeu.MontrerTuileDefaussee(null);
            

            int temp = 0;
            for (int i = 0; i < 4; i++) {
                do {
                    temp = m_oLesJoueurs[i].DeclareHonneur();
                    piocheTuiles(m_oLesJoueurs[i], temp);
                }
                while (temp > 0);
                m_oRepresentationJoueur[i].Affiche();
            }
            if (m_oLesJoueurs[0].TuileSelect >= 0) {
                m_oRepresentationJoueur[0].PictureBoxMain[m_oLesJoueurs[0].TuileSelect].SetBounds(Constantes.X + 40 * m_oLesJoueurs[0].TuileSelect, Constantes.Y, 40, 50);
                m_oLesJoueurs[0].TuileSelect = -1;
            }
            m_oVuejeu.BtnJouer.Text = "Jouer";
            m_oVuejeu.MontrerTuileDefaussee(null);
            if (m_iAQuiDeJouer == 0) {
                /* c'est au joueur joue */
                if (m_oLesJoueurs[0].aKong() > 0 || m_oLesJoueurs[0].aMahjong()) {
                    m_oVuejeu.BtnDeclarer.Enabled = true;
                } else {
                    m_oVuejeu.BtnDeclarer.Enabled = false;
                }
                m_oVuejeu.BtnJouer.Enabled = true;
                m_oVuejeu.BtnPrendre.Enabled = false;
            } else {
                /* les ordinateurs jouent */
                m_oVuejeu.BtnDeclarer.Enabled = false;
                m_oVuejeu.BtnJouer.Enabled = false;
                m_oVuejeu.BtnPrendre.Enabled = false;
                ordiJoue(m_iAQuiDeJouer);
            }
        }
        /// <summary>
        /// Fin de partie
        /// </summary>
        /// <param name="gagnant">Numéro du gagnant</param>
        private void finPartie(int gagnant) {
            DialogResult oResult = DialogResult.No;
            if (gagnant < 0) {
                //pas de gagnant

                oResult = System.Windows.Forms.MessageBox.Show("La partie s'est finie sans mahjong.\n On Continue?", "Fin de partie", MessageBoxButtons.YesNo);
                if (oResult == DialogResult.Yes) {
                    nouvellePartie(false);
                } else {
                    System.Environment.Exit(0);
                }
            } else {

                if (gagnant == 0) {
                    System.Windows.Forms.MessageBox.Show("Bien jouer! Vous avez gagn� la partie", "Mahjong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    System.Windows.Forms.MessageBox.Show("Dommage, c'est " + m_oLesJoueurs[gagnant].Nom + " qui a gagn� la partie", "Mahjong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                for (int i = 0; i < 4; i++) {
                    m_oRepresentationJoueur[i].AfficheJeuFinPartie();
                }

                calculScore(gagnant);

                oResult = System.Windows.Forms.MessageBox.Show("Partie suivante?", "Fin de partie", MessageBoxButtons.YesNo);
                if (oResult == DialogResult.Yes) {
                    if (m_oLesJoueurs[gagnant].Vent == Constantes.EST) {
                        nouvellePartie(false);
                    } else {
                        nouvellePartie(false);
                    }
                } else {
                    System.Environment.Exit(0);
                }
            }
        }
        /// <summary>
        /// Determine si l'ordi peut-il faire Mahjong?
        /// </summary>
        /// <returns>Resultat</returns>
        private bool OrdiFaitMahjong() {
            bool bResult = false;
            for (int i = 1; i < 4; i++) {
                if (m_oLesJoueurs[i].peutMahjong(m_oTuileDefaussee)) {
                    System.Console.Out.Write("Le joueur " + i + " fait Mahjong\n");
                    m_oLesJoueurs[i].ajouteTuile(m_oTuileDefaussee);
                    m_iAQuiDeJouer = i;
                    m_oTuileDefaussee = null;// new Tuile();
                    m_oVuejeu.MontrerTuileDefaussee(null);
                    finPartie(i);
                    bResult = true;
                }
            }
            return bResult;
        }

        /// <summary>
        /// Determine si l'ordi peut-il prendre la tuile defaussée
        /// </summary>
        /// <param name="i">Numéro de joueur</param>
        /// <returns>Resultat</returns>
        private bool OrdiPeutPrendre(int i) {
            bool bResult = false;
            /* un ordi peut-il prendre la tuile? */
            if (m_oLesJoueurs[i].peutPrendre(m_oTuileDefaussee) && m_iAQuiDeJouer != i) {
                /* ce joueur peut prendre ? */
                Tuile[] comb = new Tuile[4];
                int cpt = 0;

                System.Console.Out.Write("Le joueur " + i + " prend la tuile\n");
                comb[cpt++] = new Tuile(m_oTuileDefaussee);

                for (int j = 0; j <= 13; j++) {
                    /*récuperation des tuiles */
                    if (m_oLesJoueurs[i].Main[j].Chiffre == m_oTuileDefaussee.Chiffre && m_oLesJoueurs[i].Main[j].Couleur == m_oTuileDefaussee.Couleur) {
                        comb[cpt++] = new Tuile(m_oTuileDefaussee);
                        m_oLesJoueurs[i].Main[j] = new Tuile();
                    }
                }
                m_oLesJoueurs[i].ajouteCombi(comb, cpt); // ajout de la combi
                m_oRepresentationJoueur[i].Affiche(); //on rafraichi le jeu du joueur
                m_iAQuiDeJouer = i;

                if (cpt == 4) {
                    System.Console.Out.Write("Le joueur " + i + " déclare un kong\n");
                    partie(true);
                } else {
                    System.Console.Out.Write("Le joueur " + i + " déclare un pung\n");
                    partie(false);
                }
                bResult = true;
            }
            return bResult;
        }
        
        /// <summary> Fonction qui fait jouer chaque joueur
        /// </summary>
        /// <param name="doitPiocher">Le joueur doit piocher?</param>
        private void partie(bool doitPiocher) {
            int temp, temp2 = -1;
            m_oVuejeu.MontreAQuiDeJouer();

            if (doitPiocher == true) {
                /* le joueur pioche une tuile */
                if (m_iIndexPioche < 144) {
                    temp2 = piocheTuiles(m_oLesJoueurs[m_iAQuiDeJouer], 1);

                    /* d�claration des fleurs et saisons */
                    do {
                        temp = m_oLesJoueurs[m_iAQuiDeJouer].DeclareHonneur();
                        if (temp > 0 && m_iIndexPioche < 144) {
                            temp2 = piocheTuiles(m_oLesJoueurs[m_iAQuiDeJouer], temp);
                        } else if (m_iIndexPioche >= 144) {
                            finPartie(-1);
                        }
                    }
                    while (temp > 0);
                }
            }
            m_oRepresentationJoueur[m_iAQuiDeJouer].Affiche();
            /* rafraichissement de l'affichage */

            if (m_iIndexPioche >= 144) {
                finPartie(-1);
            } else {
                if (m_iAQuiDeJouer == 0) {
                    /* c'est au joueur joue */
                    if (temp2 >= 0) {
                        m_oRepresentationJoueur[0].PictureBoxMain[temp2].SetBounds(Constantes.X + 40 * temp2, Constantes.Y - 10, 40, 50); //d�calage vers le haut
                        m_oLesJoueurs[0].TuileSelect = temp2; //mémorisation de la tuile
                    }

                    if (m_oLesJoueurs[0].aKong() > 0 || m_oLesJoueurs[0].aMahjong()) {
                        m_oVuejeu.BtnDeclarer.Enabled = true;
                    }
                    m_oVuejeu.BtnJouer.Text = "Jouer";
                    m_oVuejeu.MontrerTuileDefaussee(null);
                    m_oVuejeu.BtnJouer.Enabled = true;
                } else {
                    /* les ordinateurs jouent */
                    if (m_oLesJoueurs[m_iAQuiDeJouer].aMahjong()) {
                        finPartie(m_iAQuiDeJouer);
                    } else {
                        string sNom = "";

                        /* déclaration de kong */
                        int nb = m_oLesJoueurs[m_iAQuiDeJouer].aKong(sNom);
                        for (int i = 0; i < nb; i++) {
                            m_oLesJoueurs[m_iAQuiDeJouer].DeclareKong(sNom);
                            System.Console.Out.Write("joueur" + m_iAQuiDeJouer + " déclare un kong de " + sNom + "\n");
                            if (m_iIndexPioche < 144) {
                                piocheTuiles(m_oLesJoueurs[m_iAQuiDeJouer], 1);
                                /* déclaration des fleurs et saisons */
                                do {
                                    temp = m_oLesJoueurs[m_iAQuiDeJouer].DeclareHonneur();
                                    if (temp > 0 && m_iIndexPioche < 144) {
                                        temp2 = piocheTuiles(m_oLesJoueurs[m_iAQuiDeJouer], temp);
                                    } else if (m_iIndexPioche >= 144) {
                                        finPartie(-1);
                                    }
                                }
                                while (temp > 0);
                                m_oRepresentationJoueur[m_iAQuiDeJouer].Affiche();

                                if (m_oLesJoueurs[m_iAQuiDeJouer].aMahjong()) {
                                    finPartie(m_iAQuiDeJouer);
                                    return;
                                }
                            } else {
                                finPartie(-1);
                                return;
                            }
                        }

                        m_oVuejeu.BtnJouer.Enabled = false;
                        m_oVuejeu.BtnPrendre.Enabled = false;
                        ordiJoue(m_iAQuiDeJouer);
                    }
                }
            }
        }
        /// <summary>
        /// L'ordi defausse une tuile
        /// </summary>
        /// <param name="j">Numéro de joueur</param>
        private void ordiJoue(int j) {
            System.Random rand = new System.Random();
            int i;
            int iCompteur = 0; // on fait 28 fois le test pour trouver une tuile a defausser.Si on y arrive pas c'est qu'on a que des paires.
            Tuile t;

            //Cherchons une tuile qu'on peut jeter
            do {//tuile aléatoire
                i = rand.Next(14);
                if (iCompteur++ > 28 && m_oLesJoueurs[j].Main[i].Chiffre != 0) { break; }
            }// Tant que la tuile selectionnée n'est pas vide, ou que j'en ai plusieurs (si je peux la prendre moi meme)
            while (m_oLesJoueurs[j].Main[i].Chiffre == 0 || m_oLesJoueurs[j].peutPrendre(m_oLesJoueurs[j].Main[i]));

            t = m_oLesJoueurs[j].retireTuile(i);
            m_oRepresentationJoueur[j].Affiche();//on rafraichi le jeu du joueur
            m_oTuileDefaussee = t;

            m_oVuejeu.MontrerTuileDefaussee(t.donneIcon());

            System.Console.Out.Write("Jette " + t.Nom + "\n");

            m_iCompteurTimer = 10;
            m_oTimerAttente.Start();
        }

        private void calculScore(int gagnant) {
            int[] scoreInterm = new int[4];
            int[] scoreFinal = new int[4];

            /* calcul des scores des jeux */
            for (int i = 0; i < 4; i++) {
                if (i == gagnant) {
                    scoreInterm[i] = m_oLesJoueurs[i].scorePartie(true);
                } else {
                    scoreInterm[i] = m_oLesJoueurs[i].scorePartie(false);
                }
                scoreFinal[i] = 0;
            }

            /* calcul des scores de la partie */
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    if (i != j) {
                        // ce ne sont pas les mm joueurs
                        if (i == gagnant) {
                            // je suis gagnant
                            if (scoreInterm[i] < scoreInterm[j]) {
                                //qqun d'autre a un score plus grand que moi
                                if (m_oLesJoueurs[i].Vent == Constantes.EST || m_oLesJoueurs[j].Vent == Constantes.EST) {
                                    // si je suis EST ou que l'aute est EST
                                    scoreFinal[i] += 4 * (scoreInterm[i] - scoreInterm[j]); // je re�ois 4* la diff de nos score
                                } else {
                                    scoreFinal[i] += 2 * (scoreInterm[i] - scoreInterm[j]); // ou 2*
                                }
                            } else {
                                // l'autre a un score plus petit
                                if (m_oLesJoueurs[i].Vent == Constantes.EST || m_oLesJoueurs[j].Vent == Constantes.EST) {
                                    // si je suis EST ou que l'aute est EST
                                    scoreFinal[i] += 2 * scoreInterm[i]; // je recoit 2* mon score
                                } else {
                                    scoreFinal[i] += scoreInterm[i]; // une seule fois sinon
                                }
                            }
                        } else {
                            // j'ai perdu
                            if (j == gagnant) {
                                // l'autre a gagné
                                if (scoreInterm[i] > scoreInterm[j]) {
                                    //j'ai qd mm un score plus grand
                                    if (m_oLesJoueurs[i].Vent == Constantes.EST || m_oLesJoueurs[j].Vent == Constantes.EST) {
                                        // si je suis EST ou que l'aute est EST
                                        scoreFinal[i] += 4 * (scoreInterm[i] - scoreInterm[j]); // je reçois 4* la diff de nos score
                                    } else {
                                        scoreFinal[i] += 2 * (scoreInterm[i] - scoreInterm[j]); // ou 2*
                                    }
                                } else {
                                    if (m_oLesJoueurs[i].Vent == Constantes.EST || m_oLesJoueurs[j].Vent == Constantes.EST) {
                                        // si je suis EST ou que l'aute est EST
                                        scoreFinal[i] -= 2 * scoreInterm[j]; // je donne 2* son score à l'autre
                                    } else {
                                        scoreFinal[i] -= scoreInterm[j]; // une seule fois sinon
                                    }
                                }
                            } else {
                                // nous avons tout les 2 perdus
                                if (m_oLesJoueurs[i].Vent == Constantes.EST || m_oLesJoueurs[j].Vent == Constantes.EST) {
                                    // si je suis EST ou que l'aute est EST
                                    scoreFinal[i] += 2 * (scoreInterm[i] - scoreInterm[j]); // je reçois 2* la diff de nos score
                                } else {
                                    scoreFinal[i] += (scoreInterm[i] - scoreInterm[j]); // ou 1 fois seulement
                                }
                            }
                        }
                    } else {
                        //ce sont les mm joueurs
                    }
                }
            }

            /* calcul du score final */
            for (int i = 0; i < 4; i++) {
                m_oLesJoueurs[i].Score += scoreFinal[i];
            }

            System.Windows.Forms.MessageBox.Show("SCORES\nINTERMEDIAIRE  /  PARTIE  /  FINAL\n" + m_oLesJoueurs[0].Nom + ": " + scoreInterm[0] + "     /     " + scoreFinal[0] + "     /     " + m_oLesJoueurs[0].Score + "\n" + m_oLesJoueurs[1].Nom + ": " + scoreInterm[1] + "     /     " + scoreFinal[1] + "     /     " + m_oLesJoueurs[1].Score + "\n" + m_oLesJoueurs[2].Nom + ": " + scoreInterm[2] + "     /     " + scoreFinal[2] + "     /     " + m_oLesJoueurs[2].Score + "\n" + m_oLesJoueurs[3].Nom + ": " + scoreInterm[3] + "     /     " + scoreFinal[3] + "     /     " + m_oLesJoueurs[3].Score, "Scores de la partie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int piocheTuiles(Joueur j, int nb) {
            int t = -1;
            Tuile oTuilePiochee = new Tuile();
            for (int i = 0; i < nb; i++) {
                oTuilePiochee = m_oTuilesPioche[m_iIndexPioche++];
                j.ajouteTuile(oTuilePiochee);
                m_oRepresentationJoueur[j.Numero].Tri();
                t = j.RecherchePositionTuile(oTuilePiochee);
                System.Console.Out.Write("Pioche du " + j.Main[t].Nom + "\n");
            }
            m_oRepresentationJoueur[j.Numero].Affiche();//on raifraichi le jeu du joueur
            
            m_oVuejeu.TuilePiochee();

            return t;
        }
        #endregion
    }
}
