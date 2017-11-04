using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PerryCostumeDataSet
{
    public partial class Form1 : Form
    {
        private List<Costume> costumes = new List<Costume>();
        private int minValue;
        private int maxValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void Process()
        {
            using (StreamReader file = new StreamReader(textBox1.Text))
            {
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();

                    // process file
                    string[] data = line.Split(',');

                    int cost;
                    if (int.TryParse(data[2], out cost))
                    {
                        int purchases = int.Parse(data[0]);
                        string name = data[1];
                        string scary = data[3];

                        Costume c = new Costume(purchases, name, cost, scary);
                        costumes.Add(c);
                    }
                }
            }

            minValue = (int)numericUpDown1.Value;
            maxValue = (int)numericUpDown2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process();

            var avgScary = from c in costumes
                           where c.Scary.Contains("yes")
                           select c.Cost;

            var avgNonScary = from c in costumes
                           where c.Scary.Contains("no")
                           select c.Cost;

            richTextBox1.Clear();
            richTextBox1.Text += $"Scary Average: {avgScary.Average()}";
            richTextBox1.Text += "\n";
            richTextBox1.Text += $"nonScary Average: {avgNonScary.Average()}";
            richTextBox1.Text += "\n";

            if (numericUpDown2.Value != 0)
            {
                var BetweenMinMax = from c in costumes
                                    where c.Cost >= minValue && c.Cost <= maxValue
                                    orderby c.Cost ascending
                                    select c;

                var Top3 = (from c in costumes
                            orderby c.TotalSales descending
                            select c).Take(3);

                foreach (Costume c in BetweenMinMax)
                {
                    richTextBox1.AppendText($"{c.Cost:C}\n");
                }

                int i = 1;
                foreach (Costume c in Top3)
                {
                    richTextBox1.AppendText($"Top{i}: {c.Cost:C}{c.Name}{c.TotalSales:C}\n");
                    i++;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(textBox1.Text);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconPadding(textBox1, 5);

            if (textBox1.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Error, pick a file");
            }

            else if (!(File.Exists(textBox1.Text)))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, $"{textBox1.Text} is not a file");
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            errorProvider1.Clear();
        }
    }
}
