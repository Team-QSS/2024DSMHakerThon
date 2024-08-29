using System;
using System.Collections;
using System.Collections.Generic;
using player.script;
using SaveAndLoad;
using UnityEngine;

public class ParryItem : MonoBehaviour
{
    public static bool consume;
    private BoxCollider2D bxCollider2D;
    private ParticleSystem particleSys;
    private void Start()
    {
        particleSys = GetComponentInChildren<ParticleSystem>();
        bxCollider2D = GetComponent<BoxCollider2D>();
        consume = false;
        particleSys.Play();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SaveData.SetAbilities("parry");
        particleSys.Stop();
        consume = true;
        Parry.unlockParry = true;
        PlayerMove.canmove = false;
    }
}
