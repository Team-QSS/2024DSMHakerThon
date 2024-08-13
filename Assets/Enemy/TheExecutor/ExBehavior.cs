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
        
        //private TrailRenderer tr;
        private void Start()
        {

            animator = GetComponent<Animator>();
            rb2D = GetComponent<Rigidbody2D>();
            isFirst = true;
            player = GameObject.FindWithTag("Player");
            //tr = GetComponent<TrailRenderer>();
            //tr.emitting = false;
            Dash();
        }

        private void FixedUpdate()
        {
            var position = player.transform.position;
            playerPos = new Vector2(position.x, position.y);
        }

        private void Update()
        {
            var playerPosition = player.transform.position;
            playerPos = new Vector2(playerPosition.x, playerPosition.y);
            var position = gameObject.transform.position;
            attackRange = Vector2.Distance(position, playerPos);
            playerFlipDirection = position.x - playerPos.x;
            gameObject.transform.localScale = playerFlipDirection < 0 ? new Vector3(-1.3f,1.3f,1.3f) : new Vector3(1.3f,1.3f,1.3f);
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
                randomBehavior = Random.Range(0, 2);
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
            animator.SetBool("isidle",false);
            animator.SetBool("ischase",true);
            animator.SetBool("isdash",false);
            StartCoroutine(ChaseFlow());
            animator.SetBool("isidle",true);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",false);
            NextPattern(attackRange);

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
        }
        IEnumerator DashFlow()
        {
            float originalGravity = rb2D.gravityScale;
            animator.SetBool("isidle",false);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",true);
            yield return new WaitForSeconds(0.9f);
            rb2D.gravityScale = 0f;
            //tr.emitting = true;
            //rb2D.velocity = new Vector2(gameObject.transform.localScale.x * -1f, 0f);
            rb2D.AddForce(new Vector2(gameObject.transform.localScale.x * -7f,0),ForceMode2D.Impulse);
            yield return new WaitForSeconds(1.2f);
            rb2D.velocity = new Vector2(0f, 0f);
            rb2D.gravityScale = originalGravity;
            //tr.emitting = false;
            animator.SetBool("isidle",true);
            animator.SetBool("ischase",false);
            animator.SetBool("isdash",false);
        }

        IEnumerator ChaseFlow()
        {
            for (float i = 0; i < 8f; i += Time.deltaTime)
            {
                if (attackRange > moveSet[0])
                {
                    transform.position = Vector2.MoveTowards(transform.position, playerPos, Time.deltaTime);
                    yield return null;
                    Debug.Log(transform.position);
                }
                else
                {
                    yield break;
                }
            }

            yield return new WaitForSeconds(1.5f);

        }
        

    }
}
