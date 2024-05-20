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
    float val;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;
        currentColor=material.color;
        targetColor =getNewColor();

        currentRotation =transform.localRotation;
        targetRotation= getNewRotation();
        
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
