using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using UnityEngine.UI;

public class TriggeringWithDia : MonoBehaviour
{
    [TextArea] public string diatext;
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
