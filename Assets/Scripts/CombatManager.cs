﻿using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{

    public GameObject terrain;
    public GameObject unites;
    public GameObject pointeur;

    private TerrainStats terrainStats;
    private Hud hud;
    private Controls controls;
    private CalculRayon calculRayon;
    private StyleCase styleCase;
    private StyleUnite styleUnite;

    Transform[] allChildrenTerrain;
    Transform[] allChildrenUnites;

    Color colorAttackZone = new Color(1f, 0f, 0f, 1f); // couleur grise
    Color colorDeplacement = new Color(0.5f, 0.5f, 0.5f, 1f); // couleur grise
    Color colorUniteSelec = new Color(1f, 0.92f, 0.016f, 1f); // couleur jaune

    Vector2[] zone;
    Vector2[] zoneUniteSelection;
    Vector2[] chemin;

    Vector3 positionImagePointeur;

    GameObject uniteOver;
    GameObject uniteSelection;

    bool deplacementEnCours;
	bool animationDeplacement;
	
	int compteurChemin;

    void Awake()
    { 
        zone = new Vector2[100];
        zoneUniteSelection = new Vector2[100];
        chemin = new Vector2[50];

        deplacementEnCours = false;
		animationDeplacement = false;
		
		compteurChemin = 0;

        //on recupere les scripts 
        hud = GetComponent<Hud>();
        terrainStats = GetComponent<TerrainStats>();
        controls = GetComponent<Controls>();
        calculRayon = GetComponent<CalculRayon>();
        styleCase = GetComponent<StyleCase>();
        styleUnite = GetComponent<StyleUnite>();

        positionImagePointeur = pointeur.transform.position;

        //avec les transform on peut recuperer le gameobject //gameobjet = allChildren[i].gameobject;

        //on recupere tour les transform des enfant de "terrain" et "terrain" lui meme
        allChildrenTerrain = terrain.GetComponentsInChildren<Transform>();
        //on recupere tour les transform des enfant de "unités" et "unités" lui meme  
        allChildrenUnites = unites.GetComponentsInChildren<Transform>();

        //on met les game object a null
        uniteOver = null;
        uniteSelection = null;
    }

    // Update is called once per frame
    void Update()
    {
        positionImagePointeur = pointeur.transform.position;                                                // on recupere la position de la souris

        hud.affichageCaseHud(allChildrenTerrain, terrainStats, positionImagePointeur);                      //affiche la defense de la case pointé

        uniteOver = controls.uniteOver(allChildrenUnites, positionImagePointeur, uniteOver);                //on voit si une unité est survolé et la recupere

        hud.affichageUnitOver(uniteOver);                                                                   //affiche l'unité survolé

        if (Input.GetKeyDown("mouse 1"))                                                                    //clique droit affiche la zone de deplacement/attack
        {
            if (uniteOver != null && (uniteOver != uniteSelection || uniteSelection == null))
            {
                zone = calculRayon.calculRayonDeplacement(uniteOver, allChildrenTerrain, allChildrenUnites, null);
                styleCase.paintCase(allChildrenTerrain, zone, colorAttackZone);
            }
            else
            {
                styleCase.resetAllPaintCase(allChildrenTerrain);
            }
        }

        if (deplacementEnCours)
        {
            chemin = controls.cheminUnite(uniteSelection, zoneUniteSelection, chemin, positionImagePointeur);                                            //pour definir le chemin
            controls.affichageChemin(chemin);                                                               //affiche le chemin    
                
            if (Input.GetKeyDown("mouse 1") && (uniteOver == null || uniteOver == uniteSelection) && chemin[0] == new Vector2(0,0))             //efface la selection                                                     
            {
                deplacementEnCours = false;
                styleUnite.resetPaintUnite(uniteSelection);
                uniteSelection = null;
                controls.resetArrayVector2(zoneUniteSelection);
            }

            if (Input.GetKeyDown("mouse 0"))
            {
				animationDeplacement = controls.deplacementPossible(chemin, allChildrenUnites);							//verifie que le deplacement soit possible
				if(animationDeplacement)
				{
					compteurChemin = 1;
				}
            }
        }
        else
        {
            if (uniteSelection == null)                                                                         //si une unité n'est pas selec
            {
                if (Input.GetKeyDown("mouse 0"))                                                                //selectionne l'unite sur laquelle on clique
                {
                    if (uniteOver != null)
                    {
                        uniteSelection = uniteOver;                                                             //on recupere l'unite selectionné ou désélectionne
                        styleUnite.paintUnite(uniteSelection, colorUniteSelec);
                        zoneUniteSelection = calculRayon.calculRayonDeplacement(uniteSelection, allChildrenTerrain, allChildrenUnites, null);
                        styleCase.paintCase(allChildrenTerrain, zoneUniteSelection, colorDeplacement);
                    }
                }
            }
            else                                                                                                //sinon
            {
                deplacementEnCours = true;
                //afficher stats abregé de l'unite selec
            }
        }

        /*if (Input.GetKeyDown("space"))                                                                      //deselectionne l'unite en appuyant sur espace
        {
            styleUnite.resetPaintUnite(uniteSelection);
            uniteSelection = null;
        }*/

    }
	
	void FixedUpdate()
	{
		if(compteurChemin != 0)														//deplace l'unité
		{
			compteurChemin = controls.deplacement(uniteSelection, chemin, compteurChemin);
		}
	}
}
