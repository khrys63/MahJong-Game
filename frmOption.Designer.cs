namespace MahJong {
    partial class frmOption {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.chkOption = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtNom1 = new System.Windows.Forms.TextBox();
            this.txtNom2 = new System.Windows.Forms.TextBox();
            this.txtNom3 = new System.Windows.Forms.TextBox();
            this.txtNom4 = new System.Windows.Forms.TextBox();
            this.lblNom1 = new System.Windows.Forms.Label();
            this.lblNom2 = new System.Windows.Forms.Label();
            this.lblNom3 = new System.Windows.Forms.Label();
            this.lblNom4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkOption
            // 
            this.chkOption.AutoSize = true;
            this.chkOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOption.Location = new System.Drawing.Point(90, 12);
            this.chkOption.Name = "chkOption";
            this.chkOption.Size = new System.Drawing.Size(188, 17);
            this.chkOption.TabIndex = 0;
            this.chkOption.Text = "Afficher le jeu des autres joueurs : ";
            this.chkOption.UseVisualStyleBackColor = true;
            this.chkOption.CheckedChanged += new System.EventHandler(this.chkOption_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(213, 139);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(65, 26);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNom1
            // 
            this.txtNom1.Location = new System.Drawing.Point(159, 35);
            this.txtNom1.Name = "txtNom1";
            this.txtNom1.Size = new System.Drawing.Size(119, 20);
            this.txtNom1.TabIndex = 2;
            // 
            // txtNom2
            // 
            this.txtNom2.Location = new System.Drawing.Point(159, 61);
            this.txtNom2.Name = "txtNom2";
            this.txtNom2.Size = new System.Drawing.Size(119, 20);
            this.txtNom2.TabIndex = 3;
            // 
            // txtNom3
            // 
            this.txtNom3.Location = new System.Drawing.Point(159, 87);
            this.txtNom3.Name = "txtNom3";
            this.txtNom3.Size = new System.Drawing.Size(119, 20);
            this.txtNom3.TabIndex = 4;
            // 
            // txtNom4
            // 
            this.txtNom4.Location = new System.Drawing.Point(159, 113);
            this.txtNom4.Name = "txtNom4";
            this.txtNom4.Size = new System.Drawing.Size(119, 20);
            this.txtNom4.TabIndex = 5;
            // 
            // lblNom1
            // 
            this.lblNom1.AutoSize = true;
            this.lblNom1.Location = new System.Drawing.Point(62, 38);
            this.lblNom1.Name = "lblNom1";
            this.lblNom1.Size = new System.Drawing.Size(91, 13);
            this.lblNom1.TabIndex = 6;
            this.lblNom1.Text = "Nom du joueur 1 :";
            // 
            // lblNom2
            // 
            this.lblNom2.AutoSize = true;
            this.lblNom2.Location = new System.Drawing.Point(62, 64);
            this.lblNom2.Name = "lblNom2";
            this.lblNom2.Size = new System.Drawing.Size(91, 13);
            this.lblNom2.TabIndex = 7;
            this.lblNom2.Text = "Nom du joueur 2 :";
            // 
            // lblNom3
            // 
            this.lblNom3.AutoSize = true;
            this.lblNom3.Location = new System.Drawing.Point(62, 90);
            this.lblNom3.Name = "lblNom3";
            this.lblNom3.Size = new System.Drawing.Size(91, 13);
            this.lblNom3.TabIndex = 8;
            this.lblNom3.Text = "Nom du joueur 3 :";
            // 
            // lblNom4
            // 
            this.lblNom4.AutoSize = true;
            this.lblNom4.Location = new System.Drawing.Point(62, 116);
            this.lblNom4.Name = "lblNom4";
            this.lblNom4.Size = new System.Drawing.Size(91, 13);
            this.lblNom4.TabIndex = 9;
            this.lblNom4.Text = "Nom du joueur 4 :";
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 176);
            this.Controls.Add(this.lblNom4);
            this.Controls.Add(this.lblNom3);
            this.Controls.Add(this.lblNom2);
            this.Controls.Add(this.lblNom1);
            this.Controls.Add(this.txtNom4);
            this.Controls.Add(this.txtNom3);
            this.Controls.Add(this.txtNom2);
            this.Controls.Add(this.txtNom1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOption";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOption;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtNom1;
        private System.Windows.Forms.TextBox txtNom2;
        private System.Windows.Forms.TextBox txtNom3;
        private System.Windows.Forms.TextBox txtNom4;
        private System.Windows.Forms.Label lblNom1;
        private System.Windows.Forms.Label lblNom2;
        private System.Windows.Forms.Label lblNom3;
        private System.Windows.Forms.Label lblNom4;
    }
}