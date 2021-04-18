using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace Mostrar_tablas_de_cualquier_operacion
{
    public partial class Form1 : Form
    {
        //Variables
        string Operation;
        string Number;
        string Output;
        int Iterator;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { AskOperation(); }

        private void AskOperation()
        {
            Operation = Interaction.InputBox("¿Que operación desea mostrar?\nEliga el número\n\n1. Suma\n2. Resta\n3. Multiplicación\n4. División", "Elija una Operación", "1");

            AskNumber();
        }

        private void AskNumber()
        {
            Number = Interaction.InputBox("Digite el numero a imprimir tabla", "Elija un Numero", "1");

            CalculateAll();
        }

        private void CalculateAll()
        {
            Output = string.Empty;
            try
            {
                for (Iterator = 1; Iterator <= 12; Iterator++)
                {
                    switch (Operation)
                    {
                        case "1":
                            Output += Number + " + " + Iterator + " = " + ((Int32.Parse(Number)) + (int)(Iterator)) +"\n";
                            break;

                        case "2":
                            Output += Number + " - " + Iterator + " = " + ((Int32.Parse(Number)) - (int)(Iterator)) + "\n";
                            break;

                        case "3":
                            Output += Number + " x " + Iterator + " = " + ((Int32.Parse(Number)) * (int)(Iterator)) + "\n";
                            break;

                        case "4":
                            Output += Number + " ÷ " + Iterator + " = " + ((Int32.Parse(Number)) / (float)(Iterator)).ToString("0.000") + "\n";
                            break;

                        default:
                            MessageBox.Show("Comportamiento no permitido, proceso bloqueado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AskNumber();
                            break;
                    }
                }

                DialogResult dialog = MessageBox.Show("Resultado\n\n" + Output + "\n\nDesea repetir el proceso", "Salida", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                if (dialog == DialogResult.Cancel)
                    return;

                AskOperation();
            }
            catch (Exception error)
            {
                DialogResult dialog = MessageBox.Show("Hubo un error fatal:\n\nError: " + error.Message + "\ncodigo: " + error.HResult + "\nNo se pudo completar el proceso", "Error fatal", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (dialog == DialogResult.Cancel)
                    return;

                AskOperation();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Está seguro que desea salir del programa?", "¡Está saliendo del programa!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialog == DialogResult.No)
                return;

            MessageBox.Show("Gracias por usar mi aplicación", "¡Salió del programa!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
    }
}
