using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreationMapUI : MonoBehaviour {

    //script
    private ListeCases listeCases;
    public GameObject gameManager;

    public GameObject prefab; // une cases exemple sur laquelle on va ce baser   asset / prefabs / creaton map
    Image prefabImage;
    string prefabText;
    Vector3 prefabPosition;

    Sprite imageGO;
    string textGO;
    Vector3 addPosition;

    void Awake()
    {
        //recuperation des tiles (toutes les cases) du script liste cases sur le game manager
        listeCases = gameManager.GetComponent<ListeCases>();
        GameObject[] listeGameObject = listeCases.getTiles();

        //
        prefabImage = prefab.GetComponentInChildren<Image>();
        prefabText = prefab.GetComponentInChildren<Text>().text;
        prefabPosition = new Vector3(30, 0, 0);

        addPosition = new Vector3(50, 0, 0);

       for (int x = 0; x < listeGameObject.Length; x++)            //affiche les gameObject a la suite
        {
            if(x!=0)
            {
                prefabPosition += addPosition;
            }
            imageGO = listeGameObject[x].GetComponent<SpriteRenderer>().sprite;
            textGO = listeGameObject[x].name;
            prefabImage.sprite = imageGO;
            prefabText = textGO;
            prefab.name = textGO;
            GameObject modele = Instantiate(prefab, prefabPosition, Quaternion.identity) as GameObject;       //crée des clones
            modele.transform.SetParent(this.gameObject.transform);                                              //les met en enfants de liste_cases
            modele.transform.localScale = new Vector3(1, 1, 1);                                                 //les met a la bonne taille
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
