using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{

    public Faction.Player faction;
    public Sprite c;
    [Range(2,16)] public int lineOfSight = 9;

    private void Awake()
    {
        
    }
}
