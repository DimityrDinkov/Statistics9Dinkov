using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics9Dinkov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAvr_Click(object sender, EventArgs e)
        {
            List<double> list = txtNum.Text.Split(' ').Select(l => double.Parse(l)).ToList();
            var average = list.Average();
            lblAvr.Text = ("Average is: " + average);
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            string[] numStrings = txtNum.Text.Split(' ');

            List<int> numbers = new List<int>();
            foreach (string numString in numStrings)
            {
if(int.TryParse(numString, out int num))
                {
                    numbers.Add(num);
                }
                else
                {
                    MessageBox.Show("Error!");
                    return;
                }
            }
            List<int> modes = FindMode(numbers);

            if(modes.Count > 0)
            {
                lblMode.Text = "Mode: " + string.Join(" ", modes);
            }
            else
            {
                lblMode.Text = "No mode";
            }
        }
        private List<int> FindMode(List<int> numbers)
        {
            var frequency = new Dictionary<int, int>();

            foreach (int number in numbers) 
            {
                if (frequency.ContainsKey(number))
                {
                    frequency[number]++;
                }
                else
                {
                    frequency[number] = 1;
                }
            }
            int maxFrequency = frequency.Values.Max();

            List<int> modes = frequency.Where(kv => kv.Value == maxFrequency).Select(kv => kv.Key).ToList();
            return modes;
        }
    }
}
