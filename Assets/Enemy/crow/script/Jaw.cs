using UnityEngine;

namespace Enemy.crow.script
{
    public class Jaw : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("죽다.");
            }
        }
    }
}
