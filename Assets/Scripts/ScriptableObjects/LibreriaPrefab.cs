using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LibreriaPrefab")]
public class LibreriaPrefab : ScriptableObject
{

    public GameObject [] prefabs;

    public GameObject prefab
    {
        get {return prefabs[Random.Range(0,prefabs.Length)];}
    }
}
