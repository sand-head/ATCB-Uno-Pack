using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCB_Uno_Pack.Models
{
    public class Player
    {
        public string Username;
        public List<UnoCard> Hand;

        public Player(string Username)
        {
            this.Username = Username;
            Hand = new List<UnoCard>();
        }

        public string GetHandAsString()
        {
            string s = "";
            int i = 1;
            foreach (UnoCard card in Hand)
            {
                if (card.Equals(Hand.First()))
                    s += $"{card.ToString()} ({i}),";
                else if (card.Equals(Hand.Last()))
                    s += $" and {card.ToString()} ({i})";
                else
                    s += $" {card.ToString()} ({i}),";
                i++;
            }
            return s;
        }

        public string GetAcceptableMatchesAsString(UnoCard toMatch)
        {
            string s = "";
            List<UnoCard> acceptableCards = Hand.Where(x => (x.Type.Equals(toMatch.Type) || x.Color.Equals(toMatch.Color)) || x.Color.Equals(UnoCardColor.Wild)).ToList();
            foreach (UnoCard card in acceptableCards)
            {
                if (card.Equals(acceptableCards.First()))
                    s += $"{card.ToString()},";
                else if (card.Equals(Hand.Last()))
                    s += $" and {card.ToString()}";
                else
                    s += $" {card.ToString()},";
            }
            return s;
        }

        public bool CanMatch(UnoCard card)
        {
            if (Hand.Where(x => x.Color.Equals(UnoCardColor.Wild)).ToList().Count > 0)
                return true;
            return Hand.Where(x => (x.Type.Equals(card.Type) || x.Color.Equals(card.Color))).ToList().Count > 0;
        }

        public int GetFirstAcceptableMatch(UnoCard card)
        {
            List<UnoCard> playableCards = Hand.Where(x => (x.Type.Equals(card.Type) || x.Color.Equals(card.Color)) || x.Color.Equals(UnoCardColor.Wild)).ToList();
            return Hand.IndexOf(playableCards.First());
        }
    }
}
