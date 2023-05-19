using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    
    //float sensitivity;
    
    
    Vector2 delta2;

    [SerializeField]
    float minBorder=-6.5f;
    [SerializeField]
    float maxBorder = 6.5f;
    Vector3 startPos, endPos;
    public bool isPaused =true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimController.DeathEventBackward.AddListener(()=>InputPause(true));
        PlayerAnimController.DeathEventForward.AddListener(() => InputPause(true));
    }

    // Update is called once per frame
    void Update()
    {


    }
    public async void ChangeLine(float delta)
    {

        CameraController.instance.CameraPosUpdate();

        float speedDump = speed + Mathf.Abs(delta);
        delta = Mathf.Clamp(transform.position.x + (delta), minBorder, maxBorder);
        delta2.x = delta;
        transform.position = Vector3.Lerp(transform.position, new Vector3(delta, 1, 0), speedDump * Time.deltaTime);

        await Task.Yield();

    }

    public void InputPause(bool pause) 
    {
        isPaused = pause;
    }

    }

