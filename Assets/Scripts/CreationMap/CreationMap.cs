using UnityEngine;
using System.Collections;

public class CreationMap : MonoBehaviour {

    public GameObject pointeur;
    public GameObject terrain;


    // taille de la map
    private int tailleMapLargeur = 50;
    private int tailleMapLongeur = 20;
    private int debutLargeur = 100; //en bas a gauche de la carte
    private int debutLongeur = 100;

    Transform[] allChildrenTerrain;

    Vector3 positionImagePointeur;
    Transform caseActuel;

    //Scripts
    private ListeCases listeCases;
    private GenerationMap generationMap;

    void Awake ()
    {
        generationMap = GetComponent<GenerationMap>();
        listeCases = GetComponent<ListeCases>();

        generationMap.generationMap(terrain, listeCases, tailleMapLargeur, tailleMapLongeur, debutLargeur, debutLongeur); //genere une carte ramdom
    }

    // Use this for initialization
    void Start () {
        positionImagePointeur = pointeur.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        positionImagePointeur = pointeur.transform.position;    //recupere la position du pointeur arondi
        allChildrenTerrain = terrain.GetComponentsInChildren<Transform>();      //on recupere la liste des cases

        if (Input.GetButton("Fire1"))  //avec le click gauche on applique la case
        {
            foreach (Transform child in allChildrenTerrain)             //on test si la case et deja occupé
            {
                if (positionImagePointeur == child.transform.position)
                {
                    caseActuel = child;
                    break;
                }
            }

            if(caseActuel != null)      //si la case est occupé on la supprime et on met la nouvelle case
            {
                Destroy(caseActuel.gameObject);
                GameObject modele = Instantiate(listeCases.foret, positionImagePointeur, Quaternion.identity) as GameObject;       //crée des clones
                modele.transform.SetParent(terrain.transform);                                                          //les met en enfants de terrain
                modele.transform.localScale = new Vector3(1, 1, 1);                                                     //les met a la bonne taille
                caseActuel = null;
            }
            else //sinon on met la case directement
            {
                GameObject modele = Instantiate(listeCases.foret, positionImagePointeur, Quaternion.identity) as GameObject;       //crée des clones
                modele.transform.SetParent(terrain.transform);                                                          //les met en enfants de terrain
                modele.transform.localScale = new Vector3(1, 1, 1);                                                     //les met a la bonne taille
            }                                          
        }
    }








    public int getLargeur()
    {
        return tailleMapLargeur;
    }

    public int getLongeur()
    {
        return tailleMapLongeur;
    }

    public int getDebutLargeur()
    {
        return debutLargeur;
    }

    public int getDebutLongeur()
    {
        return debutLongeur;
    }
}
