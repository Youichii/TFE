using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEvolution : MonoBehaviour
{
    public Mesh youngPlant;
    public Mesh mediumPlant;
    public Mesh adultPlant;
    public Material newMaterial;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= 0.2f && transform.localScale.x <= 0.4f)
        {
            transform.GetComponent<MeshFilter>().mesh = youngPlant;
            transform.GetComponent<MeshRenderer>().material = newMaterial;
        }
        else if (transform.localScale.x >= 0.4f && transform.localScale.x <= 0.7f)
        {
            transform.GetComponent<MeshFilter>().mesh = mediumPlant;
            transform.GetComponent<MeshRenderer>().material = newMaterial;
        }
        else if (transform.localScale.x >= 0.9f)
        {
            transform.GetComponent<MeshFilter>().mesh = adultPlant;
            transform.GetComponent<MeshRenderer>().material = newMaterial;
        }
    }
}
