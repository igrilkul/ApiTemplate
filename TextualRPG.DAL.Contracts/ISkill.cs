using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.DAL.Contracts
{
    public interface ISkill
    {
        void DisplayInfo(string indent = "");
    }
}
