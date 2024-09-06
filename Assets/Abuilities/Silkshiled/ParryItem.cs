using System;
using System.Collections;
using System.Collections.Generic;
using Abuilities;
using player.script;
using SaveAndLoad;
using UnityEngine;

class ParryItem : AbilityItemProto
{
    protected override void SetAbil()
    {
        PlayerMove.canmove = false;
        SaveData.SetAbilities("parry");
    }
}
