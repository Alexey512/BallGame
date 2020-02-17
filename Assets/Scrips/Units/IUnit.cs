using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Units
{
    public interface IUnit: IIntersectable
    {
        event Action<IUnit, int> OnDamage;

        event Action<IUnit> OnChangeHp;

        event Action<IUnit> OnDeath;
    
        int Hp { get; }    

        void Initialize();

        void Damage(int damage);
    }
}
