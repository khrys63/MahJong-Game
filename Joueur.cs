using System;
using System.Collections.Generic;

namespace MahJong {
    /// <summary>
    /// Représente un joueur
    /// </summary>
    public class Joueur {
        #region Declaration
        private List<Tuile> m_oMain = new List<Tuile>();
        private List<Tuile> m_oCombinaison = new List<Tuile>();

        private int m_iTuileSelect;
        private int[] m_iIndexCombi = new int[12];
        private int m_iVent;
        private int m_iNumero;
        private int m_iScore;
        private string m_sNom;

        #endregion

        #region Proprietes
        /// <summary></summary>
        public int TuileSelect {
            get { return m_iTuileSelect; }
            set { m_iTuileSelect = value; }
        }
        /// <summary>Tableau de tuile de la main</summary>
        public List<Tuile> Main {
            get { return m_oMain; }
            set { m_oMain = value; }
        }
        /// <summary>Tableau de tuile des combinaisons</summary>
        public List<Tuile> Combinaison {
            get { return m_oCombinaison; }
            set { m_oCombinaison = value; }
        }
        /// <summary></summary>
        public int[] IndexCombi {
            get { return m_iIndexCombi; }
            set { m_iIndexCombi = value; }
        }
        /// <summary>Vent du joueur</summary>
        public int Vent {
            get { return m_iVent; }
            set { m_iVent = value; }
        }
        /// <summary>Num�ro du joueur</summary>
        public int Numero {
            get { return m_iNumero; }
            set { m_iNumero = value; }
        }
        /// <summary>Score du joueur</summary>
        public int Score {
            get { return m_iScore; }
            set { m_iScore = value; }
        }
        /// <summary>Nom du joueur</summary>
        public string Nom {
            get { return m_sNom; }
            set { m_sNom = value; }
        }
        #endregion

        #region constructeur
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="i">Numéro et vent du joueur</param>
        public Joueur(int i) {
            for (int j = 0; j < 14; j++) {
                m_oMain.Add( new Tuile());
            }
            for (int j = 0; j < 24; j++) {
                m_oCombinaison.Add(new Tuile());
            }
            for (int j = 0; j < 12; j++) {
                m_iIndexCombi[j] = 0;
            }
            m_iVent = i;
            m_iNumero = i;
            m_iTuileSelect = -1;
            m_iScore = 0;
        }
        #endregion

        #region methodes

        public void ajouteCombi(Tuile[] combi, int nb) {
            int index = 0;

            /* determine le prochain espace dispo dans combinaison*/
            for (int i = 0; i < 12; i++) {
                index += m_iIndexCombi[i];
            }
            /* ajoute la combinaison */
            for (int i = 0; i < nb; i++) {
                m_oCombinaison[index] = combi[i];
                index++;
            }
            /* trouve le prochain espace vide ds indexCombi */
            index = 0;
            while (m_iIndexCombi[index] > 0) {
                index++;
            }
            /* ajoute le nb de tuile correspondant a la combi */
            m_iIndexCombi[index] = nb;
        }
        /// <summary>
        /// Recherche la position dans la main de la Tuile
        /// </summary>
        /// <param name="t">Tuile</param>
        /// <returns>Position</returns>
        public int RecherchePositionTuile(Tuile t) {
            int i = 0;
            int iReturn = 0;
            while (m_oMain[i].Couleur != 0 && i < 13) {
                i++;
            }

            for (int j = 0; j <= i; j++) {
                if ((m_oMain[j].Chiffre == t.Chiffre && m_oMain[j].Couleur == t.Couleur)) {
                    iReturn = j;
                }
            }
            return iReturn;
        }

