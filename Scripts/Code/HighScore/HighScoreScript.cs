using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    /* https://www.youtube.com/watch?v=KZuqEyxYZCc
     * Bizim www değişkenimiz database değişkenlerini içinde tutan bir değişken. Bu metodlar IENumerator olduğu için
     * diğer kodlardan çağrılamaz. Bu yüzden bu metodları çağırabileceğimiz basit public metodlar oluştururuz.
     * Sitemiz : http://dreamlo.com/lb/jVvrWA6oF0acZhhq4dqangvPYKpMzVVkKJMY0ZpiEK5A
     * */

    const string privateCode = "jVvrWA6oF0acZhhq4dqangvPYKpMzVVkKJMY0ZpiEK5A";
    const string publicCode = "5f4bdaadeb371809c4ffb7fc";
    const string webURL = "http://dreamlo.com/lb/";


    public Highscore[] highscoresList;
    DisplayScores highscoresDisplay;

    private void Start()
    {
        highscoresDisplay = GetComponent<DisplayScores>();
    }


    public void AddNewHighScore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    public void DownloadPersonalScore()
    {
        StartCoroutine("DownloadScoreOfThePlayer");
    }
    public void DownloadHighScore()
    {
        // argüman almayan numeratorler string şeklinde çağırılabilir.
        StartCoroutine("DownloadHighscoresFromDatabase");
    }
    // private code kısmından bize ait url ye gidip oradaki tabloya add komutu ile yeni high score eklenir.
    // Hata durumunda www.error değişkeninin içine otomatik yazılır

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Succesful!");
        }
        else
        {
            print("Error Uploading :" + www.error);
        }
    }

    // urlden alınan www.text değişkeninin içinde bütün scoreboard bulunur. eğer hatasız indirdiysek basabiliriz.
    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Download Succesfull!");
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
            highscoresDisplay.OrderOfPlayer(highscoresList);

        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }



    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }

    public struct Highscore
    {
        public string username;
        public int score;

        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }

    }


}
