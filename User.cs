using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class User 
{
    public string userName;
    public int userScore;

    public User()
    {
        userScore = PlayerScore.playerScore;
        userName = PlayerScore.playerName;
    }
}
