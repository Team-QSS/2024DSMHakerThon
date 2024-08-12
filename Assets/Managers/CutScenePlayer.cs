using player.script;
using UnityEngine;
using weapons.Silk;

namespace Managers
{
    public class CutScenePlayer : MonoBehaviour
    {
        private void Start()
        {
            Destroy(PlayerMove.Instance.gameObject);
            Destroy(SilkThrow.Instance.gameObject);
        }
    }
}
