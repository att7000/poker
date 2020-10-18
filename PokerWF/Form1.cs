using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class Form1 : Form
    {
        List<Label> list = new List<Label>();
        public Form1()
        {
            list.Add(lb0);
            list.Add(lb1);
            list.Add(lb2);
            list.Add(lb3);
            list.Add(lb4);
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           StartGame();
        }
        public void ShowTableCard(Cards card,Label lb)
        {
            lb.Text = Cards.ConverString(card.number);
            lb.ForeColor = ShowColor(card.mast);
            

        }
        public Color ShowColor(int m)
        {
            if (m == 4) return Color.Red;
            if (m ==1) return Color.Green;
            if (m== 2) return Color.Yellow;
            if (m == 3) return Color.Blue;
            else return Color.Black;
        }
        public void StartGame()
        {
            Players AllPlayers = new Players();
            AllPlayers.CreatePlayers(2);
            var AllCards = Cards.Generate();
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;




            List<PlayerHand> Plh = new List<PlayerHand>();
            for (int i = 0; i < AllPlayers.players.Count; i++)
            {
                PlayerHand hand1 = new PlayerHand(AllPlayers.players[i]);
                Plh.Add(hand1);
                Plh[i].CardsHave(AllCards);
            }

            TableCards Table = new TableCards();
            Table.CardsOnTable(AllCards);
            
            ShowTableCard(Table.cards[0], lb0);
            ShowTableCard(Table.cards[1], lb1);
            ShowTableCard(Table.cards[2], lb2);
            ShowTableCard(Table.cards[3], lb3);
            ShowTableCard(Table.cards[4], lb4);
            List<Combination> CombinationOfEachPlayer = new List<Combination>();
            for (int i = 0; i < AllPlayers.players.Count; i++)
            {
                Combination p1 = new Combination();
                //Console.Write($"Карты Игрока {i + 1} : ");
                p1.fullhand = Plh[i].hand.Union(Table.cards);
                p1.Playername = $"Player {i + 1}";
                CombinationOfEachPlayer.Add(p1);
                //foreach (Cards card in p1.fullhand)
                //    Console.Write(card.name + " ");
                //Console.WriteLine();
            }

            //foreach (var Spisok in CombinationOfEachPlayer)
            //{
            //    Spisok.CombiCheck();
            //    Console.WriteLine($"{Spisok.Playername} have {CombiName[Spisok.Rezult[0]]} of {Cards.ConverString(Spisok.Rezult[1])}");
            //}
            //var winner=FindWinner(CombinationOfEachPlayer);
            //Console.WriteLine($"{winner.Playername} WIN with {CombiName[winner.Rezult[0]]}");




        }

    }
}
