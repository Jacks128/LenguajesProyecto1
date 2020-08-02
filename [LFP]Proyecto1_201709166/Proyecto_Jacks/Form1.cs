using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = System.Drawing.Image;
namespace Proyecto_Jacks
{
    public partial class Form1 : Form
    {
        private static string filefule;
        Boolean abrir = false;
        Analizador analizador;
        Manejador token;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            String entry = rtbTexto.Text;
            analizador = new Analizador();
            analizador.Scanear(entry);

            if (Manejador.Obtenerllamado().getsalidaError().Count == 0)
            {
                analizador.TokenHTML();
                Mostrar();
                LlenarLista();
               
                generarArchivoDot();
                MostrarPais();
                IEnumerable<Pais> paises = Manejador.Obtenerllamado().GetPais().OrderBy(pais => pais.getSaturacion());
                txtpais.Text = paises.ElementAt(0).getPais();
                txtPos.Text = paises.ElementAt(0).getPoblacion().ToString();
                string imagen = paises.ElementAt(0).getBandera();
                string imagenBuena = imagen.Trim('"');

                try
                {
                    pictureBox1.Image = Image.FromFile(@imagenBuena);
                }
                catch (Exception)
                {
                    MessageBox.Show("No fue posible cargar la imagen");

                }


                Console.WriteLine(Manejador.Obtenerllamado().GetPais().Count);
              
                string url = "C:\\Users\\Benitez\\Desktop\\[LFP]Proyecto1_201709166\\Proyecto_Jacks\\bin\\Debug\\alfin.jpg";
         
                string urlBuena = url.Trim('"');
                try
                {
                    rtbGrafo.Image = Image.FromFile(@urlBuena);
                }
                catch (Exception)
                {

                    MessageBox.Show("No fue posible cargar la imagen");
                }

                // analizador.ImprimirTokens();
                // analizador.Mostrar();
            }

            else
            {
                analizador.ErrorHTML();
            }
        }


    private void label2_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            abrir = true;

            if (buscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filefule = buscar.FileName.ToString();
                string Textfile = File.ReadAllText(filefule);
                rtbTexto.Text = Textfile;
            }
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();
            abrir = true;

