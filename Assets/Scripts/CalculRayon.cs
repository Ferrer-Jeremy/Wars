using UnityEngine;
using System.Collections;

public class CalculRayon : MonoBehaviour {

	public void calculRayonDeplacement(GameObject unite, Transform[] allChildrenTerrain, Transform[] allChildrenEquipe, Transform[] allChildrenEquipeEnnemie)    //NE MARCHE QU'AVEC 2 EQUIPES POUR LE MOMENT
    {
        int rangeMin = unite.GetComponent<UniteStats>().rangeMin;
        int rangeMax = unite.GetComponent<UniteStats>().rangeMin;
        int move = unite.GetComponent<UniteStats>().move;
        string moveType = unite.GetComponent<UniteStats>().moveType;

        Vector2 positionUnite = unite.transform.position;                                                     // le vector3 va dans le v2 z est "effacé"
        Vector2 zero = new Vector2(0,0);
        Vector2 unX = new Vector2(1, 0);
        Vector2 unY = new Vector2(0, 1);

        Vector2[] zone = new Vector2[1000];                                                              //ATTENTION !!!!!!!!!!!!!!    LIMTE LA TAILLE DE LA ZONE A 100 CASES
        Vector2[] zoneCaseInterdites = new Vector2[100];
        Vector2[] zoneCaseRalentit = new Vector2[100];
        Vector2[] zoneUniteEnnemi = new Vector2[100];
        Vector2[] zoneUniteAlliee = new Vector2[100];

        int uniteX = Mathf.RoundToInt(unite.transform.position.x);
        int uniteY = Mathf.RoundToInt(unite.transform.position.y);

        int i = 0;

        bool debut = true;
        bool xPlus = true;
        bool xMoins = true;
        bool yPlus = true;
        bool yMoins = true;

        // tout ca dans le rayon de deplacement de l'unité
        //on recupere la position de toutes les cases que cette unite ne peut pas traverser
        //et celle qui ralentissent son mouvement
        switch (moveType)
        {
            case "pieds":
                foreach (Transform child in allChildrenTerrain)                                         
                {
                    //on recupere que les unites ennemis qui peuvent etre dans la zone de deplacement de  unite
                    if (child.position.x > uniteX - move && 
                        child.position.x < uniteX + move && 
                        child.position.y > uniteY - move && 
                        child.position.y < uniteY + move)
                    {
                        if (child.tag == "Mer" || child.tag == "Recif")                                     //utiliser des tags est plus rapide et use moins de ressources
                        {
                            zoneCaseInterdites[i] = child.position;
                        }
                        if (child.tag == "Montagne" || child.tag == "Riviere")                              //utiliser des tags est plus rapide et use moins de ressources
                        {
                            zoneCaseRalentit[i] = child.position;
                        }
                    }
                    i++;
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

        //on recupere la position de l'equipe ennemi 
        i = 0;
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




        //on calcul la zone un move apres l'autre  NE MARCHE PAS
        i = 1; 
        zone[0] = positionUnite;
        for (int moveRestant = move; moveRestant > 0; moveRestant--)
        {
            foreach(Vector2 caseIZ in zone) //case in zone
            {
                if(caseIZ == zero)
                {
                    break;
                }

                if(debut == false)
                {

                }
                else
                {   
                    foreach (Vector2 caseI in zoneCaseInterdites )
                    {
                        if (caseI == zero)
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
                    debut = false;
                }
            }
        }
    }
}
