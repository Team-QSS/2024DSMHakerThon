using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace TimelinePerStage.stage1
{
    public class Stage1TimeLine : MonoBehaviour
    {
        [FormerlySerializedAs("ceneMachine")] [SerializeField] private CinemachineVirtualCamera cineMachine;
        [SerializeField] private GameObject canVas;

        private void Start()
        {
            cineMachine.Priority = 1;
            canVas.SetActive(false);
        }
    }
}
