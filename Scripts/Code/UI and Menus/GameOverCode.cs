using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class GameOverCode : MonoBehaviour
{

    gameMenu gameMenu;

    private GameObject playerObject;
    private RedKing kingScript;
    private GameObject instantiateObject;
    private HighScoreScript highScoreScript;
    private GameObject adPanel;
    public Image adTime;
    private float adCoolDown = 8f;
    private MobadScript adScript;
    private int adCount;
    private bool isPlayerMadeChoice;
    private bool isAdStateFinished;
    private bool panelActivated;
    private bool isItTimeToGo;
    private bool isCountUpdated;
    void Start()
    {
        //degisim
        highScoreScript = GameObject.Find("HighScoreObject").GetComponent<HighScoreScript>();
        instantiateObject = GameObject.Find("InstantiateEnemy");
        playerObject = GameObject.FindGameObjectWithTag("Player");
        kingScript = playerObject.GetComponent<RedKing>();
        adPanel = GameObject.Find("adPanel");
        adScript = GameObject.Find("adManagerObject").GetComponent<MobadScript>();
        adPanel.SetActive(false);
        isAdStateFinished = false;
        isPlayerMadeChoice = false;
        panelActivated = false;
        isItTimeToGo = false;
        isCountUpdated = false;
        adCount = PlayerPrefs.GetInt("PlayerDontWatchTheAds");

    }

    void Update()
    {
          if(playerObject.transform.localScale.x > 0.43f)
        {
            kingScript.Die();
            ManageDieState();

        }
    }

    IEnumerator LoadScene()
    {
        instantiateObject.SetActive(false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
        instantiateObject.SetActive(true);
    }

    private void ManageDieState()
    {
        if (adScript.isAdLoaded == true)
        {
            StartCoroutine(TimeToWatchAd());
            adTime.fillAmount -= 1 / adCoolDown * Time.deltaTime;
            if (isItTimeToGo == true && isPlayerMadeChoice == false)
            {
                adPanel.SetActive(false);
                if (isCountUpdated == false)
                {
                    isCountUpdated = true;
                    adCount++;
                    PlayerPrefs.SetInt("PlayerDontWatchTheAds", adCount);
                }
                FinishTheGame();
            }
            if (kingScript.isReborned == false && panelActivated == false && isPlayerMadeChoice == false)
            {
                StartCoroutine(ActivePanel());

            }

        if(kingScript.isReborned == false && isAdStateFinished == false)
        {
            if (CrossPlatformInputManager.GetButtonDown("wantToWatch"))
            {
                isPlayerMadeChoice = true;
                adScript.ShowRewardAd();
                adPanel.SetActive(false);
                StartCoroutine(ChangeAdState());
            }
            if (CrossPlatformInputManager.GetButtonDown("dontWantToWatch"))
            {
                adCount++;
                PlayerPrefs.SetInt("PlayerDontWatchTheAds", adCount);
                adPanel.SetActive(false);
                isPlayerMadeChoice = true;
                FinishTheGame();
            }
            if (CrossPlatformInputManager.GetButtonDown("ReplayButton"))
            {
                adCount++;
                PlayerPrefs.SetInt("PlayerDontWatchTheAds", adCount);
            }
        }
        else if(isAdStateFinished == true)
        {
            FinishTheGame();
        }
        }
        else
        {
            FinishTheGame();
        }
    }

    public void FinishTheGame()
    {

        if (knocker.newEnemyCount > PlayerPrefs.GetInt("high"))
        {
            PlayerPrefs.SetInt("high", knocker.newEnemyCount);
            highScoreScript.AddNewHighScore(PlayerPrefs.GetString("PlayerID"), knocker.newEnemyCount);

        }
        gameMenu.scoreCntr = PlayerPrefs.GetInt("high");
        knocker.newEnemyCount = 0;
        StartCoroutine(LoadScene());
    }

    IEnumerator TimeToWatchAd()
    {
        yield return new WaitForSeconds(8);
        isItTimeToGo = true;
    }
    IEnumerator ChangeAdState()
    {
        yield return new WaitForSeconds(5);
        isAdStateFinished = true;
    }

    IEnumerator ActivePanel()
    {
        panelActivated = true;
        yield return new WaitForSeconds(1);
        adPanel.SetActive(true);

    }

}
