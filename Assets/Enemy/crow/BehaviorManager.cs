using Enemy.crow.script;
using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    public void EndOfPattern()
    {
        TheCrow.behavior = Random.Range(0, 1000);
    }
}
