namespace IBIS_TACHE
{
    partial class SQLObject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connexion = new System.Windows.Forms.GroupBox();
            this.PassTXT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UtilisateurTXT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BasedeDonnéesCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SunrisePass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SunriseUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SunriseBdCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SunriseServ = new System.Windows.Forms.ComboBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.coreproc = new System.Windows.Forms.TextBox();
            this.DDL = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.position = new System.Windows.Forms.Label();
            this.Connexion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connexion
            // 
            this.Connexion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Connexion.Controls.Add(this.PassTXT);
            this.Connexion.Controls.Add(this.label4);
            this.Connexion.Controls.Add(this.UtilisateurTXT);
            this.Connexion.Controls.Add(this.label3);
            this.Connexion.Controls.Add(this.label2);
            this.Connexion.Controls.Add(this.BasedeDonnéesCombo);
            this.Connexion.Controls.Add(this.label1);
            this.Connexion.Controls.Add(this.ServerCombo);
            this.Connexion.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connexion.Location = new System.Drawing.Point(3, 2);
            this.Connexion.Name = "Connexion";
            this.Connexion.Size = new System.Drawing.Size(448, 155);
            this.Connexion.TabIndex = 0;
            this.Connexion.TabStop = false;
            this.Connexion.Text = "Connexion IBIS";
            // 
            // PassTXT
            // 
            this.PassTXT.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassTXT.Location = new System.Drawing.Point(194, 80);
            this.PassTXT.Name = "PassTXT";
            this.PassTXT.PasswordChar = '*';
            this.PassTXT.Size = new System.Drawing.Size(228, 22);
            this.PassTXT.TabIndex = 7;
            this.PassTXT.Leave += new System.EventHandler(this.UpdatedbIBIS);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mot de Passe:";
            // 
            // UtilisateurTXT
            // 
            this.UtilisateurTXT.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UtilisateurTXT.Location = new System.Drawing.Point(194, 50);
            this.UtilisateurTXT.Name = "UtilisateurTXT";
            this.UtilisateurTXT.Size = new System.Drawing.Size(228, 22);
            this.UtilisateurTXT.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Utilisateur:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Base de Données :";
            // 
            // BasedeDonnéesCombo
            // 
            this.BasedeDonnéesCombo.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasedeDonnéesCombo.FormattingEnabled = true;
            this.BasedeDonnéesCombo.Location = new System.Drawing.Point(194, 108);
            this.BasedeDonnéesCombo.Name = "BasedeDonnéesCombo";
            this.BasedeDonnéesCombo.Size = new System.Drawing.Size(228, 24);
            this.BasedeDonnéesCombo.TabIndex = 2;
            this.BasedeDonnéesCombo.SelectedValueChanged += new System.EventHandler(this.updateProcList);
            this.BasedeDonnéesCombo.Enter += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serveur :";
            // 
            // ServerCombo
            // 
            this.ServerCombo.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerCombo.FormattingEnabled = true;
            this.ServerCombo.Location = new System.Drawing.Point(194, 19);
            this.ServerCombo.Name = "ServerCombo";
            this.ServerCombo.Size = new System.Drawing.Size(228, 24);
            this.ServerCombo.TabIndex = 0;
            this.ServerCombo.TextChanged += new System.EventHandler(this.UpdatedbIBIS);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "Connexion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(996, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 37);
            this.button2.TabIndex = 9;
            this.button2.Text = "Traitement";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(985, 431);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 32);
            this.button3.TabIndex = 10;
            this.button3.Text = "Appliquer";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 187);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(505, 95);
            this.listBox1.TabIndex = 11;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.SunrisePass);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.SunriseUser);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.SunriseBdCombo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.SunriseServ);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(531, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 155);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connexion Sunrise";
            // 
            // SunrisePass
            // 
            this.SunrisePass.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SunrisePass.Location = new System.Drawing.Point(194, 80);
            this.SunrisePass.Name = "SunrisePass";
            this.SunrisePass.PasswordChar = '*';
            this.SunrisePass.Size = new System.Drawing.Size(228, 22);
            this.SunrisePass.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mot de Passe:";
            // 
            // SunriseUser
            // 
            this.SunriseUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SunriseUser.Location = new System.Drawing.Point(194, 50);
            this.SunriseUser.Name = "SunriseUser";
            this.SunriseUser.Size = new System.Drawing.Size(228, 22);
            this.SunriseUser.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Utilisateur:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Base de Données :";
            // 
            // SunriseBdCombo
            // 
            this.SunriseBdCombo.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SunriseBdCombo.FormattingEnabled = true;
            this.SunriseBdCombo.Location = new System.Drawing.Point(194, 108);
            this.SunriseBdCombo.Name = "SunriseBdCombo";
            this.SunriseBdCombo.Size = new System.Drawing.Size(228, 24);
            this.SunriseBdCombo.TabIndex = 2;
            this.SunriseBdCombo.SelectedIndexChanged += new System.EventHandler(this.updateTableList);
            this.SunriseBdCombo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UpdatedbSunrise);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Serveur :";
            // 
            // SunriseServ
            // 
            this.SunriseServ.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SunriseServ.FormattingEnabled = true;
            this.SunriseServ.Location = new System.Drawing.Point(194, 19);
            this.SunriseServ.Name = "SunriseServ";
            this.SunriseServ.Size = new System.Drawing.Size(228, 24);
            this.SunriseServ.TabIndex = 0;
            this.SunriseServ.TextChanged += new System.EventHandler(this.UpdatedbSunrise);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(531, 187);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(448, 95);
            this.listBox2.TabIndex = 12;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(474, 65);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 36);
            this.button4.TabIndex = 8;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Liste des Procédures :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(537, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Liste des Tables :";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // coreproc
            // 
            this.coreproc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.coreproc.Location = new System.Drawing.Point(3, 288);
            this.coreproc.Multiline = true;
            this.coreproc.Name = "coreproc";
            this.coreproc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.coreproc.Size = new System.Drawing.Size(505, 254);
            this.coreproc.TabIndex = 15;
            // 
            // DDL
            // 
            this.DDL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DDL.Location = new System.Drawing.Point(531, 288);
            this.DDL.Multiline = true;
            this.DDL.Name = "DDL";
            this.DDL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DDL.Size = new System.Drawing.Size(448, 254);
            this.DDL.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(985, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(270, 37);
            this.button5.TabIndex = 17;
            this.button5.Text = "2.importer Objets Stockées";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(985, 204);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 37);
            this.button6.TabIndex = 18;
            this.button6.Text = "3. Generer interdépendances";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(985, 247);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(159, 37);
            this.button7.TabIndex = 19;
            this.button7.Text = "4. Importation Contrainte";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(985, 75);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 37);
            this.button8.TabIndex = 20;
            this.button8.Text = "CREER UNE BASE";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(985, 388);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(159, 37);
            this.button9.TabIndex = 21;
            this.button9.Text = "Traitement";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(985, 118);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(159, 37);
            this.button10.TabIndex = 22;
            this.button10.Text = "1.ImporterTable Sunrise";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(985, 345);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(159, 37);
            this.button11.TabIndex = 23;
            this.button11.Text = "Traitement";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(985, 288);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(159, 37);
            this.button12.TabIndex = 24;
            this.button12.Text = "5. Génération Script";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position.Location = new System.Drawing.Point(1140, 171);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(32, 16);
            this.position.TabIndex = 25;
            this.position.Text = "0/0";
            // 
            // SQLObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1257, 545);
            this.Controls.Add(this.position);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.DDL);
            this.Controls.Add(this.coreproc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Connexion);
            this.Controls.Add(this.button1);
            this.Name = "SQLObject";
            this.Text = "SQLObject";
            this.Load += new System.EventHandler(this.SQLObject_Load);
            this.Connexion.ResumeLayout(false);
            this.Connexion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Connexion;
        private System.Windows.Forms.TextBox PassTXT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UtilisateurTXT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BasedeDonnéesCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ServerCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SunrisePass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SunriseUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox SunriseBdCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox SunriseServ;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox coreproc;
        private System.Windows.Forms.TextBox DDL;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label position;
    }
}