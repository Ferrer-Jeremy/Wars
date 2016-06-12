using UnityEngine;
using System.Collections;

public class Pointeur : MonoBehaviour {

    //pour recuperer la taille de la carte
    public GameObject gameManager;
    private CreationMap creationMap; // le script
    private int largeur;
    private int longeur;
    private int debutLargeur;
    private int debutLongeur;

    void Awake()
    {
        //pour recuperer la taille de la carte
        creationMap = gameManager.GetComponent<CreationMap>();
        largeur = creationMap.getLargeur();
        longeur = creationMap.getLongeur();
        debutLargeur = creationMap.getDebutLargeur();
        debutLongeur = creationMap.getDebutLongeur();
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //on recucpere la  position de la souris a travers la camera on world space (comme la position de nos tiles)
        float mouseX = Mathf.Round(mousePosition.x);
        float mouseY = Mathf.Round(mousePosition.y);


        //le pointeur ne peut pas sortir de la carte
        if (mouseX > largeur + debutLargeur)
            mouseX = largeur + debutLargeur;
        if (mouseX < debutLargeur)
            mouseX = debutLargeur;
        if (mouseY > longeur + debutLongeur)
            mouseY = longeur + debutLongeur;
        if (mouseY < debutLongeur)
            mouseY = debutLongeur;

        transform.position = new Vector3(mouseX, mouseY, 0);
    }
}
