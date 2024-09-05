using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextText : MonoBehaviour
{
    private int totalTag;
    private TextMeshProUGUI cutSceneText;
    private GameObject player;
    private GameObject silk;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (player.activeSelf)
        {
            player.SetActive(false);
        }
        
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

        cutSceneText.text = totalTag switch
        {
            0 => "어딜 그리도 급히 가시나",
            1 => "달빛 잃은 자여",
            2 => "아직 해는 지지 않았다..",
            3 => "달이 떠도 너희는 안식을 가질 수 없지",
            4 => "달의 축복없는 모든 자에게 고통을..",
            _ => cutSceneText.text
        };
    }

    public void NextTag()
    {
        totalTag++;
        Check();
    }
}
