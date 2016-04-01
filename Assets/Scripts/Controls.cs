using UnityEngine;

public class Controls : MonoBehaviour
{

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
        return uniteOver;                                                                           //on renvoie le game object
    }


    public GameObject UniteSelection(Transform[] allChildrenUnites, Vector3 positionImagePointeur, GameObject uniteSelection)
    {

        if (Input.GetKeyDown("mouse 0"))
        {
            if (uniteSelection != null)
            {
                if (uniteSelection.transform.position != positionImagePointeur)
                {
                    foreach (Transform child in allChildrenUnites)                                      //on fait une boucle avec chaque transform
                    {
                        if (child.position == positionImagePointeur)                                    //si le transform corespond a la position du pointeur
                        {
                            uniteSelection = child.gameObject;
                            break;                                                                      //on sort de la boucle si on l'a trouvé
                        }
                        else
                        {
                            uniteSelection = null;
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
                        uniteSelection = child.gameObject;
                        break;                                                                          //on sort de la boucle si on l'a trouvé
                    }
                    else
                    {
                        uniteSelection = null;
                    }
                }
            }
        }
        return uniteSelection;
    }
}
