using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Stage1TimeLine : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ceneMachine;
    [SerializeField] private GameObject canVas;
    // Start is called before the first frame update
    void Start()
    {
        ceneMachine.Priority = 1;
        canVas.SetActive(false);
    }



    
        
    
    
    
}
