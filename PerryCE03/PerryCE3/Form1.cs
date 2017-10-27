using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerryCE3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TwoDoublesRadioButton.Checked = true;
        }

        private void calculate(out List<double> cost)
        {
            cost = new List<double>();
            int guests;
            int nights;

            if(!int.TryParse(NumberOfGuestsText.Text, out guests))
            {
                MessageBox.Show("how could you not enter a number?");
                NumberOfGuestsText.Focus();
                NumberOfGuestsText.ForeColor = Color.Red;
                cost.Clear();
                cost = null;
                return;
            }
            if (!int.TryParse(NumberOfNightsText.Text, out nights))
            {
                MessageBox.Show("how could you not enter a number?");
                NumberOfNightsText.Focus();
                NumberOfNightsText.ForeColor = Color.Red;
                cost.Clear();
                cost = null;
                return;
            }

            cost.Add(nights * (65 + 35 * guests));

            if(QueenRadioButton.Checked)
            {
                cost[0] = (nights * (20 + 65 + 35 * guests));
            }
            if (QueenRadioButton.Checked && ContinentalBreakfastCheckBox.Checked)
            {
                cost[0] = (nights * (20 + 10 + 65 + 35 * guests));
            }
            if (KingRadioButton.Checked)
            {
                cost[0] = (nights * (40 + 65 + 35 * guests));
            }
            if (KingRadioButton.Checked && ContinentalBreakfastCheckBox.Checked)
            {
                cost[0] = (nights * (40 + 10 + 65 + 35 * guests));
            }

            cost.Add(.09 * cost[0]);

            cost.Add(cost[0] + cost[1]);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            NumberOfGuestsText.ForeColor = Color.Black;
            NumberOfGuestsText.BackColor = Color.White;

            NumberOfNightsText.ForeColor = Color.Black;
            NumberOfNightsText.BackColor = Color.White;

            if(NumberOfGuestsText.Text == "")
            {
                MessageBox.Show("please enter number of guests");
                NumberOfGuestsText.Focus();
                NumberOfGuestsText.BackColor = Color.Yellow;
                return;
            }
            else if(NumberOfNightsText.Text == "")
            {
                MessageBox.Show("please enter number of nights");
                NumberOfNightsText.Focus();
                NumberOfNightsText.BackColor = Color.Yellow;
                return;
            }
            else
            {
                List<double> cost;
                calculate(out cost);

                if (cost != null)
                {
                    ReservationCostText.Text = $"{cost[0]:C}";
                    TaxText.Text = $"{cost[1]:C}";
                    TotalCostText.Text = $"{cost[2]:C}";
                }
            }
        }
    }
}
