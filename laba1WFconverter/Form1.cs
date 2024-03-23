using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba1WFconverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                double mile; // расстояние в милях
                double km;     // расстояние в км

                // если в поле редактирования нет данных
                // то при попытке преобразовать пустую
                // строку в число возникает исключение
                try
                {
                    mile = Convert.ToDouble(textBox1.Text);
                    km = mile * 1.609344;
                    label3.Text = km.ToString("n");
                }
                catch
                {   //обработка исключения:
                    // переместить курсор в поле редактирования
                    textBox1.Focus();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return; //цифра
            }
            if (e.KeyChar == '.')
            {
                //замена точки запятой
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                { e.Handled = true; }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    //установить курсор на кнопку ОК
                    button1.Focus();
                return;
            }
            // остальные символы запрещены
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    }

