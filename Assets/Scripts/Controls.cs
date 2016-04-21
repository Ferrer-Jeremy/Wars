using UnityEngine;

public class Controls : MonoBehaviour
{
    GameObject unite;
    bool boucle = true;

    public GameObject uniteOver(Transform[] allChildrenUnites, Vector3 positionImagePointeur, GameObject uniteOver)
    {
        if(uniteOver != null)
        {
            if (uniteOver.transform.position != positionImagePointeur)
            {
                foreach (Transform child in allChildrenUnites)                                      //on fait une boucle avec chaque transform
                {
                    if (child.position == positionImagePointeur)                                    //si le transform corespond a la position du pointeur
                    {
                        uniteOver = child.gameObject;
                        break;                                                                      //on sort de la boucle si on l'a trouvé
                    }
                    else
                    {
                        uniteOver = null;
                    }
                }
            }
        }
        else
        {
            foreach (Transform child in allChildrenUnites)                                          //on fait une boucle avec chaque transform
            {
                if (child.position == positionImagePointeur)                                        //si le transform corespond a la position du pointeur
                {
                    uniteOver = child.gameObject;
                    break;                                                                          //on sort de la boucle si on l'a trouvé
                }
                else
                {
                    uniteOver = null;
                }
            }
        }
        unite = uniteOver;
        return uniteOver;                                                                           //on renvoie le game object
    }


    public void deplacementUnite(GameObject uniteSelection, Vector3 positionPointeur)  // doit mettre a jour la position de l'unite 
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            if (uniteSelection != null)
            {
                uniteSelection.transform.position = positionPointeur;
            }
        }
    }
}
