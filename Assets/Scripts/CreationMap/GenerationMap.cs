using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.


public class GenerationMap : MonoBehaviour {

    private GameObject clone; //l'object instancié
    private GameObject tileChoice; //l'object choisi grace a random

    public void generationMap(GameObject terrain, ListeCases listeCases, int tailleMapLargeur, int tailleMapLongeur, int debutLargeur, int debutLongeur)    //genere la map a partir de x = 0 et y = 0 && on recupere le game object qui contient tout le terrain
    {
        GameObject[] tileArray = listeCases.getTiles();

        for(int x = debutLargeur; x <= tailleMapLargeur + debutLargeur; x++) //on crée la carte a partir de 100 * 100 pour ne pas etre dans les negatif et avoir des erreurs
        {
            for(int y = debutLongeur; y <= tailleMapLongeur + debutLongeur; y++)
            {
                tileChoice = tileArray[Random.Range(0, tileArray.Length)];
                clone = Instantiate(tileChoice, new Vector3(x,y,0), Quaternion.identity) as GameObject;                 //instancie la case
                clone.transform.SetParent(terrain.transform);                                                          //les met en enfants de terrain
                clone.transform.localScale = new Vector3(1, 1, 1);                                                     //les met a la bonne taille
            }
        }
    }
}
