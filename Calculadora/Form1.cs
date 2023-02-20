using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class formCalculadora : Form
    {
        double numero1 = 0, numero2 = 0;
        char Operador;
        public formCalculadora()
        {
            InitializeComponent();
        }

        private void agregarNumero(object sender ,EventArgs e) 
        {
            var boton = ((Button)sender);
            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);

            if (Operador == '+')
            {
                txtResultado.Text = (numero1 + numero2).ToString();
                numero1= Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == '-')
            {
                txtResultado.Text = (numero1 - numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == '/')
            {
                if (txtResultado.Text != "0") 
                {
                txtResultado.Text = (numero1 / numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);

                }
                else
                {
                    MessageBox.Show("Nose puede dividir por cero!");
                }
            }
            else if (Operador == 'X')
            {
                txtResultado.Text = (numero1 * numero2).ToString();
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 1 )
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnBorrartodo_Click(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            txtResultado.Text = "0";
            Operador = '\0';
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        private void btnCambioSigno_Click(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(txtResultado.Text);
            numero1 *= -1; //cualquier número que lo multipliques por(*=) -1 sea negativo o positivo cambia de signo
            txtResultado.Text = numero1.ToString(); 
        }

        private void clickoperador(object sender ,EventArgs e) 
        {
            var boton = ((Button)sender);

            numero1 = Convert.ToDouble(txtResultado.Text);
            Operador = Convert.ToChar(boton.Tag);

            if (Operador == '²')
            {
                numero1 = Math.Pow(numero1, 2);
                txtResultado.Text = numero1.ToString();
            }
            else if (Operador == '√')
            {
                numero1 = Math.Sqrt(numero1);
                txtResultado.Text = numero1.ToString();
            }
            else
            {
                txtResultado.Text = "0";
            }       
        
        
        }
    }
}
