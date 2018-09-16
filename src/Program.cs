using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MahJong {
    public static class Program {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        public static void Main() {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmPrinc());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Erreur...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
