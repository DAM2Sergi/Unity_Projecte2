using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    private SpriteRenderer sprite;
    public Animator animator;


    [SerializeField] private Rigidbody2D rbenemy;
    public Collider2D hurtBox;

    [SerializeField] private Transform fallCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
   
    

    public float speed = 3.0f;
    public bool checkwall = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rbenemy = GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        // if the ennemy is going right, get the vector pointing to its right
        Vector2 directionTranslation = (checkwall) ? transform.right : -transform.right; 
        directionTranslation *= Time.deltaTime * speed;

        transform.Translate(directionTranslation);

        animator.SetBool("Run", true);
        patrolEnemy();

    }

    private void patrolEnemy()
    {   

        if(Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer)){
            Vector3 currentScale = rbenemy.transform.localScale;
            currentScale.x *= -1;
            rbenemy.transform.localScale=currentScale;

            checkwall=!checkwall;
        }

        if(!(Physics2D.OverlapCircle(fallCheck.position, 0.2f, wallLayer)==null)){
            Vector3 currentScale = rbenemy.transform.localScale;
            currentScale.x *= -1;
            rbenemy.transform.localScale=currentScale;

            checkwall=!checkwall;
        }
    }




}
