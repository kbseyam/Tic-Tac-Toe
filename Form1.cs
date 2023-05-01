using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        enum Player {
            PLAYER1, PLAYER2
        }

        private string GetPlayerName(Player player) {
            return player == Player.PLAYER1 ? "Player 1" : "Player 2";
        }

        //private const string PLAYER1 = "Player 1";
        //private const string PLAYER2 = "Player 2";
        private byte clicksCounter = 0;

        private void frm1Paint(object sender, PaintEventArgs e) {
            Pen pen = new Pen(Color.White);
            pen.Width = 10;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 600, 125, 600, 525);
            e.Graphics.DrawLine(pen, 750, 125, 750, 525);

            e.Graphics.DrawLine(pen, 450, 260, 900, 260);
            e.Graphics.DrawLine(pen, 450, 400, 900, 400);
        }

        private void pb_Click(object sender, EventArgs e) {
            if (((PictureBox)sender).Tag.ToString() != "null") {
                MessageBox.Show("Wrong choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clicksCounter++;

            if (lbPlayer.Text == GetPlayerName(Player.PLAYER1)) {
                ((PictureBox)sender).Image = Resources.X;
                ((PictureBox)sender).Tag = GetPlayerName(Player.PLAYER1);
                if (IsWin(Player.PLAYER1)) {
                    lbPlayer.Text = "Game Over";
                    lbWinner.Text = GetPlayerName(Player.PLAYER1);
                    EnablePbs(false);
                }
                lbPlayer.Text = GetPlayerName(Player.PLAYER2);
            } else {
                ((PictureBox)sender).Image = Resources.O;
                ((PictureBox)sender).Tag = GetPlayerName(Player.PLAYER2);
                if (IsWin(Player.PLAYER2)) {
                    lbPlayer.Text = "Game Over";
                    lbWinner.Text = GetPlayerName(Player.PLAYER2);
                    EnablePbs(false);
                }
                lbPlayer.Text = GetPlayerName(Player.PLAYER1);
            }

            if (clicksCounter == 9) {
                lbPlayer.Text = "Game Over";
                lbWinner.Text = "Draw";
                EnablePbs(false);
            }
        }

        private void EnablePbs(bool enable) {
            pb1.Enabled = enable;
            pb2.Enabled = enable;
            pb3.Enabled = enable;
            pb4.Enabled = enable;
            pb5.Enabled = enable;
            pb6.Enabled = enable;
            pb7.Enabled = enable;
            pb8.Enabled = enable;
            pb9.Enabled = enable;
        }

        private bool IsWin(Player player) {
            string playerName = GetPlayerName(player);
            if (pb1.Tag.ToString() == playerName && pb2.Tag.ToString() == playerName && pb3.Tag.ToString() == playerName) {
                return true;
            }
            if (pb4.Tag.ToString() == playerName && pb5.Tag.ToString() == playerName && pb6.Tag.ToString() == playerName) {
                return true;
            }
            if (pb7.Tag.ToString() == playerName && pb8.Tag.ToString() == playerName && pb9.Tag.ToString() == playerName) {
                return true;
            }
            if (pb1.Tag.ToString() == playerName && pb4.Tag.ToString() == playerName && pb7.Tag.ToString() == playerName) {
                return true;
            }
            if (pb2.Tag.ToString() == playerName && pb5.Tag.ToString() == playerName && pb8.Tag.ToString() == playerName) {
                return true;
            }
            if (pb3.Tag.ToString() == playerName && pb6.Tag.ToString() == playerName && pb9.Tag.ToString() == playerName) {
                return true;
            }
            if (pb1.Tag.ToString() == playerName && pb5.Tag.ToString() == playerName && pb9.Tag.ToString() == playerName) {
                return true;
            }
            if (pb3.Tag.ToString() == playerName && pb5.Tag.ToString() == playerName && pb7.Tag.ToString() == playerName) {
                return true;
            }

            return false;
        }

        private void ResetImages() {
            pb1.Image = Resources.question_mark;
            pb2.Image = Resources.question_mark;
            pb3.Image = Resources.question_mark;
            pb4.Image = Resources.question_mark;
            pb5.Image = Resources.question_mark;
            pb6.Image = Resources.question_mark;
            pb7.Image = Resources.question_mark;
            pb8.Image = Resources.question_mark;
            pb9.Image = Resources.question_mark;
        }

        private void ResetTags() {
            pb1.Tag = "null";
            pb2.Tag = "null";
            pb3.Tag = "null";
            pb4.Tag = "null";
            pb5.Tag = "null";
            pb6.Tag = "null";
            pb7.Tag = "null";
            pb8.Tag = "null";
            pb9.Tag = "null";
        }

        private void ResetChoices() {
            ResetImages();
            ResetTags();
            clicksCounter = 0;
        }

        private void btnRestart_Click(object sender, EventArgs e) {
            ResetChoices();
            lbPlayer.Text = GetPlayerName(Player.PLAYER1);
            lbWinner.Text = "In progress";
            EnablePbs(true);
        }
    }
}
