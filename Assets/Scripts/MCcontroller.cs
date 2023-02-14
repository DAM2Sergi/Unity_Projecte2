using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCcontroller : MonoBehaviour
{

    //player movement settings
    public float speed = 2.0f;
    public float jump = 10f;

    Rigidbody2D rigidbodyplayer;

    // Start is called before the first frame update
    void Start()
    {

        rigidbodyplayer = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbodyplayer.Addforce(Vector2.up * jump, ForceMode2D.Impulse);
        }


        Vector2 position= rigidbodyplayer.position;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbodyplayer.MovePosition(position);

    }
}