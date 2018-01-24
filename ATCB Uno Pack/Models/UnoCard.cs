using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCB_Uno_Pack.Models
{
    public class UnoCard
    {
        public UnoCardColor Color { get; internal set; }
        public UnoCardType Type { get; internal set; }

        public UnoCard(UnoCardColor Color, UnoCardType Type)
        {
            this.Color = Color;
            this.Type = Type;
        }

        public string ColorToString()
        {
            return Enum.GetName(typeof(UnoCardColor), Color);
        }

        public override string ToString()
        {
            if (Type == UnoCardType.DrawFour)
                return "Draw Four";
            else if (Type == UnoCardType.DrawTwo)
                return $"{Enum.GetName(typeof(UnoCardColor), Color)} Draw Two";
            else if (Type == UnoCardType.Wild)
                return "Wild";
            else
                return $"{Enum.GetName(typeof(UnoCardColor), Color)} {Enum.GetName(typeof(UnoCardType), Type)}";
        }
    }
}
