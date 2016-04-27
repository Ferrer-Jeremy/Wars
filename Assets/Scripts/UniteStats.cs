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

    public int vie = 100;
    public int move = 3;
    public int moveRestant = 3;
    public int ammo = 0;
    public int vision = 2;
    public int rangeMin = 1;
    public int rangeMax = 1;
    public string moveType = "pieds";
    public int cost = 1000;
    public int defenseCaseActuel = 0;
    public int defenseCaseFuture = 0;
    public int defense1 = 0;
    public int defense1SuivantCase = 0;
    public int defense2 = 0;
    public int defense2SuivantCase = 0;
    public int attaque1 = 0;
    public int attaque2 = 0;
    public int typeAttaque1 = 0;
    public int typeAttaque2 = 0;
    public bool deplacer = false;      //true si l'unite a ete déplacé



    //le calcul de la defense suivant la defanse de la case en entrée 

    void defenseAvecCase(int defenseCase)
    {
        defense1SuivantCase = defense1 + defenseCase;
        defense2SuivantCase = defense2 + defenseCase;

    }

}
