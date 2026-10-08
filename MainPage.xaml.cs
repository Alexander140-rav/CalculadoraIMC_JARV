using System;
using System.Globalization;

namespace CalculadoraIMC_JARV
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Altura.Text) && !string.IsNullOrEmpty(Peso.Text))
            {
                // Reemplazamos coma por punto para evitar errores de formato por región
                string textoAltura = Altura.Text.Replace(',', '.');
                string textoPeso = Peso.Text.Replace(',', '.');

                double altura = double.Parse(textoAltura, CultureInfo.InvariantCulture);
                double peso = double.Parse(textoPeso, CultureInfo.InvariantCulture);

                // Si la altura se ingresó en centímetros (ejemplo: 184), se convierte a metros (1.84)
                if (altura > 3)
                {
                    altura = altura / 100;
                }

                double imc = peso / (altura * altura);
                IMC.Text = imc.ToString("F2"); // Formatea el resultado a 2 decimales

                string resultado = "";

                if (imc < 18.5)
                {
                    resultado = "Tienes bajo peso";
                }
                else if (imc >= 18.5 && imc <= 24.9)
                {
                    resultado = "Tu peso es normal";
                }
                else if (imc >= 25 && imc <= 29.9)
                {
                    resultado = "Tienes sobre peso";
                }
                else
                {
                    resultado = "Tienes obesidad, cuidate!";
                }

                DisplayAlert("Resultado:", resultado, "Quitar");
            }
            else
            {
                DisplayAlert("Datos erroneos", "Por favor, llena toda la informacion", "Quitar");
            }
        }
    }
}