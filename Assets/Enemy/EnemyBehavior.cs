using System.Collections;
using player.script;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public int maxHp;
    public float curHp;
    public bool isAttacking;
    public bool isStun;
    public float stunTime;
    public bool isDamaged;
    protected float inFiniteTime;
    protected string bossName;
    protected Animator stunAni;
    protected Slider bossSlider;
    protected TextMeshProUGUI bossTMP;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 0;
        curHp = 0;
        stunTime = 0;
        isAttacking = false;
        isStun = false;
        isDamaged = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&isAttacking&&Parry.isParrying)
        {
            isStun = true;
            stunAni.SetTrigger("isstun");


        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("die");
            SceneManager.LoadScene("YouDied");
        }
    }

    protected IEnumerator GetDamage(float infinity)
    {
        isDamaged = true;
        curHp--;
        bossSlider=GameObject.FindWithTag("bossHp").GetComponent<Slider>();
        bossSlider.value = curHp;
        yield return new WaitForSeconds(infinity);
        isDamaged = false;
    }

    protected void SetUpBoss()
    { 
       bossSlider=GameObject.FindWithTag("bossHp").GetComponent<Slider>();
       bossSlider.maxValue = maxHp;
       bossSlider.value = maxHp;
       bossTMP = GameObject.FindWithTag("bossName").GetComponent<TextMeshProUGUI>();
       bossTMP.text = bossName;
    }
}
