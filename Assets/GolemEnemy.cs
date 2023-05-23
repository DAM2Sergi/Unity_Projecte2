using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{
    public GameObject golemObj;

    //Stats
    public float speed= 2.5f;
    private float life= 30;

    //Attack Explosion
    public GameObject  attackBust;

    private float attackRange= 1f;
    private float nextAbility;
    private float cooldownAbility = 20f;

    //Attack AssaultJump 
    

    //Golem Components
    public Transform player;
    public Transform golem;
    public Transform golemGFX;
    public Rigidbody2D rb2d;
    public Transform wallCheck;
    public LayerMask wallLayer;
    public LayerMask playerLayer;

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
    
        Vector2 directionTranslation = (checkwall) ? transform.right : -transform.right;
        directionTranslation *= Time.deltaTime * speed;
        transform.Translate(directionTranslation);



        if(Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer)){
            Vector3 currentScale = rb2d.transform.localScale;
            currentScale.x *= -1;
            rb2d.transform.localScale=currentScale;

            checkwall=!checkwall;
        }
    }

    void burstAbility()
    {
        if (Time.time >= nextAbility + cooldownAbility) {
            //Detecta el el jugador si esta dins del rang
            if(attackRange>Vector2.Distance(player.position,golem.position)){
                nextAbility = Time.time;
                startBurst();
                Invoke("endBurst", 2f);
            }
        } else {
        }

    }
    void startBurst(){
        attackBust.SetActive(true);
    }
    void endBurst(){
        attackBust.SetActive(false);
    }
    
    void OnCollisionEnter2D(Collision2D mainColider)
    {
        hurt();
    }

    void hurt(){

        life=life - 3f ;
        Debug.Log(life);

        if(!(life > 0f)){

            Destroy(gameObject);
               
        }
    }
}
