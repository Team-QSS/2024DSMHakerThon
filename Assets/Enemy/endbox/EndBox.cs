using System.Collections;
using Enemy.TheExecutor;
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
        private ExBehavior exBehavior;
        private void Start()
        {
            exBehavior=exBehavior.transform.parent.gameObject.GetComponent<ExBehavior>();
            deathTimeLine.SetActive(false);
            youDied.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")&&!exBehavior.isStun)
            {
                Debug.Log("die");
                SceneManager.LoadScene("YouDied");
            }
        }
        
    }
}
