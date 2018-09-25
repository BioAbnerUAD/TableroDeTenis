using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tablero_de_tenis
{
    public partial class Form1 : Form
    {
        Tablero ElTablero;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ButtonPuntoA_Click(object sender, EventArgs e)
        {
            if (ElTablero.GamePointA == true)
            {
                ElTablero.GamePointA = false;
                CheckBoxA.Checked = false;
                ElTablero.ScoreA = 0;

                ElTablero.GamesA += 1;
                LabelJuegosA.Text = ElTablero.GamesA.ToString();
            }
                switch (ElTablero.ScoreA)
            {
                case 0:
                    ElTablero.ScoreA = 15;
                    LabelScoreA.Text = ElTablero.ScoreA.ToString();
                    break;
                case 15:
                    ElTablero.ScoreA = 30;
                    LabelScoreA.Text = ElTablero.ScoreA.ToString();
                    break;
                case 30:
                    ElTablero.ScoreA = 40;
                    LabelScoreA.Text = ElTablero.ScoreA.ToString();
                    break;
                case 40:
                    ElTablero.GamePointA = true;
                    CheckBoxA.Checked = true;
                    break;
            }
            if (ElTablero.GamesA == 6)
            {
                ElTablero.GamesA = 0;
                LabelJuegosA.Text = ElTablero.GamesA.ToString();
                ElTablero.SetsA += 1;
                LabelSetsA.Text = ElTablero.SetsA.ToString();
            }
           
        }

        private void ButtonPuntoB_Click(object sender, EventArgs e)
        {
            ElTablero.ScoreB += 15;
            //Debe ser la misma funcion wue ButtonPuntoA solo hay que cambiar las variables de A por las de B
        }
    }

    public class Tablero
    {
        public int ScoreA = 0;
        public int ScoreB = 0;
        public bool GamePointA = false;
        public bool GamePointB = false;
        public int GamesA = 0;
        public int GamesB = 0;
        public int SetsA = 0;
        public int SetsB = 0;
        //La lista se hace para hacer un juego precargado, bool = true es punto para equipo A, bool = false es punto para equipo B.
        public List<bool> PartidoA = new List<bool> { true, false, true };
        public List<bool> PartidoB = new List<bool> { false, true, false };
    }
}
