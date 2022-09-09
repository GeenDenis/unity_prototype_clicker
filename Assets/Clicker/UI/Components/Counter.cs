using TMPro;
using UnityEngine;

namespace Clicker.UI.Components
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _prefix;
        [SerializeField] private string _postfix;
        [SerializeField] private int _value;

        public void Init()
        {
            SetValue(_value);
        }
        
        public void SetValue(int value)
        {
            _value = value;
            _text.text = _prefix + value + _postfix;
        }
        
        public void SetPrefix(string text)
        {
            _prefix = text;
            SetValue(_value);
        }
        
        public void SetPostfix(string text)
        {
            _postfix = text;
            SetValue(_value);
        }
    }
}