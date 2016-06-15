using UnityEngine;
using System.Collections;
using System;
using System.IO;


[Serializable]
public class MapJson : MonoBehaviour
{
    public string nom;
    public int largeur;
    public int longeur;
    public string[,] cases;
    private string path = @"c:\temp\"; 

    public void initObject (string nom, int largeur, int longeur, string[,] cases)
    {
        this.nom = nom;
        this.largeur = largeur;
        this.longeur = longeur;
        this.cases = cases;     
    }

    public void enregistrer(string s)
    {
        using (StreamWriter sw = File.CreateText(this.path+this.nom+".json"))
        {
            sw.WriteLine(s);
            Debug.Log("enregistrement reussi");
        }
    }

    /*MapJson charger()
    {
       // return JsonUtility.FromJson<MyClass>();
    }*/
}