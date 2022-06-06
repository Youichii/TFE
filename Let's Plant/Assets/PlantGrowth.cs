using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float maxScale = 20;
    public Vector3 scaleChange = 0.01f * Vector3.one;
    public Vector3 positionChange;
    public Vector3 rotateChange;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (maxScale > transform.localScale.x)
        {
            transform.localScale += scaleChange * Time.deltaTime;
            transform.position += (positionChange * Time.deltaTime);
            transform.Rotate (rotateChange * Time.deltaTime); 
        }
        
    }
}
