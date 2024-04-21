using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class VehiclesController : MonoBehaviour
{
    [SerializeField] GameObject[] vehicles = new GameObject[4];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rand = new System.Random();

        for (int i = 0; i < vehicles.Length; i++)
        {
            vehicles[i].transform.Translate(new Vector3(0, 0, -1 * Time.deltaTime * rand.Next(2,10)));
        }
    }
}
