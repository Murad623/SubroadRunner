using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagers : LazyLoadManager<SaveManagers>
{
    private void OnEnable() {
        Player.score=PlayerPrefs.GetInt("coinCount");
        UIManager.scoreText.text = "Coins:" +  Player.score.ToString();
    }
    private void OnDisable() 
    {
        PlayerPrefs.SetInt("coinCount",Player.score);
    }
}
