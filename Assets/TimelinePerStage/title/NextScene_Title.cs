using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class NextScene_Title : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("Stage1");
        }
    }

