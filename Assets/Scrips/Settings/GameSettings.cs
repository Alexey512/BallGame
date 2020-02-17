using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scrips.Settings
{
    [CreateAssetMenu(menuName = "Game/Game Settings")]
    public class GameSettings: ScriptableObject, IGameSettings
    {
        [SerializeField]
        private int _damage = 11;

        public int Damage { get { return _damage; } }
    }
}
