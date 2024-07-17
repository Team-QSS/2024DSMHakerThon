using System;
using System.Collections;
using System.Collections.Generic;
using player.script;
using Unity.VisualScripting;
using UnityEngine;

public class RadderScript : MonoBehaviour
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
        if (playerMove.isFacingRight)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, maxDistance, LayerMask.GetMask("platform"));
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.name == "Radder")
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        rb.velocity = new Vector2(rb.velocity.x, climbSpeed); // 클라이밍 속도 증가
                    }
                }
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, maxDistance, LayerMask.GetMask("platform"));
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.name == "Radder")
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        rb.velocity = new Vector2(rb.velocity.x, climbSpeed); // 클라이밍 속도 증가
                    }
                }
            }
        }
    }
}