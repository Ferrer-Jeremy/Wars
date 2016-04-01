using UnityEngine;
using System.Collections;

public class UniteStats : MonoBehaviour{

    /* moveType :
    1 = pieds
    2 = pieds surentrainé
    3 = roues
    4 = chenilles
    5 =
    6 =
    7 =
    8 =
    */

    /* attaque type :
    1 = mitraillette
    2 = rocket
    3 = rocket air sol
    4 = chenilles
    5 =
    6 =
    7 =
    8 =
    */

    // faire de tout les nombres des cantaines max 100 pour eviter les arondissements lors des calculs de degats en combat

    // il faut une valeur de defense pour chaque type d'attaque (rocket, mitraillettes,...)

    int move = 3;
    int ammo = 0;
    int vision = 2;
    int rangeMin = 1;
    int rangeMax = 1;
    int moveType = 1;
    int cost = 1000;
    int defenseCaseActuel = 0;
    int defenseCaseFuture = 0;
    int defense1 = 0;
    int defense1SuivantCase = 0;
    int defense2 = 0;
    int defense2SuivantCase = 0;
    int attaque1 = 0;
    int attaque2 = 0;
    int typeAttaque1 = 0;
    int typeAttaque2 = 0;



    //le calcul de la defense suivant la defanse de la case en entrée 

    void defenseAvecCase(int defenseCase)
    {
        defense1SuivantCase = defense1 + defenseCase;
        defense2SuivantCase = defense2 + defenseCase;

    }




    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
