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
        private static readonly int IsBiting = Animator.StringToHash("isbiting");

        // Update is called once per frame
        private void Update()
        {
            newPosX= new Vector3(target.transform.position.x,1.97f, 0);
            
            if (behavior > 890)
            {
                if (Mathf.Abs(gameObject.transform.position.x - newPosX.x) < 19)
                {
                    crowAnim.SetTrigger(IsBiting);
                    gameObject.transform.position =
                        Vector3.MoveTowards(gameObject.transform.position, newPosX, 8*Time.deltaTime);
                }

            }
            else
            {
                if (Mathf.Abs(gameObject.transform.position.x - newPosX.x) > 18)
                {
                    moveSpeed = 40f;
                }
                else if(Mathf.Abs(gameObject.transform.position.x - newPosX.x) > 20)
                {
                    moveSpeed = 100f;
                }
                else
                {
                    moveSpeed = Random.Range(5, 13);
                }

                gameObject.transform.position =
                    Vector3.MoveTowards(gameObject.transform.position, newPosX, moveSpeed*Time.deltaTime);
            }
        }
    }
}
