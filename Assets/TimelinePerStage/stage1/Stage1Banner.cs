using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Banner : MonoBehaviour
{    [SerializeField] private GameObject canVas;
    // Start is called before the first frame update
    void Start()
    {
        canVas.SetActive(true);
    }
    
}
