using Enemy.crow.script;
using UnityEngine;

namespace Enemy.crow
{
    public class BehaviorManager : MonoBehaviour
    {
        public void EndOfPattern()
        {
            TheCrow.behavior = Random.Range(0, 1000);
        }
    }
}
