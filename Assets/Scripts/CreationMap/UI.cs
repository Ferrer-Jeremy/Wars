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

    public void positionPanel()
    {
        Debug.Log("Button was pressed");
        if (positionListeCases)
        {
            positionListeCases = false;
        }
        else
        {
            positionListeCases = true;
        }
    }
}
