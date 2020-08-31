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
        Dictionary<string, double> metrica;
        
        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            metrica = new Dictionary<string, double>();

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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double m1 = metrica[cbFrom.Text];
            double m2 = metrica[cbTo.Text];
            double n = Convert.ToDouble(tbFrom.Text);
            tbTo.Text = (n * m1 / m2).ToString();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string temp = cbFrom.Text;
            cbFrom.Text = cbTo.Text;
            cbTo.Text = temp;
        }

        private void cbMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMetric.Text)
            {
                case "вес":
                    metrica.Clear();
                    metrica.Add("g", 1);
                    metrica.Add("oz", 283);
                    metrica.Add("lb", 453.6);
                    metrica.Add("kg", 1000);
                    metrica.Add("t", 1000000);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("g");
                    cbFrom.Items.Add("oz");
                    cbFrom.Items.Add("lb");
                    cbFrom.Items.Add("kg");
                    cbFrom.Items.Add("t");
                    cbFrom.Text = "g";
                    cbTo.Items.Clear();
                    cbTo.Items.Add("g");
                    cbTo.Items.Add("oz");
                    cbTo.Items.Add("lb");
                    cbTo.Items.Add("kg");
                    cbTo.Items.Add("t");
                    cbTo.Text = "g";
                    break;
                    
                case "длина":
                    metrica.Clear();
                    metrica.Add("mm", 1);
                    metrica.Add("cm", 10);
                    metrica.Add("dm", 100);
                    metrica.Add("m", 1000);
                    metrica.Add("km", 1000000);
                    metrica.Add("mile", 1609344);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("mm");
                    cbFrom.Items.Add("cm");
                    cbFrom.Items.Add("dm");
                    cbFrom.Items.Add("m");
                    cbFrom.Items.Add("km");
                    cbFrom.Items.Add("mile");
                    cbFrom.Text = "mm";
                    cbTo.Items.Clear();
                    cbTo.Items.Add("mm");
                    cbTo.Items.Add("cm");
                    cbTo.Items.Add("dm");
                    cbTo.Items.Add("m");
                    cbTo.Items.Add("km");
                    cbTo.Items.Add("mile");
                    cbTo.Text = "mm";
                    break;
                default:
                    metrica.Clear();
                    cbFrom.Items.Clear();
                    cbTo.Items.Clear();
                    break;
            }
        }
    }
}
