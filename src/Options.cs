using System;
using System.Collections.Generic;
using System.Text;

namespace MahJong {
    /// <summary>
    /// Gestionnaire des options
    /// [SINGLETON]
    /// </summary>
    public class Options {
        #region Declaration
        private bool montreJeu = false;
        private string m_sNomJoueur1 = "Joueur 1";
        private string m_sNomJoueur2 = "Joueur 2";
        private string m_sNomJoueur3 = "Joueur 3";
        private string m_sNomJoueur4 = "Joueur 4";

        private static Options m_oOption;
        #endregion

        #region Constructeur
        /// <summary>Constructeur privé</summary>
        private Options() { }
        #endregion

        #region Methodes Static
        /// <summary>
        /// Retourne le gestionnaire des options
        /// </summary>
        /// <returns>L'instance</returns>
        public static Options GetOptions() {
            if (m_oOption == null) {
                m_oOption = new Options();
            }
            return m_oOption;
        }
        #endregion

        #region Propriétés
        /// <summary>Doit-on afficher les tuiles?</summary>
        public bool MontreJeu {
            get { return montreJeu; }
            set { montreJeu = value; }
        }
        /// <summary>Nom du joueur 1</summary>
        public string NomJoueur1 {
            get { return m_sNomJoueur1; }
            set { m_sNomJoueur1 = value; }
        }
        /// <summary>Nom du joueur 2</summary>
        public string NomJoueur2 {
            get { return m_sNomJoueur2; }
            set { m_sNomJoueur2 = value; }
        }
        /// <summary>Nom du joueur 3</summary>
        public string NomJoueur3 {
            get { return m_sNomJoueur3; }
            set { m_sNomJoueur3 = value; }
        }
        /// <summary>Nom du joueur 4</summary>
        public string NomJoueur4 {
            get { return m_sNomJoueur4; }
            set { m_sNomJoueur4 = value; }
        }

        #endregion

    }
}
