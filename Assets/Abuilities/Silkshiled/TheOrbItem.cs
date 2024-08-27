
using UnityEngine;

public class TheOrb : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles += new Vector3(0f,0f,100f*Time.deltaTime);
    }
}