        /// <summary>
        /// Ajoute une Tuile dans la main
        /// </summary>
        /// <param name="t">Tuile</param>
        /// <returns>Position d'ajout (la derniere de la main)</returns>
        public int ajouteTuile(Tuile t) {
            int i = 0;
            while (m_oMain[i].Couleur != 0 && i < 13) {
                i++;
            }
            if (m_oMain[i].Couleur != 0 && i == 13) {
                //si le joueur a trop de tuile c pas bon
                i = -1;
            } else {
                m_oMain[i] = t;
                //i = 0;
                //while (m_oMain[i].Chiffre != t.Chiffre || m_oMain[i].Couleur != t.Couleur) {
                //    i++;
                //}
             }
            return i;
        }
        /// <summary>
        /// Retire une tuile de la main
        /// </summary>
        /// <param name="i">la position de la Tuile à retirer</param>
        /// <returns>Tuile retirée</returns>
        public Tuile retireTuile(int i) {
            Tuile t = new Tuile(m_oMain[i]);
            m_oMain[i] = new Tuile();
            return t;
        }
        /// <summary>
        /// Retire une Tuile de la main
        /// </summary>
        /// <param name="t">Tuile à retirée</param>
        public void retireTuile(Tuile t) {
            int i = 0;
            while (m_oMain[i].Chiffre != t.Chiffre || m_oMain[i].Couleur != t.Couleur && i < 14) {
                i++;
            }
            if (i < 14) {
                m_oMain[i] = new Tuile();
            }
        }

        /// <summary> retourne la place de la prochaine fleur ou saison
        /// -1 si pas de fleur
        /// </summary>
        public int aHonneur() {
            for (int i = 0; i < 14; i++) {
                if ((m_oMain[i].Couleur == 's') || (m_oMain[i].Couleur == 'f')) {
                    return i;
                }
            }
            return -1;
        }

        /// <summary> Permet de faire déclarer à un joueur les fleurs et les saison qu'il a dans sa main
        /// Place ses fleurs et saison dans la zone de combinaison
        /// Renvoi le nombre de tuile déclarées
        /// </summary>
        public int DeclareHonneur() {
            Tuile[] combi = new Tuile[4];
            int index = 0;
            int nb_tuile = 0;

            /* initialise la nouvelle combinaison */
            for (int i = 0; i < 4; i++) {
                combi[i] = new Tuile();
            }

            //Pour chaque honneur que le joueur possède, ajoute ce dernier 
            //aux combinaison et affiche la nouvelle combinaison
            while (aHonneur() >= 0) {
                index = aHonneur();
                combi[0] = m_oMain[index];
                m_oMain[index] = new Tuile();
                ajouteCombi(combi, 1);
                nb_tuile++;
            }
            return nb_tuile;
        }

        /// <summary> Retourne le nombre de kong caché</summary>
        public int aKong() {
            int iNbPieceIdentique = 0, iNbKong = 0;
            for (int i = 0; i < 13; i++) {
                if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                    iNbPieceIdentique++;
                    if (iNbPieceIdentique == 3) {
                        iNbKong++;
                        iNbPieceIdentique = 0;
                    }
                } else {
                    iNbPieceIdentique = 0;
                }
            }

            return iNbKong;
        }
        /// <summary> Retourne le nombre de kong caché et leurs Tuiles</summary>
        public int aKong(string sNom) {
            int iNbPieceIdentique = 0, iNbKong = 0;
            for (int i = 0; i < 13; i++) {
                if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                    iNbPieceIdentique++;
                    if (iNbPieceIdentique == 3) {
                        sNom = m_oMain[i].Nom;
                        iNbKong++;
                        iNbPieceIdentique = 0;
                    }
                } else {
                    iNbPieceIdentique = 0;
                }
            }

