using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.IO;
namespace player.script
{
    public class PlayerInteraction : MonoBehaviour
    {
        private PlayerMove player;
        [SerializeField] private LayerMask interacts;
        private readonly Dictionary<string,float> interactAbles = new();
        public static bool isInteracting;
        private Collider2D otherCollider2d;
        private bool triggering;
        private float tempSpeed;
        private float tempJump;
        private float waitTime;
        private string tagName;
        // Start is called before the first frame update
        private void Start()
        {
            player = transform.parent.GetComponent<PlayerMove>();
            isInteracting = false;
            triggering = false;
            tempSpeed = player.speed;
            tempJump = player.jumpingPower;
            interactAbles.Add("npc",4);
            interactAbles.Add("item",0.8f);
            interactAbles.Add("bonefire",3f);
            interactAbles.Add("ability",4f);
        }

        // Update is called once per frame
        private void Update()
        {
            if (triggering&&Input.GetKeyDown(KeyCode.F)&&!isInteracting) OnInteractionJudge();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!interactAbles.ContainsKey(other.tag)) return;
            tagName = other.tag;
            waitTime = interactAbles[tagName];
            triggering = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            triggering = false;
        }

        private void OnInteractionJudge()
        {
            switch (tagName)
            {
                case "npc":
                    break;
                case "item":
                    break;
                case "bonefire":
                    StartCoroutine(BoneFireFlow(waitTime));
                    break;
                case "ability":
                    break;
                default:
                    Debug.LogError("Unidentified interaction");
                    break;
                    
            }
        }
        private static IEnumerator BoneFireFlow(float sec)
        {
            isInteracting = true;
            
            yield return new WaitForSeconds(sec);


        }
    }
}
