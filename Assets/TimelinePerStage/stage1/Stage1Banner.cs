using UnityEngine;

namespace TimelinePerStage.stage1
{
    public class Stage1Banner : MonoBehaviour
    {
        [SerializeField] private GameObject canVas;

        private void Start()
        {
            canVas.SetActive(true);
        }
    }
}
