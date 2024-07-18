using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathApear : MonoBehaviour
{
    [SerializeField] private GameObject deathApaer;

    void Start()
    {
        deathApaer.SetActive(true);

    }

    // Update is called once per frame
}
