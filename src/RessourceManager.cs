using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MahJong {
    /// <summary>
    /// Permet de gérer les images du fichier de ressource
    /// </summary>
    public class RessourceManager {
        /// <summary>
        /// Renvoi une image du fichier de ressource en fonction de sa clé
        /// </summary>
        /// <param name="sValeur">La clé</param>
        /// <returns>L'image retournée</returns>
        public static System.Drawing.Bitmap GetImage(string sValeur) {
            object obj = null;
            try {
                obj = resImages.ResourceManager.GetObject("_" + sValeur, resImages.Culture);
 
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ((System.Drawing.Bitmap)(obj));
        }

        /// <summary>
        /// Permet la rotation d'une image et la renvoi
        /// </summary>
        /// <param name="icon">Image</param>
        /// <param name="deg">Angle en degré</param>
        /// <returns>L'image resultant de la rotation</returns>
        public static System.Drawing.Image rotationIcon(System.Drawing.Image icon, int deg) {
            try {
                int w = icon.Width;
                int h = icon.Height;
                //creation d'une image vide de meme taille
                Bitmap image = new Bitmap(h, w);
                //creeation de l'objet Graphic depuis l'image vierge
                Graphics g2 = Graphics.FromImage(image);
                //Creation de la matrice de transformation
                Matrix temp_Matrix;
                temp_Matrix = new Matrix();
                //Translation pour se remettre en 0,0
                if (deg == -90) {
                    temp_Matrix.Translate(0, 40);
                } else {
                    temp_Matrix.Translate(50, 0);
                }
                //Rotation de l'image
                temp_Matrix.Rotate(deg);// At(deg, new PointF((w / 2), (h / 2)));
                //Application de la matrice à l'objet Graphic
                g2.Transform = temp_Matrix;
                g2.DrawImage(icon, 0, 0);

                icon = (Image)image.Clone();

                g2.Dispose();
                image.Dispose();
                temp_Matrix.Dispose();
                temp_Matrix = null;
                g2 = null;
                image = null;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return icon;
        }
    }
}
