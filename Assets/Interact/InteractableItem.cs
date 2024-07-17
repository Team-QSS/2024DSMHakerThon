using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Interact
{
    public class InteractAbleItem : MonoBehaviour
    {
        public UnityEvent onInteract;
        public bool canActive = true;
        public float interactTrim;

        public void Interact()
        {
            if (!canActive) return;
            onInteract.Invoke();
            StartCoroutine(ActiveTimer());
        }

        private IEnumerator ActiveTimer()
        {
            canActive = false;
            yield return new WaitForSeconds(interactTrim);
            canActive = true;
        }
    }
}
