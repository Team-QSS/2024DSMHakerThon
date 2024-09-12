using TMPro;
using UnityEngine;

namespace System
{
    public class VersoinCheck : MonoBehaviour
    {
        private TextMeshProUGUI _versoin;
        private void Start()
        {
            _versoin = GetComponent<TextMeshProUGUI>();
            _versoin.text = "Version  " + Application.version;
        }
    }
}
