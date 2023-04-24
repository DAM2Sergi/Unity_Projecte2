using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemEnemy : MonoBehaviour
{
    // Start is called before the first frame update


    Ray ray;




    void Start()
    {
        ray= new Ray(transform.position, transform.forward);
        
    }



    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject.name+"li ha diant un raycast");
        }
    }
}
