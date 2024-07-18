using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene5 : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CrowChacing");
    }
}
