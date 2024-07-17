using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTimeline : MonoBehaviour
{
    [SerializeField] private GameObject canVas;
    [SerializeField] private GameObject timeLine;
    private void Start()
    {
        timeLine.SetActive(false);
    }

    public void TimeLineStart()
    {
        canVas.SetActive(false);
        timeLine.SetActive(true);
    }
}
