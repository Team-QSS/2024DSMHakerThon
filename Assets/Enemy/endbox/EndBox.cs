using System.Collections;
using player.script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemy.endbox
{
    public class EndBox : MonoBehaviour
    {
        [SerializeField] private GameObject deathTimeLine;
        [SerializeField] private GameObject youDied;
        [SerializeField] private GameObject slickBar;

        private void Start()
        {
            deathTimeLine.SetActive(false);
            youDied.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")&&!Parry.isParrying)
            {
                /*
                Time.timeScale = 0;
                deathTimeLine.SetActive(true);
                slickBar.SetActive(false);
                StartCoroutine(Death());
                */
                SceneManager.LoadScene("YouDied");
            }
        }

        private static IEnumerator Death()
        {
            yield return new WaitForSecondsRealtime(5);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            /*
        Process.Start(Application.dataPath + "/../SANABANG.exe");
        Application.Quit();
        */
        }
    }
}
