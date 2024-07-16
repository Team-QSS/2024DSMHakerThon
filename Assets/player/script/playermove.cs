using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor.Searcher;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float horizontal;
    public float jumpingPower = 16f;
    public float speed = 8f;
    public bool isFacingRight = true;
    
    public bool unlockdash = false;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private Transform platformCheck;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private BoxCollider2D bcd2;
    private Animator playerani;
    private bool jumping = false;

    public float jumpstarttime;
    public float jumptime;
    public bool isjumping;
    public Vector3 nockBack;
    public bool isstuned;
    // Start is called before the first frame update
    private void Start()
    {
        playerani = GetComponent<Animator>();
        tr.emitting = false;
        isstuned = false;
    }

    void Update()
    {
        if (!isstuned)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpingPower*2);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsOnPlatform() && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower*2);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            playerani.SetBool("isjumping",true);

        }
        else
        {
            playerani.SetBool("isjumping",false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)&&canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKey(KeyCode.S)&&Input.GetKeyDown(KeyCode.Space))
        {
            if (IsOnPlatform())
            {
                bcd2.isTrigger = true;
                Invoke("Fallplatforme",0.5f);
            }

        }
        
        

        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }

        if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing||isstuned)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        playerani.SetFloat("xVelocity",Mathf.Abs(rb.velocity.x));

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
        
        Vector3 curentScale = gameObject.transform.localScale;
        curentScale.x *= -1;
        gameObject.transform.localScale = curentScale;
        isFacingRight = !isFacingRight;
    }

    private IEnumerator Dash()
    {
        if (unlockdash)
        {
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            tr.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            tr.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }

    }
    
    void Fallplatforme()
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
