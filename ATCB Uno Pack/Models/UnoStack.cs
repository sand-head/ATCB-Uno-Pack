using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATCB_Uno_Pack.Models
{
    public class UnoStack
    {
        private List<UnoCard> cards;
        private int deckCount;

        public UnoStack()
        {
            cards = new List<UnoCard>();
            deckCount = 0;
        }

        public void GenerateRandomDeck(int numOfDecks)
        {
            for (int i = 0; i < numOfDecks + 1; i++)
            {
                deckCount = numOfDecks;
                // Add one new regulation Uno deck to the stack
                foreach (UnoCardColor color in Enum.GetValues(typeof(UnoCardColor)))
                {
                    if (color != UnoCardColor.Wild)
                    {
                        foreach (UnoCardType type in Enum.GetValues(typeof(UnoCardType)))
                        {
                            if (type == UnoCardType.Zero)
                                cards.Add(new UnoCard(color, type));
                            else
                                addCards(new UnoCard(color, type), 2);
                        }
                    }
                    else
                    {
                        addCards(new UnoCard(color, UnoCardType.DrawFour), 4);
                        addCards(new UnoCard(color, UnoCardType.Wild), 4);
                    }
                }
            }
            shuffle();
        }

        public List<UnoCard> DrawCards(int num)
        {
            if (cards.Count - num <= 0)
                GenerateRandomDeck(deckCount);
            List<UnoCard> drawnCards = cards.Take(num).ToList();
            cards.RemoveAll(x => drawnCards.Contains(x));
            return drawnCards;
        }

        private void addCards(UnoCard card, int times)
        {
            for (int i = 0; i < times; i++)
            {
                cards.Add(card);
            }
        }

        private void shuffle()
        {
            Random r = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
            List<UnoCard> toShuffle = cards;
            for (int n = toShuffle.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                UnoCard temp = toShuffle[k];
                toShuffle[k] = toShuffle[n];
                toShuffle[n] = temp;
            }
        }
    }
}
