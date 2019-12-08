using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Solitaire.Model
{
    public class Card
    {
        public CardColour Colour { get; set; }
        public CardSuit Suit { get; set; }
        public CardType Type { get; set; }
    }
}
