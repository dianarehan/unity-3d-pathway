using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] GameObject myLeftBorder;
    [SerializeField] GameObject myRightBorder;
    [SerializeField] GameObject myTopBorder;
    [SerializeField] GameObject myBottomBorder;

    [SerializeField] GameObject pizzaProjectile;

 
    void Update()
    {   float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");

        if(this.transform.position.x< myLeftBorder.transform.position.x )
        {
            this.transform.position=new Vector3(myLeftBorder.transform.position.x, transform.position.y, transform.position.z);
        }
        else if( this.transform.position.x >myRightBorder.transform.position.x)
        {
            this.transform.position = new Vector3(myRightBorder.transform.position.x, transform.position.y, transform.position.z);
        }
        else if(this.transform.position.z> myTopBorder.transform.position.z)
        {
            this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,myTopBorder.transform.position.z);
        }
        else if (this.transform.position.z< myBottomBorder.transform.position.z)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, myBottomBorder.transform.position.z);

        }

        this.transform.Translate(new Vector3(speed * horizontalDirection * Time.deltaTime, 0, verticalDirection*speed*Time.deltaTime));
        


        if(Input.GetKeyDown(KeyCode.Space))
        {   if(pizzaProjectile != null) 
            Instantiate(pizzaProjectile,this.transform);
        }
        
    }
}
