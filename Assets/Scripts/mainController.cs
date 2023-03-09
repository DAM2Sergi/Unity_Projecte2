using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainController : MonoBehaviour
{

    //Player movement settings
    private float horizontal;
    public float speed = 8.0f;
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


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void FixedUpdate()
    {
        rbPlayer.velocity = new Vector2(horizontal * speed, rbPlayer.velocity.y);
    }




}