using System;
using System.Collections;
using System.Collections.Generic;
using player.script;
using SaveAndLoad;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathButtonManager : MonoBehaviour
{
    private void Start()
    {
        PlayerMove.Instance.gameObject.SetActive(false);
    }

    public void Load()
    {
        Destroy(PlayerMove.Instance.gameObject);
        SaveData.LoadScene();
    }

    public void toMain()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
