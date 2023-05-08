using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{
    public GameObject golemObj;

    //Stats
    public float speed= 2.5f;
    private int life= 30;

    //Attack Explosion
    private float attackRange= 2.5f;
    private float nextAbility;
    private float cooldownAbility= 12f;

    private bool casting=false;

    public GameObject  attackBust;

    //Attack AssaultJump 

    public GameObject playerRay;

    //Golem Components
    public Transform player;
    public Transform golem;
    public Transform golemGFX;
    public Rigidbody2D rb2d;
    public Transform wallCheck;
    public LayerMask wallLayer;

    public bool checkwall = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        patrolEnemy();
        burstAbility();
    }

    void patrolEnemy()
    {
    
        if(!isCasting()){
            Vector2 directionTranslation = (checkwall) ? transform.right : -transform.right;
            directionTranslation *= Time.deltaTime * speed;
            transform.Translate(directionTranslation);
        }


        if(Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer)){
            Vector3 currentScale = rb2d.transform.localScale;
            currentScale.x *= -1;
            rb2d.transform.localScale=currentScale;

            checkwall=!checkwall;
        }
    }

    bool isCasting(){
        if(casting == true){
            return true;
        }else if(casting ==false){
            return false;
        }
        return false;
    }

    bool cooldownCalc(float cooldownAbility)
    {
        
        if(Time.time>nextAbility)
        {
            nextAbility=Time.time+cooldownAbility;            
            return true;

        }else{
            return false;
        }
        
    }

    void burstAbility()
    {
        //Detecta el el jugador si esta dins del rang
        if(attackRange>Vector2.Distance(player.position,golem.position) && cooldownCalc(cooldownAbility)){
            attackBust.SetActive(true);
            casting=true;

        }else{
            attackBust.SetActive(false);
            casting=false;
        }
    }
    
    void assaultAbility(){

        if(burstAbility(15f)&& playerCheck()){
            speed=20;
        }

    }

    bool playerCheck(){
        return true;
    }
}
