using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene2 : MonoBehaviour
{
    [SerializeField] private GameObject nextSceneTimeLine;
    [SerializeField] private GameObject slikBank;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            nextSceneTimeLine.SetActive(true);
            slikBank.SetActive(false);
        }
    }


    
}
