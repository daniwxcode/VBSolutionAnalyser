using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBIS_TACHE
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ibis = new Ibistache();
            this.StartPosition= FormStartPosition.CenterScreen;
            ibis.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            new SQLObject().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CompressionPDF().ShowDialog();
        }
    }
}
