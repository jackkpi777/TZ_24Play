using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LocBlock : MonoBehaviour
{
    public float speed = 10;
    public bool isPaused = true;
    [SerializeField]
    [Header("Randomizer")]
    bool createCubes = true;

    [SerializeField]
    GameObject[]variantsCubes;
    // Start is called before the first frame update

    void Start()
    {
        
        Task task = Generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == false) 
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }
       
    }
    async Task Generate()
    {
        if (createCubes==true) 
        {
            variantsCubes[(Random.Range(0, variantsCubes.Length))].SetActive(true);
            await Task.Yield();
        }
    }
}
