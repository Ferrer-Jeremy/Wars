using UnityEngine;
using System.Collections;

public class ListeCases : MonoBehaviour// cette classe stoke tout les prefabs cases (tiles) et a une fonction qui renvoie un array de toute les cases
{  
    public GameObject eau;
    public GameObject plaine;
    public GameObject foret;
    public GameObject montagne;

    //pas utilisé pour l'instant (nombre max de cases de ce type)
    private int nbForet;
    private int nbRiviere;
    private int nbMontagne;
    private int nbMer;

    private GameObject[] arrayTiles = new GameObject[4]; // nombre de tiles

    public GameObject[] getTiles()
    {
        arrayTiles[0] = eau;
        arrayTiles[1] = plaine;
        arrayTiles[2] = foret;
        arrayTiles[3] = montagne;

        return arrayTiles;
    }
}