            return iNbKong;
        }
        /// <summary> Retourne le nombre de kong caché et leurs Tuiles</summary>
        public int aKong(Tuile[] oTuile) {
            int iNbPieceIdentique = 0, iNbKong = 0;
            for (int i = 0; i < 13; i++) {
                if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                    iNbPieceIdentique++;
                    if (iNbPieceIdentique == 3) {
                        oTuile[iNbKong] = new Tuile(m_oMain[i]);
                        iNbKong++;
                        iNbPieceIdentique = 0;
                    }
                } else {
                    iNbPieceIdentique = 0;
                }
            }

            return iNbKong;
        }
        /// <summary> Retourne le nombre de pung caché et leur nom</summary>
        public int aPung(Tuile[] oTuile) {
            int iNbPieceIdentique = 0, iNbPung = 0;
            for (int i = 0; i < 13; i++) {
                if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                    iNbPieceIdentique++;
                } else {
                    if (iNbPieceIdentique == 2) {
                        //la combi précédente était un pung
                        oTuile[iNbPung] = new Tuile(m_oMain[i]);
                        iNbPung++;
                    }
                    iNbPieceIdentique = 0;
                }
            }

            return iNbPung;
        }
        /// <summary> Retourne le nombre de pung caché et leur nom</summary>
        public int aPung(System.Text.StringBuilder[] k) {
            int cpt = 0, iNbPung = 0;
            for (int i = 0; i < 13; i++) {
                if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                    cpt++;
                } else {
                    if (cpt == 2) {
                        //la combi précédente était un pung
                        if (k != null) {
                            k[iNbPung].Append(m_oMain[i - 1].Nom);
                        }
                        iNbPung++;
                    }
                    cpt = 0;
                }
            }

            return iNbPung;
        }

        /// <summary>
        /// Retourne si le jeu est pur
        /// </summary>
        /// <returns>Resultat</returns>
        private bool aJeuPur() {
            bool estPur = false;
            char typePur = ' ';
            int i = 0, index = 0;
            Tuile t = new Tuile();

            //recherche dans les combinaisons
            while (m_iIndexCombi[i] > 0) {
                t = m_oCombinaison[index];
                if (t.Couleur == 'c' || t.Couleur == 'b' || t.Couleur == 'r') {
                    if (typePur != ' ' && typePur != t.Couleur) {
                        estPur = false;		// alors ce n'est pas un jeu pur
                    }
                    typePur = t.Couleur;
                }
                index += m_iIndexCombi[i];
                i++;
            }

            //recherche dans la main
            for (int j = 0; i < 13; i++) {
                if ((m_oMain[j].Chiffre != 0) && (m_oMain[j].Couleur == 'c' || m_oMain[j].Couleur == 'b' || m_oMain[j].Couleur == 'r')) {
                    /* si le type pur a déja été défini et qu'il est different du type de la combi */
                    if (typePur != ' ' && typePur != m_oMain[j].Couleur) {
                        estPur = false;		// alors ce n'est pas un jeu pur
                    }
                    typePur = m_oMain[j].Couleur;
                }
            }
            return estPur;
        }

        /// <summary> Retourne le nombre de pung caché et leur nom</summary>
        public int aPaire() {
            int iNdPieceIdentique = 0, iNbPaire = 0;
            for (int i = 0; i < 13; i++) {
                if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                    iNdPieceIdentique++;
                } else {
                    if (iNdPieceIdentique == 1) {
                        //la combi précédente était une paire
                        //elle ne compte que si c'est une paire de dragon ou de son propre vent
                        //TODO: Gestion des paires de vent de la partie
                        if (m_oMain[i - 1].Couleur == 'd' || (m_oMain[i - 1].Couleur == 'v' && m_oMain[i - 1].Chiffre == (m_iVent + 1))) {
                            iNbPaire++;
                        }
                    }
                    iNdPieceIdentique = 0;
                }
            }

            return iNbPaire;
        }

        public void DeclareKong(string sNom) {
            Tuile[] combi = new Tuile[4];
            int cpt = 0;

            for (int i = 0; i < 14; i++) {
                if (m_oMain[i].Nom == sNom) {
                    combi[cpt] = new Tuile(m_oMain[i]);
                    m_oMain[i] = new Tuile();
                    cpt++;
                }
                //if (String.CompareOrdinal(m_oMain[i].Nom, k.ToString()) == 0) {
                //    combi[cpt] = new Tuile(m_oMain[i]);
                //    m_oMain[i] = new Tuile();
                //    cpt++;
                //}
            }
            ajouteCombi(combi, 4);
        }

        public bool aMahjong() {
            int cpt = 0, nbCombi1 = 0, nbCombi2 = 0;
            System.String[] combi = new System.String[4];
            bool kongSeul = true, vraiePaire;

            for (int i = 0; i < 4; i++) {
                combi[i] = new System.Text.StringBuilder().ToString();
            }
            /* compte les combi kong/pung dans les combinaison */
            for (int i = 0; i < 12; i++) {
                if (m_iIndexCombi[i] > 1) {
                    nbCombi1++;
                }
            }
            /* Avec 4 combi exposé, il ne reste que 2 tuiles dans le main */
            if (nbCombi1 == 4) {
                if ((m_oMain[0].Chiffre == m_oMain[1].Chiffre) && (m_oMain[0].Couleur == m_oMain[1].Couleur)) {
                    return true; /* si c'est une paire: Mahjong */
                }
            }

            /* Recherche les combinaisons cachée dans le main */
            for (int i = 0; i < 13; i++) {
                if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                    cpt++;
                    if (cpt == 2) {
                        /* à partir de 3 tuile c'est une combi */
                        combi[nbCombi2] = m_oMain[i].Nom;
                        nbCombi2++;
                    }
                } else {
                    if (cpt == 2) {
                        /*la combi précédente était just un pung */
                        kongSeul = false; //ce n'est pas un mahjong kong caché pur
                    }
                    cpt = 0;
                }
            }

            /* Avec 4 combi (ou 3 kong caché), mahjong possible, donc cherche une paire */
            if ((nbCombi1 + nbCombi2 == 4) || (nbCombi2 == 3 && kongSeul == true)) {
                for (int i = 0; i < 13; i++) {
                    if ((m_oMain[i].Chiffre == m_oMain[i + 1].Chiffre) && (m_oMain[i].Chiffre != 0) && (m_oMain[i].Couleur == m_oMain[i + 1].Couleur) && (m_oMain[i].Couleur != 0)) {
                        vraiePaire = true;
                        for (int j = 0; j < 4; j++) {
                            if (String.CompareOrdinal(combi[j], m_oMain[i].Nom) == 0) {
                                vraiePaire = false;
                            }
                        }
                        if (vraiePaire) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool peutMahjong(Tuile t) {
            bool result = false;
            int i = 0;

            if ((i = ajouteTuile(t)) >= 0) {
                if (aMahjong()) {
                    result = true;
                } else {
                    result = false;
                }
                retireTuile(i);
            }
            return result;
        }
        /// <summary> retourne true si le joueur a au moins 2 tuiles identiques à celle passée
        /// en paramètre
        /// </summary>
        public bool peutPrendre(Tuile t) {
            int iNbTuileIdentique = 0;
            bool bResult = false;
            if (t.Chiffre != 0) {
                for (int i = 0; i <= 13; i++) {
                    if (m_oMain[i].Chiffre != 0 && m_oMain[i].Chiffre == t.Chiffre && m_oMain[i].Couleur == t.Couleur) {
                        iNbTuileIdentique++;
                    }
                    ///* si 2 tuiles sont semblables à celle proposée */
                    //if (m_oMain[i].Chiffre == t.Chiffre && m_oMain[i].Couleur == t.Couleur && m_oMain[i + 1].Chiffre == t.Chiffre && m_oMain[i + 1].Couleur == t.Couleur) {
                    //    return true; /* alors le joueur peut la prendre */
                    //}
                }
                if (iNbTuileIdentique>1){
                    bResult=true;
                }
                if (peutMahjong(t)) {
                    bResult = true;
                }
            }
            return bResult;
        }

        public int scorePartie(bool estGagnant) {
            int score = 0, multi = 0;
            int i = 0, index = 0;
            Tuile t = new Tuile();

            /* calcul des points des combinaisons */
            while (m_iIndexCombi[i] > 0) {
                t = m_oCombinaison[index];
                score += combiScore(t, m_iIndexCombi[i], false);
                multi += combiMulti(t);
                index += m_iIndexCombi[i];
                i++;
            }

            /* calcul des points de la main */
            Tuile[] TuileMain = new Tuile[4];
            // si le joueur a des kong cachés
            if ((index = aKong(TuileMain)) > 0) {
                for (i = 0; i < index; i++) {
                    score += combiScore(TuileMain[i], 4, true);
                    multi += combiMulti(TuileMain[i]);
                }
            }
            // si le joueur a des pung cachés
            if ((index = aPung(TuileMain)) > 0) {
                for (i = 0; i < index; i++) {
                    score += combiScore(TuileMain[i], 3, true);
                    multi += combiMulti(TuileMain[i]);
                }
            }
            //on ajoute 2 point par paires (dragon et vent) cachées
            score += (aPaire() * 2);

            /* si le joueur a fait mahjong, +20pts*/
            if (estGagnant == true) {
                score += 20;
                /* trois doubles pour un jeu pur gagnant */
                if (aJeuPur()) {
                    multi += 3;
                }
            }

            return (int)(score * System.Math.Pow(2, multi));
        }

        public int combiScore(Tuile t, int nb, bool cache) {
            int score = 0;
            //TODO:Ajout de la paire de son vent et de la paire de dragon
            switch (t.Couleur) {

                case 'f':
                case 's':
                    score = 4; //fleur/saison : 4pts
                    break;

                case 'v':
                case 'd':
                    if (nb == 3) {
                        score = 8; //pung dragon/vent : 8pts
                    } else if (nb == 4) {
                        score = 16; //kong dragon/vent : 16pts
                    }
                    break;

                case 'c':
                case 'r':
                case 'b':
                    if (t.Chiffre == 1 || t.Chiffre == 9) {
                        if (nb == 3) {
                            score = 4; // pung de 1/9 rond/bamboo/caractères : 8pts
                        } else if (nb == 4) {
                            score = 16; // kong de 1/9 rond/bamboo/caractères : 16pts
                        }
                    } else {
                        if (nb == 3) {
                            score = 2; // pung de autre rond/bamboo/caractères : 4pts
                        } else if (nb == 4) {
                            score = 8; // kong de autre rond/bamboo/caractères : 8pts
                        }
                    }
                    break;

                default:
                    break;

            }
            if (cache == true) {
                score *= 2; //double le score si combi cachée
            }
            return score;
        }

        public int combiMulti(Tuile t) {
            int multi = 0;
            if (t.Couleur == 'd') {
                // un double pour une combi de dragon
                multi += 1;
            }
            if ((t.Couleur == 'v' || t.Couleur == 'f' || t.Couleur == 's') && t.Chiffre == (m_iVent + 1)) {
                multi += 1; // un double pour sa saison/fleur ou une combi de son vent 
            }
            //TODO:Ajout du multi si la meme couleur
            return multi;
        }

        //public int combiPaire(Tuile t,int nb) {
        //    int iPaire = 0;
        //    if (nb == 2) {
        //        if (t.Couleur == 'd') {
        //            // deux point pour une paire de dragon
        //            iPaire =2;
        //        }
        //        if ((t.Couleur == 'v') && t.Chiffre == (m_iVent + 1)) {
        //            iPaire = 2; // deux point pour une paire de son vent
        //        }
        //    }

        //    return iPaire;
        //}
        //public int combiMonoCouleur() {
        //    int iMulti = 0;
        //    int iPresenceBambou = 0;
        //    int iPresenCarac = 0;
        //    int iPresenRond = 0;
        //    Tuile t = new Tuile();
        //    int i = 0;
        //    while (m_iIndexCombi[i] > 0) {
        //        t = m_oCombinaison[i];
        //        switch (t.Couleur) {
        //            case 'b':
        //                iPresenceBambou=1;
        //                break;
        //            case 'c':
        //                iPresenCarac=1;
        //                break;
        //            case 'r':
        //                iPresenRond=1;
        //                break;
        //            default:
        //                break;
        //        }
        //        i++;
        //    }
        //    if (iPresenceBambou + iPresenCarac + iPresenRond <= 1) {
        //        iMulti = 3;
        //    }
        //    t = null;
        //    return iMulti;
        //}

        #endregion
    }
}