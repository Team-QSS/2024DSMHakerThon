using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;

public class TriggeringWithDia : MonoBehaviour
{
    [SerializeField] private string diatext;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.GetInstance().SetUpDialogue(diatext,transform.position,Color.white);
        }
    }
}
