using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] animals;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void SpawnRandomAnimal()
    {   //3 is exclusive
        Vector3 pos = new Vector3((int)Random.Range(-15, 15), 0, this.transform.position.z);
        Instantiate(animals[(int)Random.Range(0, animals.Length)], pos, animals[(int)UnityEngine.Random.Range(0, animals.Length)].transform.rotation);
    }
}
