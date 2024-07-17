using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SilkGaugeChange : MonoBehaviour
{
    
    public Sprite usedSilk;
    private Image chargedSilk;
    // Start is called before the first frame update
    void Start()
    {
        chargedSilk = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ChangeImg()
    {
        chargedSilk.sprite = usedSilk;
    }
}
