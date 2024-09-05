using player.script;
using UnityEngine;

namespace furniture.radder
{
    public class LadderScript : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 1f;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float climbSpeed = 3f; // 클라이밍 속도 증가

        private PlayerMove playerMove;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            playerMove = GetComponent<PlayerMove>();
        }

        private void FixedUpdate()
        {
            var hit = Physics2D.Raycast(transform.position, playerMove.isFacingRight ? Vector2.right : Vector2.left,
                maxDistance, LayerMask.GetMask("platform"));
            if (!hit.collider) return;
            if (hit.collider.name != "Radder") return;
            if (Input.GetKey(KeyCode.W)) rb.velocity = new Vector2(rb.velocity.x, climbSpeed); // 클라이밍 속도 증가
        }
    }
}