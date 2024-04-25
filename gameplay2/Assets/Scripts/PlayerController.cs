using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] GameObject myLeftBorder;
    [SerializeField] GameObject myRightBorder;
    [SerializeField] GameObject pizzaProjectile;

    void Start()
    {
        
    }

   
    void Update()
    {   float direction = Input.GetAxis("Horizontal");
        if(this.transform.position.x< myLeftBorder.transform.position.x )
        {
            this.transform.position=new Vector3(myLeftBorder.transform.position.x, transform.position.y, transform.position.z);
        }
        else if( this.transform.position.x >myRightBorder.transform.position.x)
        {
            this.transform.position = new Vector3(myRightBorder.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            this.transform.Translate(new Vector3(speed * direction * Time.deltaTime, 0, 0));
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {   if(pizzaProjectile != null) 
            Instantiate(pizzaProjectile,this.transform);
        }
        if(pizzaProjectile.transform.position.z>40)
            Destroy(pizzaProjectile) ;
    }
}
