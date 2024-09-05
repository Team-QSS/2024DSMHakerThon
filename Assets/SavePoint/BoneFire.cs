
using System.Collections;
using player.script;
using SaveAndLoad;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SavePoint
{
    public class BoneFire : MonoBehaviour
    {
        private Animator _ani;
        private Light2D _light2D;
        private ParticleSystem _prt;
        private Vector2 _playerLocation;
        private Vector2 location;

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
            location = gameObject.transform.position;
            if (SaveData.playerStatus.boneFireLocation == location)
            {
                ActivedBoneFire();
            }
        }
        
        public IEnumerator BoneFireFlow()
        {
            PlayerMove.canmove = false;
            PlayerInteraction.isInteracting = true;
            SaveData.SaveScene();
            SaveData.playerStatus.lastLocation = PlayerMove.playerPos;
            SaveData.playerStatus.boneFireLocation = location;
            SaveData.SaveToJson();
            yield return new WaitForSeconds(1f);
            _prt.Play();
            yield return new WaitForSeconds(1.2f);
            _light2D.enabled = true;
            _ani.SetBool("lit",true);
            PlayerInteraction.isInteracting = false;
            PlayerMove.canmove = true;
        }

        private void ActivedBoneFire()
        {
            _prt.Play();
            _light2D.enabled = true;
            _ani.SetBool("lit",true);
        }
    }
}
