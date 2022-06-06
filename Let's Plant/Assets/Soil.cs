using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{

    public enum SoilStatus
    {
        Dry,
        Wet,
    }

    public SoilStatus soilStatus;

    public Material wetSoil, drySoil;
    new Renderer renderer;

    public GameObject select;

    public float waterLevel = 100;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        soilStatus = SoilStatus.Dry;
    }

    void Update()
    {
        waterLevel -= 10 * Time.deltaTime;
        if (waterLevel <= 10)
        {
            soilStatus = SoilStatus.Dry;
            renderer.material = drySoil;
        }
    }

    public void GiveWater()
    {
        waterLevel = 100;
    }

    public void SwitchSoilStatus(SoilStatus statusToSwitch)
    {
       soilStatus = statusToSwitch;
       Material materialToSwitch = drySoil;

        switch(statusToSwitch)
        {
            case SoilStatus.Dry:
                materialToSwitch = drySoil;
                break;
            case SoilStatus.Wet:
                materialToSwitch = wetSoil;
                break;
        }

        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle){
        select.SetActive(toggle);
    }

    public void Interact()
    {
        if(soilStatus == SoilStatus.Dry)
        {
            SwitchSoilStatus(SoilStatus.Wet);
        }
        else
        {
            SwitchSoilStatus(SoilStatus.Dry);
        }
    }
}
