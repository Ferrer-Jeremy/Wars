using UnityEngine;
using System.Collections;

public class ControlCamera : MonoBehaviour
{
    private float speedCamera = 0.25f;
    private float distanceCamera = 5; //on met en public pour pouvoir le changer dans l'editeur
    new Camera camera;
    Vector3 cameraPosition;
    Vector3 cameraPostionfuture;

    //pour recuperer la taille de la carte
    public GameObject gameManager; 
    private CreationMap creationMap; // le script
    private int largeur;
    private int longeur;
    private int debutLargeur;
    private int debutLongeur;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        cameraPosition = new Vector3(110, 110, -10);

        //pour recuperer la taille de la carte
        creationMap = gameManager.GetComponent<CreationMap>();
        largeur = creationMap.getLargeur();
        longeur = creationMap.getLongeur();
        debutLargeur = creationMap.getDebutLargeur();
        debutLongeur = creationMap.getDebutLongeur();

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
        
        cameraPosition = cameraPosition + cameraPostionfuture;//on ajoute a la position de la camera le deplacement
       

        //corection de la position de la camera pour ne pas qu'elle sorte de la carte
        if (cameraPosition.x > largeur + debutLargeur)
            cameraPosition.x = largeur + debutLargeur;
        if (cameraPosition.x < debutLargeur)
            cameraPosition.x = debutLargeur;
        if (cameraPosition.y > longeur + debutLongeur)
            cameraPosition.y = longeur + debutLongeur;
        if (cameraPosition.y < debutLongeur)
            cameraPosition.y = debutLongeur;

        camera.transform.position = cameraPosition;//on met a jour la camera camera
    }
}