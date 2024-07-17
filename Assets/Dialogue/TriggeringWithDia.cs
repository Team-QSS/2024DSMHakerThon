using UnityEngine;
using UnityEngine.Serialization;

namespace Dialogue
{
    public class TriggeringWithDia : MonoBehaviour
    {
        [FormerlySerializedAs("diatext")] [TextArea] public string diaText;
        [SerializeField] private Color color;
        [SerializeField] private float plainTime = 1f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                DialogueManager.GetInstance().SetUpDialogue(diaText, transform.position, color, plainTime);
            }
        }
    }
}
