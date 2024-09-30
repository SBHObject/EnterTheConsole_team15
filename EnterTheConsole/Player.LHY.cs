using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Play_LHY
{
    public class Player
    {
     public string Name { get; set; }
     public int HP { get; set; }

        public Player(string name, int hp)
        {
         Name = name;
         HP = hp;
         }

    }

}

