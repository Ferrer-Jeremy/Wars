using UnityEngine;
using System.Collections;

public class CalculRayon : MonoBehaviour {

	public Vector2[] calculRayonDeplacement(GameObject unite, Transform[] allChildrenTerrain, Transform[] allChildrenEquipe, Transform[] allChildrenEquipeEnnemie)    //NE MARCHE QU'AVEC 2 EQUIPES POUR LE MOMENT
    {
        int rangeMin = unite.GetComponent<UniteStats>().rangeMin;
        int rangeMax = unite.GetComponent<UniteStats>().rangeMin;
        int move = unite.GetComponent<UniteStats>().moveRestant;
        string moveType = unite.GetComponent<UniteStats>().moveType;

        Vector2 positionUnite = unite.transform.position;                                                   // le vector3 va dans le v2 z est "effacé"
        Vector2 zero = new Vector2(0,0);
        Vector2 unX = new Vector2(1, 0);
        Vector2 unY = new Vector2(0, 1);

        Vector2[] zone = new Vector2[1000];                                                                 //ATTENTION !!!!!!!!!!!!!!    LIMTE LA TAILLE DE LA ZONE A 100 CASES
        Vector2[] zoneCaseInterdites = new Vector2[100];
        Vector2[] zoneCaseRalentit = new Vector2[100];
        Vector2[] zoneUniteEnnemi = new Vector2[100];
        Vector2[] zoneUniteAlliee = new Vector2[100];

        int uniteX = Mathf.RoundToInt(unite.transform.position.x);
        int uniteY = Mathf.RoundToInt(unite.transform.position.y);

        int i = 0;

        bool xPlus = true;
        bool xMoins = true;
        bool yPlus = true;
        bool yMoins = true;

        // la vision limite la zone de recherche pour les unités ennemis
        //et celle qui ralentissent son mouvement A FAIRE


        switch (moveType)                                                                                   //on recupere la position de toutes les cases que cette unite ne peut pas traverser
        {
            case "pieds":
                foreach (Transform child in allChildrenTerrain)                                         
                {
                    
                    if (child.position.x > uniteX - move && 
                        child.position.x < uniteX + move && 
                        child.position.y > uniteY - move && 
                        child.position.y < uniteY + move)
                    {
                        if (child.tag == "Mer" || child.tag == "Recif")                                     //utiliser des tags est plus rapide et use moins de ressources
                        {
                            zoneCaseInterdites[i] = child.position;
                            i++;
                        }
                        if (child.tag == "Montagne" || child.tag == "Riviere")                              //utiliser des tags est plus rapide et use moins de ressources
                        {
                            //zoneCaseRalentit[i] = child.position;
                        }
                    }  
                }
                break;
            case "roues":

                break;
            case "chenilles":

                break;
            case "air":

                break;
            case "eau":

                break;
            case "eau profonde":

                break;
            default:
                Debug.Log("erreur mauvais type de deplacement de l'unité CalculRayon");
                break;
        }

        //on recupere que les unites ennemis qui peuvent etre dans la zone de deplacement de  unite
        i = 0;
        if (allChildrenEquipeEnnemie != null)
        {
            foreach (Transform child in allChildrenEquipeEnnemie)
            {
                if (child.position.x > uniteX - move &&
                    child.position.x < uniteX + move &&
                    child.position.y > uniteY - move &&
                    child.position.y < uniteY + move)
                {
                    zoneUniteEnnemi[i] = child.position;
                }
                i++;
            }
        }

        //on recupere la position de notre equipe, on ne peut pas s'areter sur une unite de notre equipe
        i = 0;
        foreach (Transform child in allChildrenEquipe)                                         
        {
            if (child.position.x > uniteX - move &&
                child.position.x < uniteX + move &&
                child.position.y > uniteY - move &&
                child.position.y < uniteY + move)                    //on recupere que les unites ennemis qui peuvent etre dans la zone de deplacement de  unite
            {
                zoneUniteAlliee[i] = child.position;
            }
            i++;
        }
        i = 0;



        //AJOUTER LES CASES INTERDITES 



        //on calcul la zone
        i = 1; 
        zone[0] = positionUnite;

        foreach(Vector2 caseIZ in zone) //case in zone
        {
            if(caseIZ == zero)                                          //on sort des que l'on atteint la valeur zero(0.0) puisque toutes celle qui suivent son a zero aussi  
            {
                break;
            }
  
            foreach (Vector2 caseI in zoneCaseInterdites )              // on verifie si c'est une case interdite
            {
                if (caseI == zero)                                      //on sort des que l'on atteint la valeur zero(0.0) puisque toutes celle qui suivent sont a zero aussi       
                {
                    break;
                }

                if (caseIZ + unX == caseI)                              //si la caseIZ (case de depart) + 1 en x fait partie des cases interdites xplus devient faux et cette case ne sera pas enregistré
                {
                    xPlus = false;
                }
                if (caseIZ - unX == caseI)
                {
                    xMoins = false;
                }
                if (caseIZ + unY == caseI)
                {
                    yPlus = false;
                }
                if (caseIZ - unY == caseI)
                {
                    yMoins = false;
                }
            }
            foreach (Vector2 caseIZbis in zone)                         //on verifie si la case a deja ete ajouté
            {
                if (caseIZbis == zero)                                  //on sort des que l'on atteint la valeur zero(0.0) puisque toutes celle qui suivent sont a zero aussi
                {
                    break;
                }

                if (caseIZ + unX == caseIZbis)                          //si la caseIZ + 1 en x fait partie des cases deja ajouté, xplus devient faux et cette case ne sera pas enregistré
                {
                    xPlus = false;
                }
                if (caseIZ - unX == caseIZbis)
                {
                    xMoins = false;
                }
                if (caseIZ + unY == caseIZbis)
                {
                    yPlus = false;
                }
                if (caseIZ - unY == caseIZbis)
                {
                    yMoins = false;
                }
            }

            if (Mathf.Abs(zone[0].y - caseIZ.y) + Mathf.Abs(zone[0].x - (caseIZ + unX).x) > move)         //on verifie si la case depasse le deplacement maximal (move)
            {
                xPlus = false;
            }
            if (Mathf.Abs(zone[0].y - caseIZ.y) + Mathf.Abs(zone[0].x - (caseIZ - unX).x) > move)
            {
                xMoins = false;
            }
            if (Mathf.Abs(zone[0].y - (caseIZ + unY).y) + Mathf.Abs(zone[0].x - caseIZ.x) > move)
            {
                yPlus = false;
            }
            if (Mathf.Abs(zone[0].y - (caseIZ - unY).y) + Mathf.Abs(zone[0].x - caseIZ.x) > move)
            {
                yMoins = false;
            }


            if (xPlus)                                                   //on enregistre les cases qui ont été validé
            { 
                zone[i] = caseIZ + unX;
                i++;
            }
            if (xMoins)
            {
                zone[i] = caseIZ - unX;
                i++;
            }
            if (yPlus)
            {
                zone[i] = caseIZ + unY;
                i++;
            }
            if (yMoins)
            {
                zone[i] = caseIZ - unY;
                i++;
            }
            xPlus = true;
            xMoins = true;
            yPlus = true;
            yMoins = true;
        }        
    return zone;
    }
}
