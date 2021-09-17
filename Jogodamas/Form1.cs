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
            string cor = selecionado.Name.ToString().Substring(0, 4);

            if (validacao(selecionado,quadro, cor))
            {
                Point anterior = selecionado.Location;
                selecionado.Location = quadro.Location;
                int avancar = anterior.Y - quadro.Location.Y;

                if (!movimentosExtras(cor) | Math.Abs(avancar) == 50)
                {                
                   
                    if(true)
                    {
                        Ifqueen(cor);
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

        private bool movimentosExtras(string cor)
        {
            List<PictureBox> ladoOposto = cor == "Verm" ? azuis : vermelhos;
            List<Point> posicoes = new List<Point>();
            int sigPosicao = cor == "Verm" ? -100 : 100;

            posicoes.Add(new Point(selecionado.Location.X + 100, selecionado.Location.Y + sigPosicao));
            posicoes.Add(new Point(selecionado.Location.X - 100, selecionado.Location.Y + sigPosicao));
            if (selecionado.Tag == "queen")
            {
                posicoes.Add(new Point(selecionado.Location.X + selecionado.Location.Y - sigPosicao));
                posicoes.Add(new Point(selecionado.Location.X - selecionado.Location.Y - sigPosicao));
            }
            bool resultado = false;
            for (int i = 0; i < posicoes.Count; i++)
            {
                if (posicoes[i].X >= 50 && posicoes[i].X <= 400 && posicoes[i].Y >= 50 && posicoes[i].Y <=400)
                {
                    if(!ocupado(posicoes[i], vermelhos) && !ocupado(posicoes[i], azuis))
                    {
                        Point pontoMedio = new Point(media(posicoes[i].X, selecionado.Location.X), media(posicoes[i].Y, selecionado.Location.Y));
                        if(ocupado(pontoMedio, ladoOposto))
                        {
                            resultado = true;
                        }
                    }
                }
            }
            return resultado;
        } 
        private bool ocupado(Point ponto, List<PictureBox>lado)
        {
            for (int i = 0; i < lado.Count; i++)
            {
                if (ponto == lado[i].Location)
                {
                    return true;
                }
            }
            return false;
        }
        private int media(int n1, int n2)
        {
            int resultado = n1 + n2;
            resultado = resultado / 2;
            return Math.Abs(resultado);

        }

        private bool validacao(PictureBox origem, PictureBox destino, string cor)
        {
            Point pontoOrigem = origem.Location;
            Point pontoDestino = destino.Location;
            int avance = pontoOrigem.Y - pontoDestino.Y;
            avance = cor == "vermelho" ? avance : (avance * -1);
            avance = selecionado.Tag == "queen" ? Math.Abs(avance) : avance;

            if (avance == 50)
            {
                return true;
            }
            else if (avance == 100)
            {
                Point pontoMedio = new Point(media(pontoDestino.X, pontoOrigem.X), media(pontoDestino.Y, pontoOrigem.Y)); // 6min aula 3
                List<PictureBox> ladoOposto = cor == "vermelhos" ? azuis : vermelhos;
                for(int i = 0; i < ladoOposto.Count; i++)
                {
                    if(ladoOposto[i].Location == pontoMedio)
                    {
                        ladoOposto[i].Location = new Point(0, 0);
                        ladoOposto[i].Visible = false;
                        return true;
                    }
                }
            }
            return false;
        }
        private void Ifqueen(string color)
        {
            if(color == "PcAz" && selecionado.Location.Y == 390)
            {
                selecionado.BackgroundImage = Properties.Resources.coroazul;
                selecionado.Tag = "rainha";
            }
            else if (color == "PcVe" && selecionado.Location.Y == 82 )
            {
                selecionado.BackgroundImage = Properties.Resources.coroaverm;
                selecionado.Tag = "rainha";
            }
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
