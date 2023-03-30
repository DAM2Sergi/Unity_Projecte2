using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnKill : MonoBehaviour
{
    public GameObject player; //Obj jugador
    public GameObject respawnPoint; //Obj el ultim punt de respawn
    [SerializeField] Collider2D colider; //Colider de fi de mapa
    
    private void OnTriggerEnter2D(Collider2D colider)
    {
        mainController controller = colider.GetComponent<mainController>();

        if (colider.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            controller.health--;
        }
    }
}
