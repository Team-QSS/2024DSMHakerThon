using System.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace player.script
{
    public class Parry : MonoBehaviour
    {
        private Animator ani;
        private GameObject rotateCore;
        private void Start()
        {
            ani = GetComponent<Animator>();
            rotateCore = GameObject.Find("rotatecore").gameObject;
            rotateCore.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ani.SetTrigger("parry");
            }
        }

        public void StartAni()
        {
            rotateCore.SetActive(true);
        }

        public void EndAni()
        {
            rotateCore.SetActive(false);
        }
    }
}
