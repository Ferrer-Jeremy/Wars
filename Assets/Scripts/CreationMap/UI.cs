using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    public bool positionListeCases;


	// Use this for initialization
	void Start () {
        positionListeCases = true;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void positionPanel(bool panelHaut)
    {
        Debug.Log("Button was pressed");
        if (panelHaut)
        {
            positionListeCases = false;
        }
        else
        {
            positionListeCases = true;
        }
    }
}
