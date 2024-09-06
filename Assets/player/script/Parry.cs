using System.Data;
using Managers;
using SaveAndLoad;
using Unity.VisualScripting;
using UnityEngine;

namespace player.script
{
    
    public class Parry : MonoBehaviour
    {
        public static bool isParrying;
        private Animator ani;
        private GameObject rotateCore;
        private void Start()
        {
            ani = GetComponent<Animator>();
            rotateCore = GameObject.Find("rotatecore").gameObject;
            rotateCore.SetActive(false);
            isParrying = false;
            SaveData.LoadFromJson();
        }

        private void Update()
        {
            if (SaveData.HasAbilities("parry")&&Input.GetMouseButtonDown(0)&&!isParrying&&PlayerMove.canmove)
            {
                ani.SetTrigger("parry");
                //AudioManager.PlaySoundInstance("Audio/Dash");
                AudioManager.PlaySoundInstance("Audio/PARRY_PROCESS");
            }
        }

        public void StartAni()
        {
            rotateCore.SetActive(true);
            isParrying = true;
        }

        public void EndAni()
        {
            isParrying = false;
            rotateCore.SetActive(false);
        }
    }
}
