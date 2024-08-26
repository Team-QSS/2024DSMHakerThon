using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageManager
{
    public class NextScene : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(SaveData.playerStatus.stageTag + 1);
            }
        }
    }
}
