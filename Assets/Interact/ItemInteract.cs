using TMPro;
using UnityEngine;

namespace Interact
{
    public class ItemInteract : MonoBehaviour
    {
        public static ItemInteract instance;
        private TMP_Text textPanel;
        public Camera cam;

        private void Awake()
        {
            textPanel = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
            instance = this;
            gameObject.SetActive(false);
        }

        public void ChangeText(string text)
        {
            textPanel.text = text;
        }

        public void InteractOnHere(Vector3 position)
        {
            transform.position = cam.WorldToScreenPoint(position + new Vector3(0,0,10f));
            gameObject.SetActive(true);
        }

        public void InteractOut()
        {
            gameObject.SetActive(false);
        }
    }
}
