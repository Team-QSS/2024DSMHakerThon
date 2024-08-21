using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace player.script
{
    public class PlayerInteraction : MonoBehaviour
    {
        private PlayerMove player;
        [SerializeField] private LayerMask interacts;
        [SerializeField]private readonly Dictionary<string,int> interactAbles = new();
        public bool isInteracting;
        private Collider2D otherCollider2d;
        private bool triggering;
        private float tempSpeed;
        private float tempJump;
        // Start is called before the first frame update
        private void Start()
        {
            player = transform.parent.GetComponent<PlayerMove>();
            isInteracting = false;
            triggering = false;
            tempSpeed = player.speed;
            tempJump = player.jumpingPower;
            interactAbles.Add("npc",1);
            interactAbles.Add("item",2);
            interactAbles.Add("bonefire",3);
            interactAbles.Add("ability",4);
        }

        // Update is called once per frame
        private void Update()
        {
            if (triggering)
            {

            }

            /*if (Input.GetKeyDown(KeyCode.F))
            {
                if (isInteracting)
                {
                    player.speed = 0;
                    player.jumpingPower = 0;
                    Invoke(nameof(EndWaiting),2.0f);
                }

            }*/
            
        }

        private void EndWaiting()
        {
            player.speed = tempSpeed;
            player.jumpingPower = tempJump;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            triggering = true;

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            triggering = false;
        }
    }
}
