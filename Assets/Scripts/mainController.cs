using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainController : MonoBehaviour
{

    //Player movement settings
    private float horizontal;
    public float speed = 8f;
    public float jump = 18f;

    //Lives
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearth;
    public Sprite emptyHeart;

    //Time of Invincible
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;


    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private SpriteRenderer PlayerGFX;
    [SerializeField] private Transform PlayerLocation;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;


    //Player Death/ Game Over
    public gameOverScreen overScreen;
    //Player Death/ Game Over
    public gamePauseScreen pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        PlayerGFX = GetComponent<SpriteRenderer>();
        PlayerLocation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        
        horizontal = Input.GetAxisRaw("Horizontal");//La funcio getAxisRaw canvia el valor de moviment de 0 a -1 de manera directa no gradual
        
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetBool("Ground", IsGounded());

        if (Input.GetButtonDown("Jump") && IsGounded())
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jump);
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pauseScreen.Setup();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            pauseScreen.unSetup();
            
        }


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)isInvincible = false;
        }

        


        Health();

    }

    public void Health()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {

                hearts[i].sprite = fullHearth;

            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }

        if (health == 0)
        {
            Debug.Log("mort");
            speed=0;
            overScreen.Setup();
        }

    }

    public void ChangeHealth()
    {
        int damage = -1;
        if (damage < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        health = Mathf.Clamp(health - 1, 0, numOfHearts);
    }

    private bool IsGounded()
    {
        bool isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        return isGround;
    }


    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(horizontal * speed, rbPlayer.velocity.y);
        flipPlayer();
        
    }

    private void flipPlayer(){
        if (rbPlayer.velocity.x >= Mathf.Epsilon)
        {

            PlayerLocation.localScale = new Vector3(1.2f, 1.4f, 1f);
            //Que es Mathf.Epsilon?
            //El numero mes petit float diferent a zero 

        }
        else if (rbPlayer.velocity.x <= -Mathf.Epsilon)
        {

            PlayerLocation.localScale = new Vector3(-1.2f, 1.4f, 1f);

        };
    }


}