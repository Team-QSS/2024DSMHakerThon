using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    public static ItemInteract Instance;
    private TMP_Text textPanel;
    public Camera cam;

    private void Awake()
    {
        textPanel = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ChangeText(string Text)
    {
        textPanel.text = Text;
    }

    public void InteractOnHere(Vector3 Position)
    {
        transform.position = cam.WorldToScreenPoint(Position + new Vector3(0,0,10f));
        gameObject.SetActive(true);
    }

    public void InteractOut()
    {
        gameObject.SetActive(false);
    }
}
