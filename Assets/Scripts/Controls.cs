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
                    chemin[i] = position;       //on ajoute la position
                    uniteSelection.GetComponent<UniteStats>().moveRestant--;
                }
            }
        }

        if (Input.GetKeyDown("mouse 1"))                                        //on efface tout si on fait un clique droit
        {
            chemin = resetArrayVector2(chemin);									//on efface le chemin
			uniteSelection.GetComponent<UniteStats>().moveRestant = uniteSelection.GetComponent<UniteStats>().move; // on reset le nombre de move
			GameObject[] cheminImage = GameObject.FindGameObjectsWithTag("CheminUnite");			//on recupere tout les game object chemin pour les effacer
			foreach(GameObject child in cheminImage)
			{
				Destroy(child);
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

    public bool deplacementPossible(Vector2[] chemin, Transform[] allChildrenUnites)  //a changer pour ne prendre en compte que les unité alliées
    {
		int nombreDeplacement = 0;
		bool onUnite = false;
		
        if (chemin[0] != zero)
        {
			foreach(Vector2 child in chemin)		//on recupere la derniere position du chemin
			{
				if(child  == zero)
				{
					break;
				}
				nombreDeplacement++;
			}
			
			foreach(Transform child in allChildrenUnites)						//on verifie si il a une unite deja sur la derniere position du chemin
			{
				if(chemin[nombreDeplacement].x == child.position.x && chemin[nombreDeplacement].y == child.position.y && child.position != Vector3.zero)
				{
					onUnite = true;
					break;
				}
			}
        }
		return !onUnite;
    }

	public int deplacement(GameObject unite, Vector2[] chemin, int i)
	{
		float smoothTime = 50f; 									//un parametre de temps pour le deplacement de l'unité
		float marge = 0.0001f;
		Rigidbody2D rb2D = unite.GetComponent<Rigidbody2D>();
		Vector2 unitePos = unite.transform.position;
		Vector2 end = chemin[i - 1];
		Vector2 velocity = Vector2.zero;
		
		if(end == Vector2.zero)												//on verifie si on a fini le chemin si end est a zero le chemin est terminé on sort			
		{	
			rb2D.position = new Vector2(Mathf.RoundToInt(chemin[i-2].x), Mathf.RoundToInt(chemin[i-2].y));
			return 0;
		}
		else														//on bouge l'unité
		{
			//rb2D.position = Vector2.Lerp(unitePos, end, smoothTime*Time.deltaTime);	
			rb2D.position = Vector2.SmoothDamp(rb2D.position, end, ref velocity, smoothTime * Time.deltaTime);
			
			if(( Mathf.Abs(end.x - unitePos.x) <= marge || Mathf.Abs(end.y - unitePos.y) <= marge ) )//&& end - unitePos != Vector2.zero) //des que l'unité arrive a une certain distance on la passe directement sur end
			{
				//Debug.Log(end);
				//Debug.Log(Time.deltaTime);
				rb2D.position = end;
				i++;
			}
			return i;
		}	
	}

	public Vector2[] resetArrayVector2(Vector2[] zone)
	{
		for (int j = 0; j < zone.GetLength(0); j++)
			{
				zone[j] = zero;
			}
		return zone;
	}
}
