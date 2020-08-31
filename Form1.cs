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
        int count = 0;
        static Random random;
        string password;
        char[] specChars = new char[] {'~', '@', '#', '$', '%', '^', '&', '*', '(', ')'};
        
        public MainForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа Utilities содержит ряд небольших программ,\nкоторые могут пригодится в повседневном использовании ПК.\n\n\t\tAuthor: Paul Winter", "About program");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCount.Text = Convert.ToString(count);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                MessageBox.Show("Uncorrect input data\nPlease, try again", "ERROR!");
                var temp = numericUpDown1.Value;
                numericUpDown1.Value = numericUpDown2.Value;
                numericUpDown2.Value = temp;
            }
            int gen;
            gen = random.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) + 1);

            if (cbRandom.Checked)
            {
                int i = 0;                              //
                while (tbRandom.Text.IndexOf(gen.ToString()) != -1)
                {
                    gen = random.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) + 1);
                    i++;                                //
                    if (i > 1000) break;                //
                    //lblRandom.Text = gen.ToString();
                    //tbRandom.AppendText(gen + "\n");
                }
                if (i <= 1000)
                {
                    lblRandom.Text = gen.ToString();
                    tbRandom.AppendText(gen + "\n");
                }
            }
            else                                        //
            {
                lblRandom.Text = gen.ToString();
                tbRandom.AppendText(gen + "\n");
            }
        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void btnRandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }

        private void tmsiInsertDate_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortDateString() + "\n");
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            rtbNotepad.Clear();
        }

        private void tsmiSaveNote_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotepad.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error save");
            }
        }

        void LoadNotepad()
        {
            try
            {
                rtbNotepad.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error load");
            }
        }

        private void tsmiLoadNote_Click(object sender, EventArgs e)
        {
            LoadNotepad();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNotepad();
            clbPassword.SetItemChecked(0, true);
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            password = "";
            if (clbPassword.CheckedItems.Count == 0)
                return;

            for (int count = 0; count < nudPassLength.Value; count++)
            {
                int i = random.Next(clbPassword.CheckedItems.Count);
                string s = clbPassword.CheckedItems[i].ToString();
                switch (s)
                {
                    case "Цифры": password += random.Next(10); break;
                    case "Прописные буквы": password += Convert.ToChar(random.Next(65, 91)); break;
                    case "Строчные буквы": password += Convert.ToChar(random.Next(97, 123)); break;
                    default: password += specChars[random.Next(specChars.Length)]; break;
                }
                tbPassword.Text = password;
            }
        }

        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
                Clipboard.SetText(password);
        }

        private void tsmiInsertBuffer_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(Clipboard.GetText());
        }
    }
}
