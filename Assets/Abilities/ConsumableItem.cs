using System;
using player.script;
using SaveAndLoad;
using UnityEngine;

namespace Abilities
{
    public class ConsumableItem : MonoBehaviour
    {
        [NonSerialized] public bool Consume;
        private ParticleSystem particleSys;
        [Header("Consumable Item")]
        public string ability;
        public GameObject descriptionText;
        public void Start()
        {
            particleSys = GetComponentInChildren<ParticleSystem>();
            particleSys.Play();
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            particleSys.Stop();
            Consume = true;
            PlayerMove.canmove = false;
            SaveData.SetAbilities(ability);
        }
    }
}
