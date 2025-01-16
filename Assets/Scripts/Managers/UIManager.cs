using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : LazyLoadManager<UIManager>
{
   [SerializeField] private Slider healtBar;
   public static TMP_Text scoreText;

   private void OnEnable() 
   {
        //subscriber
        Player.OnTakeDamage += ChangeHealthValue;
        Player.OnGetCoin += ChangeScoreText;
   }

    public void ChangeHealthValue(float health)=> healtBar.value = health;
    public void ChangeScoreText(int score)=> scoreText.text = "Coins:" +  score.ToString();
    private void OnDisable() 
    {
        //Unsubscriber
        Player.OnTakeDamage -= ChangeHealthValue;
        Player.OnGetCoin -= ChangeScoreText;
    }
}
