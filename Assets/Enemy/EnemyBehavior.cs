using System;
using System.Collections;
using System.Collections.Generic;
using Enemy.TheExecutor;
using player.script;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int maxHp;
    public float curHp;
    public bool isAttacking;
    public bool isStun;
    public float stunTime;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 0;
        curHp = 0;
        stunTime = 0;
        isAttacking = false;
        isStun = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&isAttacking&&Parry.isParrying)
        {
            isStun = true;
            Debug.Log(3);
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log(2);
        }
        Debug.Log(1);
    }
}
