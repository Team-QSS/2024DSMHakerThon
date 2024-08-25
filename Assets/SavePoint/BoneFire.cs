
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
        private static Vector2 _playerLocation;
        private static Vector2 _location;

        private void Awake()
        {
            SaveData.LoadFromJson();
        }

        private void Start()
        {
            _light2D = GetComponentInChildren<Light2D>();
            _prt = GetComponentInChildren<ParticleSystem>();
            _ani = GetComponent<Animator>();
            _light2D.enabled = false;
            _prt.Stop();
            _location = gameObject.transform.position;
            if (SaveData.playerStatus.boneFireLocation == _location)
            {
                ActivedBoneFire();
            }
        }
        
        public static IEnumerator BoneFireFlow(float sec)
        {
            PlayerInteraction.isInteracting = true;
            SaveData.playerStatus.lastLocation = PlayerMove.playerPos;
            SaveData.playerStatus.boneFireLocation = _location;
            SaveData.SaveToJson();
            yield return new WaitForSeconds(1f);
            _prt.Play();
            yield return new WaitForSeconds(1.2f);
            _light2D.enabled = true;
            _ani.SetBool("lit",true);
            PlayerInteraction.isInteracting = false;

        }

        private void ActivedBoneFire()
        {
            _prt.Play();
            _light2D.enabled = true;
            _ani.SetBool("lit",true);
        }
    }
}
