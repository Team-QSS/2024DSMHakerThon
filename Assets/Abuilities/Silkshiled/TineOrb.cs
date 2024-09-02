using player.script;
using UnityEngine;

public class TineOrbItem : MonoBehaviour
{
    [SerializeField]
    private float rotationForce;
    
    
    private void Update()
    {
        //gameObject.transform.rotation = new Quaternion(20f, 0f, 0f,0f);
        if (!ParryItem.consume)
        {
            transform.eulerAngles += new Vector3(0f,0f,rotationForce*Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
