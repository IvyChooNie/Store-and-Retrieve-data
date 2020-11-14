using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;

    private System.Random random = new System.Random();

    public static int playerScore;
    public static string playerName;

    User user = new User();

    private void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Score: " + playerScore;
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
        PostToDatabase();
    }

    public void OnGetScore()
    {
     RetrieveFromDatabase();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + user.userScore;
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://fyp-testing1.firebaseio.com/" + playerName + ".json", user);
    }

    private void RetrieveFromDatabase() {
        RestClient.Get<User>("https://fyp-testing1.firebaseio.com/" + nameText.text + ".json").Then(response =>
        {
            user = response;
            UpdateScore();
        });
    }
}
