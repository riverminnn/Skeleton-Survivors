using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string PlayerName;

    public PlayerData(Player player)
    {
        PlayerName = player.playerName;
    }
}
