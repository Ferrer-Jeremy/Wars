using UnityEngine;
using System.Collections;

public class ControlCamera : MonoBehaviour
{
    public float speedCamera = 0.25f;
    public float distanceCamera = 5; //on met en public pour pouvoir le changer dans l'editeur
    new Camera camera;
    Vector3 cameraPosition;
    Vector3 cameraPostionfuture;

    // Use this for initialization
    void Start()
    {
        cameraPosition = new Vector3(30, 30, -10);
        camera = GetComponent<Camera>();
        GetComponent<Transform>().position = cameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
        distanceCamera = distanceCamera - (Input.GetAxis("Mouse ScrollWheel") * 2); //on recupere l'incrementation de la roue puis on la multiplie pour avoir une valeur de plus grande amplitude

        if (distanceCamera > 9)             //distance max de la camera
            distanceCamera = 9;
        if (distanceCamera < 2)             //distance min de la camera
            distanceCamera = 2;

        camera.orthographicSize = distanceCamera;  //on defini la distance de la camera


        float moveX = Input.GetAxis("Horizontal") * speedCamera; //touches gauche droite * la vitesse choisi
        float moveY = Input.GetAxis("Vertical") * speedCamera;   //touches haut bas * la vitesse choisi
        cameraPostionfuture = new Vector3(moveX, moveY, 0);//on crée un vector 2 dans lequel on met les input 
        cameraPosition = GetComponent<Transform>().position;//on recupere la position de la camera
        cameraPosition = cameraPosition + cameraPostionfuture;//on ajoute a la position de la camera le deplacement

        camera.transform.position = cameraPosition;//on met a jour la camera la camera
    }

}