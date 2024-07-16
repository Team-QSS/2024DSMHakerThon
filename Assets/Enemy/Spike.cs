using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject core;
    private PlayerHitBox nockingBack;
    private void Start()
    {
        nockingBack = core.GetComponent<PlayerHitBox>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            nockingBack.NockBack(gameObject.transform.position,5f,0.5f);
        }

    }
}
