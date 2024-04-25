using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    public float speed = 40;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed*Time.deltaTime));
        if (transform.position.z > 40f)
            Destroy(gameObject);

        //lol lama 3malt Destroy(this) i basically deleted the script component out of the gameobj not the obj itself
        //so he stopped moving
        else if (transform.position.z < -15)
        {
            Destroy(gameObject);
            Debug.Log("not gg loser you lost!!");
        }
    }
}
