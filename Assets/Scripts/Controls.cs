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


    public GameObject UniteSelection(GameObject uniteSelection)
    {
        if (uniteSelection == null)
        {
            if (Input.GetKeyDown("mouse 0"))             //selectionne l'unite sur laquelle on clique
            {
                uniteSelection = unite;
            }         
        }
        else
        {
            if (Input.GetKeyDown("space"))               //deselectionne l'unite en appuyant sur espace
            {
                uniteSelection = null;
            }
        }           
        return uniteSelection;
    }

    
    public void affichageAttackZone()                   
    {
        int rangeMin;
        int rangeMax;
        int departX;
        int departY;
        int[,] zone = new int[100,2];   //ATTENTION !!!!!!!!!!!!!!    LIMTE LA TAILLE DE LA ZONE A 100 CASES
        int i = 0;

        //init a faire

        if (unite != null)
        {
            if (Input.GetKeyDown("mouse 1"))                //clique droit
            {
                //rangeMin = unite.spript.rangeMin + unite.spript.deplacementRestant;  rangeMax = unite.spript.rangeMax + unite.spript.deplacementRestant;    if(artillerie) {rangeMin = unite.spript.rangeMin; rangeMax = unite.spript.rangeMax;}       
                //on recupe les stats del'unité A FAIRE !!!!!!!!!!!!!!!!!!!
                //sauf pour l'artillerie qui ne peut pas tirer et ce deplacer dans le meme tour
                //prendre en compte le type de terrain
                rangeMin = 2;
                rangeMax = 2;
                departX = Mathf.RoundToInt(unite.transform.position.x);
                departY = Mathf.RoundToInt(unite.transform.position.y);
                if (boucle == true)
                {
                    for (int xPlus = 0; xPlus <= rangeMin; xPlus++)
                    {
                        for (int yPlus = 0; yPlus <= rangeMin - xPlus; yPlus++)
                        {
                            zone[i, 0] = xPlus + departX;
                            zone[i, 1] = yPlus + departY;
                            i++;
                        }
                        for (int yMoins = 0; yMoins >= -rangeMin + xPlus; yMoins--)
                        {
                            zone[i, 0] = xPlus + departX;
                            zone[i, 1] = yMoins + departY;
                            i++;
                        }
                    }
                    for (int xMoins = 0; xMoins >= -rangeMin; xMoins--)
                    {
                        for (int yPlus = 0; yPlus <= rangeMin + xMoins; yPlus++)
                        {
                            zone[i, 0] = xMoins + departX;
                            zone[i, 1] = yPlus + departY;
                            i++;
                        }
                        for (int yMoins = 0; yMoins >= -rangeMin - xMoins; yMoins--)
                        {
                            zone[i, 0] = xMoins + departX;
                            zone[i, 1] = yMoins + departY;
                            i++;
                        }
                    }

                    // on suprime les nombre en double
                    for (int j = 0; j < zone.GetLength(0); j++)    //GetLength(0) recupere la longeur de la premiere coordonnée de l'array
                    {
                        if (zone[j, 0] != 0 || zone[j, 1] != 0)// si l'un des 2 est different de 0
                        {
                            for (int k = 0; k < zone.GetLength(0); k++)
                            {
                                if (zone[j, 0] == zone[k, 0] && zone[j, 1] == zone[k, 1] && k != j) //si on a 2 fois le meme chiffre (sauf 0,0) on met le 2eme a zero
                                {
                                    zone[k, 0] = 0;
                                    zone[k, 1] = 0;                                 
                                }
                            }
                        }
                    }
                    
                    for (int j = 0; j < zone.GetLength(0); j++)    //test pour afficher les coordonnées differentes de 0,0
                    {
                        if (zone[j, 0] != 0 || zone[j, 1] != 0)
                        {
                            Debug.Log(zone[j, 0] + "," + zone[j, 1]);
                        }
                    }
                }
                boucle = false;
            }
        }
    }
}
