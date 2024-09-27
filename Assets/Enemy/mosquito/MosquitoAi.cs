using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class mosquitoAi : MonoBehaviour
{
   
    private Rigidbody2D _enemyRigid;
    private float _enemyAtkDelay = 0;
    private const float EnemySpeed = 16;
    private GameObject _target;
    private const float EnemySight = 54;
    private const float EnemyAtkSight = 3.5f;
    public Animator _enemyAnimator;
    public float _direct = 3;
    private GameObject _player;
    private SpriteRenderer _sr;
    
    void Start()
    {
        _enemyRigid = GetComponent<Rigidbody2D>();
        InvokeRepeating("Cliff", 3f, 3f);
        _enemyAtkDelay = 2;
        _player = GameObject.FindWithTag("Player");
        _target = _player;
        _sr = GetComponent<SpriteRenderer>();
        _sr.flipX = false;

    }
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, _target.transform.position);
        _enemyAtkDelay -= Time.deltaTime;
            if (_enemyAtkDelay <= 0 && distance <= EnemySight)
            {
                LockOnTarget();
                if (distance <= EnemyAtkSight)
                {
                    AttackToTarget();   
                }

                if (distance is <= EnemySight and >= EnemyAtkSight)
                {
                    MoveToTarget();
                }
            }
            else
            {
                _enemyRigid.velocity = new Vector2(_direct, _enemyRigid.velocity.y);
            }
            
            
            
         
    }
    
    //Enemy Damage Operation
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //Enemy AI
    private void LockOnTarget()
    {
        if (_target.transform.position.x - transform.position.x < 0)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }
    }

    void MoveToTarget()
    {
        float dir = _target.transform.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, EnemySpeed * Time.deltaTime);
    }

    void AttackToTarget()
    {
        _enemyAtkDelay = 1.3f;
    }

    void Cliff()
    {
        if (_direct == 3)
        {
            _direct = -3;
        }
        else
        {
            _direct = 3;
        }
    }
}
