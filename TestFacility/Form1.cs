using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TestFacility;


namespace TestFacility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String inputText = richTextBox1.Text;
            long[] unsortedArray = HelpersLib.parseRichTextBoxData(inputText);

            if (unsortedArray.Length == 0)
            {
                MessageBox.Show(
                    "Вы должны ввести исходные элементы массива",
                    "Ошибка ввода данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                richTextBox1.Focus();
                return;
            }

            long[] sortedArray = HelpersLib.gnomeSort(unsortedArray);
            richTextBox2.Text = String.Join(",", sortedArray);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            long needle;
            bool itemInArray = false;
            
            String inputText = richTextBox4.Text;
            long[] unsortedArray = HelpersLib.parseRichTextBoxData(inputText);
            
            if (unsortedArray.Length == 0)
            {
                MessageBox.Show(
                    "Вы должны ввести исходные элементы массива",
                    "Ошибка ввода данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                richTextBox4.Focus();
                return;
            }

            long[] sortedArray = HelpersLib.gnomeSort(unsortedArray);
            bool isParsed = Int64.TryParse(textBox1.Text, out needle);

            if (!isParsed)
            {
                MessageBox.Show(
                    "Введите целочисленное значение искомого элемента",
                    "Ошибка ввода данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                textBox1.Clear();
                textBox1.Focus();
                
                return;
            }

            itemInArray = HelpersLib.isItemInArray(needle, sortedArray);
            label8.Text = itemInArray ? "Искомый элемент находится в массиве" : "Искомый элемент НЕ найден в массиве";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] numbers = HelpersLib.getNumbers();
            String summ = HelpersLib.getArrayItemsSumm(numbers).ToString();
            richTextBox5.Text = String.Join(" + ", numbers) + " = " + summ;
            label9.Text = summ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String inputText = richTextBox6.Text;
            long[] unsortedArray = HelpersLib.parseRichTextBoxData(inputText);

            if (unsortedArray.Length == 0)
            {
                MessageBox.Show(
                    "Вы должны ввести исходные элементы массива",
                    "Ошибка ввода данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                richTextBox6.Focus();
                return;
            }

            long singletone = HelpersLib.findSingletone(unsortedArray);
            label17.Text = singletone.ToString();
        }

        /**
         * Prevents keyboard input characters other than numbers
         */
        private void denyNotNumbersInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            denyNotNumbersInput(sender, e);
        }

        private void richTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            denyNotNumbersInput(sender, e);
        }

        private void richTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            denyNotNumbersInput(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Double.Parse(textBox2.Text);
                double y = Double.Parse(textBox3.Text);

                if (HelpersLib.checkNumbersInRange(x, y))
                {
                    label24.Text = "Координаты находятся в диапазоне";
                }
                else
                {
                    label24.Text = "Координаты НЕ находятся в диапазоне";
                }
            }
            catch (FormatException formatException)
            {
                MessageBox.Show(
                    "Координаты X и Y должны быть вещественными числами",
                    "Ошибка ввода данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Focus();
            }
        }
    }
}
