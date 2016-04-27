using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject prefabChemin;

    Vector2 zero = new Vector2(0, 0);

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


    public Vector2[] cheminUnite(GameObject uniteSelection, Vector2[] zone, Vector2[] chemin, Vector3 positionPointeur)  
    {

        Vector2 position;
        Vector2 previousPosition;
        Vector2 direction;

        bool isInZone = false;
        bool isInChemin = false;

        int i = 0;

        if (uniteSelection.GetComponent<UniteStats>().moveRestant > 0)                                                                // si il reste des mouvement
        {
            position = positionPointeur;
            previousPosition = uniteSelection.transform.position;                           

            if(chemin[0] != zero)
            {
                foreach (Vector2 child in chemin)                                               //on cherche la position precedente
                {
                    if (child == zero)
                    {
                        break;
                    }
                    previousPosition = child;
                    i++;
                }
            }

            if (position != previousPosition && position != new Vector2(uniteSelection.transform.position.x, uniteSelection.transform.position.y))                                               
            {
                direction = position - previousPosition;                                    
                foreach (Vector2 child in zone)
                {
                    if (child == zero)
                    {
                        break;
                    }
                    if (position == child)
                    {
                        isInZone = true;
                    }
                }

                foreach (Vector2 child in chemin)
                {
                    if (child == zero)
                    {
                        break;
                    }
                    if (position == child)
                    {
                        isInChemin = true;
                    }
                }

                if (isInZone == true && isInChemin == false && (Mathf.Abs(direction.x) == 1 || Mathf.Abs(direction.y) == 1) && !(Mathf.Abs(direction.x) == 1 && Mathf.Abs(direction.y) == 1)) //on verifie que la case est dans zone et qu'elle est adjacente
                {
                    Debug.Log(position);
                    chemin[i] = position;       //on ajoute la position
                    uniteSelection.GetComponent<UniteStats>().moveRestant--;
                }
            }
        }

        if (Input.GetKeyDown("mouse 1"))                                        //on efface tout si on fait un clique droit
        {
            for (int j = 0; j < chemin.GetLength(0); j++)
            {
                chemin[j] = new Vector2(0, 0);
                uniteSelection.GetComponent<UniteStats>().moveRestant = uniteSelection.GetComponent<UniteStats>().move;
                GameObject[] cheminImage = GameObject.FindGameObjectsWithTag("CheminUnite");
                foreach(GameObject child in cheminImage)
                {
                    Destroy(child);
                }
            }
        }

        return chemin;
    }

    public void affichageChemin(Vector2[] chemin)
    {
        GameObject[] cheminImage = GameObject.FindGameObjectsWithTag("CheminUnite");
        bool existe = false;

        foreach (Vector2 child in chemin)
        {
            if (child == zero)
            {
                break;
            }
            foreach(GameObject childBis in cheminImage)
            {
                if (child == new Vector2(childBis.transform.position.x, childBis.transform.position.y))
                {
                    existe = true;
                }
            }
            if(!existe)
            {
                Instantiate(prefabChemin, child, new Quaternion(0, 0, 0, 0));
            }
            existe = false;
        }
    }

    public void deplacement(Vector2[] chemin)
    {
        if (chemin[0] != zero)
        {
            //si il a une unite deja sur la case

        }
    }
}
