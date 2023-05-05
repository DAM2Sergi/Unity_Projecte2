using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{

    public float speed= 2.5f;
    private int life= 30;
    private float range= 15f;



    public Transform player;
    public Transform golem;
    public Transform golemGFX;
    public Rigidbody2D rb2d;
    public Transform wallCheck;
    public LayerMask wallLayer;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //detecta el el jugador si esta dins del rang
        if(range>Vector2.Distance(player.position,golem.position)){
            


        }else{
            life=30;
        }

        
    }
    void FixedUpdate()
    {
        if(Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer)){

            

        }

    }

    void flipEnemy(){//Falta ficar-ho a el obj de grafic
        if (rb2d.velocity.x >= Mathf.Epsilon)
        {

            golemGFX.localScale = new Vector3(8f, 8f, 1f);

        }
        else if (rb2d.velocity.x <= -Mathf.Epsilon)
        {

            golemGFX.localScale = new Vector3(-8f, 8f, 1f);

        };
    }

}