            if (buscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filefule = buscar.FileName.ToString();
                string Textfile = File.ReadAllText(filefule);
                rtbTexto.Text = Textfile;
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            MessageBox.Show("Guardado", "",
          MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jackeline Alexandra Benitez Benitez   Carnet 201709166", "Acerca de",
          MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }

        private void menúToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            if (guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter archivo = File.CreateText(guardar.FileName);
                archivo.Write(rtbTexto.Text);
                archivo.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void rtbTexto_TextChanged(object sender, EventArgs e)
        {

        }
        public static void Colorear(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }


        public void Mostrar()
        {
            rtbTexto.Clear();

            for (int i = 0; i < Manejador.Obtenerllamado().getsalidaToken().Count(); i++)
            {
                int id = Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).GetId();
                if (id == 1)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Blue);
                }
                else if (id == 2)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Blue);
                }
                else if (id == 11)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Blue);
                }
                else if (id == 3)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Blue);
                }
                else if (id == 4)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Blue);
                }
                else if (id == 6)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Blue);
                }
                else if (id == 7)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Blue);
                }
                else if (id == 9)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.ForestGreen);
                    //Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Black);
                }
                else if (id == 8)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.ForestGreen);

                }
                else if (id == 10)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Yellow);

                }
                else if (id == 14)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Red);
                }
                else if (id == 13)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Orange);
                }
                else if (id == 12)
                {
                    Colorear(rtbTexto, Manejador.Obtenerllamado().getsalidaToken().ElementAt(i).getAuxlex(), Color.Black);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            rtbTexto.Text = "";
            Manejador.Obtenerllamado().getsalidaToken().Clear();
            Manejador.Obtenerllamado().getsalidaError().Clear();
            Manejador.Obtenerllamado().GetPais().Clear();
           
            txtpais.Text = "";
            txtPos.Text = "";
            pictureBox1.Image = null;
            rtbGrafo.Image = null;
        }

        public void MostrarPais() {
            for (int i = 0; i < Manejador.Obtenerllamado().GetPais().Count(); i++)
            {
                Pais aux = Manejador.Obtenerllamado().GetPais().ElementAt(i);
                Console.WriteLine(aux.getNameGraphic() + "| " + aux.getContinente() + "|" + aux.getSatCont() + "|" + aux.getPais() + "| " + aux.getPoblacion() + " |" + aux.getSaturacion() + "| " + aux.getBandera());

            }
        }

        public string generarDot()
        {
            string cadena = "digraph hierarchy{\n" +
                "size=4 \n" +
                "node[shape=record]\n";
            string nodos = "";
            string enlaces = "";
            Pais aux;
            for (int i = 0; i < Manejador.Obtenerllamado().GetPais().Count; i++)/*Recorro lista de Pais*/
            {
                aux = Manejador.Obtenerllamado().GetPais().ElementAt(i);
                nodos += "\"" + aux.getNameGraphic() + "\"[shape=Mdiamond label= \"" + aux.getNameGraphic() + "\" ]\n" +
                    "\"" + aux.getContinente() + "\"[label=\"{" + aux.getContinente() + "|" + aux.getSatCont() + "}\" style= filled fillcolor=" + darColor(aux.getSatCont()) + "]\n" +
                    "\"" + aux.getPais() + "\"[label=\"{" + aux.getPais() + "|" + aux.getSaturacion() + "}\" style=filled fillcolor=" + darColor(aux.getSaturacion()) + "]\n";
                enlaces += "\"" + aux.getNameGraphic() + "\" -> " + "\"" + aux.getContinente() + "\"\n";
                enlaces += "\"" + aux.getContinente() + "\" -> " + "\"" + aux.getPais() + "\"\n";
            }
            cadena += nodos + enlaces + "}";
            return cadena;
        }


        String ruta;
        #region HTML
        public void generarArchivoDot()
        {
            File.WriteAllText("imagen.txt", generarDot());
            System.Diagnostics.Process.Start("imagen.txt");
            System.Diagnostics.Process proce = new System.Diagnostics.Process();
            proce.StartInfo.FileName = "cmd.exe";
            proce.StartInfo.RedirectStandardInput = true;
            proce.StartInfo.RedirectStandardOutput = true;
            proce.StartInfo.CreateNoWindow = true;
            proce.StartInfo.UseShellExecute = false;
            proce.Start();
            proce.StandardInput.WriteLine("dot -Tjpg imagen.txt -o alfin.jpg");
            proce.StandardInput.Flush();
            proce.StandardInput.Close();
            //ruta = Path.GetFullPath("alfin.jpg");
            //proce.WaitForExit();
        }
        #endregion
      //  Console.WriteLine(ruta);
        public string darColor(int saturacion)
        {
            String color = "";
            if (0 <= saturacion && saturacion <= 15)
            {
                color = "white";
            }
            else if (16 <= saturacion && saturacion <= 30)
            {
                color = "blue";
            }
            else if (31 <= saturacion && saturacion <= 45)
            {
                color = "green";
            }
            else if (46 <= saturacion && saturacion <= 60)
            {
                color = "yellow";
            }
            else if (61 <= saturacion && saturacion <= 75)
            {
                color = "orange";
            }
            else if (76 <= saturacion && saturacion <= 100)
            {
                color = "red";
            }
            return color;
        }
       

        public void LlenarLista() {
            string grafica = "";
            string continente = "";
            int numerador = 0;
            int cantPais = 0;
            string pais = "";
            int poblacion = 0;
            int saturacion = 0;
            string bandera = "";



            List<Token> listaux = Manejador.Obtenerllamado().getsalidaToken();
            for (int i = 0; i < listaux.Count; i++)
            {
                if (listaux.ElementAt(i).getAuxlex().Equals("Grafica"))
                {
                    grafica = listaux.ElementAt(i + 5).getAuxlex().Trim('"');
                }
                else if (listaux.ElementAt(i).getAuxlex().Equals("Continente"))
                {
                    continente = listaux.ElementAt(i + 5).getAuxlex().Trim('"');
                }
                else if ((listaux.ElementAt(i).getAuxlex().Equals("Nombre")
                    && (!listaux.ElementAt(i - 2).getAuxlex().Equals("Grafica") ||
                    !listaux.ElementAt(i - 2).getAuxlex().Equals("Continente"))))
                {
                    pais = listaux.ElementAt(i + 2).getAuxlex().Trim('"');
                    cantPais++;
                    Console.WriteLine(pais);

                }
                else if (listaux.ElementAt(i).getAuxlex().Equals("Poblacion"))
                {
                    poblacion = int.Parse(listaux.ElementAt(i + 2).getAuxlex());
                    Console.WriteLine(poblacion);
                }
                else if (listaux.ElementAt(i).getAuxlex().Equals("Saturacion"))
                {
                    saturacion = int.Parse(listaux.ElementAt(i + 2).getAuxlex().Trim('%'));
                    numerador = numerador+saturacion;
                    Console.WriteLine(saturacion);

                }
                else if (listaux.ElementAt(i).getAuxlex().Equals("Bandera"))
                {
                    bandera = listaux.ElementAt(i + 2).getAuxlex();
                    Console.WriteLine(bandera);
                }
                else {

                }

                if (!grafica.Equals("") && !continente.Equals("") && !pais.Equals("") && !bandera.Equals("")
                    && saturacion != 0 && poblacion != 0)
                {
                    Manejador.Obtenerllamado().agregarPais(grafica, continente, numerador / cantPais, pais, poblacion, saturacion, bandera);
                    pais = "";
                    bandera = "";
                    saturacion = 0;
                    numerador = 0;
                    cantPais = 0;
                    poblacion = 0;
                }
                else {

                }
            }
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            if (rtbGrafo.Image != null)
            {
                generarPDF();
            }
            else
            {
                MessageBox.Show("No se puede generar el PDF");
            }
        }

        public void generarPDF()
        {
            Document pdf = new Document();
            PdfWriter.GetInstance(pdf, new FileStream("Decision.pdf", FileMode.Create));
            pdf.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 16f, BaseColor.MAGENTA);
            titulo.Add("Grafica de Paises");
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\\Users\\Benitez\\Desktop\\[LFP]Proyecto1_201709166\\Proyecto_Jacks\\bin\\Debug\\alfin.jpg");
            imagen.ScaleAbsolute(450, 350);
            Paragraph seleccion = new Paragraph();
            IEnumerable<Pais> paises = Manejador.Obtenerllamado().GetPais().OrderBy(pais => pais.getSaturacion());
            seleccion.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f, BaseColor.CYAN);
            seleccion.Add("País Seleccionado: " + paises.ElementAt(0).getPais() + " Con una población de: " + paises.ElementAt(0).getPoblacion());

            //iTextSharp.text.Image imagencita = iTextSharp.text.Image.GetInstance(paises.ElementAt(0).getBandera());
            //imagencita.ScaleToFit(50, 50);
            pdf.Add(titulo);
            pdf.Add(imagen);
            pdf.Add(seleccion);
           // pdf.Add(imagencita);
            pdf.Close();
            System.Diagnostics.Process.Start("Decision.pdf");
        }

        
       
        }
    }
