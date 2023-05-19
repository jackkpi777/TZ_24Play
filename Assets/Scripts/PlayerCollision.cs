using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 6 && collision.gameObject.GetComponent<StackContainer>() == null)
        {
            PlayerAnimController.DeathEventBackward.Invoke();
        }
    }
}
