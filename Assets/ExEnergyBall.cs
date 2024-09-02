using System.Collections;
using System.Collections.Generic;
using player.script;
using UnityEngine;

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
        rb2D.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, 10f * Time.deltaTime);
    }
}
