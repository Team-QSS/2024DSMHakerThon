using UnityEngine;

namespace Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        public void Script1()
        {
            DialogueManager.GetInstance().SetUpDialogue("텍스트", transform.position+new Vector3(0,3,0), Color.white);
        }
    }
}
