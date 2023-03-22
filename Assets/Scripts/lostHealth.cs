using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lostHealth : MonoBehaviour
{

    [SerializeField] Collider2D colider;

    private void OnTriggerStay2D(Collider2D colider)
    {
        mainController controller = colider.GetComponent<mainController>();

        if (controller != null)
        {
            controller.ChangeHealth();
        }
        
    }
}