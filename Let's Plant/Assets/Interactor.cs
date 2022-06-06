using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{

    public LayerMask interactableLayerMask = 10;
    public Interactable interactable;
    public Informations informations;

    Soil selectedSoil = null;
    // Start is called before the first frame update
    void Start()
    {
        //get the canvas with the name Informations
        informations = GameObject.Find("Informations").GetComponent<Informations>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4f, interactableLayerMask))
        {
            OnInteractableHit(hit);
        }
        // else remove focus
        else
        {
            OnInteractableMiss();
        }

        // open the canvas named Informations on key tab pressed
        if (Input.GetKeyDown(KeyCode.Tab) && informations.isOpen == false)
        {
            informations.onOpen();
        }
        // close the canvas named Informations on key esc pressed
        if (Input.GetKeyDown(KeyCode.Escape) && informations.isOpen == true)
        {
            informations.onClose();
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        if (hit.collider.GetComponent<Interactable>())
            {
                if (interactable == null ||interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable.name == "Soil") {
                        Soil soil = interactable.GetComponent<Soil>();
                        SelectSoil(soil);
                    }
                }

                if (Input.GetKeyDown(KeyCode.E) && interactable.name == "Soil")
                {
                    interactable.GetComponent<Soil>().SwitchSoilStatus(Soil.SoilStatus.Wet);
                    interactable.GetComponent<Soil>().waterLevel = 100;
                }
                if (Input.GetKeyDown(KeyCode.F) && interactable.name == "Soil")
                {
                    // add a sphere above the soil as on the same position with the script PlantGrowth
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = interactable.transform.position;
                    sphere.transform.parent = interactable.transform;
                    sphere.transform.localScale = new Vector3(0.1f, 2f, 0.1f);
                    sphere.transform.localPosition = new Vector3(0, 1f, 0);
                    sphere.transform.localRotation = Quaternion.identity;
                    sphere.GetComponent<Renderer>().material.color = Color.green;
                    sphere.name = "Sphere";
                    sphere.AddComponent<PlantGrowth>();
                    sphere.AddComponent<PlantManager>();
                    sphere.GetComponent<PlantGrowth>().scaleChange = new Vector3(0.01f, 0.1f, 0.01f);
                }
            }
    }

    void OnInteractableMiss()
    {
        interactable = null;
        DeselectSoil();
    }

    void SelectSoil(Soil soil)
    {
        selectedSoil = soil;
        selectedSoil.Select(true);
    }

    void DeselectSoil()
    {
        if (selectedSoil != null)
        {
            selectedSoil.Select(false);
            selectedSoil = null;
        }
    }
}
