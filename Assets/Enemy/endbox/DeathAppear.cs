using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy.endbox
{
    public class DeathAppear : MonoBehaviour
    {
        [FormerlySerializedAs("deathApaer")] [SerializeField] private GameObject deathAppaer;

        void Start()
        {
            deathAppaer.SetActive(true);

        }

        // Update is called once per frame
    }
}
