using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject player;
    [SerializeField]
    ParticleSystem effectWarp;
    public static CameraController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayerAnimController.DeathEventBackward.AddListener(MakeVibro);
        StackContainer.FailedEvent.AddListener(CameraPosUpdate);
        StackContainer.SuccessEvent.AddListener(CameraPosUpdate);

        PlayerAnimController.DeathEventBackward.AddListener(PauseView);
        PlayerAnimController.DeathEventForward.AddListener(PauseView);
    }

    public void CameraPosUpdate()
    {
       
            Vector3 pos = player.transform.position;
            pos.z = -20;
            pos.x = pos.x + 5;
            pos.y = pos.y + 10;
            transform.DOMove(pos, speed);
    }
    void PauseView() 
    {

        transform.DOMove(new Vector3(8,12,-15), speed);
        transform.DORotate(new Vector3(30, -28, 0), speed);
        effectWarp.Stop();
    }
    void MakeVibro() 
    {
        Handheld.Vibrate();
    }
}
