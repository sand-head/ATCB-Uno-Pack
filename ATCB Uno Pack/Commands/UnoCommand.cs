using ATCB.Library.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCB_Uno_Pack.Commands
{
    public class UnoCommand : Command
    {
        public UnoCommand() { }

        public override bool IsSynonym(string commandText) => commandText == "uno";

        public override void Run(CommandContext context)
        {
            
        }
    }
}
