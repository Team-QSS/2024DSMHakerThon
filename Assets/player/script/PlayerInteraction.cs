using System.Collections.Generic;
using Interact;
using SavePoint;
using Unity.VisualScripting;
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
            player = transform.parent.GetComponent<PlayerMove>();
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

            var position = transform.position;
            var rayCast = Physics2D.Raycast(new Vector2(position.x, position.y),player.isFacingRight ? Vector3.right : Vector3.left, 2, interacts);
            if (rayCast.collider&& interactAbles.ContainsKey(rayCast.collider.tag))
            {
                interactionKey.SetActive(true);
                tagName = rayCast.collider.tag;
                waitTime = interactAbles[tagName];
                triggering = true;
            }
            else
            {
                interactionKey.SetActive(false);
                triggering = false;
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!interactAbles.ContainsKey(other.tag)) return;

        }

        private void OnTriggerExit2D(Collider2D other)
        {

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
