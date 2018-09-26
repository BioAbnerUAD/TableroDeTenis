using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tablero_de_tenis
{
    public partial class Form1 : Form
    {
        private Tablero ElTablero = new Tablero();

        public Form1()
        {
            InitializeComponent();
            UseCustomFont(LebelA);
            UseCustomFont(LabelB);

            UseCustomFont(LabelSet);
            UseCustomFont(LabelSetsA);
            UseCustomFont(LabelSetsB);

            UseCustomFont(LabelScore);
            UseCustomFont(LabelScoreA);
            UseCustomFont(LabelScoreB);


            UseCustomFont(LabelJuego);
            UseCustomFont(LabelJuegosA);
            UseCustomFont(LabelJuegosB);
        }

        void UseCustomFont(Label label)
        {

            PrivateFontCollection modernFont = new PrivateFontCollection();

            modernFont.AddFontFile("Digital.otf");

            label.Font = new Font(modernFont.Families[0], label.Font.Size);
        }

        private void ButtonPuntoA_Click(object sender, EventArgs e)
        {
            ElTablero.Puntuar(0);
            UpdateScores();
        }

        private void ButtonPuntoB_Click(object sender, EventArgs e)
        {
            ElTablero.Puntuar(1);
            UpdateScores();
        }

        private void UpdateScores()
        {
            LabelSetsA.Text = ElTablero.players[0].Sets.ToString();
            LabelSetsB.Text = ElTablero.players[1].Sets.ToString();

            if (ElTablero.players[0].Score == 50) LabelScoreA.Text = "AD";
            else LabelScoreA.Text = ElTablero.players[0].Score.ToString();
            if (ElTablero.players[1].Score == 50) LabelScoreB.Text = "AD";
            else LabelScoreB.Text = ElTablero.players[1].Score.ToString();

            LabelJuegosA.Text = ElTablero.players[0].Games.ToString();
            LabelJuegosB.Text = ElTablero.players[1].Games.ToString();
            
            CheckBoxA.Checked = ElTablero.players[0].GamePoint;
            CheckBoxB.Checked = ElTablero.players[1].GamePoint;
            
            if (ElTablero.players[0].Sets >= 2)
            {
                MessageBox.Show("El Jugador A Gana");
                Reset();
            }
            else if (ElTablero.players[1].Sets >= 2)
            {
                MessageBox.Show("El Jugador B Gana");
                Reset();
            }
        }

        private void Reset()
        {
            for (int i = 0; i < 2; i++)
            {
                ElTablero.players[i].GamePoint = false;
                ElTablero.players[i].Score = 0;
                ElTablero.players[i].Games = 0;
                ElTablero.players[i].Score = 0;
            }
        }
    }

    public class Player
    {
        public int Score;
        public bool GamePoint;
        public int Games;
        public int Sets;
        public void Puntuar(Player other)
        {
            if (GamePoint) GamePoint = false;
            switch (Score)
            {
                case 0:
                    Score = 15;
                    break;
                case 15:
                    Score = 30;
                    break;
                case 30:
                    Score = 40;
                    break;
                case 40:
                    if (other.Score < 40)
                    {
                        GamePoint = true;
                        Games++;
                        Score = 0;
                    }
                    else if (other.Score == 40)
                    {
                        Score = 50;
                    }
                    else
                    {
                        other.Score = 40;
                    }
                    break;
                case 50:
                    GamePoint = true;
                    Games++;
                    Score = 0;
                    break;
            }
            if (Games >= 6)
            {
                if(other.Games < 5 || Games == 7)
                {
                    Games = 0;
                    Sets++;
                }
            }
        }
    }

    public class Tablero
    {
        public Player[] players = new Player[2];
        //La lista se hace para hacer un juego precargado, bool = true es punto para equipo A, bool = false es punto para equipo B.
        public List<bool> PartidoA = new List<bool> { true, false, true };
        public List<bool> PartidoB = new List<bool> { false, true, false };
        public void Puntuar(int index)
        {
            if (index == 0) players[0].Puntuar(players[1]);
            else players[0].Puntuar(players[1]);
        }
    }
}
