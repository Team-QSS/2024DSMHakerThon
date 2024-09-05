using System;
using Abuilities;
using player.script;
using UnityEngine;

public class TineOrbItem : MonoBehaviour
{
    [SerializeField]
    private float rotationForce;

    private AbilityItemProto parentAbil;

    private void Start()
    {
        parentAbil = transform.parent.GetComponent<AbilityItemProto>();
    }

    private void Update()
    {
        //gameObject.transform.rotation = new Quaternion(20f, 0f, 0f,0f);
        if (!parentAbil.consume)
        {
            transform.eulerAngles += new Vector3(0f,0f,rotationForce*Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
