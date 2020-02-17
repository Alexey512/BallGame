using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Units
{
    public class Unit: MonoBehaviour, IUnit
    {
        public event Action<IUnit, int> OnDamage;

        public event Action<IUnit> OnChangeHp;

        public event Action<IUnit> OnDeath;

        public int Hp { get { return _hp; } }
        
        private int _hp;

        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();          
        }

        public void Initialize()
        {
            _hp = 100;
            OnChangeHp?.Invoke(this);
        }

        public void Damage(int damage)
        {
            _hp -= damage;
            
            OnDamage.Invoke(this, damage);
            OnChangeHp?.Invoke(this);
            
            if (_hp <= 0)
            {
                _hp = 0;
                OnDeath?.Invoke(this);

                GameObject.Destroy(gameObject);
            }
        }

        public bool IsIntersect(Ray ray)
        {
            if (!_collider)
                return false;

            return _collider.OverlapPoint(ray.origin);
        }
    }
}
