using Unity.VisualScripting;
using UnityEngine;

namespace StageManager
{
    public class StageManager : MonoBehaviour
    {
        void Start()
        {
            
        }
    
        void Update()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                
            }
        }
    }
}
