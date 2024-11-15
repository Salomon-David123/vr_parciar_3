using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUERTA : MonoBehaviour
{
    Rigidbody rb;
    GameObject OBj;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MAR"))
        {
            rb.isKinematic = false;
            timeforDeath();
            Destroy(OBj );
            

        }


    }
      public IEnumerator timeforDeath()
    {
        yield return new WaitForSeconds(2f);
        
    }
}
