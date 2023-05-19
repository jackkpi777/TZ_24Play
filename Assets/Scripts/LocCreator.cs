using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LocCreator : MonoBehaviour
{
    [SerializeField]
    public List <Transform> blocksOnScene;
    public GameObject[] blocksLibrary;
    public int maxQuantity = 5;
    Vector3 distToAdd;
    bool isPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimController.DeathEventBackward.AddListener(() => GamePaused(true));
        PlayerAnimController.DeathEventForward.AddListener(() => GamePaused(true));
        distToAdd = new Vector3(0, 0, transform.GetChild(0).gameObject.transform.GetChild(0).localScale.z);
        
        for (int i = 0; i < maxQuantity; i++)
        {
            blocksOnScene.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    public void GamePaused(bool pause)
    {
        foreach (var item in blocksOnScene)
        {
            item.GetComponent<LocBlock>().isPaused = pause;
        }
    }
    public void SpawnBlock()
    {
        Debug.Log("SpawnNewBlock");
        GameObject blockClone =  Instantiate(blocksLibrary[0], transform.GetChild(maxQuantity-1).position + distToAdd+new Vector3(0,-20,0), Quaternion.identity,gameObject.transform);
        blocksOnScene.Add(blockClone.transform);
        blockClone.GetComponent<LocBlock>().isPaused = false;
        blockClone.transform.DOMoveY(-0.5f, 1);
    }
}
