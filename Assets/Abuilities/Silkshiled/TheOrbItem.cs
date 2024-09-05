
using System;
using Abuilities;
using player.script;
using SaveAndLoad;
using UnityEngine;

public class TheOrb : MonoBehaviour
{
    private GameObject parentObj;
    private AbilityItemProto abilityItem;
    [SerializeField] private GameObject descriptionText;

    private void Start()
    {
        parentObj = transform.parent.gameObject;
        abilityItem = parentObj.GetComponent<AbilityItemProto>();
        if (Parry.unlockParry)
        {
            descriptionText.SetActive(false);
            Destroy(parentObj);
        }
    }

    private void Update()
    {
        transform.eulerAngles += new Vector3(0f,0f,30f*Time.deltaTime);
        if (!abilityItem.consume) return;
            transform.position = Vector2.MoveTowards(transform.position, PlayerMove.playerPos, 0.8f * Time.deltaTime);
            if (new Vector2(transform.position.x, transform.position.y) != PlayerMove.playerPos) return;
            PlayerMove.canmove = true;
            Destroy(parentObj);

    }
}
