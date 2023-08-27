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
using System.IO.Ports;
using System.Configuration;
using System.Runtime.Remoting.Contexts;

namespace bascula
{
    public partial class bascula : Form
    {   
        int posicion = Convert.ToInt32((ConfigurationManager.AppSettings["posicion"].ToString()));
        string dividir = ConfigurationManager.AppSettings["didivircadena"];

        string ultimopesaje;
        string ultimahorapesaje;
        public bascula()
        {
            InitializeComponent();
        }
        
        private void bascula_Load(object sender, EventArgs e)
        {
            spBalanza.DataReceived += new SerialDataReceivedEventHandler(spBalanza_DataReceived);
            Conectarbalanza();

        }

        private void spBalanza_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            try
            {

                var cadenaBalanza = spBalanza.ReadExisting().Trim();

                Guardarhistorialcadenacompleta(cadenaBalanza);

                string[] arreglo = cadenaBalanza.Split(' ');

                

                //StreamWriter sw = new StreamWriter("D:\\pesaje.txt");
                //StreamReader sr = new StreamReader("D:\\pesaje.txt");
                //Read the first line of text
                //var line = sr.ReadLine();

                //sw.WriteLine(cadenaenviar);
                if (arreglo.Count()>5)
                {
                    string cadenaenviar = devolverpesado(arreglo);

                    if (cadenaenviar != "ERROR")
                    {
                        GuardarPesaje(cadenaenviar);
                        Historialdepesajes(cadenaenviar);
                        ultimopesaje = cadenaenviar;
                        this.Invoke(new EventHandler(Actualizar));
                    }
                }
                
                    
                    
                    
                //cargarcontroles(cadenaenviar);



                //sw.Close();

            }
            catch (Exception ex)
            {
                Guardarlogerrores(ex.Message + "   " + ex.StackTrace.ToString());
            }
        }

        public void Actualizar(object sender, EventArgs e)
        {
            lblultimopesaje.Text = ultimopesaje;

          
            lblultimahora.Text = DateTime.Now.ToString("F");
        }
         

