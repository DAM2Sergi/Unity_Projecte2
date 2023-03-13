using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recoverHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        mainController controller = other.GetComponent<mainController>();

        if (controller != null)
        {
            Destroy(gameObject);
        }

        controller.health++;
    }
}
