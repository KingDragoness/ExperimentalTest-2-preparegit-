using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{

    public Faction.Player faction;
    public Sprite c;
    public Transform target;
    public float speed = 10;
    [Range(2,16)] public int lineOfSight = 9;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (target != null)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
