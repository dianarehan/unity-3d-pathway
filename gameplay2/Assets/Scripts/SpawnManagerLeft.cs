using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLeft : MonoBehaviour
{
    public GameObject[] animals;
    void Start()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animals[i].transform.rotation = new Quaternion(0, 0.707106829f, 0, 0.707106829f);
        }
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    // Update is called once per frame
    void SpawnRandomAnimal()
    {   //3 is exclusive
        Vector3 pos = new Vector3(this.transform.position.x, 0, (int)Random.Range(-15, 15));
        Instantiate(animals[(int)Random.Range(0, animals.Length)], pos, animals[(int)UnityEngine.Random.Range(0, animals.Length)].transform.rotation);
    }
}
