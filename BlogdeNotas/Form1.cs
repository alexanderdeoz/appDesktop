using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //

namespace BlogdeNotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpen = new OpenFileDialog();//open file dialog abre el navegador par aimportar y creamos un objeto con una clase
            StreamReader myLectura = null;
            myOpen.Filter = "Archivo de texto (.txt)|*.text|Todos los archivos(*.*)|*.*"; //crearmos la ruta donde vamos a sacar el archivo 
            myOpen.Title = "Abrir archivo ";// poner titulo al archivo
            myOpen.ShowDialog();//ejecuta un cuadro de dialogo con un propietario predeterminado
            myOpen.OpenFile(); //abre el archivo seleccionado solo lectura
            string rutaArchivo = myOpen.FileName; //obtenemos la cadena de archivos seleccionador
            myLectura = File.OpenText(rutaArchivo);
            richTextBox1.Text = myLectura.ReadToEnd();

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySave = new SaveFileDialog();
            StreamWriter myEscritura = null;
            mySave.Filter = "Archivo de texto (.txt)|*.text|Todos los archivos(*.*)|*.*";
            mySave.Title = "Guarcar Como";
            mySave.ShowDialog();
            string ruta = mySave.FileName;
            myEscritura = File.AppendText(ruta); //apptext crea el archivo
            myEscritura.Write(richTextBox1.Text);
            myEscritura.Flush(); // flasj borr y escribe el archivo 
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();//vuelve aplicar la ultima operacion indicada en el control

        }

        private void atrasdesacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();//desase la ultima ves la edision de texto 
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void borrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void horaYFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            richTextBox1.Text = fecha.ToString();
        }

        private void estiloFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog myFont = new FontDialog();
            myFont.Font = richTextBox1.Font;
            if (myFont.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = myFont.Font;
            }
        }

        private void colorFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog myColor = new ColorDialog();
            if (myColor.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.ForeColor = myColor.Color;
            }
        }

        private void colorDeFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog myFondo = new ColorDialog();
            if (myFondo.ShowDialog()==DialogResult.OK) 
            {
                richTextBox1.BackColor = myFondo.Color;
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Steven ChinchinDS  Creacion de app de escritorio");
        }
    }
}
