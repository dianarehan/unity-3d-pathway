using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.localPosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position+offset;
    }
}
