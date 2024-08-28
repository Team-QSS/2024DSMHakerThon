using System.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace player.script
{
    
    public class Parry : MonoBehaviour
    {
        public static bool unlockParry;
        public static bool isParrying;
        private Animator ani;
        private GameObject rotateCore;
        private void Start()
        {
            ani = GetComponent<Animator>();
            rotateCore = GameObject.Find("rotatecore").gameObject;
            rotateCore.SetActive(false);
            isParrying = false;
            SaveData.GetAbilities();
        }

        private void Update()
        {
            if (unlockParry&&Input.GetMouseButtonDown(0)&&!isParrying)
            {
                ani.SetTrigger("parry");
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
