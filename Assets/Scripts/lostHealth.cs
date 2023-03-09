using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lostHealth : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        mainController controller = other.GetComponent<mainController>();

        if (controller != null)
        {
            controller.ChangeHealth();
        }
    }
}