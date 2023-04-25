using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{


    public GameObject raycast;

    Rigidbody2D rb2D;


    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

    }


    void FixedUpdate()
    {
        if(CheckPlayer()){
            
        }

    }

    bool CheckPlayer(){
        RaycastHit2D hit = Physics2D.Raycast(raycast.transform.position, new Vector3(1,0,0), LayerMask.GetMask("Player"), 20);

        if (hit.collider != null){
            return true;
        }else{
             return false;
        }
    }


}
