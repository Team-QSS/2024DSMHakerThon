using UnityEngine;
using UnityEngine.Serialization;

namespace player.script
{
    public class PlayerWeapons : MonoBehaviour
    {
        public GameObject[] weapons;
        //private List<GameObject> glist = new List<GameObject>();
        private void Start()
        {
            weapons[0].SetActive(false);
        }
    }
}
