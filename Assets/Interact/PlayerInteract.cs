using player.script;
using UnityEngine;

namespace Interact
{
    public class PlayerInteract : MonoBehaviour
    {
        private Vector3 playerPos;
        private PlayerMove playerMove;
        private bool watching;
        [SerializeField] private ItemInteract interact;

        private void Awake()
        {
            playerMove = gameObject.GetComponent<PlayerMove>();
            interact.InteractOut();
        }

        private void Update()
        {
            playerPos = gameObject.transform.position;
            var rayCast = Physics2D.Raycast(new Vector2(playerPos.x, playerPos.y),
                (playerMove.isFacingRight ? Vector3.right : Vector3.left), 2, LayerMask.GetMask("Interactable"));
            if (rayCast.collider && rayCast.collider.gameObject.CompareTag("Interactive") &&
                rayCast.collider.GetComponent<InteractAbleItem>().canActive)
            {
                interact.InteractOnHere(gameObject.transform.position);
                if (!Input.GetKey(KeyCode.F)) return;
                rayCast.collider.gameObject.GetComponent<InteractAbleItem>().Interact();
                interact.InteractOut();
            }
            else interact.InteractOut();
        }
    }
}
