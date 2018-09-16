using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MahJong {
    public interface IMahjong {
        /// <summary>une tuile a été piochée</summary>
        void TuilePiochee();
        /// <summary>Une tuile a été défaussée il faut l'afficher</summary>
        /// <param name="img">Image de la tuile</param>
        void MontrerTuileDefaussee(Image img);
        /// <summary>Il faut monter qui doit jouer</summary>
        void MontreAQuiDeJouer();
        /// <summary>Retourne le bouton Jouer</summary>
        Button BtnJouer { get;}
        /// <summary>Retourne le bouton Declarer</summary>
        Button BtnDeclarer { get;}
        /// <summary>Retourne le bouton Prendre</summary>
        Button BtnPrendre { get;}
    }
}
