using UnityEngine;
using System.Collections;
using System;
using System.IO;

[Serializable]
public class MapJson : MonoBehaviour
{
    private string nom;
    private int largeur;
    private int longeur;
    private string[,] cases;
    private string path = @"c:\temp\";

    public MapJson (string nom, int largeur, int longeur, string[,] cases)
    {
        this.nom = nom;
        this.largeur = largeur;
        this.longeur = longeur;
        this.cases = cases;
    }

    public void enregistrer(MapJson mapJson)
    {
        string json = JsonUtility.ToJson(mapJson);
        using (StreamWriter sw = File.CreateText(path+nom+".json"))
        {
            sw.WriteLine(json);
        }
    }

    /*MapJson charger()
    {
       // return JsonUtility.FromJson<MyClass>();
    }*/
}