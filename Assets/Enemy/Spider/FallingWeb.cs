using UnityEngine;

namespace Enemy.Spider
{

    public class FallingWeb : MonoBehaviour
    {
        [SerializeField] private GameObject effect;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("wall"))
            {
                WebSummoner.Objects.Enqueue(gameObject);
                gameObject.SetActive(false);
                Destroy(Instantiate(effect, transform.position, Quaternion.Euler(0, 0, 0), transform.parent),1f);
            }
            if (!collision.CompareTag("Barrier")) return;
            WebSummoner.Objects.Enqueue(gameObject);
            gameObject.SetActive(false);
            Destroy(Instantiate(effect, transform.position, Quaternion.Euler(0, 0, 0), transform.parent),1f);
        }
    }
}
