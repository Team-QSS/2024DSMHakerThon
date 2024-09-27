using UnityEngine;

namespace Abilities.OrbItem
{
    public class TineOrbItem : MonoBehaviour
    {
        [SerializeField]
        private float rotationForce;

        private ConsumableItem parentAbility;

        private void Start()
        {
            parentAbility = transform.parent.GetComponent<ConsumableItem>();
        }

        private void Update()
        {
            //gameObject.transform.rotation = new Quaternion(20f, 0f, 0f,0f);
            if (!parentAbility.Consume)
            {
                transform.eulerAngles += new Vector3(0f,0f,rotationForce*Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
