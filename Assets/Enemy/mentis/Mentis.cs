using System.Collections;
using System.Collections.Generic;
using player.script;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Mentis : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 newPosX;
    [SerializeField] private Animator mentisAnim;
    private PlayerMove playerMove;
    [SerializeField] private GameObject attackrange;
    private bool iswalking;
    private bool isattacking;
    private bool isidling;
    public LayerMask playerCheck;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = target.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        newPosX= new Vector3(target.transform.position.x,-0.2f, 0);
        if (Physics2D.OverlapCircle(attackrange.transform.position, 0.7f, playerCheck))
        {
            mentisAnim.SetBool("isidling",false);
            mentisAnim.SetBool("iswalking",false);    
            mentisAnim.SetTrigger("isattacking");
        }
        else
        { 
            if (target.transform.position.x > gameObject.transform.position.x){                                      
                                                                                                                          
            var scale = gameObject.transform.localScale;                                                               
            scale.x = 1f;                                                                                              
            gameObject.transform.localScale = scale;                                                                   
            if (playerMove.isFacingRight)                                                                              
            {                                                                                                          
                gameObject.transform.position =                                                                        
                    Vector3.MoveTowards(gameObject.transform.position, newPosX, 2*Time.deltaTime);                     
                mentisAnim.SetBool("isidling",false);                                                                  
                mentisAnim.SetBool("iswalking",true);                                                                  
            }                                                                                                          
            else                                                                                                       
            {                                                                                                          
                mentisAnim.SetBool("isidling",true);                                                                   
                mentisAnim.SetBool("iswalking",false);                                                                 
            }                                                                                                          
        }                                                                                                              
        else                                                                                                           
        {                                                                                                              
            var scale = gameObject.transform.localScale;                                                               
            scale.x = -1f;                                                                                             
            gameObject.transform.localScale = scale;                                                                   
            if (!playerMove.isFacingRight)                                                                             
            {                                                                                                          
                gameObject.transform.position =                                                                        
                    Vector3.MoveTowards(gameObject.transform.position, newPosX, 2*Time.deltaTime);                     
                mentisAnim.SetBool("isidling",false);                                                                  
                mentisAnim.SetBool("iswalking",true);                                                                  
                mentisAnim.SetBool("isattacking",false);                                                               
            }
            else
            {
                mentisAnim.SetBool("isidling", true);
                mentisAnim.SetBool("iswalking", false);
                mentisAnim.SetBool("isattacking", false);
            }
        }
                                                             

        }
   
    }
    
}
