using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scrips.Units;

namespace Assets.Scrips.UI
{
    public class UIUnitHud: MonoBehaviour
    {
        [SerializeField]
        private Unit _unit;
        
        [SerializeField]
        private UIProgressBar _progressBar;

        private void Start()
        {
            if (_unit != null)
            {
                _unit.OnChangeHp += OnChangeHp;
                UpdateHp();
            }
        }

        private void UpdateHp()
        {
            if (_progressBar == null || _unit == null)
                return;

            _progressBar.Value = _unit.Hp;
        }

        private void OnChangeHp(IUnit unit)
        {
            UpdateHp();
        }
    }
}
