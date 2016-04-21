using UnityEngine;
using System.Collections;

public class StyleCase : MonoBehaviour {

    private SpriteRenderer imageCase;
    Color couleurBase = new Color(1f, 1f, 1f, 1f);                                          // couleur blanc transparent

    public void paintCase(Transform[] allChildrenTerrain, Vector2[] zone, Color color)      // met un filtre couleur sur une zone de cases
    {
        for (int j = 0; j < zone.GetLength(0); j++)    
        {
            if (zone[j].x != 0 || zone[j].y != 0)                                           //test pour afficher les coordonnées differentes de 0,0
            {      
                Vector3 position = new Vector3(zone[j].x, zone[j].y, 0);
                foreach (Transform child in allChildrenTerrain)                             //on fait une boucle avec chaque transform
                {
                    if (child.position == position)                                       
                    {
                        imageCase = child.GetComponent<SpriteRenderer>();                   //A CHANGER les appels get... demandent beacoup de ressources
                        imageCase.color = color;
                    }
                }
            }
        }
    }

    public void resetPaintCase(Transform[] allChildrenTerrain, Vector2[] zone)                 // enleve tous les filtres couleur sur une zone de cases ou une seule case
    {
        paintCase(allChildrenTerrain, zone, couleurBase);
    }

    public void resetAllPaintCase(Transform[] allChildrenTerrain)                           // enleve tous les filtres couleur sur toutes les cases
    {
        foreach (Transform child in allChildrenTerrain)                                     //on remet la couleur de base de chaque case 
        {    
            if (child.name != "Terrain")                                                    //on exclu le game objet terrain on on aura une erreur
            {
                imageCase = child.GetComponent<SpriteRenderer>();                           //A CHANGER les appels get... demandent beacoup de ressources
                imageCase.color = couleurBase;
            }
        }
    }


    //A FINIR

    public void changeSprite(GameObject gameObject, string sprite)                          //change le sprite du game object
    {
        switch (sprite)
        {
            case "base":                                                                    //remet le sprite de base

                break;

            case "feu":

                break;
        }

    }
}
