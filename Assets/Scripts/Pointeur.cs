using UnityEngine;
using System.Collections;

public class Pointeur : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //on recucpere la  position de la souris a travers la camera on world space (comme la position de nos tiles)
        float mouseX = Mathf.Round(mousePosition.x);
        float mouseY = Mathf.Round(mousePosition.y);
        transform.position = new Vector3(mouseX, mouseY, 0);
    }
}
