using player.script;
using SaveAndLoad;
using UnityEngine;

namespace Abuilities
{
    public abstract class AbilityItemProto : MonoBehaviour
    {
        public bool consume;
        public ParticleSystem particleSys;
        public void Start()
        {
            particleSys = GetComponentInChildren<ParticleSystem>();
            consume = false;
            particleSys.Play();
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            particleSys.Stop();
            consume = true;
            SetAbil();
        }

        protected abstract void SetAbil();
    }
}
