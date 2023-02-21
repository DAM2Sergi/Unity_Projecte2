using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovent : MonoBehaviour
{

    [SerializeField] float speed = 1f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(IsFacing()){
            rb.velocity= new Vector2(speed,0f);
        }else{
            rb.velocity= new Vector2(-speed,0f);
        }
    }

    private bool IsFacing(){
        return transform.localScale.x >Mathf.Epsilon;
                                    //Epsilon = 0.0001f
    }

    
    private void OnTriggerExit2D(Collider2D collision) {
        transform.localScale = new Vector2(-Mathf.Sign(rb.velocity.x),transform.localScale.y);
                                            //Sign = 1 o -1 perfecte per a girar el nostre sprite
    }



}
