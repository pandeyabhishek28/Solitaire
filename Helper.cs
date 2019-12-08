using Solitaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    public abstract class CustomItemSet<T> : List<T> where T : Card
    {
        public T GetCard(CardSuit suit, CardType type)
        {
            return this.FirstOrDefault(x => x.Suit == suit && x.Type == type);
        }

        public abstract void Load();
    }

    public class ClubsSet : CustomItemSet<Card>
    {
        public ClubsSet()
        {
            Load();
        }
        public override void Load()
        {
            this.Clear();
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.CA});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C2});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C3});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C4});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C5});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C6});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C7});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C8});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C9});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.C10});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.CJ});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.CQ});
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Clubs, Type = CardType.CK });
        }
    }
    public class DiamondsSet : CustomItemSet<Card>
    {
        public DiamondsSet()
        {
            Load();
        }
        public override void Load()
        {
            this.Clear();
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.CA });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C2 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C3 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C4 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C5 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C6 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C7 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C8 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C9 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.C10 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.CJ });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.CQ });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Diamonds, Type = CardType.CK });
        }
    }
    public class HeartsSet : CustomItemSet<Card>
    {
        public HeartsSet()
        {
            Load();
        }
        public override void Load()
        {
            this.Clear();
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.CA });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C2 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C3 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C4 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C5 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C6 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C7 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C8 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C9 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.C10 });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.CJ });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.CQ });
            this.Add(new Card() { Colour = CardColour.Red, Suit = CardSuit.Hearts, Type = CardType.CK });
        }
    }
    public class SpadesSet : CustomItemSet<Card>
    {
        public SpadesSet()
        {
            Load();
        }
        public override void Load()
        {
            this.Clear();
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.CA });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C2 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C3 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C4 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C5 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C6 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C7 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C8 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C9 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.C10 });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.CJ });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.CQ });
            this.Add(new Card() { Colour = CardColour.Black, Suit = CardSuit.Spades, Type = CardType.CK });
        }
    }

    public class DeckSet : CustomItemSet<Card>
    {
        public DeckSet()
        {
            Load();
        }
        public override void Load()
        {
            this.Clear();
            this.AddRange(new ClubsSet());
            this.AddRange(new DiamondsSet());
            this.AddRange(new HeartsSet());
            this.AddRange(new SpadesSet());
        }
    }
}
