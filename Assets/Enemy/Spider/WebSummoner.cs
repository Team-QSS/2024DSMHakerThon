using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Spider
{
    public class WebSummoner : MonoBehaviour
    {
        public static readonly Queue<GameObject> Objects = new();
        public GameObject webObject;
        public float summonTime;
        private void Start()
        {
            StartCoroutine(SummonWeb());
        }

        private IEnumerator SummonWeb()
        {
            while (true)
            {
                var obj = Objects.Count > 0 ? Objects.Dequeue() : Instantiate(webObject);
                obj.SetActive(true);
                obj.transform.position = new Vector3(Random.Range(-105f, 35f), gameObject.transform.position.y);
                yield return new WaitForSeconds(summonTime);
            }
        }
    }
}