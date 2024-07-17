using UnityEngine;
using UnityEngine.UIElements;

namespace weapons.Silk
{
    public class SilkGaugeChange : MonoBehaviour
    {
    
        public Sprite usedSilk;
        private Image chargedSilk;
        // Start is called before the first frame update
        private void Start()
        {
            chargedSilk = GetComponent<Image>();
        }

        private void ChangeImg()
        {
            chargedSilk.sprite = usedSilk;
        }
    }
}
