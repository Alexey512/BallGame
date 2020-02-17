using Assets.Scripts.Game;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scrips.Units;
using Assets.Scrips.Settings;

namespace Assets.Scrips.Game
{
    public class GameScene
    {
        private IInputManager _inputManager;
        
        private SceneRoot _root;

        private IGameSettings _settings;

        private List<IUnit> _units = new List<IUnit>();

        public GameScene(SceneRoot root, IInputManager inputManager, IGameSettings settings)
        {
            _inputManager = inputManager;
            _root = root;
            _settings = settings;
            _inputManager.OnClick += OnSceneClick;

            LoadUnits(_root.Root);
        }

        private void LoadUnits(Transform root)
        {
            for (int i = 0; i < root.childCount; i++)
            {
                var unit = root.GetChild(i).GetComponent<IUnit>();
                if (unit == null)
                    continue;

                unit.Initialize();

                unit.OnDamage += OnUnitDamage;
                unit.OnDeath += OnUnitDeath;

                _units.Add(unit);
            }
        }

        private void OnSceneClick(Ray ray)
        {
            foreach (var unit in _units)
            {
                if (unit.IsIntersect(ray))
                {
                    unit.Damage(_settings.Damage);
                    break;
                }
            }
        }

        private void OnUnitDamage(IUnit unit, int damage)
        {
            
        }

        private void OnUnitDeath(IUnit unit)
        {
            unit.OnDamage -= OnUnitDamage;
            unit.OnDeath -= OnUnitDeath;
            _units.Remove(unit);
        }
    }
}
