using System;
using System.Collections;
using System.Collections.Generic;
using player.script;
using UnityEngine;

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

    void Update()
    {
        playerPos = gameObject.transform.position;
        RaycastHit2D raycast = Physics2D.Raycast(new Vector2(playerPos.x, playerPos.y), (playerMove.isFacingRight ?  Vector3.right : Vector3.left),2,LayerMask.GetMask("Interactable"));
        if (raycast.collider is not null)
        {
            if (raycast.collider.gameObject.CompareTag("Interactive"))
            {
                Debug.Log("hello");
                if (raycast.collider.GetComponent<InteractAbleItem>().canActive)
                {
                    Debug.Log("itis canactive");
                    interact.InteractOnHere(gameObject.transform.position);
                    if (Input.GetKey(KeyCode.F))
                    { 
                        Debug.Log("yammy");
                        raycast.collider.gameObject.GetComponent<InteractAbleItem>().Interact();
                    }
                     
                }
            }
        }
        else
        {
            interact.InteractOut();
        }
    }
}
