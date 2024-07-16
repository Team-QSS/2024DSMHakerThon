using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private playermove playerMove;

    private void Start()
    {
        playerMove = Player.GetComponent<playermove>();
    }
    

    public void NockBack(Vector3 enemyPos,float power,float time)
    {
   
        if (gameObject.transform.position.x - enemyPos.x < 0)
        {
            playerMove.isstuned = true;    
            playerMove.NockLeft(power);
            StartCoroutine(NockBackFlow(time));

        }
        else
        {
            playerMove.isstuned = true;
            playerMove.NockRight(power);
            StartCoroutine(NockBackFlow(time));
        }
        
    }

    IEnumerator NockBackFlow(float time)
    {
        yield return new WaitForSeconds(time);
        playerMove.isstuned = false;
    }
    
}
