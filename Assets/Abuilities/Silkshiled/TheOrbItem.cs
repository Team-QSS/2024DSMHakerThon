
using System;
using player.script;
using SaveAndLoad;
using UnityEngine;

public class TheOrb : MonoBehaviour
{
    private GameObject parentObj;
    [SerializeField] private GameObject descriptionText;

    private void Start()
    {
        parentObj = transform.parent.gameObject;
        if (Parry.unlockParry)
        {
            descriptionText.SetActive(false);
            Destroy(parentObj);
        }
    }

    private void Update()
    {
        transform.eulerAngles += new Vector3(0f,0f,30f*Time.deltaTime);
        if (!ParryItem.consume) return;
            transform.position = Vector2.MoveTowards(transform.position, PlayerMove.playerPos, 0.8f * Time.deltaTime);
            if (new Vector2(transform.position.x, transform.position.y) != PlayerMove.playerPos) return;
            PlayerMove.canmove = true;
            Destroy(parentObj);

    }
}
