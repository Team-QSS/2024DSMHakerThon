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
        private static Parry _instance;
        private static readonly int Cancel1 = Animator.StringToHash("cancel");
        private Animator ani;
        private GameObject rotateCore;
        private void Start()
        {
            _instance = this;
            ani = GetComponent<Animator>();
            rotateCore = GameObject.Find("rotatecore").gameObject;
            rotateCore.SetActive(false);
            isParrying = false;
            SaveData.LoadFromJson();
        }

        private void Update()
        {
            if (!SaveData.HasAbilities("parry") || !Input.GetMouseButtonDown(0) || isParrying || !PlayerMove.canmove) return;
            ani.SetTrigger("parry");
            AudioManager.PlaySoundInstance("Audio/PARRY_PROCESS");
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
        public static void Cancel()
        {
            _instance.EndAni();
            _instance.ani.SetTrigger(Cancel1);
        }
    }
}
