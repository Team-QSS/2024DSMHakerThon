using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.Spider
{

    public class FallingWeb : MonoBehaviour
    {
        [SerializeField] private GameObject effect;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("wall"))
            {
                
                Destroy(Instantiate(effect, transform.position, Quaternion.Euler(0, 0, 0)),1f);
                Destroy(gameObject);
            }
            if(collision.CompareTag("Barrier"))
            {
                Destroy(Instantiate(effect, transform.position, Quaternion.Euler(0, 0, 0)),1f);
                Destroy(gameObject);
            }
        }
    }
}
