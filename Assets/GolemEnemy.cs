using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{

    public float speed= 2.5f;
    public int life= 30;

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Transform enemyGFX;
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask wallLayer;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        

        patrolEnemy();
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        
    }

    private void patrolEnemy(){   

        if(Physics2D.OverlapCircle(wallCheck.position, 0.3f, wallLayer)){
            
            Vector3 currentScale = rb2d.transform.localScale;
            currentScale.x *= -1;
            rb2d.transform.localScale=currentScale;
        }

    }

}
