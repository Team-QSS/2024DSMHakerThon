using System.Collections;
using UnityEngine;

namespace Enemy.Spider
{
    public class WebSummoner : MonoBehaviour
    {
        
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
                Instantiate(webObject, new Vector3(Random.Range(-105f, 35f), gameObject.transform.position.y), webObject.transform.rotation);
                yield return new WaitForSeconds(summonTime);
            }
        }
    }
}