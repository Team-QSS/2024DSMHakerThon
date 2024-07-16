using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteraction : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask specailItem;
    [SerializeField] private LayerMask npc;
    [SerializeField] private Transform nearItem;
    [SerializeField] private GameObject dialoguemanager;
    public static playerinteraction pi;
    public bool interaction;
    public bool interactionwithnpc;
    private float tempspeed;
    private float tempjump;
    private playermove speedmanager;
    // Start is called before the first frame update
    void Start()
    {
        speedmanager = player.GetComponent<playermove>();
        interaction = false;
        interactionwithnpc = false;
        tempspeed = speedmanager.speed;
        tempjump = speedmanager.jumpingPower;
    }

    // Update is called once per frame
    void Update()
    {
        // interaction = (nearItem.position - transform.position).sqrMagnitude <= 4f);
        interaction = Physics2D.OverlapCircle(nearItem.position, 0.5f, specailItem);
        interactionwithnpc = Physics2D.OverlapCircle(nearItem.position, 0.5f, npc);
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (interaction)
            {
                speedmanager.speed = 0;
                speedmanager.jumpingPower = 0;
                Invoke("Endwaiting",2.0f);
            }

        }
        if (interactionwithnpc)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                speedmanager.speed = 0;
                speedmanager.jumpingPower = 0; 
            }
            else
            {
                speedmanager.speed = 0;
                speedmanager.jumpingPower = 0;  
            }
        }
        
         if (Physics2D.OverlapCircle(nearItem.position, 2f, specailItem))
        {
            interaction = true;
        } 
    }

    private void Endwaiting()
    {
        speedmanager.speed = tempspeed;
        speedmanager.jumpingPower = tempjump;
    }

    
}
