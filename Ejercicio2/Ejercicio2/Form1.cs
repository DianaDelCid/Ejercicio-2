using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void CalcularButton_Click(object sender, EventArgs e)
        {
            //Condiciones simples para que evalua si caja de texto esta vacia
            if (Nota1TextBox.Text == "")
            {
                errorProvider1.SetError(Nota1TextBox, "Ingrese Nota"); //Si es verdadera muestra un error y pide que ingrese la nota
                Nota1TextBox.Focus(); //metodo que situa el cursor en el campo nombrado
                return;
            }
            if (Nota2TextBox.Text == "")
            {
                errorProvider1.SetError(Nota2TextBox, "Ingrese Nota"); 
                Nota2TextBox.Focus(); 
                return;
            }
            if (Nota3TextBox.Text == "")
            {
                errorProvider1.SetError(Nota3TextBox, "Ingrese Nota"); 
                Nota3TextBox.Focus(); 
                return;
            }
            if (Nota4TextBox.Text == "")
            {
                errorProvider1.SetError(Nota4TextBox, "Ingrese Nota"); 
                Nota4TextBox.Focus();
                return;
            }
            errorProvider1.Clear(); //Limpia el control Error en la pantalla

            //VARIABLES Y CONVERSIÓN DE LAS CAJAS DE TEXTO
            decimal nota1 = Convert.ToDecimal(Nota1TextBox.Text);
            decimal nota2 = Convert.ToDecimal(Nota2TextBox.Text);
            decimal nota3 = Convert.ToDecimal(Nota3TextBox.Text);
            decimal nota4 = Convert.ToDecimal(Nota4TextBox.Text);


            decimal NotaFinal = await PromedioAsync(nota1, nota2, nota3, nota4);
            PromedioLabel.Text = Convert.ToString(NotaFinal);

        }

        //FUNCIÓN ASÍNCRONA
        //Permite devolver UNA TAREA que devuelve un valor decumal es decir el resultado final del promedio
        private async Task<decimal> PromedioAsync(decimal n1, decimal n2, decimal n3, decimal n4)
        {
            //DECLARAMOS EL PROMEDIO QUE VA A RETORNAR
            decimal promedio = await Task.Run(() =>
            {
                //RETORNA LA OPERACION Y LA ALMACENA EN VARIABLE PROMEDIO
                return (n1 + n2 + n3 + n4) / 4;
            });
            //RETORNA LA TAREA ASINCRONA PROMEDIO 
            return promedio;
        }

        private void BorrarButton_Click(object sender, EventArgs e)
        {
            //Boton que limpia los datos de las cajas de textos
            Nota1TextBox.Text = "";
            Nota2TextBox.Text = "";
            Nota3TextBox.Text = "";
            Nota4TextBox.Text = "";
            PromedioLabel.Text = "";
            Nota1TextBox.Focus(); //metodo que situa el cursor en el campo nombrado
        }
    }
}
