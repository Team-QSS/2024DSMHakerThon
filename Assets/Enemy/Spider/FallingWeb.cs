using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.Spider
{
    public class FallingWeb : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("wall"))
            {
                Destroy(gameObject);
            }
            if(collision.CompareTag("Barrier"))
            {
                Destroy(gameObject);
            }
        }
    }
}
