using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_ADB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static void ExecuteCommand(string _Command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = true;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            string result = proc.StandardOutput.ReadToEnd();

            //Muestra en pantalla la salida del Comando
            Console.WriteLine(result);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((bool)radioButton1.Checked)
            {
                ExecuteCommand("adb reboot recovery");
            }
            if ((bool)radioButton2.Checked)
            {
                ExecuteCommand("adb reboot");
            }
            if ((bool)radioButton3.Checked)
            {
                ExecuteCommand("adb reboot-bootloader");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "APK|*.apk";
            DialogResult resul = open.ShowDialog();
            if (resul == System.Windows.Forms.DialogResult.OK)
            {
                tb_DirectorioAPK.Text = open.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tb_DirectorioAPK.Text != "")
            {
                ExecuteCommand("adb install " + tb_DirectorioAPK.Text );
            }
        }
    }
}
