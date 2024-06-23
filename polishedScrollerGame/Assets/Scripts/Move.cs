using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 20f;
    private PlayerController controller;

    private void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {

        if (!controller.gameOver)
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (gameObject.tag.Equals("Log") && (gameObject.transform.position.x < -25 || gameObject.transform.position.y < -3))
            {
                Destroy(gameObject);
            }
        }
    }

}
