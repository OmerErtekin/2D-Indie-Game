using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour
{
    public Text[] highscoreText;
    HighScoreScript highscoreManager;

    public Text userScore;
    string playerName;
    int playerOrder;
    public Button refreshButton;



    void Start()
    {
        //playerOrder = 0;
        playerName = PlayerPrefs.GetString("PlayerID");
        highscoreManager = GetComponent<HighScoreScript>();
        for(int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ".Fetching...";
        }
        StartCoroutine(RefreshHighScores());
    }

    public void RefreshTable()
    {
        highscoreManager.DownloadHighScore();
        StartCoroutine(ChangeButtonState());
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ".Refreshing...";
        }
    }


    public void OnHighscoresDownloaded(HighScoreScript.Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". ";
            if (i < highscoreList.Length)
            {
                highscoreText[i].text += highscoreList[i].username + " : " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighScores()
    {
        while (true)
        {
            highscoreManager.DownloadHighScore();
            yield return new WaitForSeconds(30);
        }
    }

    IEnumerator ChangeButtonState()
    {
        refreshButton.interactable = false;
        yield return new WaitForSeconds(1);
        refreshButton.interactable = true;
    }

    public void OrderOfPlayer(HighScoreScript.Highscore[] playerList)
    {

        for (int i = 0; i < playerList.Length; i++)
        {
            if (string.Equals(playerName, playerList[i].username))
            {
                playerOrder = i;
                //Debug.Log(playerList[i].username + " sıralaması : " + playerList[i].score);
                userScore.text = (playerOrder + 1).ToString() +". " + playerName + ": " + playerList[i].score;
                
            }
        }
        
    }
}
