using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class flipenemy : MonoBehaviour
{

    public AIPath aiPath=null;

    // Update is called once per frame
    void Update()
    {

        if(aiPath.desiredVelocity.x > Mathf.Epsilon ){

            transform.localScale = new Vector3(4f,4f,1f);
            //Que es Mathf.Epsilon?¿
            //El numero mes petit float diferent a zero 

        }else if(aiPath.desiredVelocity.x < -Mathf.Epsilon ){

            transform.localScale = new Vector3(-4f,4f,1f);
            
        };
        
    }
}
