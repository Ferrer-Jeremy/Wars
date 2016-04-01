using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Hud : MonoBehaviour {

    public GameObject textDefense;
    public GameObject textUniteOver;
    public GameObject imageUniteOver;

   
    Text textPanelDefense;  //on cree un game component text 
    Text textPanelUniteOver;

    Image imagePanelUniteOver;

    int def;
    string defense;

    void Awake()
    {
        textPanelDefense = textDefense.GetComponent<Text>();
        textPanelUniteOver = textUniteOver.GetComponent<Text>();
        imagePanelUniteOver = imageUniteOver.GetComponent<Image>();
    }

    public void affichageCaseHud(Transform[] allChildren, TerrainStats terrainStats, Vector3 positionImagePointeur) //affiche les stats de la case
    {
        foreach (Transform child in allChildren)                                    //on fait une boucle avec chaque transform
        {
            if (child.position == positionImagePointeur)                            //si le transform corespond a la position du pointeur
            {
                //on cherche le bon tag ca serait peut etre mieux avec un for et alltags
                //si on trouve le bon on crée un game objet pour afficher les stats du terrain
                if (child.tag == "Mer")
                {
                    def = terrainStats.merDef;
                }
                else if (child.tag == "Plage")
                {
                    def = terrainStats.plageDef;
                }
                else if (child.tag == "Foret")
                {
                    def = terrainStats.foretDef;
                }
                else if (child.tag == "Montagne")
                {
                    def = terrainStats.montagneDef;
                }
                else if (child.tag == "Route")
                {
                    def = terrainStats.routeDef;
                }
                else if (child.tag == "Ville")
                {
                    def = terrainStats.villeDef;
                }
                else if (child.tag == "Plaine")
                {
                    def = terrainStats.plaineDef;
                }
                else if (child.tag == "Riviere")
                {
                    def = terrainStats.riviereDef;
                }
                else if (child.tag == "Recif")
                {
                    def = terrainStats.recifDef;
                }

                defense = "Defense : " + def;
                textPanelDefense.text = defense; // on met a jour le text
            }
        }
    }

    public void affichageUnitOver(GameObject uniteOver)                 // affiche les stats de l'unité sur laquelle on passe
    {
        if (uniteOver != null) //on affiche le descriptif
        {
            imagePanelUniteOver.enabled = true;
            imagePanelUniteOver.sprite = uniteOver.GetComponent<SpriteRenderer>().sprite; //on recupere le sprite de l'unité over et l'affiche  TROUVER UNE MEILLEURE FACOB QUE GET COMPONENT (LENT)
            textPanelUniteOver.text = "";
        }
        else //on efface tout
        {
            textPanelUniteOver.text = "Aucune unite";
            imagePanelUniteOver.enabled = false;
        }
    }
}
