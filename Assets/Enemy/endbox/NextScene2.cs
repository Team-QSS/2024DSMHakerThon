using System;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.endbox
{
    public class NextScene2 : MonoBehaviour
    {
        [SerializeField] private GameObject nextSceneTimeLine;
        [FormerlySerializedAs("slikBank")] [SerializeField] private GameObject silkBank;

        private void Start()
        {
            AudioManager.PlaySoundInstance("Audio/WhiteNoiseInc");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            Time.timeScale = 0;
            nextSceneTimeLine.SetActive(true);
            silkBank.SetActive(false);
        }
    }
}
