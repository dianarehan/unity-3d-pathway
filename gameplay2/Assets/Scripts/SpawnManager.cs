using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] animals;
    public GameObject rightBorder;
    public GameObject leftBorder;
    public GameObject topBorder;
    public GameObject bottomBorder;



    void Start()
    {
        
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
        InvokeRepeating("SpawnAnimalsLeft", 3, 1.75f);
        InvokeRepeating("SpawnAnimalsRight", 5, 3f);


    }


    void SpawnRandomAnimal()
    {   //3 is exclusive
        Vector3 pos = new Vector3((int)Random.Range(-15, 15), 0, this.transform.position.z);
        Instantiate(animals[(int)Random.Range(0, animals.Length)], pos, animals[(int)UnityEngine.Random.Range(0, animals.Length)].transform.rotation);
    }
    void SpawnAnimalsLeft()
    {
        Vector3 rotation = new Vector3(0, 90, 0);
        Vector3 pos = new Vector3(leftBorder.transform.position.x, 0, Random.Range(bottomBorder.transform.position.z,topBorder.transform.position.z));
        Instantiate(animals[(int)Random.Range(0, animals.Length)],pos, Quaternion.Euler(rotation));
    }

    void SpawnAnimalsRight()
    {
        Vector3 rotation = new Vector3(0, -90, 0);
        Vector3 pos = new Vector3(rightBorder.transform.position.x, 0, Random.Range(bottomBorder.transform.position.z, topBorder.transform.position.z));
        Instantiate(animals[(int)Random.Range(0, animals.Length)], pos,Quaternion.Euler(rotation));
    }
}
