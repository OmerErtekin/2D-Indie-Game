using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    private bool isActived = false;
    private bool isStarted = false;
    private RedKing kingScript;
    private int jumpCounter;
    private GameObject highScoreObject;
    private GameObject adObject;
    private GameObject gameOverObject;
    private GameObject whiteSquares;
    private GameObject instantiateEnemys;

    private void Start()
    {
        highScoreObject = GameObject.Find("HighScoreObject");
        adObject = GameObject.Find("adManagerObject");
        gameOverObject = GameObject.Find("GameOver");
        kingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<RedKing>();
        whiteSquares = GameObject.Find("tutorialWhitePackage");
        instantiateEnemys = GameObject.Find("InstantiateEnemy");
        whiteSquares.SetActive(false);
        jumpCounter = 0;
        if(PlayerPrefs.GetInt("isTutorialPlayed") == 0)
        {
            instantiateEnemys.SetActive(false);
        }
    }


    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("SkipTutorial"))
        {
            Debug.Log("bastı");
            PlayerPrefs.SetInt("isTutorialPlayed", 1);
            knocker.newEnemyCount = 0;
            SceneManager.LoadScene(1);
        }
        /* Kullanıcı her bir şartı tek tek sağlamak zorundadır. Öncelikle sağa dönmesi gerekir. Sağa dönmeyi başardıktan sonra sola dönme tutorialine geçiş yapabilir. Burada hazırlayacağımız
         * yazı yönergeleri ve birer parmak işareti ile nereye basması gerektiğini söylersek kullanıcı ne yapması gerektiğini anlayacaktır.Bütün tutoriali bitirdikten sonra playerprefs te tutulan
         * daha önce tutorial oynadı mı değişkeni değiştirilir. Playerprefs her kullanıcı için özeldir ve bir kez değiştiğinde tekrar aksi belirtilmedikçe o halde kalır.
         */
        if (PlayerPrefs.GetInt("isTutorialPlayed") == 0)
        {

            highScoreObject.SetActive(false);
            gameOverObject.SetActive(false);
            adObject.SetActive(false);
            highScoreObject.SetActive(false);
            popUps[15].SetActive(true);
            if (popUpIndex == 0)
            {
                popUps[0].SetActive(true);
                StartCoroutine(WaitAndChange());
            }
            if (popUpIndex == 1)
            {   // playerın sağa gitmeyi öğrendiği yer
                // text : Knockerı sağa döndürmek için ekranın sağ tarafına dokun!
                popUps[0].SetActive(false);
                popUps[1].SetActive(true);
                popUps[13].SetActive(true);
                if (CrossPlatformInputManager.GetButtonDown("Right"))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 2)
            {
                popUps[13].SetActive(false);
                popUps[14].SetActive(true);
                popUps[1].SetActive(false);
                popUps[2].SetActive(true);
                // text : Harika ! Şimdi sola dönmek için ekranın soluna dokun!
                if (CrossPlatformInputManager.GetButtonDown("Left"))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 3)
            { // playerın düşman vurduğu yer
              // text : Çok iyi! Şimdi knockerı kullanarak düşmanı öldür!
                popUps[14].SetActive(false);
                popUps[2].SetActive(false);
                popUps[3].SetActive(true);
                instantiateEnemys.SetActive(true);
                if (knocker.newEnemyCount != 0)
                {
                    instantiateEnemys.SetActive(false);
                    popUpIndex++;
                }
                
            }
            else if (popUpIndex == 4)
            {
                // text : İşte Böyle! Beyaz kareleri öldürmemeye dikkat et! Onlar seni zayıflatarak hayatta tutacak!
                // playerın beyaz kareleri tanıdığı yer
                kingScript.isAlive = false;

                if (isActived == false)
                    {
                        isActived = true;
                        popUpIndex++;
                    }
                StartCoroutine(ActiveWhiteSquares());
                
            }
            else if (popUpIndex == 5)
            {// içeri dışarı zıplamayı öğrendiği yer
             // text: Şimdi daha fazla hareket zamanı! Halkalar arasında geçiş yapmak için zıplama butonuna dokun!
                kingScript.isAlive = true;
                if (CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    jumpCounter++;
                }
                if(jumpCounter >= 2)
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 6)
            {// skill kullanmayı öğrendiği yer
             // text : Son bir şey daha ! Yeteneklerini kullanarak düşmanalrı daha kolay öldürebilirsin. Ancak dikkat etmelisin. Yeteneklerin bir bekleme süresi vardır!
                popUps[5].SetActive(false);
                popUps[9].SetActive(false);
                popUps[6].SetActive(true);
                popUps[10].SetActive(true);
                if (CrossPlatformInputManager.GetButtonDown("Skill"))
                {
                    popUpIndex++;
                }
            }
            else if(popUpIndex == 7)
            {
                // text : ah! neredeyse unutuyordum ! Düşmanları uzaktan vurmak için shoot yeteneğini kullan.
                popUps[6].SetActive(false);
                popUps[7].SetActive(true);
                popUps[10].SetActive(false);
                popUps[11].SetActive(true);
                popUps[12].SetActive(true);

                if(kingScript.shootedEnemy > 1)
                {
                    popUpIndex = 8;
                }
                

            }
            else if (popUpIndex == 8)
            { // text : İşte bu kadar! Artık oynamaya hazırsın!
                popUps[6].SetActive(false);
                popUps[7].SetActive(false);
                popUps[8].SetActive(true);
                popUps[11].SetActive(false);
                popUps[12].SetActive(false);
                StartCoroutine(LoadNewScene());
                
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }



        IEnumerator LoadNewScene()
        {
            yield return new WaitForSeconds(4f);
            // player prefsten tutorial yaptı mı bool unu değiştir
            popUps[15].SetActive(false);
            knocker.newEnemyCount = 0;
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("isTutorialPlayed", 1);
        }

        
    }

    IEnumerator ActiveWhiteSquares()
    {
        popUps[3].SetActive(false);
        popUps[4].SetActive(true);
        whiteSquares.SetActive(true);
        yield return new WaitForSeconds(6f);
        instantiateEnemys.SetActive(true);
        popUps[4].SetActive(false);
        popUps[5].SetActive(true);
        popUps[9].SetActive(true);

    }

    IEnumerator WaitAndChange()
    {
        yield return new WaitForSeconds(10f);
        if (isStarted == false)
        {
            isStarted = true;
            popUpIndex++;
        }
    }
    }

