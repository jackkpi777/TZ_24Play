using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer==6 && collision.gameObject.GetComponent<StackContainer>()!=null) 
        {
            collision.gameObject.GetComponent<StackContainer>().ChangeCollection(gameObject, true);
            
        }
        if (collision.gameObject.layer == 6 && collision.gameObject.GetComponent<StackContainer>() == null)
        {
            StackContainer stack = gameObject.GetComponentInParent<StackContainer>();
            stack.ChangeCollection(gameObject, false);
            collision.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            transform.parent = collision.transform;
            //Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            //rb.isKinematic = false;
            //rb.useGravity = true;
        }

    }

    
}
