using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BettingSimulator
{
    public class Guy
    {
        public string Name; // The guy's name
        public Bet MyBet; // An instance of Bet that has his bet
        public int Cash; // How much cash he has


        // The last two fields are the guy's GUI controls on the form
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            // Set my label to my bet's description, and the label on my
            // radio button to show my cash ("Joe has 43 bucks")
            
            MyRadioButton.Text = Name + " has " + Cash + " bucks";

            if (MyBet == null)
            {
                MyBet = new Bet()
                {
                    Amount = 0,
                    Dog = 0,
                    Bettor = this
                };

                MyLabel.Text = MyBet.GetDescription();
            }
            else
            {
                //MyLabel.Text = Name + " bets " + MyBet.Amount + " on dog " + MyBet.Dog;
                MyLabel.Text = MyBet.GetDescription();
            }
        }

        public void ClearBet() {
            MyBet = null;
        } // Reset my bet so it's zero

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            if (BetAmount < Cash)
            {
                MyBet = new Bet()
                {
                    Bettor = this,
                    Amount = BetAmount,
                    Dog = DogToWin
                };
                return true;
            }
            else
            {
                MessageBox.Show(Name + " doesn't have enough money to bid this much!", "Bet too much!");
                return false;
            }
        }

        public void Collect(int Winner)
        {
            // Ask my bet to pay out, clear my bet, and update my labels
            Cash = Cash + MyBet.PayOut(Winner);
            ClearBet();
            UpdateLabels();
        }
    }
}
