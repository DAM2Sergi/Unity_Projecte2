using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsInstance : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        MCcontroller controller = other.GetComponent<MCcontroller>();

        if (controller != null)
        {
            Destroy(gameObject);
        }

        ScoreManager.instance.AddPoint();
    }
}
