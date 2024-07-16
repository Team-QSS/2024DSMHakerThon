using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhp : MonoBehaviour
{
    public float Playerhp;
    [SerializeField] private Slider playerhpveiw;

    public float CurrentPlayerhp=100;
    
    // Start is called before the first frame update
    void Start()
    {
        playerhpveiw.value = Playerhp;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.U))
        {
            StopAllCoroutines();
            SmallHpDamage();
        }

    }

    void SmallHpDamage()
    {
        Playerhp -= 40;
        StartCoroutine(ChangeHealth(Playerhp));
    }

    IEnumerator ChangeHealth(float health)
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            playerhpveiw.value = Mathf.Lerp(playerhpveiw.value, health, 2 * Time.deltaTime);
            yield return null;
        }

        playerhpveiw.value = health;
    }


    
}
