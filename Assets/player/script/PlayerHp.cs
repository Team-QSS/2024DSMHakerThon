using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace player.script
{
    public class PlayerHp : MonoBehaviour
    {
        public float playerhp;
        [SerializeField] private Slider playerHpView;

        public float currentPlayerhp = 100;
    
        // Start is called before the first frame update
        private void Start()
        {
            playerHpView.value = playerhp;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.U)) return;
            StopAllCoroutines();
            SmallHpDamage();
        }

        private void SmallHpDamage()
        {
            playerhp -= 40;
            StartCoroutine(ChangeHealth(playerhp));
        }

        private IEnumerator ChangeHealth(float health)
        {
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                playerHpView.value = Mathf.Lerp(playerHpView.value, health, 2 * Time.deltaTime);
                yield return null;
            }
            playerHpView.value = health;
        }
    }
}
