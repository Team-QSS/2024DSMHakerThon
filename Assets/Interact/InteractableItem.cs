using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractAbleItem : MonoBehaviour
{
    public UnityEvent onInteract;
    public bool canActive = true;
    public float InteractTrim;

    public void Interact()
    {
        if (canActive)
        {
            onInteract.Invoke();
            StartCoroutine(activeTimer());
        }
    }

    IEnumerator activeTimer()
    {
        canActive = false;
        yield return new WaitForSeconds(InteractTrim);
        canActive = true;
    }
}
