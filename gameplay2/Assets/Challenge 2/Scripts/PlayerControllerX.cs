using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float waitTime = 0.75f;
    float waited = 0;
    // Update is called once per frame
    void Update()
    {
        waited += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space)&& waited >= waitTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            waited = 0f;
        }
    }
}
