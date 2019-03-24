using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateDatabaseLibrary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createDatabaseButton_Click(object sender, EventArgs e)
        {
            var ops = new CreateDatabase(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database1.accdb"));
            if (ops.Execute())
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Failed");
            }
            
        }
    }
}
