using System;
using System.Collections;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.TheExecutor
{
    public class ExBehavior : MonoBehaviour
    {
        private GameObject player;
        private Vector2 playerPos;
        private bool isFirst; 
        [SerializeField]private float[] moveSet;
        private float attackRange;
        private Rigidbody2D rb2D;
        private Animator animator;
        private int randomBehavior;
        private float playerFlipDirection;
        private void FixedUpdate()
        {
            var position = player.transform.position;
            playerPos = new Vector2(position.x, position.y);
        }

        private void Start()
        {

            animator = GetComponent<Animator>();
            rb2D = GetComponent<Rigidbody2D>();
            isFirst = true;
            player = GameObject.FindWithTag("Player");
            Dash();
            //moveSet[0] = 4;
            //moveSet[1] = 10;
            //moveSet[2] = 20;
        }
        private void Update()
        {
            var position = gameObject.transform.position;
            attackRange = Vector2.Distance(position, playerPos);
            playerFlipDirection = position.x - playerPos.x;
            Debug.Log(playerFlipDirection);
            gameObject.transform.localScale = attackRange < 0 ? new Vector3(-1.3f,1.3f,1.3f) : new Vector3(1.3f,1.3f,1.3f);
        }

        private void NextPattern(float atkRange)
        {
            if (atkRange < moveSet[0])
            {
                Attack();
            }

            else if (atkRange > moveSet[1] && atkRange < moveSet[2])
            {
                
                Dash();
            }
            else if (atkRange > moveSet[0] && atkRange < moveSet[1])
            {
                randomBehavior = Random.Range(0, 1);
                switch (randomBehavior)
                {
                    case 0:
                        Chase();
                        break;
                    case 1:
                        Dash();
                        break;
                }
            }
            else
            {
                Chase();
            }
            
        }

        private void Chase()
        {
            StartCoroutine(ChaseFlow());
        }
        
        private void Dash()
        {
            StartCoroutine(DashFlow());
        }

        private void Attack()
        {
            StartCoroutine(AttackFlow());
        }

        public void PatternEnd()
        {
            NextPattern(attackRange);
        }

        IEnumerator AttackFlow()
        {
            animator.SetBool("isidle",false);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",false);
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(0.7f);
            animator.SetBool("isidle",false);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",false);
            yield return new WaitForSeconds(0.3f);
            Debug.Log(1);
        }
        IEnumerator DashFlow()
        {
            float originalGravity = rb2D.gravityScale;
            animator.SetBool("isidle",false);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",true);
            yield return new WaitForSeconds(0.9f);
            rb2D.gravityScale = 0f;
            rb2D.velocity = new Vector2(gameObject.transform.localScale.x * -2.3f, 0f);
            yield return new WaitForSeconds(1.2f);
            rb2D.velocity = new Vector2(0f, 0f);
            rb2D.gravityScale = originalGravity;
            animator.SetBool("isidle",true);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",false);
            yield return new WaitForSeconds(0.2f);
            Debug.Log(2);
        }

        IEnumerator ChaseFlow()
        {
            animator.SetBool("isidle",false);
            animator.SetBool("ischase",true);
            animator.SetBool("isdash",false);
            rb2D.velocity = new Vector2(gameObject.transform.localScale.x * -1f, 0f);
            yield return new WaitForSeconds(1f);
            rb2D.velocity = new Vector2(0f, 0f);
            animator.SetBool("isidle",true);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",false);
            yield return new WaitForSeconds(0.4f);
            Debug.Log(3);
        }
    }
}
