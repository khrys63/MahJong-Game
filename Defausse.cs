using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MahJong {
        public delegate void AfficherTuilesDefaussees();
    /// <summary>
    /// Classe représentant les tuiles défaussées en cours de partie
    /// [SINGLETON]
    /// </summary>
    public class Defausse {


        #region Declaration
        private static Defausse m_oDefausse;
        private int[,] tableau = new int[9,6];
        private IDefausse m_oVue;

        #endregion

        public IDefausse Vue {
            get { return m_oVue; }
            set { m_oVue = value; }
        }

        #region Constructeur
        private Defausse() {

            init();
        }
        #endregion

        #region Methode static
        /// <summary>
        /// Renvoi un objet Defausse
        /// </summary>
        /// <returns>Une defausse</returns>
        public static Defausse getDefausse() {
            if (m_oDefausse == null) {
                m_oDefausse = new Defausse();
            }
            return m_oDefausse;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// RAZ du tableau
        /// </summary>
        public void init() {
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 6; j++) {
                    tableau[i,j] = 0;
                }
            }
        }

        /// <summary>
        /// Ajout d'une tuile à la défausse
        /// </summary>
        /// <param name="t">La tuile defaussée</param>
        public void add(Tuile t) {
            tableau[t.Chiffre - 1,t.CouleurToInt()] += 1;
            if (m_oVue!=null){
                m_oVue.AfficherTuilesDefaussees();
            }
        }

        //public void affiche(Tuile[] main) {
            //for(int i=0; i<14; i++){
            //    if(main[i].Chiffre == 0 || main[i].Couleur == 0){
            //        labelDiscard[i].setText("");
            //    }
            //    else{
            //        if(Main.montreDiscard){
            //            labelDiscard[i].setText(""+tableau[main[i].chiffre-1][couleurToInt(main[i].couleur)]);
            //        }
            //        else{
            //            labelDiscard[i].setText("");
            //        }
            //    }
            //}
        //}

        /// <summary>
        /// Retourne le nombre de tuile jetée
        /// </summary>
        /// <param name="t">Tuile</param>
        /// <returns>Resultat</returns>
        public int nbJet(Tuile t) {
            return tableau[t.Chiffre - 1,t.CouleurToInt()];
        }
        /// <summary>
        /// Retourne le nombre de tuile jetée
        /// </summary>
        /// <param name="t">Tuile</param>
        /// <returns>Resultat</returns>
        public int nbJet(int iChiffre, char cCouleur) {
            return tableau[iChiffre - 1, Tuile.CouleurToInt(cCouleur)];
        }
        #endregion
    }
}
