using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informations : MonoBehaviour
{

    public bool isOpen = false;

    public string nomC = "bonjour";
    public string nomS = "je";
    public string syn = "suis";
    public string taille = "grand";
    public string typ = "arbre";
    public string flor = "rose";
    public string eau = "bon";
    public string env = "ensoleille";
    public string mal = "mauvais";
    public string desc = "arbre";

    // get the canavs in a variable
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        //get the canvas with the name Informations
        canvas = GameObject.Find("Informations").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        // if open display the canvas
        if (isOpen)
        {
            canvas.enabled = true;
        }
        // else hide the canvas
        else
        {
            canvas.enabled = false;
        }
    }

    public void onOpen()
    {        
        isOpen = true;
    }

    public void onClose()
    {
        isOpen = false;
    }
}
