using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Calculadora
{
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
        Modulo = 5,
        Potencia = 6, //Operacion para x^y
        Factorial = 7, // Operacion para factorial

    }
    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        Operacion operador = Operacion.NoDefinida;
        private void LeerNumero(string numero)
        {
            if (cajaresultado.Text == "0" && cajaresultado.Text != null)
            {
                cajaresultado.Text = numero;
            }
            else
            {
                cajaresultado.Text += numero;
            }
        }

        private double EjecutarOperacion()
        {
            double resultado = 0;
            switch (operador)
            {

                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.Division:
                    if (valor2 == 0)
                    {
                        MessageBox.Show("No se puede dividir entre 0");
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;
                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.Modulo:
                    resultado = valor1 % valor2;
                    break;
                case Operacion.Potencia:
                    resultado = Math.Pow(valor1, valor2);
                    break;



            }
            return resultado;

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            operador = Operacion.Division;
            Obtenervalor("/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (valor2 == 0)
            {
                valor2 = Convert.ToDouble(cajaresultado.Text);
                lblhistorial.Text += valor2 + "=";
                double resultado = EjecutarOperacion();
                valor1 = 0;
                valor2 = 0;
                cajaresultado.Text = Convert.ToString(resultado);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            LeerNumero("1");
        }

        private void Obtenervalor(string operador)
        {
            valor1 = Convert.ToDouble(cajaresultado.Text);
            lblhistorial.Text = cajaresultado + operador;
            cajaresultado.Text = "0";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            operador = Operacion.Suma;
            Obtenervalor("+");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cajaresultado.Text = "0";
            lblhistorial.Text = "";

        }

        private void button18_Click(object sender, EventArgs e)
        {
            LeerNumero("2");

        }

        private void button15_Click(object sender, EventArgs e)
        {
            operador = Operacion.Resta;
            Obtenervalor("-");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cajaresultado.Text.Length > 1)
            {
                string txtResultado = cajaresultado.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                if (txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    cajaresultado.Text = "0";
                }
                else
                {
                    cajaresultado.Text = txtResultado;
                }

            }
            else
            {
                cajaresultado.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(cajaresultado.Text, out double valor))
            {
                if (valor < 0)
                {
                    MessageBox.Show("No se puede calcular la raíz cuadrada de un número negativo.");
                }
                else
                {

                    double resultado = Math.Sqrt(valor);


                    cajaresultado.Text = resultado.ToString();


                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un número válido.");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            LeerNumero("3");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            LeerNumero("4");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            LeerNumero("5");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            LeerNumero("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LeerNumero("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LeerNumero("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LeerNumero("9");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            cajaresultado.Text = cajaresultado.Text + "0";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            cajaresultado.Text = cajaresultado.Text + ",";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            operador = Operacion.Multiplicacion;
            Obtenervalor("x");

        }

        private void lblhistorial_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            operador = Operacion.Modulo;
            Obtenervalor("%");
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            if (double.TryParse(cajaresultado.Text, out double valor))
            {

                double resultado = Math.Log10(valor);


                cajaresultado.Text = resultado.ToString();


            }
            else
            {
                MessageBox.Show("Por favor ingrese un número válido.");
            }
        }


        private void buttonPotencia_Click(object sender, EventArgs e)
        {
            operador = Operacion.Potencia;
            Obtenervalor("^");
        }

        private void buttonCuadrado_Click(object sender, EventArgs e)
        {
            if (double.TryParse(cajaresultado.Text, out double valor))
            {
                double resultado = Math.Pow(valor, 2); //Elevacion al cuadrado
                cajaresultado.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Por favor ingrese un numero valido");
            }
        }





        private void button11_Click(object sender, EventArgs e)
        {
            if (double.TryParse(cajaresultado.Text, out double valor))
            {
                double resultado = valor * Math.Pow(10, valor);


                cajaresultado.Text = resultado.ToString();


            }
            else
            {
                MessageBox.Show("Por favor ingrese un número válido.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(cajaresultado.Text, out int valor))
            {
                if (valor < 0)
                {
                    MessageBox.Show("El factorial no está definido para números negativos.");
                }
                else
                {
                    // Calcula el factorial del valor actual
                    long resultado = Factorial(valor);

                    // Muestra el resultado en la caja de texto
                    cajaresultado.Text = resultado.ToString();

                    // Actualiza el historial si es necesario
                    lblhistorial.Text = valor + "! = " + resultado;
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un número válido.");
            }
        }
        // Función para calcular el factorial
        private long Factorial(int n)
        {
            long resultado = 1;
            for (int i = 1; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }
    }
}

