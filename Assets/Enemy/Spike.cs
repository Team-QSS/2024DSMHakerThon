using player.script;
using UnityEngine;

namespace Enemy
{
    public class Spike : MonoBehaviour
    {
        public GameObject core;
        private PlayerHitBox knockingBack;
        private void Start()
        {
            knockingBack = core.GetComponent<PlayerHitBox>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) knockingBack.NockBack(gameObject.transform.position,5f,0.5f);
        }
    }
}
