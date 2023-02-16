using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCcontroller : MonoBehaviour
{

    //Player movement settings
    private float horizontal;

    public float speed = 8.0f;
    public float jump = 18f;

    private Rigidbody2D rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        horizontal = Input.GetAxisRaw("Horizontal");//La funcio getAxisRaw canvia el valor de moviment de 0 a -1 de manera directa no gradual


        if (Input.GetButtonDown("Jump"))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jump);
        }


    }

    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(horizontal * speed, rbPlayer.velocity.y);
    }




}