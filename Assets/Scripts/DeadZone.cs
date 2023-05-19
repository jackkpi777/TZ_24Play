using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    LocCreator locCreator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LocBlock>()!=null) 
        {
            Destroy(other.gameObject);
            locCreator.blocksOnScene.RemoveAt(0);
            locCreator.SpawnBlock();
        }
      
    }
}
