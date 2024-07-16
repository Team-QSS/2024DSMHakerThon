using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.crow.script
{
    public class TheCrow : MonoBehaviour
    {
        private float moveSpeed;
        [SerializeField] private GameObject target;
        private Vector3 newPosX;
        [SerializeField] private Animator crowAnim;
        public static float behavior;

        // Update is called once per frame
        private void Update()
        {
            newPosX= new Vector3(target.transform.position.x,1.97f, 0);
            if (behavior > 890)
            {
                crowAnim.SetTrigger("isbiting");
                gameObject.transform.position =
                    Vector3.MoveTowards(gameObject.transform.position, newPosX, 4*Time.deltaTime);
            }
            else
            {
                moveSpeed = Random.Range(4, 10);
                gameObject.transform.position =
                    Vector3.MoveTowards(gameObject.transform.position, newPosX, moveSpeed*Time.deltaTime);
            }
        }
    }
}
