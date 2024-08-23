using System.Collections;
using player.script;
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
            PlayerInteraction.isInteracting = true;
            Debug.Log("lit");
            yield return new WaitForSeconds(sec);
            ani.SetBool("lit",true);
            PlayerInteraction.isInteracting = false;

        }
    }
}
