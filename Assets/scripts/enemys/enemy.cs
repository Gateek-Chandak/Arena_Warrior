using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName ="Enemy")]
public class enemy : ScriptableObject
{

    [Header("VARIABLESz")]
    public float damage;
    public int scoreToGive;
    public string typeOfEnemy;

    [Header("EFFECTS")]
    public GameObject hitEffect;
    public GameObject deathEffect;
}
