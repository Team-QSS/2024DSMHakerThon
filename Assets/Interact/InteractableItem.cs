using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAbleItem : MonoBehaviour
{
    public UnityEvent onInteract;
    public bool canActive = true;

    public void Interact()
    {
        onInteract.Invoke();
    }
}
