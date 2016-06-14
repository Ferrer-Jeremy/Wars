using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public GameObject terrain;

    public GameObject menu;
    public GameObject quitter;
    public GameObject save;
    public GameObject load;
    public Text nomMap;
    public Text largeur;
    public Text longeur;
    private string map;
    private string largeurMap;
    private string longeurMap;

    //pour recuperer la taille de la carte
    public GameObject gameManager;
    private CreationMap creationMap; // le script
    private int largeurSave;
    private int longeurSave;
    private int debutLargeur;
    private int debutLongeur;


    // Use this for initialization
    void Start () {
        //pour recuperer la taille de la carte
        creationMap = gameManager.GetComponent<CreationMap>();
        largeurSave = creationMap.getLargeur();
        longeurSave = creationMap.getLongeur();
        debutLargeur = creationMap.getDebutLargeur();
        debutLongeur = creationMap.getDebutLongeur();
    }
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetButtonDown("Cancel"))// fait apparaitre ou disparaitre la menu
        {
            if(menu.activeSelf)
            {
                menu.SetActive(false);
                quitter.SetActive(false);
                save.SetActive(false);
                load.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
            }
        }
    }

    public void quitterButton() //pour le bouton quitter et quitter non
    {
        if (quitter.activeSelf)
        {
            quitter.SetActive(false);
        }
        else
        {
            quitter.SetActive(true);
        }
    }

    public void quitterButtonOui() //pour le bouton quitter oui
    {

    }

    public void newMap() //pour le bouton nouvelle carte
    {
        // recupere les inputs largeur et longeur et recharge la scene avec ces parametres si il n'y en a pas met des valeur pas defaut
    }

    public void saveMap() //fait apparaitre et disparaitre la fenetre enregistrer a l'aide du bouton enregistrer et enregistrer non
    {
        if (save.activeSelf)
        {
            save.SetActive(false);
        }
        else
        {
            save.SetActive(true);
        }
    }

    public void saveMapOui()// pour le bouton sauvegarder oui
    {
        //recupere le champ input pour enregistrer la carte si il n'y en a pas l'enregistre sous un nom generique
        string[,] cases = new string[largeurSave + debutLargeur + 1, longeurSave + debutLongeur + 1];
        Transform[] allChildrenTerrain;
        allChildrenTerrain = terrain.GetComponentsInChildren<Transform>();

        for(int x = debutLargeur; x <= largeurSave + debutLargeur; x++)
        {
            for(int y = debutLongeur; x <= longeurSave + debutLongeur; y++)
            {
                foreach(Transform boop in allChildrenTerrain)
                {
                    if(boop.position.x == x && boop.position.y == y)
                    {
                        cases[x, y] = boop.tag; //a changer pour recuperer le bon type de case exactement
                    }
                }
            }
        }


        MapJson mapJson = new MapJson(nomMap.text, largeurSave, longeurSave, cases);

        //nomMap.text
        Debug.Log(nomMap.text);
    }

    public void loadMap()//fait apparaitre et disparaitre la fenetre charger a l'aide du bouton charger et charger non
    {
        if (load.activeSelf)
        {
            load.SetActive(false);
        }
        else
        {
            load.SetActive(true);
            // affiche toutes les maps presente dans le dossier assets/maps
        }
    }

    public void loadMapOui()//pour le bouton valider dans charger 
    {
        //relance la scene avec cette carte
    }

}
