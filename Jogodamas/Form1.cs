using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogodamas
{
    public partial class Form1 : Form
    {
        int vez = 0;
        bool movExtra = false;
        PictureBox selecionado = null;

        List<PictureBox> azuis = new List<PictureBox>();
        List<PictureBox> vermelhos = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            cargaLista();
        }

        private void cargaLista()
        {
            azuis.Add(PcAzul1);
            azuis.Add(PcAzul2);
            azuis.Add(PcAzul3);
            azuis.Add(PcAzul4);
            azuis.Add(PcAzul5);
            azuis.Add(PcAzul6);
            azuis.Add(PcAzul7);
            azuis.Add(PcAzul8);
            azuis.Add(PcAzul9);
            azuis.Add(PcAzul10);
            azuis.Add(PcAzul11);
            azuis.Add(PcAzul12);

            vermelhos.Add(PcVermelho1);
            vermelhos.Add(PcVermelho2);
            vermelhos.Add(PcVermelho3);
            vermelhos.Add(PcVermelho4);
            vermelhos.Add(PcVermelho5);
            vermelhos.Add(PcVermelho6);
            vermelhos.Add(PcVermelho7);
            vermelhos.Add(PcVermelho8);
            vermelhos.Add(PcVermelho9);
            vermelhos.Add(PcVermelho10);
            vermelhos.Add(PcVermelho11);
            vermelhos.Add(PcVermelho12);
        }

        public void selecao(object objeto)
        {
            try { selecionado.BackColor = Color.Black; }
            catch { }
            PictureBox registro = (PictureBox)objeto;
            selecionado = registro;
            selecionado.BackColor = Color.Lime;
        }
        private void movimento(PictureBox quadro)
        {
            if(selecionado != null)
            {
                if(true)
                {                
                    string cor = selecionado.Name.ToString().Substring(0, 4);
                    Point anterior = selecionado.Location;
                    selecionado.Location = quadro.Location;
                    int avancar = anterior.Y - quadro.Location.Y;

                    if(true)
                    {
                        vez++;
                        selecionado.BackColor = Color.Black;
                        selecionado = null;
                        movExtra = false;
                    }
                    else
                    {
                        movExtra = true;
                    }
                }
            }
        }

        private void ifqueen(string color)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PcVermelho9_Click(object sender, EventArgs e)
        {

        }

        private void selecionarAzul(object sender, MouseEventArgs e)
        {
            selecao(sender);
        }

        private void selecionarVermelho(object sender, MouseEventArgs e)
        {
            selecao(sender);
        }

        //private void q(object sender, MouseEventArgs e)
        //{

        //}

        private void quadroClick(object sender, MouseEventArgs e)
        {
            movimento((PictureBox)sender);
        }
    }
}
