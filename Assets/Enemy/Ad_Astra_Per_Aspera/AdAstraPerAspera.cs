using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using player.script;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerMove = player.script.PlayerMove;
using Random = UnityEngine.Random;

namespace Enemy.Ad_Astra_Per_Aspera
{
    public class AdAstraPerAspera : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Vector2 home;
        private Vector2 targetPos;
        private TrailRenderer trail;
        private bool isAttacking;
        private bool localParry;
        public List<PatternInfo> patterns;
        private readonly Queue<GameObject> spears = new();
        [SerializeField] private GameObject spear;
        private void Start()
        {
            if (patterns.Count == 0)
            {
                patterns.Add(new PatternInfo(2, 0.5f, 0));
                patterns.Add(new PatternInfo(5, 0.03f, 1));
            }
            rb = GetComponent<Rigidbody2D>();
            home = transform.position;
            trail = GetComponent<TrailRenderer>();
            StartCoroutine(SetTargetLocationFlow());
        }

        private IEnumerator SetTargetLocationFlow()
        {
            while (gameObject)
            {
                yield return new WaitForSeconds(Random.Range(3f, 5f));
                targetPos = new Vector3(home.x + Random.Range(-5f, 5f), rb.position.y);
            }
        }

        private void FixedUpdate()
        {
            if (isAttacking && Parry.isParrying) localParry = true;
            if (isAttacking)
            {
                rb.position = PlayerMove.playerPos + new Vector2(PlayerMove.Instance.isFacingRight ? 2 : -2, 0);
                rb.velocity = Vector2.zero;
                return;
            }
            if ((PlayerMove.playerPos - rb.position).magnitude < 5f && (rb.position - home).magnitude < 10f) targetPos = PlayerMove.playerPos;
            var vector = new Vector2(targetPos.x, rb.position.y) - rb.position;
            if (vector.magnitude < 0.1f)
            {
                rb.position = new Vector3(targetPos.x, rb.position.y);
                rb.velocity = Vector2.zero;
            } else rb.velocity = vector.normalized * 3;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isAttacking || !other.CompareTag("Player")) return;
            isAttacking = true;
            trail.enabled = true;
            rb.position = PlayerMove.playerPos + new Vector2(PlayerMove.Instance.isFacingRight ? 2 : -2, 0);
            rb.velocity = Vector2.zero;
            StartCoroutine(AttackFlow());
        }

        private IEnumerator AttackFlow()
        {
            PlayerMove.disableOnlyMove++;
            foreach (var info in patterns)
            {
                for (var i = 0; i < info.repeatTime; i++)
                {
                    var pos = PlayerMove.playerPos + new Vector2(Random.Range(-2f, 2f), 5);
                    var vector = PlayerMove.playerPos - pos;
                    spears.Enqueue(Instantiate(spear, pos, new Quaternion(vector.x, vector.y, 0, 0), PlayerMove.Instance.transform));
                    AudioManager.PlaySoundInstance("Audio/SilkCatch");
                    yield return new WaitForSeconds(info.waitTime);
                }
                yield return new WaitForSeconds(info.postDelay);
            }
            var failParry = !localParry;
            foreach (var info in patterns)
            {
                for (var i = 0; i < info.repeatTime; i++)
                {
                    var o = spears.Dequeue();
                    o.transform.position = PlayerMove.playerPos;
                    AudioManager.PlaySoundInstance(failParry ? "Audio/PARRY_PROCESS" : "Audio/PARRY_SUCCESS");
                    Destroy(o, info.waitTime + info.postDelay);
                    yield return new WaitForSeconds(info.waitTime);
                }
                yield return new WaitForSeconds(info.postDelay);
            }
            PlayerMove.disableOnlyMove--;
            isAttacking = false;
            localParry = false;
            if (failParry)
            {
                SceneManager.LoadScene("YouDied");
                isAttacking = false;
                yield break;
            }
            Destroy(gameObject);
        }
    }

    [Serializable]
    public class PatternInfo
    {
        public int repeatTime;
        public float waitTime;
        public float postDelay;

        public PatternInfo(int repeatTime, float waitTime, float postDelay)
        {
            this.repeatTime = repeatTime;
            this.waitTime = waitTime;
            this.postDelay = postDelay;
        }
    }
}
