using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext4 : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LastScene");
    }
}
