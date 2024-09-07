using UnityEngine;
using UnityEngine.SceneManagement;
using weapons.Silk;

namespace StageManager
{
    public class NextScene : MonoBehaviour
    {
        private bool isActivated;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isActivated || !other.CompareTag("Player")) return;
            isActivated = true;
            SilkThrow.Instance.gameObject.SetActive(false);
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene("LastScene");
                return;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
