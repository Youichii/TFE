using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{

    // get the parent object
    public GameObject parent;
    public float life = 100;

    // Start is called before the first frame update
    void Start()
    {
        // get the parent object
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(parent.GetComponent<Soil>().waterLevel);
        // if the soil = 0 remove the plant
        if (parent.GetComponent<Soil>().waterLevel <= 0)
        {
            life -= 10 * Time.deltaTime;
            // change color to brown if life is below 50
            if (life <= 50)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (parent.GetComponent<Soil>().waterLevel >= 50)
        {
            life += 10 * Time.deltaTime;
            // change color to green if life is above 50
            if (life >= 50)
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
