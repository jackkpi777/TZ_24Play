using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.Events;

public class StackContainer : MonoBehaviour
{
    public List<GameObject> collection;
    public static int stat;
    public Ease easeMain;
    public Ease easeobjects;
    [SerializeField]
    GameObject effetTrail;
    GameObject effectClone;
    public static UnityEvent SuccessEvent = new UnityEvent();
    public static UnityEvent FailedEvent = new UnityEvent();
    void Start()
    {
        stat = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public async void ChangeCollection(GameObject obj, bool pickup_destroy)
    {
        if (pickup_destroy)
        {
            stat++;
            SuccessEvent.Invoke();
            obj.transform.DOShakeScale(0.2f, 0.5f, 5, 0);
            obj.transform.parent = transform;
            if (collection.Count != 0)
            {
                obj.transform.position = collection[collection.Count - 1].gameObject.transform.position + new Vector3(0, -1f, 0);
            }
            else
            {
                obj.transform.position = transform.position + new Vector3(0, -0.5f, 0);
            }
            collection.Add(obj);
        }
        else
        {
            stat--;
            if (stat <= 0)
            {
                Debug.Log("stat is 0");
                //PlayerAnimController.instance.MakeState(1);
                PlayerAnimController.DeathEventBackward.Invoke();
                return;
            }
            if (stat>0)
            {
                FailedEvent.Invoke();
                obj.transform.DOPunchScale(new Vector3(0.8f, 0.8f, 0.8f), 0.2f, 2, 0.5f);
                collection.Remove(obj);
                Task task = CheckConnection();
                await Task.WhenAll(task);
            }
            
        }
        MakeOwnMove();
    }
    
    async Task CheckConnection()
    {
        await Task.Delay(80);
        for (int i = 0; i < collection.Count; i++)
        {
            transform.GetChild(i).DOLocalMoveY(-(i + 0.5f), 0.1f).SetEase(easeobjects);
            Debug.Log("Made position for" + i);
            await Task.Yield();
        }
        //Destroy(effectClone);
        //effectClone = Instantiate(effetTrail,collection[collection.Count].transform.position-new Vector3(0,-0.5f,0),Quaternion.identity ,collection[collection.Count].transform);
    
    }
    void MakeOwnMove() 
    {
        Debug.Log("MakeOwnMove");
       
        transform.parent.DOMoveY(stat + 1, 0.5f).SetEase(easeMain);
        if (stat >= 1)
        {
            PlayerAnimController.instance.MakeState(2);
        }
        
    }
}

