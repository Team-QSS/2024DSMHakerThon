using UnityEngine;

namespace player.script
{
    public class Playerinteraction : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private LayerMask specialItem;
        [SerializeField] private LayerMask npc;
        [SerializeField] private Transform nearItem;
        [SerializeField] private GameObject dialogueManager;
        public static Playerinteraction pi;
        public bool interaction;
        public bool interactionWithNpc;
        private float tempSpeed;
        private float tempJump;
        private PlayerMove speedManager;
        // Start is called before the first frame update
        private void Start()
        {
            speedManager = player.GetComponent<PlayerMove>();
            interaction = false;
            interactionWithNpc = false;
            tempSpeed = speedManager.speed;
            tempJump = speedManager.jumpingPower;
        }

        // Update is called once per frame
        private void Update()
        {
            // interaction = (nearItem.position - transform.position).sqrMagnitude <= 4f);
            interaction = Physics2D.OverlapCircle(nearItem.position, 0.5f, specialItem);
            interactionWithNpc = Physics2D.OverlapCircle(nearItem.position, 0.5f, npc);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (interaction)
                {
                    speedManager.speed = 0;
                    speedManager.jumpingPower = 0;
                    Invoke(nameof(EndWaiting),2.0f);
                }

            }
            if (interactionWithNpc)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    speedManager.speed = 0;
                    speedManager.jumpingPower = 0; 
                }
                else
                {
                    speedManager.speed = 0;
                    speedManager.jumpingPower = 0;  
                }
            }
        
            if (Physics2D.OverlapCircle(nearItem.position, 2f, specialItem))
            {
                interaction = true;
            } 
        }

        private void EndWaiting()
        {
            speedManager.speed = tempSpeed;
            speedManager.jumpingPower = tempJump;
        }
    }
}
