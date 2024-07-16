using System.Collections;
using UnityEngine;

namespace player.script
{
    public class PlayerHitBox : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private PlayerMove playerMove;

        private void Start()
        {
            playerMove = player.GetComponent<PlayerMove>();
        }
    

        public void NockBack(Vector3 enemyPos,float power,float time)
        {
   
            if (gameObject.transform.position.x - enemyPos.x < 0)
            {
                playerMove.stunned = true;    
                playerMove.NockLeft(power);
                StartCoroutine(NockBackFlow(time));

            }
            else
            {
                playerMove.stunned = true;
                playerMove.NockRight(power);
                StartCoroutine(NockBackFlow(time));
            }
        
        }

        private IEnumerator NockBackFlow(float time)
        {
            yield return new WaitForSeconds(time);
            playerMove.stunned = false;
        }
    
    }
}
