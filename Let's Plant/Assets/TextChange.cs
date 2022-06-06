using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{

    public string text;
    
    // get the text component
    Text textO;

    public void getText()
    {
        textO=GameObject.Find("NomC").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        getText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
