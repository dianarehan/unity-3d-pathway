using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    Boolean flag = true;
    Quaternion orgRot;
    void Start()
    {
        offset = transform.localPosition;
        orgRot = transform.localRotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        if (Input.GetMouseButtonUp(0))
        {
            flag = !flag;
            
        }
        if (flag)
        {
            transform.position = player.transform.position + offset;
            transform.rotation = orgRot;
        }
        if (!flag)
        {
            transform.position = player.transform.position+ new Vector3(0,2,1);
            transform.rotation = player.transform.rotation* player.transform.rotation;
        }
    }
}
