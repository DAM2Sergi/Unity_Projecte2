using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsInstance : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        mainController controller = other.GetComponent<mainController>();

        if (controller != null)
        {
            Destroy(gameObject);
        }

        scoreManager.instance.AddPoint();
    }
}
