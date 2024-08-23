using System.Collections;
using UnityEngine;

namespace SavePoint
{
    public class BoneFire : MonoBehaviour
    {
        private static Animator ani;
        // Start is called before the first frame update
        void Start()
        {
            ani = GetComponent<Animator>();
        }
        

        // Update is called once per frame
        public static IEnumerator BoneFireFlow(float sec)
        {
            Debug.Log("lit");
            ani.SetBool("lit",true);
            yield return new WaitForSeconds(sec);
        }
    }
}
