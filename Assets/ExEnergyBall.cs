using System;
using System.Collections;
using System.Collections.Generic;
using player.script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExEnergyBall : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, 12f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&&!Parry.isParrying)
        {
            SceneManager.LoadScene("YouDied");
        }
        else if (other.CompareTag("Player") && Parry.isParrying)
        {
            Destroy(gameObject);
        }
        else if(other.CompareTag("wall")){
            Destroy(gameObject);
        }
    }
}
