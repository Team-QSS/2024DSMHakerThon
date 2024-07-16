using System.Collections;
using UnityEngine;

namespace player.script
{
    public class PlayerMove : MonoBehaviour
    {
        public float horizontal;
        public float jumpingPower = 16f;
        public float speed = 8f;
        public bool isFacingRight = true;
    
        public bool unlockDash;
        private bool canDash = true;
        private bool isDashing;
        public float dashingPower = 24f;
        private const float DashingTime = 0.2f;
        public float dashingCooldown = 1f;
    
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask platformLayer;
        [SerializeField] private Transform platformCheck;
        [SerializeField] private TrailRenderer tr;
        [SerializeField] private BoxCollider2D bcd2;
        private Animator playerAnim;
        private bool jumping;

        public float jumpStartTime;
        public float jumpTime;
        public bool isJumping;
        public Vector3 nockBack;
        public bool stunned;

        private static readonly int IsJumping = Animator.StringToHash("isjumping");
        private static readonly int XVelocity = Animator.StringToHash("xVelocity");

        // Start is called before the first frame update
        private void Start()
        {
            playerAnim = GetComponent<Animator>();
            tr.emitting = false;
            stunned = false;
        }

        private void Update()
        {
            if (!stunned) horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !Input.GetKey(KeyCode.S)) rb.velocity = new Vector2(rb.velocity.x,jumpingPower*2);
            if (Input.GetKeyDown(KeyCode.Space) && IsOnPlatform() && !Input.GetKey(KeyCode.S)) rb.velocity = new Vector2(rb.velocity.x, jumpingPower*2);
        
            if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
            {
                //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                playerAnim.SetBool(IsJumping,true);
            }
            else playerAnim.SetBool(IsJumping,false);

            if (Input.GetKeyDown(KeyCode.LeftShift)&&canDash) StartCoroutine(Dash());

            if (Input.GetKey(KeyCode.S)&&Input.GetKeyDown(KeyCode.Space))
            {
                if (IsOnPlatform())
                {
                    bcd2.isTrigger = true;
                    Invoke(nameof(FallPlatform),0.5f);
                }
            }

            if (horizontal > 0 && !isFacingRight) Flip();
            if (horizontal < 0 && isFacingRight) Flip();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (isDashing||stunned) return;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            playerAnim.SetFloat(XVelocity, Mathf.Abs(rb.velocity.x));

        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private bool IsOnPlatform()
        {
            return Physics2D.OverlapCircle(platformCheck.position, 0.2f, platformLayer);
        }

        private void Flip()
        {
            var currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            isFacingRight = !isFacingRight;
        }

        private IEnumerator Dash()
        {
            if (!unlockDash) yield break;
            canDash = false;
            isDashing = true;
            var originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(DashingTime);
            tr.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }

        private void FallPlatform()
        {
            bcd2.isTrigger = false;
        }

        public void NockRight(float power)
        {
            //rb.velocity = new Vector2(rb.velocity.x*power, rb.velocity.y*power * 0.3f);
            nockBack.x = power * 5;
            nockBack.y = power * 0.3f;
            rb.AddForce(nockBack,ForceMode2D.Impulse);
        }

        public void NockLeft(float power)
        {
            //rb.velocity = new Vector2(rb.velocity.x*power, rb.velocity.y*power * 0.3f);
            nockBack.x = power*5*-1;
            nockBack.y = power * 0.3f;
            rb.AddForce(nockBack,ForceMode2D.Impulse);
        }
        //상태가 넉백이 아닐때만 인풋을 받는다.
    }
}
