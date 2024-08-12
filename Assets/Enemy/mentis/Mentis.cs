using player.script;
using UnityEngine;

namespace Enemy.mentis
{
    public class Mentis : MonoBehaviour
    {
        private GameObject target;
        private Vector3 newPosX;
        [SerializeField] private Animator mentisAnim;
        private PlayerMove playerMove;
        [SerializeField] private GameObject attackRange;
        [SerializeField] private GameObject recognitionRange;
        private bool isWalking;
        private bool isAttacking;
        private bool isIdling;
        private Rigidbody2D rb;
        public LayerMask playerCheck;
        private static readonly int IsIdling = Animator.StringToHash("isidling");
        private static readonly int IsWalking = Animator.StringToHash("iswalking");
        private static readonly int IsAttacking = Animator.StringToHash("isattacking");

        // Start is called before the first frame update
        private void Start()
        {
            playerMove = PlayerMove.Instance;
            target = playerMove.gameObject;
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            newPosX = new Vector3(target.transform.position.x, -0.2f, 0);

            if (Physics2D.OverlapCircle(attackRange.transform.position, 0.7f, playerCheck))
            {
                SetAnimation(IsAttacking);
                return;
            }
            if (target.transform.position.x > gameObject.transform.position.x)
            {
                var scale = gameObject.transform.localScale;
                scale.x = 1f;
                gameObject.transform.localScale = scale;
                if (playerMove.isFacingRight)
                    if (Physics2D.OverlapCircle(recognitionRange.transform.position, 8.5f, playerCheck))
                    {
                        rb.position = Vector3.MoveTowards(gameObject.transform.position, newPosX,
                            2 * Time.deltaTime);
                        SetAnimation(IsWalking);
                    }
                    else SetAnimation(IsIdling);
                else SetAnimation(IsIdling);
            }
            else
            {
                var scale = gameObject.transform.localScale;
                scale.x = -1f;
                gameObject.transform.localScale = scale;
                if (!playerMove.isFacingRight)
                    if (Physics2D.OverlapCircle(recognitionRange.transform.position, 8.5f, playerCheck))
                    {
                        rb.position = Vector3.MoveTowards(gameObject.transform.position, newPosX,
                            2 * Time.deltaTime);
                        SetAnimation(IsWalking);
                    }
                    else SetAnimation(IsIdling);
                else SetAnimation(IsIdling);
            }
        }

        private void SetAnimation(int id)
        {
            mentisAnim.SetBool(IsIdling, false);
            mentisAnim.SetBool(IsWalking, false);
            mentisAnim.SetBool(IsAttacking, false);
            mentisAnim.SetBool(id, true);
        }
    }
}