using player.script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    public int maxHp;
    public float curHp;
    public bool isAttacking;
    public bool isStun;
    public float stunTime;
    protected Animator stunAni;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 0;
        curHp = 0;
        stunTime = 0;
        isAttacking = false;
        isStun = false;
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
            Debug.Log(3);
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("die");
            SceneManager.LoadScene("YouDied");
        }
    }
}
