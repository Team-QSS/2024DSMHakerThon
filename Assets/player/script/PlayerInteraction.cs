using System.Collections.Generic;
using SavePoint;
using UnityEngine;
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
        private float waitTime;
        private string tagName;
        private GameObject interactionKey;
        private void Start()
        {
            interactionKey = GameObject.Find("InteractionKey");
            isInteracting = false;
            triggering = false;
            interactAbles.Add("npc",4f);
            interactAbles.Add("item",0.8f);
            interactAbles.Add("bonefire",3f);
            interactAbles.Add("ability",4f);
            interactionKey.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {
            if (triggering)
            {
                if (Input.GetKeyDown(KeyCode.F) && !isInteracting)
                {
                    OnInteractionJudge();
                }
            }


        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!interactAbles.ContainsKey(other.tag)) return;
            interactionKey.SetActive(true);
            tagName = other.tag;
            waitTime = interactAbles[tagName];
            triggering = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            interactionKey.SetActive(false);
            triggering = false;
        }

        private void OnInteractionJudge()
        {
            interactionKey.SetActive(false);
            switch (tagName)
            {
                case "npc":
                    break;
                case "item":
                    break;
                case "bonefire":
                    StartCoroutine(BoneFire.BoneFireFlow(waitTime));
                    break;
                case "ability":
                    break;
                default:
                    Debug.LogError("Unidentified interaction");
                    break;
                    
            }
        }

    }
}
