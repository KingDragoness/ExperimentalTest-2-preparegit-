using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Faction
{
    public enum Player
    {
        Player1,
        Player2,
        Player3,
        Player4,
        Player5,
        Player6,
        Player7,
        Player8
    }

    public Color32 GetColor_FOWValue(Player faction)
    {
        if (faction == Player.Player1)
        {
            return new Color32(255, 0, 0, 255);
        }
        else if (faction == Player.Player2)
        {
            return new Color32(250, 0, 0, 255);
        }
        else if (faction == Player.Player3)
        {
            return new Color32(245, 0, 0, 255);
        }
        else if (faction == Player.Player4)
        {
            return new Color32(240, 0, 0, 255);
        }
        else if (faction == Player.Player5)
        {
            return new Color32(235, 0, 0, 255);
        }
        else if (faction == Player.Player6)
        {
            return new Color32(230, 0, 0, 255);
        }
        else if (faction == Player.Player7)
        {
            return new Color32(225, 0, 0, 255);
        }
        else if (faction == Player.Player8)
        {
            return new Color32(220, 0, 0, 255);
        }

        return new Color32(255, 0, 0, 255);

    }
}