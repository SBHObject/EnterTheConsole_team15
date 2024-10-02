using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterTheConsole
{
    internal class Monster
    {
        //속성은 외부에서 해당 속성을 사용하기 위해 사용합니다.
        //단, 외부에서 이 값을 수정하는것은 객체 지향 프로그래밍에 좋지 않습니다.
        //따라서 외부에서 변수값을 수정하게 해주는 set을 숨겨주는것이 좋습니다
        public string Name { get; private set; }
        public int HP { get; private set; }
        public int ATK { get; private set; }
        //사망 판정
        public bool IsDead { get; private set; } = false;
        //몬스터 레벨도 따로 정해주는것이 좋아보입니다
        public int Level {  get; private set; }

        public Monster(string name, int hp, int atk, int level)
        {
            Name = name;
            HP = hp;
            ATK = atk;
            Level = level;
        }

        //외부에서 속성의 수정을 막았기 때문에 HP를 수정하는 함수를 만들어서 사용해줍니다.
        public void TakeDamage(int damage)
        {
            HP -= damage;
            //체력이 0이하일경우, 사망판정
            if (HP <= 0)
            {
                IsDead = true;
            }
        }
    }
}
