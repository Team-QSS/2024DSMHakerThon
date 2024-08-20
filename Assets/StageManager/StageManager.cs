using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageManager
{
    public class StageManager : MonoBehaviour
    {
        void Start()
        {
            SaveData.SaveScene();            
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
