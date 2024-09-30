using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Play_LHY
{
    public class Monster
    {
     public string Name { get; set; }
     public int HP { get; set; }
     public int ATK { get; set; }

    public Monster(string name, int hp, int atk)
    {
     Name = name;
     HP = hp;
     ATK = atk;
     }

   }  

}


   

