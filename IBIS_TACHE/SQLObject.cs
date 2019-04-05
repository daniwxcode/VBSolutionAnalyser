using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLDMO;


namespace IBIS_TACHE
{
    public partial class SQLObject : Form
    {
        object SQLDMO = default(object);
        SQLDMO.Application SQLApp = new SQLDMO.Application();
        private static string fichierresult = @"D:\IBISimportPS.txt";
        private StoredProcedures Liste_procedure;
        private List<_StoredProcedure> _listeProcedureVf=new List<_StoredProcedure>();
        
        private Tables table;
        int i = 0;
        int j = 0;


        public SQLObject()
        {  SQLApp = new SQLDMO.Application();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SQLObject_Load(object sender, EventArgs e)
        {
            //Create a Server instance
            SQLServer server = new SQLServer();
            //Create a Database instance
            SQLDMO.Database dBase = new SQLDMO.Database();
            RemplirSQLServers();
            if (File.Exists(fichierresult))
            {
                File.Delete("fichierresult");
            }

            File.Create(fichierresult);
            
        }



        #region gestion sql server

        private void RemplirSQLServers()
        {
            try
            {

                // SQLDMO.NameList serverSql = SQLApp.ListAvailableSQLServers();
                int i = 0;
                ServerCombo.Items.Clear();
                var listServeur = SQLApp.ListAvailableSQLServers();
                foreach (var serverSql in listServeur)
                {
                    ServerCombo.Items.Insert(i, serverSql);
                    SunriseServ.Items.Insert(i, serverSql);

                    // Suivant
                    i++;
                }
                ServerCombo.SelectedIndex = 0;
                SunriseServ.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                //
            }
        }

        

        private void remplirComboBase(ComboBox combo, string server,string user,string pass)
        {
            var fServer = new SQLServer();
            try
            {
                combo.Items.Clear();
                fServer.Connect(server, user, pass);
                for (int i = 0; i < fServer.Databases.Count; i++)
                {

                    combo.Items.Add(fServer.Databases.Item(i + 1).Name);
                }
                // Back to normal 
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                // Back to normal 
                Cursor.Current = Cursors.Default;
                MessageBox.Show(e.Message + $@"
                                            Serveur: {server} 
                                            Utilisateur: {user}
                                            Mot de Passe: {pass}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Back to normal 
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion
        public ArrayList ListStoredProcedures()
        {
            ArrayList SPList = new ArrayList();
            var fServer = new SQLServer();
            fServer.Connect(server(), user(), pass());
            try
            {
                Liste_procedure = fServer.Databases.Item(bd(), null).StoredProcedures;
                foreach (StoredProcedure sp in Liste_procedure)
                {
                    if (!SPList.Contains(sp.Owner+"."+sp.Name))
                    {
                        SPList.Add(sp.Owner + "." + sp.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return SPList;
        }
        public ArrayList ListAllTables()
        {
            //create a new ArrayList
            ArrayList TableList = new ArrayList();
            //try
            //{
                //Retrieve the Database specified
                //DBase = (SQLDMO.Database)Server.Databases.Item(db_name, null);
                var fServer = new SQLServer(); 
                fServer.Connect(SunriseServer(), sunriseUser(), sunrisePass());
                //Loop through all the tables on the database
                //NOTE: we arent showing system tables
                table = fServer.Databases.Item(SunriseBD(), null).Tables;
                foreach (Table tbl in table)
                {
                    //Make sure the table doesnt
                    //begin with "sys"
                    if (tbl.Name.Length <= 3)
                    {
                        if (!TableList.Contains(tbl.Name))
                        {
                            //It doesnt so add it
                            TableList.Add(tbl.Name);
                        }

                    }
                   else if (!(tbl.Name.Substring(0, 3) == "sys"))
                    {
                        //Check to see if the table already
                        //exists in our ArrayList
                        if (!TableList.Contains(tbl.Owner+tbl.Name))
                        {
                            //It doesnt so add it
                            TableList.Add(tbl.Name);
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //return the ArrayList
            return TableList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
         }

        private void UpdatedbIBIS()
        {
            if (server() != null && user() != String.Empty && pass() != String.Empty)
            {
                // Waiting / hour glass
                Cursor.Current = Cursors.WaitCursor;
                remplirComboBase(BasedeDonnéesCombo, server(), user(), pass());
                

            }
        }
        private void UpdatedbSunrise()
        {
            if (SunriseServer() != null && sunriseUser() != String.Empty && sunrisePass() != String.Empty)
            {
                remplirComboBase(SunriseBdCombo, SunriseServer(), sunriseUser(), sunrisePass());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                foreach (StoredProcedure sp in Liste_procedure)
                {
                    foreach (var item in listBox2.Items)
                    {
                        coreproc.Text = sp.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //**return SPList;
        }

        private string pass()
        {
            return PassTXT.Text;
        }

        private string user()
        {
            return UtilisateurTXT.Text;
        }

        private string server()
        {
            return ServerCombo.Text;
        }

        private string bd()
        {
            return BasedeDonnéesCombo.Text;
        }

        private string SunriseServer()
        {
            return SunriseServ.Text;
        }
        private string SunriseBD()
        {
            return SunriseBdCombo.Text;
        }

        private string sunrisePass()
        {
            return SunrisePass.Text;
        }

        private string sunriseUser()
        {
            return SunriseUser.Text;
        }

        private void UpdatedbIBIS(object sender, EventArgs e)
        {
            UpdatedbIBIS();
        }

        private void UpdatedbSunrise(object sender, EventArgs e)
        {
            UpdatedbSunrise();
        }

        private void UpdatedbSunrise(object sender, MouseEventArgs e)
        {
            UpdatedbSunrise();
        }

        private void updateProcList(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var c = ListStoredProcedures();
            foreach (var item in c)
            {
                try
                {
                    _StoredProcedure tmp = Liste_procedure.Item(c.IndexOf(item)+1);                 
                    var txt = tmp.Text;
                    listBox1.Items.Add(item);
                    _listeProcedureVf.Add(tmp);
                    position.Text = _listeProcedureVf.Count.ToString();
                }
                catch (Exception exception)
                {
                    //Liste_procedure.Remove(c.IndexOf(item.ToString().Split('.')[1]) + 1);
                    Console.WriteLine(exception.Message);
                    //  throw;
                }
              
               
            }
        }

        private void updateTableList(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var c = ListAllTables();
            foreach (var item in c)
            {
                listBox2.Items.Add(item);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SunriseServ.SelectedIndex = ServerCombo.SelectedIndex;
            SunriseUser.Text = user();
            SunrisePass.Text = pass();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            try
            {
                var ps = _listeProcedureVf[listBox1.SelectedIndex];
                coreproc.Text = ps.Text;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
            {  
                var ps =table.Item(listBox2.SelectedIndex+1);
                if (ps.PrimaryKey != null)
                {
                    DDL.Text = $@"
/*
====================================
||COLONNE COMPOSANTS LA CLE PRIMAIRE||
====================================
                                */";
                    foreach (var name in ps.PrimaryKey.KeyColumns)
                    {
                         DDL.Text += $@"
||{(name.ToString()).PadRight(54,' ')}||
=====================================
                                */";
                    }
                   
                }
                else
                {
                    DDL.Text = $@"
/*
=====================================
||    TABLE SANS CLE PRIMAIRE       ||
=====================================

                                */";
                }
                
              
              //  DDL.Text = ps.Keys.ToString()??" ";
                DDL.Text += @"
---------------------------------------------------------------
"+ps.Script();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ecriture(object p)
        {
            using (FileStream fs = new FileStream(fichierresult, FileMode.Open, FileSystemRights.AppendData,
                FileShare.Write, 4096, FileOptions.None))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(p);

                }
            }
        }
 
        private static object cadena = new Object();
        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //   {
            Thread[] threads = new Thread[_listeProcedureVf.Count];
            foreach (_StoredProcedure sp in _listeProcedureVf)
                {
                //Création et lancement des threads.
                    try
                    {
                        var ligne = sp.Name + '┴' + sp.Text;
                        threads[i] = new Thread(GenerationScript);
                        threads[i].Start(ligne);
                        Thread.Sleep(200);
                        i++;
                    }
                    catch (Exception X)
                    {
                        
                        i++;
                        
                    }
                    
                //On laisse passer 500ms entre les création de thread.
             
                }
            

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        //On crée notre delagate.
        public delegate void MontrerProgres();

        public void GenerationScript(object sp)
        {
            string tmp = sp as string;
          
            foreach (var item in listBox2.Items)
            {
                if (
                    tmp.Split('┴')[1].ToUpper().Contains(" "+item.ToString().ToUpper()+" ")
                    ||
                    tmp.Split('┴')[1].Contains("["+item.ToString().ToUpper()+"] ")
                    ||
                    tmp.Split('┴')[1].Contains("."+item.ToString().ToUpper()+" ")
                    
                    )
                {
                    Thread t1 = new Thread(Ecriture);
                    t1.Start($"{tmp.Split('┴')[0]};{item.ToString()}");               
                }
            }
            //lock (cadena)
            //{
            //    i++;
            //}
            Invoke((MontrerProgres)Progres);
          
        }
        public void Progres()
        {
            //On met la valeur dans le contrôle Windows Forms.
            position.Text = $"{i}/{listBox1.Items.Count} P ";
        }
    }
}
