using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;

public class TriggeringWithDia : MonoBehaviour
{
    [SerializeField] private string diatext;
    [SerializeField] private Color color;
    [SerializeField] private float plainTime = 1f;

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.GetInstance().SetUpDialogue(diatext,transform.position,color,plainTime);
        }
    }
}
