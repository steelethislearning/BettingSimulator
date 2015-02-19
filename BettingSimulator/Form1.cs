using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BettingSimulator
{
    public partial class Form1 : Form
    {
        Random GameRandomizer = new Random();

        Guy[] guys = new Guy[3];
        Greyhound[] greyhounds = new Greyhound[4];
        bool winner;
        int winningDog;

        public Form1()
        {
            InitializeComponent();

            minimumBetLabel.Text = "Minimum bet: " + betNumericUpDown.Minimum + " bucks";

            // Initializing Guy objects
            guys[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyBet = null,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };
            guys[1] = new Guy()
            {
                Name = "Bob",
                Cash = 75,
                MyBet = null,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };
            guys[2] = new Guy()
            {
                Name = "Al",
                Cash = 45,
                MyBet = null,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel
            };

            // Initializing Greyhound objects
            greyhounds[0] = new Greyhound()
            {
                MyPictureBox = greyhound1PictureBox,
                StartingPosition = greyhound1PictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - greyhound1PictureBox.Width,
                Randomizer = GameRandomizer
            };
            greyhounds[1] = new Greyhound()
            {
                MyPictureBox = greyhound2PictureBox,
                StartingPosition = greyhound2PictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - greyhound2PictureBox.Width,
                Randomizer = GameRandomizer
            };
            greyhounds[2] = new Greyhound()
            {
                MyPictureBox = greyhound3PictureBox,
                StartingPosition = greyhound3PictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - greyhound3PictureBox.Width,
                Randomizer = GameRandomizer
            };
            greyhounds[3] = new Greyhound()
            {
                MyPictureBox = greyhound4PictureBox,
                StartingPosition = greyhound4PictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - greyhound4PictureBox.Width,
                Randomizer = GameRandomizer
            };

            foreach (var guy in guys)
            {
                guy.UpdateLabels();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < greyhounds.Length; i++)
            {
                winner = greyhounds[i].Run();
                if (winner == true)
                {
                    timer1.Stop();
                    MessageBox.Show("Dog #" + (i + 1) + " Won the race!", "Winner!");
                    winningDog = i + 1;
                    foreach (var guy in guys)
                    {
                        guy.Collect(winningDog);
                    }
                    foreach (var dog in greyhounds)
                    {
                        dog.TakeStartingPosition();
                    }
                    bettingParlorGroupBox.Enabled = true;
                }
            }               
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            if (winner == true)
            {
                winner = false;
            }
            bettingParlorGroupBox.Enabled = false;
            timer1.Start();
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if (guys[0].MyRadioButton.Checked == true)
            {
                nameLabel.Text = guys[0].Name;
                guys[0].PlaceBet((int)betNumericUpDown.Value, (int)dogNumericUpDown.Value);
                guys[0].UpdateLabels();
            }
            else if (guys[1].MyRadioButton.Checked == true)
            {
                nameLabel.Text = guys[1].Name;
                guys[1].PlaceBet((int)betNumericUpDown.Value, (int)dogNumericUpDown.Value);
                guys[1].UpdateLabels();
            }
            else if (guys[2].MyRadioButton.Checked == true)
            {
                nameLabel.Text = guys[2].Name;
                guys[2].PlaceBet((int)betNumericUpDown.Value, (int)dogNumericUpDown.Value);
                guys[2].UpdateLabels();
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = guys[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = guys[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = guys[2].Name;
        }
    }
}
