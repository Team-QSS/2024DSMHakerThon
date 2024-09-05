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
                SceneManager.LoadScene(SaveData.playerStatus.stageTag + 1);
            }
        }
    }
}
