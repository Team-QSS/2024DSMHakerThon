
using System;
using Abuilities;
using player.script;
using SaveAndLoad;
using UnityEngine;

public class TheOrb : MonoBehaviour
{
    private GameObject parentObj;
    private AbilityItemProto abilityItem;
    private Rigidbody2D rb;
    [SerializeField] private GameObject descriptionText;
    [SerializeField] private string ability;
    private void Start()
    {
        parentObj = transform.parent.gameObject;
        abilityItem = parentObj.GetComponent<AbilityItemProto>();
        rb = GetComponent<Rigidbody2D>();
        if (!SaveData.HasAbilities(ability)) return;
        descriptionText.SetActive(false);
        Destroy(parentObj);
    }

    private void Update()
    {
        transform.eulerAngles += new Vector3(0f, 0f, 30f * Time.deltaTime);
        if (!abilityItem.consume) return;
        var force = PlayerMove.playerPos - rb.position;
        var rot = new Quaternion(force.x, force.y, 0, force.magnitude).eulerAngles;
        rot.z -= 160f;
        var qt = Quaternion.Euler(rot);
        rb.velocity = new Vector2(qt.x, qt.y) * (force.magnitude * 15);
        if ((PlayerMove.playerPos - rb.position).magnitude >= 0.5f) return;
        PlayerMove.canmove = true;
        Destroy(parentObj);
    }
}
