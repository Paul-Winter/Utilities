using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа Utilities содержит ряд небольших программ,\nкоторые могут пригодится в повседневном использовании ПК.\n\n\t\tAuthor: Paul Winter", "About program");
        }
    }
}
