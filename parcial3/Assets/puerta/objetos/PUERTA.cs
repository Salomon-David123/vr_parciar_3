using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUERTA : MonoBehaviour
{
    Rigidbody rb;

   
 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hacha"))
        {
            rb.isKinematic = false;
            
            Destroy(gameObject, 6f);



        }


    }

}
