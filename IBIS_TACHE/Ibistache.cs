using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBIS_TACHE
{

    public partial class Ibistache : Form
    {
        private static string fichierresult = @"D:\IBIS2017.txt";
        private string fichierRecherché = @"*.vbp";
        private string fichiersuivi = @"D:\IBISsuivi2017.txt";
        private string FichierAppliFeuilles = @"D:\Appli_feuilles.txt";
        public List<string> ListeVbp = new List<string>();


        public Ibistache()
        {
            InitializeComponent();

        }

        private  List<string> fichiersParcou = new List<string>();
        private int cont = 0;
        private  async void ParcourirFichier(string filename)
        {

            string nom = filename.Split('\\')[filename.Split('\\').Length - 1].ToUpper();
            if (!fichiersParcou.Contains(nom))
            {
                if (nom.EndsWith("TEST.FRM") || nom.EndsWith("ANC.FRM"))
                {
                    goto dehors;
                }

                string module = await lectureModule(filename);
                List<string> feuilles = await listeFeuille(filename, module);
                List<string> taches = TacheIbis(filename, module);

                List<string> liste = new List<string>();

                foreach (string t in taches)
                {
                    if (t.Contains("IBIS_GESBANC_ED"))
                    {
                        Debug.WriteLine(filename);
                    }
                    string tmp = "";
                    string[] tache = t.Split(';');
                    if (tache.Length > 4)
                    {
                        foreach (string f in feuilles)
                        {
                            string[] feuille = f.Split(';');
                            if (feuille.Length > 2)
                            {
                                if (feuille[2] == "A")
                                {
                                    if (string.Equals(tache[1], feuille[0].Trim('\"'), StringComparison.OrdinalIgnoreCase))
                                    {
                                        tmp = tache[0] + ";" + tache[1] + ";" + tache[2] + ";" + feuille[2] + ";" +
                                              tache[3] + ";" + feuille[1];
                                        break;
                                    }
                                    else
                                    {
                                        tmp = tache[0] + ";" + tache[1] + ";" + tache[2] + ";" + "M" + ";" + tache[3] +
                                              ";";
                                        ; //
                                    }
                                }
                                else
                                {
                                    if (string.Equals(tache[1], feuille[0], StringComparison.OrdinalIgnoreCase))
                                    //   (tache[1] == feuille[1])
                                    {
                                        tmp = tache[0] + ";" + tache[1] + ";" + tache[2] + ";" + tache[4] + ";" + tache[3] +
                                              ";" + feuille[2];
                                        break;
                                    }

                                }

                            }

                        }
                        if (tmp.Length == 0)
                        {


                            tmp = tache[0] + ";" + tache[1] + ";" + tache[2] + ";" + "M" + ";" + tache[3] + ";"; //
                        }
                        else
                        {
                            if (t.Contains("IBIS_GESBANC_ED"))
                            {

                                string[] xtmp = tmp.Split(';');

                                if (liste.Any(ti => (ti.Contains(xtmp[0]) && ti.Contains(xtmp[1]) &&
                                                ti.Contains(xtmp[2]))))
                                {
                                    Debug.WriteLine(tmp);
                                }
                            }
                        }



                        liste.Add(tmp);
                    }

                }
                //if (liste.Any(p=>p.Contains("PROJ_PAR_SCENARIO")))
                //if (liste.Any(p=>p.Contains("IBIS_GESBANC_ED_ALPHA_LIST_CLI_INTERV")))

                if (
                    liste.Any(p => p.Contains("DEP_PAR_RUBR_BUDGET"))
                   )
                {
                    Debug.WriteLine(filename);
                }
                Ecriture(module, liste);
                fichiersParcou.Add(nom);
            }
            else { cont++; }

            dehors:
            label3.Text = fichiersParcou.Count + "/" + cont;

        }

        public List<string> TacheIbis(string filename, string module)
        {
            #region declaratio
            string chaine;
            string chaine2;
            string chaine3;
            string chaine4;
            int Niveau;
            int[] ValeurNiveau = new int[10000];
            string[] NiveauTâches = new string[10000];
            string SousNiveaux;
            string[] TypeTâches = new string[10000];
            long Num1;
            long Num2;
            bool[] TestStructure = new bool[10000];
            bool NbBegin;
            bool TraitEnCours;
            int h;

            #endregion


            // Initialisation
            Niveau = 0;
            NbBegin = false;
            TraitEnCours = false;
            for (h = 1; h <= 50; h++)
            {
                ValeurNiveau[h] = 0;
            }

            SousNiveaux = "";
            for (h = 1; h <= 20; h++)
            {
                TestStructure[h] = false;
                TypeTâches[h] = "T";
            }
            Num1 = 0;
            Num2 = 0;
            List<string> retour = new List<string>();

            System.IO.StreamReader tmpfile = new System.IO.StreamReader(filename, System.Text.Encoding.GetEncoding("iso-8859-8"));

            while ((chaine = tmpfile.ReadLine()) != null)
            {
                string tmp = module;
                chaine = Strings.Trim(chaine);
                // Recherche d'une ouverture de ligne de menu
                if (Strings.InStr(chaine, "Begin VB.Menu") > 0)
                {
                    // Ligne de menu trouvée !

                    // Décodage de son nom et de son caption
                    // Nom
                    chaine3 = Strings.Trim(Strings.Mid(chaine, Strings.InStr(chaine, "VB.Menu") + 7));
                    // Caption
                    chaine2 = tmpfile.ReadLine();
                    chaine2 = Strings.Trim(chaine2);
                    chaine4 = Strings.Trim(Strings.Mid(chaine2, Strings.InStr(chaine2, "=") + 1));
                    // Suppression des apostrophes
                    if (Strings.Left(chaine4, 1) == ((char)34).ToString())
                    {
                        chaine4 = Strings.Mid(chaine4, 2);
                    }

                    if (Strings.Right(chaine4, 1) == ((char)34).ToString())
                    {
                        chaine4 = Strings.Left(chaine4, Strings.Len(chaine4) - 1);
                    }
                    // Suppression des &
                    if (Strings.Len(chaine4) > 0)
                    {
                        chaine2 = chaine4;
                        for (h = 1; h <= Strings.Len(chaine4); h++)
                        {
                            if (Strings.Mid(chaine4, h, 1) == "&")
                            {
                                chaine2 = Strings.Left(chaine2, h - 1) + Strings.Mid(chaine2, h + 1);
                            }
                        }
                        chaine4 = chaine2;
                    }

                    // Vérification si pas ligne de soulignement
                    if (chaine4 != "-")
                    {
                        // Vérification si précedent sous-menu encore ouvert
                        if (Niveau > 0 & Num2 > 0)
                        {
                            if (NbBegin)
                            {
                                // Mise à jour de son type
                                TypeTâches[Num2] = "M";
                            }
                        }

                        // Incrémentation de son nombre
                        Num2 = Num2 + 1;
                        // Augmentation de son niveau
                        Niveau++;
                        ValeurNiveau[Niveau] = ValeurNiveau[Niveau] + 1;
                        if (Niveau > 1)
                        {

                            SousNiveaux = SousNiveaux + ValeurNiveau[Niveau - 1].ToString("D2");
                        }

                        // Mise à jour
                        TestStructure[Niveau] = true;
                        NbBegin = true;
                        TraitEnCours = false;

                        // Mise à jour
                        string NomTâches = chaine3;
                        string LibelléTâches = chaine4;

                        TypeTâches[Num2] = "T";
                        NiveauTâches[Num2] = SousNiveaux + ValeurNiveau[Niveau].ToString("D2");

                        // Affichage
                        //  lblNombreTâches = Format(Num2, "#####");
                        string lblNomTâche = chaine3;
                        string lblPositionTâche = NiveauTâches[Num2];


                        tmp += ";" + NomTâches + ";" + LibelléTâches + ";" + lblPositionTâche;
                    }
                    else
                    {
                        // Barre de séparation en cours de traitement
                        TraitEnCours = true;
                    }
                }
                else if (Strings.InStr(chaine, "End") > 0 & TestStructure[Niveau] & !TraitEnCours)
                {

                    // Mise à jour
                    TestStructure[Niveau] = false;
                    NbBegin = false;
                    // Diminution du nombre de niveau
                    ValeurNiveau[Niveau + 1] = 0;
                    Niveau = Niveau - 1;
                    if (SousNiveaux != "")
                    {

                        SousNiveaux = Strings.Left(SousNiveaux, Strings.Len(SousNiveaux) - 2);// ValeurNiveau[Niveau].ToString("D2").Length);

                    }
                }
                if (tmp.Length > module.Length)
                {
                    retour.Add(tmp + ";" + TypeTâches[Num2]);
                }
                // Incrémentation du nombre de lignes lus
                Num1++;


            }
            tmpfile.Close();
            tmpfile.Dispose();



            return retour;

        }

        private async Task<string> lectureModule(string filename)
        {
            string module = "";
            System.IO.StreamReader tmpfile = new System.IO.StreamReader(filename);
            string tmp = string.Empty;
            while ((module = tmpfile.ReadLine()) != null)
            {
                if (module.Contains("Begin VB.MDIForm"))
                {

                    tmp = module.Split(' ')[2];
                }

                if (module.Contains("CtrlAppliVersion"))
                {
                    module = module.Split('\"')[1];
                    // button2.Enabled = true;
                    break;
                }
            }
            tmpfile.Close();
            tmpfile.Dispose();
            using (System.IO.StreamWriter files =
                new System.IO.StreamWriter(fichiersuivi, true, System.Text.Encoding.GetEncoding("iso-8859-8")))
            {
                string marque = module == "M12PAR" ? "X" : "";

                string li = (filename.Split('\\')[filename.Split('\\').Length - 1]) + marque;
                if ((filename.Split('\\')[filename.Split('\\').Length - 1]).ToUpper() == "MDI_IMMOBILISATION.FRM")
                {
                    module = "M82IMMO";
                }
                files.WriteLine(li);
            }

            tmp = module ?? filename.Split('\\')[filename.Split('\\').Length];
            tmp = tmp.Replace("MDI_IBIS2000;", "M00;");
            tmp = tmp.Replace("M501PRT;", "M050;");
            tmp = tmp.Replace("MDI_CONTROLEGESTION;", "M077;");
            tmp = tmp.Replace("MDI_REPORTING_IMF;", "M067;");
            tmp = tmp.Replace("MDI_STATISTIQUES;", "M025;");
            tmp = tmp.Replace("MDI_SITUATION_TRESORERIE;", "M221SIT_TRES;");
            tmp = tmp.Replace("MDI_CHEQUE_BANCAIRE;", "M222CHQBANC;");
            tmp = tmp.Replace("MDI_OPERATION_DEVISE;", "M223OPDEV;");
            tmp = tmp.Replace("MDI_PRET_EMPRUNT_BANCAIRE;", "M224PEI;");
            tmp = tmp.Replace("MDI_RAPPROCHEMENT_BANCAIRE;", "M225RAPBANC;");
            tmp = tmp.Replace("MDI_GARANTIE;", "M121;");
            tmp = tmp.Replace("Mdi_DOMDOC;", "M554DMD;");
            tmp = tmp.Replace("MDI_PRETS_PARTICIPATIFS;", "M124;");
            tmp = tmp.Replace("MDI_AFFACTURAGE;", "M142;");
            tmp = tmp.Replace("MDI_CAUTION;", "M54CAUT;");
            tmp = tmp.Replace("MDI_GARANTIES_RECUES;", "M053;");
            tmp = tmp.Replace("MDI_LIGNE_CREDIT;", "M51LIGN;");
            tmp = tmp.Replace("MDI_PARAMETRAGE;", "M12PAR;");
            tmp = tmp.Replace("MDI_PRETS_AMORTISSABLES;", "M52PRET;");
            tmp = tmp.Replace("MDI_CLE_TELEGRAPHIQUE;", "M105;");
            tmp = tmp.Replace("MDI_SERVEUR_FINANCIER;", "M08;");
            tmp = tmp.Replace("MDI_IMMOBILISATION;", "M82IMMO;");
            tmp = tmp.Replace("MDI_IMMOBILIER;", "M131;");
            tmp = tmp.Replace("MDI_ARRETE_DES_COMPTES;", "M93_ARR;");
            tmp = tmp.Replace("MDI_GARANTIES_HYPOTHECAIRE;", "M123;");
            tmp = tmp.Replace("MDI_TELECOMPENSE;", "M942TLC;");
            tmp = tmp.Replace("MDI_INTERFACE_MONETIQUE;", "M78MON;");
            tmp = tmp.Replace("MDI_INTERFACE_RTGS;", "M102;");
            tmp = tmp.Replace("M50PARA;", "M05;");
            tmp = tmp.Replace("M551CMX;", "M057;");
            tmp = tmp.Replace("M571GRH;", "M072;");
            tmp = tmp.Replace("M79GIM;", "M104;");
            tmp = tmp.Replace("M99UTIL;", "M30;");
            tmp = tmp.Replace("MDI_Finder;", "M301;");
            tmp = tmp.Replace("MDI_BALANCE_PAIEMENT;", "M65BALP;");
            tmp = tmp.Replace("MDI_INCIDENT_DE_PAIEMENT;", "M64INCI;");
            tmp = tmp.Replace("MDI_CENTRALE_DES_RISQUES;", "M63CRS;");
            tmp = tmp.Replace("MDI_TRATIEMENTS;", "M91TRAI;");
            tmp = tmp.Replace("MDI_MONEYGRAM;", "M948MONEYGRAM;");
            tmp = tmp.Replace("MDI_INTERFACE_PRET;", "M056;");
            tmp = tmp.Replace("MDI_REFORME_BCEAO;", "M302;");

            return tmp;
        }

        private async Task<string> LireVbp(string filename)
        {
            List<string> feuillesvb = new List<string>();
            string retour = "";
            string matmp = "";
            using (System.IO.StreamWriter files =
                    new System.IO.StreamWriter(FichierAppliFeuilles, true, System.Text.Encoding.GetEncoding("iso-8859-8")))
            {

                List<string> result = new List<string>();

                System.IO.StreamReader tmpfile = new System.IO.StreamReader(filename, Encoding.GetEncoding(1252));
                string tmp = string.Empty;
                string mdi;
                while ((mdi = tmpfile.ReadLine()) != null)
                {

                    if (mdi.Contains("Form="))
                    {
                        tmp = mdi.Split('=')[1];
                        result.Add(tmp);
                        string feuille = tmp.Split('\\')[tmp.Split('\\').Length - 1].ToUpper();
                        string repertoire = tmp;
                        feuillesvb.Add((";" + feuille + ";" + repertoire));
                        //.WriteLine;
                    }

                    if (mdi.Contains("Startup="))
                    {
                        try
                        {
                            ;
                            mdi = Regex.Replace(mdi.Split('=')[1], "\"*", "");
                            mdi = mdi == "CONNEXION" ? "MDI_IBIS2000" : mdi;
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }

                        break;
                    }

                }


                foreach (string tmpsresult in result)
                {
                    matmp = tmpsresult.IndexOf("MDI", StringComparison.CurrentCultureIgnoreCase) != -1 ? tmpsresult : "";
                    if (tmpsresult.IndexOf(mdi, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        retour = tmpsresult;
                        break;
                    }
                    if (retour == "")
                    {

                    }
                }

                retour = retour == "" ? matmp : retour;
                //retour = result.FirstOrDefault(p => p.Contains(mdi + ".frm"));

                if (retour.Contains(@"\\Vboxsvr"))
                {
                    retour = Regex.Replace(retour, @"\s+", "");
                    int longueur = retour.Length;
                    string tmps = "";
                    for (int i = "\\Vboxsvr\\sources\\".Length; i < longueur; i++)
                    {
                        tmps += retour[i];
                    }
                    retour = tmps;
                }

                if (retour.Contains(".."))
                {
                    retour = folderBrowserDialog1.SelectedPath + "\\" + retour;
                }
                else
                {
                    retour = Directory.GetParent(folderBrowserDialog1.SelectedPath) + "\\" + retour;
                }
                string module = await lectureModule(retour);
                foreach (string feuille in feuillesvb)
                {
                    files.WriteLine(module + feuille);
                }

            }
            return retour;
        }

        #region parcours


        private async Task<List<string>> listeFeuille(string filename, string module)
        {
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filename, System.Text.Encoding.GetEncoding("iso-8859-8"));
            List<string> list = new List<string>();
            line = "";
            while ((line = file.ReadLine()) != null)
            {

                if (line == null)
                {
                    break;
                }
                string tmp = module + ";";
                if (line.Contains("Exec_Tache \""))
                {
                    int index = 0;
                    string[] sep = line.Split(' ');
                    string tache = "";
                    string feuille = "";
                    foreach (string c in sep)
                    {

                        tmp = c.Trim();
                        if (tmp.Length > 4)
                        {
                            int l = tmp.Length;
                            index++;
                            if (index == 2)
                            {
                                tache = c.Substring(1, l - 3);
                            }
                            if (index == 3)
                            {
                                feuille = c.Substring(1, l - 3);
                            }
                        }

                    }



                    tmp = string.Concat(tache, ";", feuille, ";", "A");
                    list.Add(tmp);
                }
                else if (line.Contains("Var_Tache ="))
                {
                    string l = line.Split('=')[1];
                    tmp = l.Substring(2, l.Length - 3) + ";";
                    line = file.ReadLine();

                    while (!line.Contains("End Sub"))
                    {
                        if (line.Contains("Show"))
                        {
                            tmp += ";" + Regex.Replace(line.Split('.')[0], @"\s+", "");

                        }
                        else
                        {
                            if (line.Contains("Load"))
                            {
                                tmp += Regex.Replace(line.Replace("Load", ""), @"\s+", "");

                            }
                        }

                        line = file.ReadLine();
                    }
                    list.Add(tmp);
                    //     list.Add(tmp);
                }

            }

            file.Close();
            return list;
        }
        private  List<string> resuList = new List<string>();

        private static int doublon = 0;
        public async void Ecriture(string module, List<string> list)
        {
            using (System.IO.StreamWriter files =
                new System.IO.StreamWriter(fichierresult, true, System.Text.Encoding.GetEncoding("iso-8859-8")))
            {
                foreach (string li in list)
                {
                    string tmp = li;

                    List<string> liste = new List<string>{"MDI_INTERFACE_CBAIL",
                       "MDI_FINANCEMENT_VIF", "MDI_INTERFACE_FONDS","M57FGAR",
                    "MDI_TELCOMPS","MDI_TELECOMPENS","InterfaceHostISO8583"};

                    bool saut = false;
                    foreach (string str in liste)
                    {
                        if (tmp.Contains(str))
                        {
                            saut = true;
                            break;
                        }
                    }
                    if (saut || resuList.Any(c => c == tmp))
                    {
                        if (!saut)
                        {

                            label1.Text = (++doublon).ToString();
                        }
                        continue;
                    }
                    files.WriteLine(tmp);
                    resuList.Add(tmp);
                }
            }

        }


        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "0/0";
            treeView1.ResetText();
            label2.Text = "";
            dossier.Text = "";

            folderBrowserDialog1.ShowDialog();
            if (File.Exists(fichierresult))
            {
                File.Delete(fichierresult);
            }

            if (File.Exists(fichiersuivi))
            {
                File.Delete(fichiersuivi);
            }

            LoadDirectory(folderBrowserDialog1.SelectedPath);
            string chemin = folderBrowserDialog1.SelectedPath;
            dossier.Text = chemin;

        }

        #region Dossier




        public void LoadDirectory(string Dir)
        {
            if (!Directory.Exists(Dir))
            {
                return;
            }

            treeView1.Nodes.Clear();
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value  
            try
            {
                progressBar1.Maximum = Directory.GetFiles(Dir, fichierRecherché, SearchOption.AllDirectories).Length +
                                       Directory.GetDirectories(Dir, "**", SearchOption.AllDirectories).Length;
                TreeNode tds = treeView1.Nodes.Add(di.Name);
                tds.Tag = di.FullName;
                tds.StateImageIndex = 0;
                LoadFiles(Dir, tds);
                LoadSubDirectories(Dir, tds);
                statut.Text = progressBar1.Maximum.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void LoadSubDirectories(string dir, TreeNode td)
        {
            // Get all subdirectories  
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories  
            foreach (string subdirectory in subdirectoryEntries)
            {

                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.StateImageIndex = 0;
                tds.Tag = di.FullName;
                try
                {
                    LoadFiles(subdirectory, tds);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                finally
                {
                    try
                    {
                        LoadSubDirectories(subdirectory, tds);
                    }
                    catch (Exception d)
                    {
                        MessageBox.Show(d.Message, "Erreur",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    finally
                    {
                        UpdateProgress();
                    }
                }


            }
        }
        private void UpdateProgress()
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                int percent = (int)((progressBar1.Value / (double)progressBar1.Maximum) * 100);
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

                Application.DoEvents();
            }
        }
        #endregion
        private async void LoadFiles(string dir, TreeNode td)
        {
            try
            {
                List<string> Files = Directory.GetFiles(dir, fichierRecherché).ToList();
                foreach (string file in Files)
                {
                    if (file.Contains("InterfaceHostISO8583") ||
                    file.Contains("M79_GIMMOBILE"))
                    {
                        cont++;
                        continue;

                    }


                    //ListeVbp.Add(LireVbp(file));
                    // ParcourirFichier(file, i);
                    FileInfo fi = new FileInfo(file);
                    TreeNode tds = td.Nodes.Add(fi.Name);
                    tds.Tag = fi.FullName;
                    tds.StateImageIndex = 1;

                    try
                    {
                        ParcourirFichier(await LireVbp(file));
                        UpdateProgress();

                    }
                    catch (Exception)
                    {
                        UpdateProgress();
                    }
                    finally
                    {
                        UpdateProgress();
                    }




                }


            }
            catch (Exception exeException)
            {
                MessageBox.Show(exeException.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void statut_Click(object sender, EventArgs e)
        {

        }

    }
}
