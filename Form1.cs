using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 Написать приложение, обладающее следующей функциональностью:
 После нажатия клавиши <Enter> через каждую секунду (или иной 
промежуток времени) «прячется» одна из кнопок «Калькулятора», 
выбранная случайным образом;
 После нажатия клавиши <Esc> данный процесс останавливается.
*/

namespace Buttons_Hide
{
    public partial class Form1 : Form
    {
        private int first;           // первое число
        private int second;          // второе число
        private char sign;           // оператор
        private int visibleControls; // счетчик видимых кнопок и полей
        public Form1()
        {
            InitializeComponent();
            Result.Text = 0.ToString();
            this.KeyPreview = true;
            visibleControls = this.Controls.Count;
        }

        #region Кнопки калькулятора
        private void button7_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button7.Text;
            else
                Result.Text += button7.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button6.Text;
            else
                Result.Text += button6.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button5.Text;
            else
                Result.Text += button5.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button4.Text;
            else
                Result.Text += button4.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button3.Text;
            else
                Result.Text += button3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button2.Text;
            else
                Result.Text += button2.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button15.Text;
            else
                Result.Text += button15.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button14.Text;
            else
                Result.Text += button14.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button13.Text;
            else
                Result.Text += button13.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Result.Text == "" || Convert.ToInt32(Result.Text) == 0)
                Result.Text = button9.Text;
            else
                Result.Text += button9.Text;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Result.Text = 0.ToString();
        }

        private void Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number))
                e.Handled = true;
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            first = Convert.ToInt32(Result.Text);
            sign = '+';
            Result.Text = 0.ToString();
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            first = Convert.ToInt32(Result.Text);
            sign = '-';
            Result.Text = 0.ToString();
        }

        private void Mul_Click(object sender, EventArgs e)
        {
            first = Convert.ToInt32(Result.Text);
            sign = '*';
            Result.Text = 0.ToString();
        }

        private void Div_Click(object sender, EventArgs e)
        {
            first = Convert.ToInt32(Result.Text);
            sign = '/';
            Result.Text = 0.ToString();
        }

        private double ResultCalc(int first, int second, char sign)
        {
            switch (sign)
            {
                case '+': return (double)first + second;
                case '-': return (double)first - second;
                case '*': return (double)first * second;
                case '/': return (double)first / second;
                default: throw new Exception("неверный символ");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            second = Convert.ToInt32(Result.Text);
            Result.Text = ResultCalc(first, second, sign).ToString();
        }

        #endregion

        // при отпускании кнопки Ввод запускается таймер
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Tick += Timer1_Tick;
                timer1.Interval = 1000;
                timer1.Start();
            }

            if (e.KeyCode == Keys.Escape)
            {
                timer1.Stop();
            }
        }

        // каждый тик один элемент калькулятора будет становиться невидимым
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int index;
            do
            {
                index = r.Next(0, this.Controls.Count);
            } while (Controls[index].Visible == false);

            Controls[index].Visible = false;
            --visibleControls;
            if (visibleControls == 0)
                timer1.Stop();
        }
    }
}
