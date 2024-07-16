using System.Collections.Generic;
using UnityEngine;

namespace weapons.Silk
{
    public class SilkThrow : MonoBehaviour
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

        private void Awake()
        {
            silkThrow = GameObject.Find("player").GetComponent<Silk>();
            for (int i = 0; i < particleInstanceCount; i++)
            {
                particlesQueue.Enqueue(Instantiate(particle));
            }
        }
        private void Start()
        {
            gameObject.SetActive(false);
            joint2D = GetComponent<SpringJoint2D>();
            stopPos = Vector2.zero;
            executePos = Vector2.zero;
            isBlocked = false;
            isGraped = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("wall"))
            {
                joint2D.enabled = true;
                silkThrow.isAttach = true;
                isBlocked = true;
                stopPos = gameObject.transform.position;
                if (particlesQueue.Count == 0)
                {
                    var particleInstance =
                        Instantiate(particle, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                    particleInstance.SetActive(true);
                    Destroy(particleInstance,2f);
                }
                else
                {
                    var particleInstance = particlesQueue.Dequeue();
                    particleInstance.SetActive(true);
                    particleInstance.transform.position = gameObject.transform.position;
                    particleInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
                    particleInstance.GetComponent<ParticleSystem>().Play();
                    parameterQueue.Enqueue(particleInstance);
                    Invoke(nameof(ParticleDisable), 3f);
                }
            }
            else if (collision.CompareTag("enemy"))
            {
                joint2D.enabled = true;
                isGraped = true;
                executePos = gameObject.transform.position;
            }
        }

        private void ParticleDisable()
        {
            var particleInstance = parameterQueue.Dequeue();
            particleInstance.SetActive(false);
            particlesQueue.Enqueue(particleInstance);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("wall")) return;
            isBlocked = false;
            stopPos = Vector2.zero;
            isGraped = false;
        }
    }
}