        public void Historialdepesajes(string cadena)
        {
            var rutaarchivo = ConfigurationManager.AppSettings["RutaPesajetxt"];
            try
            {
                if (!System.IO.File.Exists(rutaarchivo + @"HISTORIALPESO.txt"))
                {
                    var myFile = System.IO.File.Create(rutaarchivo + @"HISTORIALPESO.txt");

                    myFile.Close();
                }

                System.IO.File.AppendAllText(rutaarchivo + @"HISTORIALPESO.txt", cadena + "\n\n\n");



            }
            catch (Exception ex)
            {

            }
        }
        public string devolverpesado(string[] lista)
        {
            try { 
            List<string> pesosencontrados= new List<string>();
            int pesajedevolver = 0;

            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].ToString().StartsWith("lb"))
                {
                    pesosencontrados.Add( lista[i-1].ToString());
                }
            }
            //verificamos si es pesaje o repesaje

            if (pesosencontrados.Count()==1)
            {
                //es pesaje
                return pesosencontrados[0];

            }
            else
            {
                //es repesaje
                return pesosencontrados[1];

            }
            }catch (Exception ex)
            {
                Guardarlogerrores(ex.Message + "   " + ex.StackTrace.ToString());
                return "ERROR";
            }



        }

        public void GuardarPesaje(string cadena)
        {
            var rutaarchivo = ConfigurationManager.AppSettings["RutaPesajetxt"];
            try
            {
                if (!System.IO.File.Exists(rutaarchivo + @"PESO.txt"))
                {
                    var myFile = System.IO.File.Create(rutaarchivo + @"PESO.txt");

                    myFile.Close();
                }

               
               
                    System.IO.File.WriteAllText(rutaarchivo + @"PESO.txt", cadena);


     

                //System.IO.File.AppendAllText(rutaarchivo + @"CADENACOMPLETA.txt", cadena+ "\n\n\n");
                //label1.Text = cadena;

                //MessageBox.Show(cadena);


            }
            catch (Exception ex)
            {
                Guardarlogerrores(ex.Message +"   " + ex.StackTrace.ToString());
            }
        }

        public void Guardarhistorialcadenacompleta(string cadena)
        {
            var rutaarchivo = ConfigurationManager.AppSettings["RutaPesajetxt"];
            try
            {
                if (!System.IO.File.Exists(rutaarchivo + @"CADENACOMPLETA.txt"))
                {
                    var myFile = System.IO.File.Create(rutaarchivo + @"CADENACOMPLETA.txt");

                    myFile.Close();
                }


                System.IO.File.AppendAllText(rutaarchivo + @"CADENACOMPLETA.txt", cadena + "\n--------------------------------------------------------\n\n");
                System.IO.File.AppendAllText(rutaarchivo + @"CADENACOMPLETA.txt", "\n");




                //System.IO.File.AppendAllText(rutaarchivo + @"CADENACOMPLETA.txt", cadena+ "\n\n\n");
                //label1.Text = cadena;

                //MessageBox.Show(cadena);


            }
            catch (Exception ex)
            {

            }
        }

        public void Guardarlogerrores(string error)
        {
            var rutaarchivo = ConfigurationManager.AppSettings["RutaPesajetxt"];
            try
            {
                if (!System.IO.File.Exists(rutaarchivo + @"LogErrores.txt"))
                {
                    var myFile = System.IO.File.Create(rutaarchivo + @"LogErrores.txt");

                    myFile.Close();
                }



                System.IO.File.AppendAllText(rutaarchivo + @"LogErrores.txt", DateTime.Now.ToString("F")+ "   " + error + "\n"); ;




                //System.IO.File.AppendAllText(rutaarchivo + @"CADENACOMPLETA.txt", cadena+ "\n\n\n");
                //label1.Text = cadena;

                //MessageBox.Show(cadena);


            }
            catch (Exception ex)
            {

            }
        }



        public void Conectarbalanza()
        {
            //spBalanza.DataReceived += new SerialDataReceivedEventHandler(spBalanza_DataReceived);
            try
            {
                CerrarPuerto();

                //configuracion de la balanza

                var Paridad =  ConfigurationManager.AppSettings["Paridad"]; 
                var Puerto = ConfigurationManager.AppSettings["Puerto"];
                var Parada = ConfigurationManager.AppSettings["Parada"];
                var CtrlFlujo = "";
                var Plantilla = "";
                var Bitdatos = ConfigurationManager.AppSettings["Bitdatos"];
                var Baud = ConfigurationManager.AppSettings["Baud"];

                spBalanza.PortName = Puerto;

                switch (Paridad.ToUpper())
                {
                    case "NONE":
                        spBalanza.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "PAR":
                        spBalanza.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "IMPAR":
                        spBalanza.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "ESPACIO":
                        spBalanza.Parity = System.IO.Ports.Parity.Space;
                        break;
                    case "MARCA":
                        spBalanza.Parity = System.IO.Ports.Parity.Mark;
                        break;
                }
                switch (Parada.ToUpper())
                {
                    case "UNO":
                        spBalanza.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "UNOYMEDIO":
                        spBalanza.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    case "DOS":
                        spBalanza.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                }
                switch (CtrlFlujo.ToUpper())
                {
                    case "NONE":
                        spBalanza.Handshake = System.IO.Ports.Handshake.None;
                        break;
                    case "HARDWARE":
                        spBalanza.Handshake = System.IO.Ports.Handshake.RequestToSend;
                        break;
                    case "HARDWARE_XONXOFF":
                        spBalanza.Handshake = System.IO.Ports.Handshake.RequestToSendXOnXOff;
                        break;
                    case "XONXOFF":
                        spBalanza.Handshake = System.IO.Ports.Handshake.XOnXOff;
                        break;
                }
                spBalanza.DataBits = Convert.ToInt32(Bitdatos);
                spBalanza.BaudRate = Convert.ToInt32(Baud);
                string estado = "";
                //validando el puerto
                //var isValid = SerialPort.GetPortNames().Any(x => string.Compare(x, spBalanza.PortName, true) == 0);
                //if (!isValid)
                //{

                //    estado = "Invalido";

                //}
                //else
                //{
                //    estado = "Valido";
                //}

                if (!spBalanza.IsOpen)

                    spBalanza.Open();


                label1.Text = "Se realizo la conexion con exito";
                lblestado.Text = "CONECTADO";
                lblestado.BackColor = Color.Green;

            }
            catch (Exception ex)
            {
                label1.Text = "Hubo un problema para conectar   " + ex.Message;
                Guardarlogerrores(ex.Message + "   " + ex.StackTrace.ToString());
            }


        }

        private void CerrarPuerto()
        {

            try
            {
                if (spBalanza.IsOpen)
                {
                    spBalanza.Close();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bascula_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarPuerto();
        }

        public void verificarconexion(object sender, EventArgs e)
        {
            try
            {
                if (!spBalanza.IsOpen)
                {
                    //abrimos la conexion denuevo
                    Conectarbalanza();
                }


            }
            catch(Exception ex)
            {
                Guardarlogerrores(ex.Message + "   " + ex.StackTrace.ToString());
                label1.Text = "Hubo un problema para conectar   " + ex.Message;
            }
        }

        private void timerconexion_Tick(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(verificarconexion));
            
        }
    }
}
