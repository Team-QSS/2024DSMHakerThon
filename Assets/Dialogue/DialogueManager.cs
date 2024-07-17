using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager _instance;
        public GameObject text;
        private readonly Queue<GameObject> spawnedObjects = new();

        private void Awake()
        {
            _instance = this;
        }

        public static DialogueManager GetInstance()
        {
            return _instance;
        }

        public void SetUpDialogue(string plainText, Vector3 position, Color color, float plainTime = 1f)
        {
            var o = spawnedObjects.Count > 0 ? spawnedObjects.Dequeue() : Instantiate(text);
            o.SetActive(true);
            o.transform.position = position;
            var t = o.GetComponent<TextMeshPro>();
            t.text = plainText;
            t.color = new Color(color.a, color.g, color.b, 0);
            StartCoroutine(TextAppearFlow(t, color, plainTime));
        }

        private IEnumerator TextAppearFlow(TextMeshPro t, Color target, float plainTime)
        {
            while (!(Mathf.Abs(t.color.a - target.a) < 0.02f))
            {
                t.color = Color.Lerp(t.color, target, Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(plainTime);
            target.a = 0;
            while (!(Mathf.Abs(t.color.a - target.a) < 0.02f))
            {
                t.color = Color.Lerp(t.color, target, Time.deltaTime);
                yield return null;
            }
            t.gameObject.SetActive(false);
            spawnedObjects.Enqueue(t.gameObject);
        }
    }
}
