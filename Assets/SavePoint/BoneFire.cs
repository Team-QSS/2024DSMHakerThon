using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator BoneFireFlow(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
