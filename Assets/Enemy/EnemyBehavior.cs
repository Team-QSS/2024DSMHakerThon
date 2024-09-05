using System.Collections;
using Managers;
using player.script;
using SaveAndLoad;
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
    protected bool cleared;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 0;
        curHp = 0;
        stunTime = 0;
        isAttacking = false;
        isStun = false;
        isDamaged = false;
        cleared = false;
    }
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&isAttacking&&Parry.isParrying)
        {
            isStun = true;
            AudioManager.PlaySoundInstance("Audio/PARRY_SUCCESS");
            stunAni.SetTrigger("isstun");


        }
        else if (other.CompareTag("Player")) SceneManager.LoadScene("YouDied");
    }

    protected IEnumerator BossGetDamage(float infinity)
    {
        isDamaged = true;
        curHp--;
        bossSlider=GameObject.FindWithTag("bossHp").GetComponent<Slider>();
        bossSlider.value = curHp;
        if (curHp<=0)
        {
            SaveData.SavePreviousScene();
            cleared = true;

        }
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
