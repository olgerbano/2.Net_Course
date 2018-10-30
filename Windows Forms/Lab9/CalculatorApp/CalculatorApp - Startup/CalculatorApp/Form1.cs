using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Type calcType;
        public object calcInstance;
        private string lastCommand;

        public Form1()
        {
            InitializeComponent();

            // Incarcati assembly-ul Test.dll
            // Obtineti tipul Calculator si creati o instanta
 
            SetResult();
            valueTb.Text = "0";
            lastCommand = string.Empty;
        }

        // Aceasta metoda este chemata cand se completeaza o valoare in textBox
        private void ValueCanged(object sender, EventArgs e)
        {
            double result;
            if (!Double.TryParse(valueTb.Text, out result))
            {
                valueTb.Text = "0";
            }
        }

        private void AddValue(object sender, EventArgs e)
        {
            double value = Double.Parse(valueTb.Text);

            // Obtineti metoda necesara pentru a efectua operatia de adunare
            // Chemati aceasta metoda

            SetResult();
            lastCommand = "Add";
        }

        private void SubstractValue(object sender, EventArgs e)
        {
            double value = Double.Parse(valueTb.Text);

            // Obtineti metoda necesara pentru a efectua operatia de scadere
            // Chemati aceasta metoda

            SetResult();
            lastCommand = "Substract";

        }

        private void Equal(object sender, EventArgs e)
        {
            double value = Double.Parse(valueTb.Text);

            // In functie de ultima operatie ceruta, cautati metoda necesara si apelati-o
       
            SetResult();
            valueTb.Text = "0";
        }

        // Aceasta metoda va reseta valoare retinuta in instanta calcInstance
        private void Clear(object sender, EventArgs e)
        {
            // Obtineti metoda necesara pentru a reseta valorile
            // Chemati aceasta metoda

            SetResult();
        }


        // Aceasta metoda va seta rezultatul in textBox-ul resultTb
        private void SetResult()
        {
            string result = string.Empty;

            // Obtineti valoarea retinuta in instanta 

            resultTb.Text = result;
        }
    }
}
