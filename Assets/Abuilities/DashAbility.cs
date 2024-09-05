using player.script;
using SaveAndLoad;

namespace Abuilities
{
    public class DashAbility : AbilityItemProto
    {
        protected override void SetAbil()
        {
            PlayerMove.canmove = false;
            PlayerMove.unlockDash = true;
            SaveData.SetAbilities("dash");
        }
    }
}
