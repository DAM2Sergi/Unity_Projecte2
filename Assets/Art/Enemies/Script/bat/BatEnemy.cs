using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BatEnemy : MonoBehaviour
{


    public float health = 9f;

    GameObject mainController;

    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask palyerLayer;



    void Awake()
    {


        playerCheck = GetComponent<Transform>();
       
    }

    void Start()
    {
        mainController = GameObject.Find("mainController");
    }

    void OnCollisionEnter2D(Collision2D mainColider)
    {
        hurt();
    }

    void hurt(){

        health=health - 3f ;

        if(!(health > 0f)){

            Destroy(gameObject);
               
        }
    }




}
