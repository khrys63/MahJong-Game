namespace MahJong {
    partial class frmPrinc {
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJouer = new System.Windows.Forms.Button();
            this.btnDeclarer = new System.Windows.Forms.Button();
            this.btnPrendre = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblDiscard = new System.Windows.Forms.Label();
            this.lblJoueur3 = new System.Windows.Forms.Label();
            this.lblJoueur1 = new System.Windows.Forms.Label();
            this.lblJoueur2 = new System.Windows.Forms.Label();
            this.lblJoueur4 = new System.Windows.Forms.Label();
            this.lblReste = new System.Windows.Forms.Label();
            this.frmDefausse = new System.Windows.Forms.GroupBox();
            this.lbTuileDefausse = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl1b = new System.Windows.Forms.Label();
            this.lbl2b = new System.Windows.Forms.Label();
            this.lbl3b = new System.Windows.Forms.Label();
            this.lbl4b = new System.Windows.Forms.Label();
            this.lbl5b = new System.Windows.Forms.Label();
            this.lbl6b = new System.Windows.Forms.Label();
            this.lbl7b = new System.Windows.Forms.Label();
            this.lbl8b = new System.Windows.Forms.Label();
            this.lbl9b = new System.Windows.Forms.Label();
            this.lbl3d = new System.Windows.Forms.Label();
            this.lbl2d = new System.Windows.Forms.Label();
            this.lbl1d = new System.Windows.Forms.Label();
            this.lbl9r = new System.Windows.Forms.Label();
            this.lbl8r = new System.Windows.Forms.Label();
            this.lbl7r = new System.Windows.Forms.Label();
            this.lbl6r = new System.Windows.Forms.Label();
            this.lbl5r = new System.Windows.Forms.Label();
            this.lbl4r = new System.Windows.Forms.Label();
            this.lbl3r = new System.Windows.Forms.Label();
            this.lbl2r = new System.Windows.Forms.Label();
            this.lbl1r = new System.Windows.Forms.Label();
            this.lbl2v = new System.Windows.Forms.Label();
            this.lbl3v = new System.Windows.Forms.Label();
            this.lbl4v = new System.Windows.Forms.Label();
            this.lbl1v = new System.Windows.Forms.Label();
            this.lbl9c = new System.Windows.Forms.Label();
            this.lbl8c = new System.Windows.Forms.Label();
            this.lbl7c = new System.Windows.Forms.Label();
            this.lbl6c = new System.Windows.Forms.Label();
            this.lbl5c = new System.Windows.Forms.Label();
            this.lbl4c = new System.Windows.Forms.Label();
            this.lbl3c = new System.Windows.Forms.Label();
            this.lbl2c = new System.Windows.Forms.Label();
            this.lbl1c = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.frmDefausse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.aProposToolStripMenuItem.Text = "A propos...";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // btnJouer
            // 
            this.btnJouer.Enabled = false;
            this.btnJouer.Location = new System.Drawing.Point(249, 519);
            this.btnJouer.Name = "btnJouer";
            this.btnJouer.Size = new System.Drawing.Size(77, 22);
            this.btnJouer.TabIndex = 1;
            this.btnJouer.Text = "Jouer";
            this.btnJouer.UseVisualStyleBackColor = true;
            this.btnJouer.Click += new System.EventHandler(this.btnJouer_Click);
            // 
            // btnDeclarer
            // 
            this.btnDeclarer.Enabled = false;
            this.btnDeclarer.Location = new System.Drawing.Point(332, 519);
            this.btnDeclarer.Name = "btnDeclarer";
            this.btnDeclarer.Size = new System.Drawing.Size(77, 22);
            this.btnDeclarer.TabIndex = 2;
            this.btnDeclarer.Text = "Declarer";
            this.btnDeclarer.UseVisualStyleBackColor = true;
            this.btnDeclarer.Click += new System.EventHandler(this.btnDeclarer_Click);
            // 
            // btnPrendre
            // 
            this.btnPrendre.Enabled = false;
            this.btnPrendre.Location = new System.Drawing.Point(415, 519);
            this.btnPrendre.Name = "btnPrendre";
            this.btnPrendre.Size = new System.Drawing.Size(77, 22);
            this.btnPrendre.TabIndex = 3;
            this.btnPrendre.Text = "Prendre";
            this.btnPrendre.UseVisualStyleBackColor = true;
            this.btnPrendre.Click += new System.EventHandler(this.btnPrendre_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDiscard
            // 
            this.lblDiscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblDiscard.Location = new System.Drawing.Point(417, 130);
            this.lblDiscard.Name = "lblDiscard";
            this.lblDiscard.Size = new System.Drawing.Size(40, 50);
            this.lblDiscard.TabIndex = 4;
            // 
            // lblJoueur3
            // 
            this.lblJoueur3.AutoSize = true;
            this.lblJoueur3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblJoueur3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueur3.Location = new System.Drawing.Point(125, 24);
            this.lblJoueur3.Name = "lblJoueur3";
            this.lblJoueur3.Size = new System.Drawing.Size(56, 13);
            this.lblJoueur3.TabIndex = 5;
            this.lblJoueur3.Text = "Joueur 3";
            // 
            // lblJoueur1
            // 
            this.lblJoueur1.AutoSize = true;
            this.lblJoueur1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblJoueur1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueur1.Location = new System.Drawing.Point(744, 634);
            this.lblJoueur1.Name = "lblJoueur1";
            this.lblJoueur1.Size = new System.Drawing.Size(56, 13);
            this.lblJoueur1.TabIndex = 6;
            this.lblJoueur1.Text = "Joueur 1";
            // 
            // lblJoueur2
            // 
            this.lblJoueur2.AutoSize = true;
            this.lblJoueur2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblJoueur2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueur2.Location = new System.Drawing.Point(874, 34);
            this.lblJoueur2.Name = "lblJoueur2";
            this.lblJoueur2.Size = new System.Drawing.Size(56, 13);
            this.lblJoueur2.TabIndex = 7;
            this.lblJoueur2.Text = "Joueur 2";
            // 
            // lblJoueur4
            // 
            this.lblJoueur4.AutoSize = true;
            this.lblJoueur4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblJoueur4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueur4.Location = new System.Drawing.Point(27, 34);
            this.lblJoueur4.Name = "lblJoueur4";
            this.lblJoueur4.Size = new System.Drawing.Size(56, 13);
            this.lblJoueur4.TabIndex = 8;
            this.lblJoueur4.Text = "Joueur 4";
            // 
            // lblReste
            // 
            this.lblReste.AutoSize = true;
            this.lblReste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblReste.Location = new System.Drawing.Point(249, 500);
            this.lblReste.Name = "lblReste";
            this.lblReste.Size = new System.Drawing.Size(87, 13);
            this.lblReste.TabIndex = 9;
            this.lblReste.Text = "Tuiles restantes :";
            // 
            // frmDefausse
            // 
            this.frmDefausse.Controls.Add(this.lbl2v);
            this.frmDefausse.Controls.Add(this.lbl3v);
            this.frmDefausse.Controls.Add(this.lbl4v);
            this.frmDefausse.Controls.Add(this.lbl1v);
            this.frmDefausse.Controls.Add(this.lbl9c);
            this.frmDefausse.Controls.Add(this.lbl8c);
            this.frmDefausse.Controls.Add(this.lbl7c);
            this.frmDefausse.Controls.Add(this.lbl6c);
            this.frmDefausse.Controls.Add(this.lbl5c);
            this.frmDefausse.Controls.Add(this.lbl4c);
            this.frmDefausse.Controls.Add(this.lbl3c);
            this.frmDefausse.Controls.Add(this.lbl2c);
            this.frmDefausse.Controls.Add(this.lbl1c);
            this.frmDefausse.Controls.Add(this.lbl9r);
            this.frmDefausse.Controls.Add(this.lbl8r);
            this.frmDefausse.Controls.Add(this.lbl7r);
            this.frmDefausse.Controls.Add(this.lbl6r);
            this.frmDefausse.Controls.Add(this.lbl5r);
            this.frmDefausse.Controls.Add(this.lbl4r);
            this.frmDefausse.Controls.Add(this.lbl3r);
            this.frmDefausse.Controls.Add(this.lbl2r);
            this.frmDefausse.Controls.Add(this.lbl1r);
            this.frmDefausse.Controls.Add(this.lbl1d);
            this.frmDefausse.Controls.Add(this.lbl2d);
            this.frmDefausse.Controls.Add(this.lbl3d);
            this.frmDefausse.Controls.Add(this.lbl9b);
            this.frmDefausse.Controls.Add(this.lbl8b);
            this.frmDefausse.Controls.Add(this.lbl7b);
            this.frmDefausse.Controls.Add(this.lbl6b);
            this.frmDefausse.Controls.Add(this.lbl5b);
            this.frmDefausse.Controls.Add(this.lbl4b);
            this.frmDefausse.Controls.Add(this.lbl3b);
            this.frmDefausse.Controls.Add(this.lbl2b);
            this.frmDefausse.Controls.Add(this.lbl1b);
            this.frmDefausse.Controls.Add(this.lbTuileDefausse);
            this.frmDefausse.Controls.Add(this.pictureBox7);
            this.frmDefausse.Controls.Add(this.pictureBox6);
            this.frmDefausse.Controls.Add(this.pictureBox3);
            this.frmDefausse.Controls.Add(this.pictureBox2);
            this.frmDefausse.Controls.Add(this.lblDiscard);
            this.frmDefausse.Controls.Add(this.pictureBox1);
            this.frmDefausse.ForeColor = System.Drawing.Color.Black;
            this.frmDefausse.ImeMode = System.Windows.Forms.ImeMode.On;
            this.frmDefausse.Location = new System.Drawing.Point(226, 238);
            this.frmDefausse.Name = "frmDefausse";
            this.frmDefausse.Size = new System.Drawing.Size(485, 201);
            this.frmDefausse.TabIndex = 10;
            this.frmDefausse.TabStop = false;
            this.frmDefausse.Text = "Tuiles défaussées";
            // 
            // lbTuileDefausse
            // 
            this.lbTuileDefausse.AutoSize = true;
            this.lbTuileDefausse.Location = new System.Drawing.Point(401, 106);
            this.lbTuileDefausse.Name = "lbTuileDefausse";
            this.lbTuileDefausse.Size = new System.Drawing.Size(79, 13);
            this.lbTuileDefausse.TabIndex = 11;
            this.lbTuileDefausse.Text = "Dernière Tuile :";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::MahJong.resImages.dragons_tiles;
            this.pictureBox7.Location = new System.Drawing.Point(284, 81);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(92, 38);
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::MahJong.resImages.wind_tiles;
            this.pictureBox6.Location = new System.Drawing.Point(284, 19);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(122, 38);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MahJong.resImages.bamboo_tiles;
            this.pictureBox3.Location = new System.Drawing.Point(6, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(272, 38);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MahJong.resImages.characters_tiles;
            this.pictureBox2.Location = new System.Drawing.Point(6, 142);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(272, 38);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MahJong.resImages.ball_tiles;
            this.pictureBox1.Location = new System.Drawing.Point(6, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 38);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl1b
            // 
            this.lbl1b.AutoSize = true;
            this.lbl1b.Location = new System.Drawing.Point(14, 60);
            this.lbl1b.Name = "lbl1b";
            this.lbl1b.Size = new System.Drawing.Size(13, 13);
            this.lbl1b.TabIndex = 12;
            this.lbl1b.Text = "0";
            // 
            // lbl2b
            // 
            this.lbl2b.AutoSize = true;
            this.lbl2b.Location = new System.Drawing.Point(44, 60);
            this.lbl2b.Name = "lbl2b";
            this.lbl2b.Size = new System.Drawing.Size(13, 13);
            this.lbl2b.TabIndex = 13;
            this.lbl2b.Text = "0";
            // 
            // lbl3b
            // 
            this.lbl3b.AutoSize = true;
            this.lbl3b.Location = new System.Drawing.Point(74, 60);
            this.lbl3b.Name = "lbl3b";
            this.lbl3b.Size = new System.Drawing.Size(13, 13);
            this.lbl3b.TabIndex = 14;
            this.lbl3b.Text = "0";
            // 
            // lbl4b
            // 
            this.lbl4b.AutoSize = true;
            this.lbl4b.Location = new System.Drawing.Point(105, 60);
            this.lbl4b.Name = "lbl4b";
            this.lbl4b.Size = new System.Drawing.Size(13, 13);
            this.lbl4b.TabIndex = 15;
            this.lbl4b.Text = "0";
            // 
            // lbl5b
            // 
            this.lbl5b.AutoSize = true;
            this.lbl5b.Location = new System.Drawing.Point(134, 60);
            this.lbl5b.Name = "lbl5b";
            this.lbl5b.Size = new System.Drawing.Size(13, 13);
            this.lbl5b.TabIndex = 16;
            this.lbl5b.Text = "0";
            // 
            // lbl6b
            // 
            this.lbl6b.AutoSize = true;
            this.lbl6b.Location = new System.Drawing.Point(164, 60);
            this.lbl6b.Name = "lbl6b";
            this.lbl6b.Size = new System.Drawing.Size(13, 13);
            this.lbl6b.TabIndex = 17;
            this.lbl6b.Text = "0";
            // 
            // lbl7b
            // 
            this.lbl7b.AutoSize = true;
            this.lbl7b.Location = new System.Drawing.Point(195, 60);
            this.lbl7b.Name = "lbl7b";
            this.lbl7b.Size = new System.Drawing.Size(13, 13);
            this.lbl7b.TabIndex = 18;
            this.lbl7b.Text = "0";
            // 
            // lbl8b
            // 
            this.lbl8b.AutoSize = true;
            this.lbl8b.Location = new System.Drawing.Point(224, 60);
            this.lbl8b.Name = "lbl8b";
            this.lbl8b.Size = new System.Drawing.Size(13, 13);
            this.lbl8b.TabIndex = 19;
            this.lbl8b.Text = "0";
            // 
            // lbl9b
            // 
            this.lbl9b.AutoSize = true;
            this.lbl9b.Location = new System.Drawing.Point(254, 60);
            this.lbl9b.Name = "lbl9b";
            this.lbl9b.Size = new System.Drawing.Size(13, 13);
            this.lbl9b.TabIndex = 20;
            this.lbl9b.Text = "0";
            // 
            // lbl3d
            // 
            this.lbl3d.AutoSize = true;
            this.lbl3d.Location = new System.Drawing.Point(292, 122);
            this.lbl3d.Name = "lbl3d";
            this.lbl3d.Size = new System.Drawing.Size(13, 13);
            this.lbl3d.TabIndex = 25;
            this.lbl3d.Text = "0";
            // 
            // lbl2d
            // 
            this.lbl2d.AutoSize = true;
            this.lbl2d.Location = new System.Drawing.Point(323, 122);
            this.lbl2d.Name = "lbl2d";
            this.lbl2d.Size = new System.Drawing.Size(13, 13);
            this.lbl2d.TabIndex = 26;
            this.lbl2d.Text = "0";
            // 
            // lbl1d
            // 
            this.lbl1d.AutoSize = true;
            this.lbl1d.Location = new System.Drawing.Point(352, 122);
            this.lbl1d.Name = "lbl1d";
            this.lbl1d.Size = new System.Drawing.Size(13, 13);
            this.lbl1d.TabIndex = 27;
            this.lbl1d.Text = "0";
            // 
            // lbl9r
            // 
            this.lbl9r.AutoSize = true;
            this.lbl9r.Location = new System.Drawing.Point(254, 122);
            this.lbl9r.Name = "lbl9r";
            this.lbl9r.Size = new System.Drawing.Size(13, 13);
            this.lbl9r.TabIndex = 36;
            this.lbl9r.Text = "0";
            // 
            // lbl8r
            // 
            this.lbl8r.AutoSize = true;
            this.lbl8r.Location = new System.Drawing.Point(224, 122);
            this.lbl8r.Name = "lbl8r";
            this.lbl8r.Size = new System.Drawing.Size(13, 13);
            this.lbl8r.TabIndex = 35;
            this.lbl8r.Text = "0";
            // 
            // lbl7r
            // 
            this.lbl7r.AutoSize = true;
            this.lbl7r.Location = new System.Drawing.Point(195, 122);
            this.lbl7r.Name = "lbl7r";
            this.lbl7r.Size = new System.Drawing.Size(13, 13);
            this.lbl7r.TabIndex = 34;
            this.lbl7r.Text = "0";
            // 
            // lbl6r
            // 
            this.lbl6r.AutoSize = true;
            this.lbl6r.Location = new System.Drawing.Point(164, 122);
            this.lbl6r.Name = "lbl6r";
            this.lbl6r.Size = new System.Drawing.Size(13, 13);
            this.lbl6r.TabIndex = 33;
            this.lbl6r.Text = "0";
            // 
            // lbl5r
            // 
            this.lbl5r.AutoSize = true;
            this.lbl5r.Location = new System.Drawing.Point(134, 122);
            this.lbl5r.Name = "lbl5r";
            this.lbl5r.Size = new System.Drawing.Size(13, 13);
            this.lbl5r.TabIndex = 32;
            this.lbl5r.Text = "0";
            // 
            // lbl4r
            // 
            this.lbl4r.AutoSize = true;
            this.lbl4r.Location = new System.Drawing.Point(105, 122);
            this.lbl4r.Name = "lbl4r";
            this.lbl4r.Size = new System.Drawing.Size(13, 13);
            this.lbl4r.TabIndex = 31;
            this.lbl4r.Text = "0";
            // 
            // lbl3r
            // 
            this.lbl3r.AutoSize = true;
            this.lbl3r.Location = new System.Drawing.Point(74, 122);
            this.lbl3r.Name = "lbl3r";
            this.lbl3r.Size = new System.Drawing.Size(13, 13);
            this.lbl3r.TabIndex = 30;
            this.lbl3r.Text = "0";
            // 
            // lbl2r
            // 
            this.lbl2r.AutoSize = true;
            this.lbl2r.Location = new System.Drawing.Point(44, 122);
            this.lbl2r.Name = "lbl2r";
            this.lbl2r.Size = new System.Drawing.Size(13, 13);
            this.lbl2r.TabIndex = 29;
            this.lbl2r.Text = "0";
            // 
            // lbl1r
            // 
            this.lbl1r.AutoSize = true;
            this.lbl1r.Location = new System.Drawing.Point(14, 122);
            this.lbl1r.Name = "lbl1r";
            this.lbl1r.Size = new System.Drawing.Size(13, 13);
            this.lbl1r.TabIndex = 28;
            this.lbl1r.Text = "0";
            // 
            // lbl2v
            // 
            this.lbl2v.AutoSize = true;
            this.lbl2v.Location = new System.Drawing.Point(381, 60);
            this.lbl2v.Name = "lbl2v";
            this.lbl2v.Size = new System.Drawing.Size(13, 13);
            this.lbl2v.TabIndex = 53;
            this.lbl2v.Text = "0";
            // 
            // lbl3v
            // 
            this.lbl3v.AutoSize = true;
            this.lbl3v.Location = new System.Drawing.Point(353, 60);
            this.lbl3v.Name = "lbl3v";
            this.lbl3v.Size = new System.Drawing.Size(13, 13);
            this.lbl3v.TabIndex = 52;
            this.lbl3v.Text = "0";
            // 
            // lbl4v
            // 
            this.lbl4v.AutoSize = true;
            this.lbl4v.Location = new System.Drawing.Point(324, 60);
            this.lbl4v.Name = "lbl4v";
            this.lbl4v.Size = new System.Drawing.Size(13, 13);
            this.lbl4v.TabIndex = 51;
            this.lbl4v.Text = "0";
            // 
            // lbl1v
            // 
            this.lbl1v.AutoSize = true;
            this.lbl1v.Location = new System.Drawing.Point(293, 60);
            this.lbl1v.Name = "lbl1v";
            this.lbl1v.Size = new System.Drawing.Size(13, 13);
            this.lbl1v.TabIndex = 50;
            this.lbl1v.Text = "0";
            // 
            // lbl9c
            // 
            this.lbl9c.AutoSize = true;
            this.lbl9c.Location = new System.Drawing.Point(254, 183);
            this.lbl9c.Name = "lbl9c";
            this.lbl9c.Size = new System.Drawing.Size(13, 13);
            this.lbl9c.TabIndex = 49;
            this.lbl9c.Text = "0";
            // 
            // lbl8c
            // 
            this.lbl8c.AutoSize = true;
            this.lbl8c.Location = new System.Drawing.Point(224, 183);
            this.lbl8c.Name = "lbl8c";
            this.lbl8c.Size = new System.Drawing.Size(13, 13);
            this.lbl8c.TabIndex = 48;
            this.lbl8c.Text = "0";
            // 
            // lbl7c
            // 
            this.lbl7c.AutoSize = true;
            this.lbl7c.Location = new System.Drawing.Point(195, 183);
            this.lbl7c.Name = "lbl7c";
            this.lbl7c.Size = new System.Drawing.Size(13, 13);
            this.lbl7c.TabIndex = 47;
            this.lbl7c.Text = "0";
            // 
            // lbl6c
            // 
            this.lbl6c.AutoSize = true;
            this.lbl6c.Location = new System.Drawing.Point(164, 183);
            this.lbl6c.Name = "lbl6c";
            this.lbl6c.Size = new System.Drawing.Size(13, 13);
            this.lbl6c.TabIndex = 46;
            this.lbl6c.Text = "0";
            // 
            // lbl5c
            // 
            this.lbl5c.AutoSize = true;
            this.lbl5c.Location = new System.Drawing.Point(134, 183);
            this.lbl5c.Name = "lbl5c";
            this.lbl5c.Size = new System.Drawing.Size(13, 13);
            this.lbl5c.TabIndex = 45;
            this.lbl5c.Text = "0";
            // 
            // lbl4c
            // 
            this.lbl4c.AutoSize = true;
            this.lbl4c.Location = new System.Drawing.Point(105, 183);
            this.lbl4c.Name = "lbl4c";
            this.lbl4c.Size = new System.Drawing.Size(13, 13);
            this.lbl4c.TabIndex = 44;
            this.lbl4c.Text = "0";
            // 
            // lbl3c
            // 
            this.lbl3c.AutoSize = true;
            this.lbl3c.Location = new System.Drawing.Point(74, 183);
            this.lbl3c.Name = "lbl3c";
            this.lbl3c.Size = new System.Drawing.Size(13, 13);
            this.lbl3c.TabIndex = 43;
            this.lbl3c.Text = "0";
            // 
            // lbl2c
            // 
            this.lbl2c.AutoSize = true;
            this.lbl2c.Location = new System.Drawing.Point(44, 183);
            this.lbl2c.Name = "lbl2c";
            this.lbl2c.Size = new System.Drawing.Size(13, 13);
            this.lbl2c.TabIndex = 42;
            this.lbl2c.Text = "0";
            // 
            // lbl1c
            // 
            this.lbl1c.AutoSize = true;
            this.lbl1c.Location = new System.Drawing.Point(14, 183);
            this.lbl1c.Name = "lbl1c";
            this.lbl1c.Size = new System.Drawing.Size(13, 13);
            this.lbl1c.TabIndex = 41;
            this.lbl1c.Text = "0";
            // 
            // frmPrinc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 701);
            this.Controls.Add(this.frmDefausse);
            this.Controls.Add(this.lblReste);
            this.Controls.Add(this.lblJoueur4);
            this.Controls.Add(this.lblJoueur2);
            this.Controls.Add(this.lblJoueur1);
            this.Controls.Add(this.lblJoueur3);
            this.Controls.Add(this.btnPrendre);
            this.Controls.Add(this.btnDeclarer);
            this.Controls.Add(this.btnJouer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrinc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tuile défaussée :";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.frmDefausse.ResumeLayout(false);
            this.frmDefausse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.Button btnJouer;
        private System.Windows.Forms.Button btnDeclarer;
        private System.Windows.Forms.Button btnPrendre;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDiscard;
        private System.Windows.Forms.Label lblJoueur3;
        private System.Windows.Forms.Label lblJoueur1;
        private System.Windows.Forms.Label lblJoueur2;
        private System.Windows.Forms.Label lblJoueur4;
        private System.Windows.Forms.Label lblReste;
        private System.Windows.Forms.GroupBox frmDefausse;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTuileDefausse;
        private System.Windows.Forms.Label lbl2v;
        private System.Windows.Forms.Label lbl3v;
        private System.Windows.Forms.Label lbl4v;
        private System.Windows.Forms.Label lbl1v;
        private System.Windows.Forms.Label lbl9c;
        private System.Windows.Forms.Label lbl8c;
        private System.Windows.Forms.Label lbl7c;
        private System.Windows.Forms.Label lbl6c;
        private System.Windows.Forms.Label lbl5c;
        private System.Windows.Forms.Label lbl4c;
        private System.Windows.Forms.Label lbl3c;
        private System.Windows.Forms.Label lbl2c;
        private System.Windows.Forms.Label lbl1c;
        private System.Windows.Forms.Label lbl9r;
        private System.Windows.Forms.Label lbl8r;
        private System.Windows.Forms.Label lbl7r;
        private System.Windows.Forms.Label lbl6r;
        private System.Windows.Forms.Label lbl5r;
        private System.Windows.Forms.Label lbl4r;
        private System.Windows.Forms.Label lbl3r;
        private System.Windows.Forms.Label lbl2r;
        private System.Windows.Forms.Label lbl1r;
        private System.Windows.Forms.Label lbl1d;
        private System.Windows.Forms.Label lbl2d;
        private System.Windows.Forms.Label lbl3d;
        private System.Windows.Forms.Label lbl9b;
        private System.Windows.Forms.Label lbl8b;
        private System.Windows.Forms.Label lbl7b;
        private System.Windows.Forms.Label lbl6b;
        private System.Windows.Forms.Label lbl5b;
        private System.Windows.Forms.Label lbl4b;
        private System.Windows.Forms.Label lbl3b;
        private System.Windows.Forms.Label lbl2b;
        private System.Windows.Forms.Label lbl1b;
    }
}