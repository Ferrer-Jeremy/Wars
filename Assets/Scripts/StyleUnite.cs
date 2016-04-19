using UnityEngine;
using System.Collections;

public class StyleUnite : MonoBehaviour
{

    SpriteRenderer rendererUnite;
    Color couleurBase = new Color(1f, 1f, 1f, 1f);                                               // couleur blanc transparent

    public void paintUnite(GameObject unite, Color color)                                        // met un filtre couleur sur un game object qui a un sprite renderer -> dans ce cas une unité
    {
        rendererUnite = unite.GetComponent<SpriteRenderer>();                                    //A CHANGER les appels get... demandent beacoup de ressources
        rendererUnite.color = color;
    }

    public void resetPaintUnite(GameObject unite)                                                // reset
    {
        paintUnite(unite, couleurBase);
    }

    public void resetEquipePaintUnite(Transform[] equipe)                                       // reset pour toute une equipe
    {
        foreach (Transform unite in equipe)                                                     //on remet la couleur de base de chaque case 
        {
            if (unite.name != equipe[0].gameObject.name)                                        //on exclu le game objet equipe on on aura une erreur A VERIFIER SI CELLA MARCHE !!! le premier(0) est sencé etre l'adulte equipe
            {
                resetPaintUnite(unite.gameObject);                                              //voir au dessus
            }
        }
    }
}
