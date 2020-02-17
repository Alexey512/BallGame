using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrips.UI
{
    public class UIProgressBar: MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _back;

        private int _value;

        private Vector3 _localScale = Vector3.one;

        public int Value
        {
            get 
            {
                return _value;
            }
            set 
            {
                if (_back == null)
                    return;
                _back.transform.localScale = new Vector3(_localScale.x * value / 100f, _localScale.y, _localScale.z);
            } 
        }

        void Start() 
        {
            if (_back != null)
            {
                _localScale = _back.transform.localScale;
            }
            
            Value = 0;
        }
    }
}
