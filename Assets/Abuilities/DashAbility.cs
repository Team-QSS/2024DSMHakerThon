using player.script;
using SaveAndLoad;

namespace Abuilities
{
    public class DashAbility : AbilityItemProto
    {
        protected override void SetAbil()
        {
            PlayerMove.canmove = false;
            SaveData.SetAbilities("dash");
        }
    }
}
