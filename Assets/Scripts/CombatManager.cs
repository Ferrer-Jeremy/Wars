using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{

    public GameObject objetPointeur;
    public GameObject terrain;
    public GameObject unites;

    private TerrainStats terrainStats;
    private Hud hud;
    private Controls controls;

    Transform[] allChildrenTerrain;
    Transform[] allChildrenUnites;

    Vector3 positionImagePointeur;
    GameObject uniteOver;
    GameObject uniteSelection;

    void Awake()
    { 
        //on recupere les scripts 
        hud = GetComponent<Hud>();
        terrainStats = GetComponent<TerrainStats>();
        controls = GetComponent<Controls>();

        //on positionne le pointeur
        positionImagePointeur = new Vector3(30, 30, 0);
        objetPointeur.transform.position = positionImagePointeur;

        //avec les transform on peut recuperer le gameobject //gameobjet = allChildren[i].gameobject;

        //on recupere tour les transform des enfant de "terrain" et "terrain" lui meme
        allChildrenTerrain = terrain.GetComponentsInChildren<Transform>();
        //on recupere tour les transform des enfant de "unités" et "unités" lui meme  
        allChildrenUnites = unites.GetComponentsInChildren<Transform>();

        //on met les game object a null
        uniteOver = null;
        uniteSelection = null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        affichagePointeur();                                                                                //affiche le pointeur
        hud.affichageCaseHud(allChildrenTerrain, terrainStats, positionImagePointeur);                      //affiche la defense de la case pointé

        uniteOver = controls.uniteOver(allChildrenUnites, positionImagePointeur, uniteOver);                //on voit si une unité est survolé et la recupere
        hud.affichageUnitOver(uniteOver);                                                                   //affiche l'unité survolé

        uniteSelection = controls.UniteSelection(uniteSelection);                                           //on recupere l'unite selectionné ou désélectionne
        controls.affichageAttackZone(allChildrenTerrain);                                                   // affiche la zone de deplacement/attack
        controls.deplacementUnite(uniteSelection, positionPointeur());                                      //deplace l'unite

    }

    void affichagePointeur() //affiche le pointeur
    {
        objetPointeur.transform.position = positionPointeur();        //on met le game objet pointeur a l'endroit ou l'on pointe
    }

    public Vector3 positionPointeur()  // la position du pointeur arondi !
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //on recucpere la  position de la souris a travers la camera on world space (comme la position de nos tiles)
        float mouseX = Mathf.Round(mousePosition.x);
        float mouseY = Mathf.Round(mousePosition.y);
        positionImagePointeur = new Vector3(mouseX, mouseY, 0);
        return positionImagePointeur;
    }
}
