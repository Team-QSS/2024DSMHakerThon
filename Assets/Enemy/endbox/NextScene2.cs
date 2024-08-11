using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.endbox
{
    public class NextScene2 : MonoBehaviour
    {
        [SerializeField] private GameObject nextSceneTimeLine;
        [FormerlySerializedAs("slikBank")] [SerializeField] private GameObject silkBank;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Time.timeScale = 0;
                nextSceneTimeLine.SetActive(true);
                silkBank.SetActive(false);
            }
        }


    
    }
}
