using System;

namespace MahJong {
    /// <summary>
    /// Représente une Tuile
    /// </summary>
    public class Tuile {
        #region Declaration
        private int m_iChiffre;
        private char m_cCouleur;
        private string m_sNom;
        #endregion

        #region Proprietes
        /// <summary>Nom de la tuile</summary>
        public string Nom {
            get { return m_sNom; }
            set { m_sNom = value; }
        }
        /// <summary>Valeur</summary>
        public int Chiffre {
            get { return m_iChiffre; }
            set { m_iChiffre = value; }
        }
        /// <summary>Couleur</summary>
        public char Couleur {
            get { return m_cCouleur; }
            set { m_cCouleur = value; }
        }
        #endregion

        #region Constructeur
        /// <summary>Constructeur</summary>
        public Tuile() {
            m_iChiffre = 0;
            m_cCouleur = (char)(0);
            m_sNom = new System.Text.StringBuilder().ToString();
        }
        /// <summary>
        /// Constructeur à partir d'une tuile existante
        /// </summary>
        /// <param name="t"></param>
        public Tuile(Tuile t) {
            m_iChiffre = t.Chiffre;
            m_cCouleur = t.Couleur;
            m_sNom = t.Nom;
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="iChiffre">Chiffre</param>
        /// <param name="cCouleur">Couleur</param>
        /// <param name="sNom">Nom</param>
        public Tuile(int iChiffre, char cCouleur, string sNom) {
            m_iChiffre = iChiffre;
            m_cCouleur = cCouleur;
            m_sNom = sNom;
        }
        #endregion

        #region Methodes
        /// <summary>Donne l'image de fond des cartes</summary>
        /// <returns>Image de fond</returns>
        public static System.Drawing.Image donneFond() {
            return resImages.fond;
        }
        /// <summary>
        /// Donne l'image de fond des cartes à 90 degrés
        /// </summary>
        /// <returns>Image de fond</returns>
        public static System.Drawing.Image donneFond90() {
            return resImages.fond90;
        }
        /// <summary>
        /// Donne l'image de fond des cartes à 270 degrés
        /// </summary>
        /// <returns>Image de fond</returns>
        public static System.Drawing.Image donneFond270() {
            return resImages.fond270;
        }
        /// <summary>
        /// Donne l'image d'une tuile
        /// </summary>
        /// <returns>Image</returns>
        public System.Drawing.Image donneIcon() {
            string sValeur = "";
            sValeur = m_iChiffre.ToString() + m_cCouleur.ToString();
            return RessourceManager.GetImage(sValeur);
        }

        /// <summary>
        /// Retourne une valeur entière correspondant à la couleur de la tuile
        /// </summary>
        /// <returns>Valeur entière</returns>
        public int CouleurToInt() {
            int iResult;

            switch (m_cCouleur) {
                case 'b':
                    iResult = 0;
                    break;
                case 'c':
                    iResult = 1;
                    break;
                case 'r':
                    iResult = 2;
                    break;
                case 'v':
                    iResult = 3;
                    break;
                case 'd':
                    iResult = 4;
                    break;
                default:
                    iResult = 5;
                    break;
            }

            return iResult;
        }

        /// <summary>
        /// Retourne une valeur entière correspondant à la couleur de la tuile
        /// </summary>
        /// <returns>Valeur entière</returns>
        public static int CouleurToInt(char cCouleur) {
            int iResult;

            switch (cCouleur) {
                case 'b':
                    iResult = 0;
                    break;
                case 'c':
                    iResult = 1;
                    break;
                case 'r':
                    iResult = 2;
                    break;
                case 'v':
                    iResult = 3;
                    break;
                case 'd':
                    iResult = 4;
                    break;
                default:
                    iResult = 5;
                    break;
            }

            return iResult;
        }
        #endregion
    }
}