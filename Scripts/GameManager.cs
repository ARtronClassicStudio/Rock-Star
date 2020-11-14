using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player",menuName ="Player Data",order =1)]
[System.Serializable]
public class GameManager : ScriptableObject
{
    public int HealthPlayer;
    public float SpeedRock;
    public int Point;
    public bool RunGun = true;



}
