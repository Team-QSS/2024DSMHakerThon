using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextText : MonoBehaviour
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
                cutSceneText.text = "어딜 그리도 급히 가시나";
                break;
            case 1:
                cutSceneText.text = "달빛 잃은 자여";
                break;
            case 2:
                cutSceneText.text = "아직 해는 지지 않았다..";
                break;
            case 3:
                cutSceneText.text = "달이 떠도 너희는 안식을 가질 수 없지";
                break;
            case 4:
                cutSceneText.text = "달의 축복없는 모든 자에게 고통을..";
                break;
        }
    }

    public void NextTag()
    {
        totalTag++;
        Check();
    }
}
