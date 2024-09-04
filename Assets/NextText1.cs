using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextText1: MonoBehaviour
{
    private int totalTag;
    private TextMeshProUGUI cutSceneText;
    private GameObject player;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.SetActive(false);
        totalTag = 0;
        cutSceneText = GameObject.FindWithTag("timelinetmp").GetComponent<TextMeshProUGUI>();
        Check();
        
    }

    private void Check()
    {
        if (totalTag >= 5)
        {
            player.SetActive(true);
            SceneManager.LoadScene("Excuter");
        }
        switch (totalTag)
        {
            case 0:
                cutSceneText.text = ". . . ?";
                break;
            case 1:
                cutSceneText.text = "명줄이 꽤 질기군..";
                break;
            case 2:
                cutSceneText.text = "이렇게까지 고전할 줄은 몰랐는데";
                break;
            case 3:
                cutSceneText.text = "달의 신이여";
                break;
            case 4:
                cutSceneText.text = "무한한 월광의힘을 주소서";
                break;
        }
    }

    public void NextTag()
    {
        totalTag++;
        Check();
    }
}
