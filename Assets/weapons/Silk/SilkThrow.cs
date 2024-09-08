using System.Collections.Generic;
using Managers;
using player.script;
using UnityEngine;
using Utils;

namespace weapons.Silk
{
    [RequireComponent(typeof(SilkThrow))]
    public class SilkThrow : SingleMono<SilkThrow>
    {
        private Silk silkThrow;
        public SpringJoint2D joint2D;
        public Vector2 stopPos;
        public bool isBlocked;
        public Vector2 executePos;
        public bool isGraped;
        public GameObject particle;
        [SerializeField] private int particleInstanceCount;
        private readonly Queue<GameObject> particlesQueue = new();
        private readonly Queue<GameObject> parameterQueue = new();
        private PlayerMove playerMove;

        protected override void Awake()
        {
            base.Awake();
            Instance.particlesQueue.Clear();
            for (var i = 0; i < particleInstanceCount; i++) Instance.particlesQueue.Enqueue(Instantiate(particle));
        }

        private void Start()
        {
            playerMove = gameObject.GetComponent<PlayerMove>();
            silkThrow = GameObject.Find("player").GetComponent<Silk>();
            gameObject.SetActive(false);
            joint2D = GetComponent<SpringJoint2D>();
            stopPos = Vector2.zero;
            executePos = Vector2.zero;
            isBlocked = false;
            isGraped = false;
        }

        public void ForceAttach(RaycastHit2D hit)
        {
            transform.position = hit.point;
            joint2D.enabled = true;
            silkThrow.isAttach = true;
            AudioManager.PlaySoundInstance("Audio/SilkCatch");
            isBlocked = true;
            stopPos = transform.position;
            var particleInstance = particlesQueue.Count == 0
                ? Instantiate(particle)
                : particlesQueue.Dequeue();
            particleInstance.transform.position = transform.position;
            particleInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
            particleInstance.GetComponent<ParticleSystem>().Play();
            parameterQueue.Enqueue(particleInstance);
            Invoke(nameof(ParticleDisable), 3f);
        }
        
        public void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("wall")) return;
            joint2D.enabled = true;
            silkThrow.isAttach = true;
            AudioManager.PlaySoundInstance("Audio/SilkCatch");
            isBlocked = true;
            stopPos = transform.position;
            var particleInstance = particlesQueue.Count == 0
                ? Instantiate(particle)
                : particlesQueue.Dequeue();
            particleInstance.SetActive(true);
            particleInstance.transform.position = transform.position;
            particleInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
            particleInstance.GetComponent<ParticleSystem>().Play();
            parameterQueue.Enqueue(particleInstance);
            Invoke(nameof(ParticleDisable), 3f);
        }

        private void ParticleDisable()
        {
            var particleInstance = parameterQueue.Dequeue();
            particleInstance.SetActive(false);
            particlesQueue.Enqueue(particleInstance);
        }
        
        private void OnTriggerExit2D(Collider2D col)
        {
            if (!col.CompareTag("wall")) return;
            isBlocked = false;
            stopPos = Vector2.zero;
            isGraped = false;
        }
    }
}
