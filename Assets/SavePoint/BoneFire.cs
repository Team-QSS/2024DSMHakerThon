using System.Collections;
using player.script;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SavePoint
{
    public class BoneFire : MonoBehaviour
    {
        private static Animator _ani;
        private static Light2D _light2D;
        private static ParticleSystem _prt;
        
        // Start is called before the first frame update
        private void Start()
        {
            _light2D = GetComponentInChildren<Light2D>();
            _prt = GetComponentInChildren<ParticleSystem>();
            _ani = GetComponent<Animator>();
            _light2D.enabled = false;
            _prt.Stop();
        }
        

        // Update is called once per frame
        public static IEnumerator BoneFireFlow(float sec)
        {
            PlayerInteraction.isInteracting = true;
            Debug.Log("lit");
            yield return new WaitForSeconds(1f);
            _prt.Play();
            yield return new WaitForSeconds(1.2f);
            _light2D.enabled = true;
            _ani.SetBool("lit",true);
            PlayerInteraction.isInteracting = false;

        }
    }
}
