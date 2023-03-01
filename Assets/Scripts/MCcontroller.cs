using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MCcontroller : MonoBehaviour
{

    //Player movement settings
    private float horizontal;
    public float speed = 8.0f;
    public float jump = 18f;

    //Lives
    public int lives = 3;

    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        horizontal = Input.GetAxisRaw("Horizontal");//La funcio getAxisRaw canvia el valor de moviment de 0 a -1 de manera directa no gradual
        

        if (Input.GetButtonDown("Jump") && IsGounded())
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jump);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    private bool IsGounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(horizontal * speed, rbPlayer.velocity.y);
    }




}