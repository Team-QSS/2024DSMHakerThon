using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyking : MonoBehaviour
{
    private Pkye pyking;
    public SpringJoint2D joint2D;
    public Vector2 stopPos;
    public bool isBlocked;
    public Vector2 excutePos;
    public bool isGraped;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        pyking = GameObject.Find("player").GetComponent<Pkye>();
        joint2D = GetComponent<SpringJoint2D>();
        stopPos = Vector2.zero;
        excutePos = Vector2.zero;
        isBlocked = false;
        isGraped = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            joint2D.enabled = true;
            pyking.isAttach = true;
            isBlocked = true;
            stopPos = gameObject.transform.position;
            Destroy(Instantiate(particle, gameObject.transform.position, Quaternion.Euler(0, 0, 0)),2f);
        }
        else if (collision.CompareTag("enemy"))
        {
            joint2D.enabled = true;
            isGraped = true;
            excutePos = gameObject.transform.position;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("wall")){
            
                isBlocked = false;
                stopPos = Vector2.zero;
                isGraped = false;
                
        }

    }
    
}
