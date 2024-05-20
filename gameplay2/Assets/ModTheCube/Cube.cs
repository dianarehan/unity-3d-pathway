using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    Material material;
    private Color targetColor;
    private Color currentColor;

    Quaternion currentRotation;
    Quaternion targetRotation;

    Vector3 startPosition;
    Vector3 targetPosition;
    float val;

    Vector3 scalei;
    Vector3 scalej;

    float transitionSpeed = 1.0f; 
    private float lerpTime = 0f;
    private float lerpTime2 = 0f;



    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;
        currentColor=material.color;
        targetColor =getNewColor();

        currentRotation =transform.localRotation;
        targetRotation= getNewRotation();

        startPosition=this.transform.position;
        targetPosition = new Vector3(-6.88999987f, 0f, -0.150000006f);

        scalei = this.transform.localScale;
        scalej = this.transform.localScale*2;
        
    }

    void Update()
    {
        val += Time.deltaTime;
        
        currentColor = Color.Lerp(currentColor,targetColor,0.5f*Time.deltaTime);
        material.color=currentColor;
        if (Vector4.Distance(targetColor, currentColor) < 0.01f)
        {
            targetColor=getNewColor();
        }
        
        
        currentRotation = Quaternion.Lerp(currentRotation, targetRotation,0.05f*val);

        gameObject.transform.localRotation = currentRotation;

        if (Quaternion.Angle( targetRotation, currentRotation) < 1f)
        {
            targetRotation = getNewRotation();
            val = 0;
        }
        lerpTime += Time.deltaTime * transitionSpeed;
        

        transform.localPosition = Vector3.Lerp(startPosition, targetPosition, lerpTime);

        
        if (Vector3.Distance(targetPosition,transform.localPosition) < 0.01f)
        {
            
            Vector3 temp = startPosition;
            startPosition = targetPosition;
            targetPosition = temp;
            lerpTime = 0f;
        }

        lerpTime2 += Time.deltaTime * transitionSpeed;
        transform.localScale = Vector3.Lerp(scalei,scalej,lerpTime2);


        if (Vector3.Distance(scalej, transform.localScale) < 0.01f)
        {
            Vector3 temp = scalei;
            scalei = scalej;
            scalej=temp;
            lerpTime2 = 0f;

        }
    }
    Quaternion getNewRotation()
    {
        return Random.rotation;
    }
    Color getNewColor()
    {
        return new Color(Random.value, Random.value,Random.value,Random.value);
    }
}
