using System;
using SaveAndLoad;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using weapons.Silk;

namespace StageManager
{
    public class NextScene : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SilkThrow.Instance.gameObject.SetActive(false);
                if (SceneManager.GetActiveScene().buildIndex == 6)
                {
                    SceneManager.LoadScene("LastScene");
                    return;
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
