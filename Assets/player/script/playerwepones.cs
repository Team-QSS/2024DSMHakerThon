using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerwepones : MonoBehaviour
{
    public GameObject[] wepones;
    //private List<GameObject> glist = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        wepones[0].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
