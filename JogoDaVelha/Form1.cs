using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class JogoDaVelha : Form
    {
        public enum Player {X, O}

        Player currentPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons;

        public JogoDaVelha()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.Beige;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.PaleTurquoise;
            buttons.Remove(button);
            CheckGame();
            CPUTimer.Start();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                )
            {
                CPUTimer.Stop();
                MessageBox.Show("Player wins!");
                playerWinCount++;
                label1.Text = "Player wins: " + playerWinCount;
                RestartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU wins!");
                CPUWinCount++;
                label2.Text = "CPU wins: " + CPUWinCount;
                RestartGame();
            } 
            /*else
            {
                CPUTimer.Stop();
                MessageBox.Show("It's a draw! The game is tied. Let's start a new game!");
                RestartGame();
            }*/
        }

        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9};

            foreach (Button X in buttons)
            {
                X.Enabled = true;
                X.Text = "";
                X.BackColor = Color.White;
                
            }
        }

        private void JogoDaVelha_Load(object sender, EventArgs e)
        {

        }
    }
}
