using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryItem : MonoBehaviour
{
    private BoxCollider2D bxCollider2D;

    private void Start()
    {
        bxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SaveData.SetAbilities("parry");
    }
}
