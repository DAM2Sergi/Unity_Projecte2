using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{

    public float speed= 2.5f;
    private int life= 30;
    private float attackRange= 2.5f;
    private float burstcooldown= 10f;


    public GameObject golemObj;
    public GameObject  attackBust;

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

        Vector2 directionTranslation = (checkwall) ? transform.right : -transform.right; 
        directionTranslation *= Time.deltaTime * speed;
        transform.Translate(directionTranslation);
        
        patrolEnemy();

        useAbility();
    }
    void patrolEnemy()
    {
        if(Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer)){
            Vector3 currentScale = rb2d.transform.localScale;
            currentScale.x *= -1;
            rb2d.transform.localScale=currentScale;

            checkwall=!checkwall;
        }
    }

    void useAbility()
    {
        //detecta el el jugador si esta dins del rang
        if(attackRange>Vector2.Distance(player.position,golem.position)){
            attackBust.SetActive(true);

        }else{
            attackBust.SetActive(false);
        }
    }
}
