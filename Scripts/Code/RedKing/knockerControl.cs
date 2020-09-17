using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class knockerControl : MonoBehaviour
{


    private GameObject outsideCenter;
    private GameObject outsideCenter2;
    private GameObject knocker0;
    private GameObject knocker1;
    private GameObject playerObject;

    private int selectedCircle = 1;
    public Button jumpButton;
    public Image skillCoolDownImage;

    private float skillCoolDown = 15f;
    private float lastSkillTime = 0;
    private bool canJump = true;
    public float turnSpeed = 7.5f;
    public float turnSpeed_2 = -7.5f;
    private float turnButtonSpeedTime = 0;
    private float turnButtonSpeedTime_2 = 0;
    private bool turnTimeCntrl = false;
    private bool turnTimeCntrl_2 = false;
    private bool isSkillCoolDown = false;
    private bool isSkillUsed = false;
    public AudioSource skillSound;

    private void Start()
    {
        skillCoolDownImage.fillAmount = 0;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        knocker0 = GameObject.Find("vur_0");
        knocker1 = GameObject.Find("vur_1");
        outsideCenter = GameObject.Find("OutsideCenter");
        outsideCenter2 = GameObject.Find("OutsideCenter2");
        knocker1.SetActive(false);  
     }
    private void Update()
    {
        Shoot();
        Jump();
        if(Time.time > lastSkillTime)
        {
            skillCoolDownImage.fillAmount = 0;
        }
        if (CrossPlatformInputManager.GetButtonDown("Skill") && Time.time > lastSkillTime)
        {
            skillSound.Play();
            // skillere bekleme süresi eklediğimiz yer. geçen zaman + bekleme süresi en son skill kullanılan zamandan büyük değilse demek ki bekleme süresi kadar zaman geçmemiştir. O olmadığı sürece kullanılamaz.
            lastSkillTime = Time.time + skillCoolDown;
            StartCoroutine(Skill());

        }
        if (isSkillUsed == true)
        {
            SkillCoolDownCounter();
        }

        if(playerObject.GetComponent<RedKing>().isAlive == false)
        {
            knocker0.SetActive(false);
            knocker1.SetActive(false);
        }
        else
        {
            knocker0.SetActive(true);
        }

    }

    void turnButtonSensibilisation()
    {
        // kullanıcı butona çok kısa süre bas çek yaptığında hassas bir hareket yapmak istiyor olabilir. Özellikle shoot atarken. Hem uzağa gitmek istediğinde onu yavaşlatmayacak hem de kısa menzilli dönüşler yapmasına
        //el verecek şekilde bir hassasiyet ayarı ypatık. Kullanıcı 0.3 saniyeden az bastığı taktirde yavaşça dön. Ama süre bunu geçerse hızlıca dönmeye devam et.
        if (turnTimeCntrl)
        {
            turnButtonSpeedTime += Time.deltaTime;
            if (turnButtonSpeedTime>0.33f)
            {
                turnSpeed = -7.5f;   
            }
            if (turnButtonSpeedTime < 0.33f)
            {
                turnSpeed = -2.5f;
            }
        }
        else if (!turnTimeCntrl)
        {
            turnButtonSpeedTime = 0;
        }

        if (turnTimeCntrl_2)
        {
            turnButtonSpeedTime_2 += Time.deltaTime;
            if (turnButtonSpeedTime_2 > 0.33f)
            {
                turnSpeed_2 = 7.5f;
            }
            if (turnButtonSpeedTime_2 < 0.33f)
            {
                turnSpeed_2 = 2.5f;
            }
        }
        else if (!turnTimeCntrl_2)
        {
            turnButtonSpeedTime_2 = 0;
        }

    }
    void FixedUpdate()
    {

        if (CrossPlatformInputManager.GetButton("Right") || Input.GetKey(KeyCode.RightArrow))
        {
            turnTimeCntrl = true;
            turnButtonSensibilisation();
            transform.Rotate(0, 0, turnSpeed);
            turnTimeCntrl_2 = false;
            //Debug.Log(turnSpeed);
        }
        else turnTimeCntrl = false;
        turnButtonSensibilisation();


        if (CrossPlatformInputManager.GetButton("Left") || Input.GetKey(KeyCode.LeftArrow))
        {
            turnTimeCntrl_2 = true;
            turnButtonSensibilisation();
            transform.Rotate(0, 0, turnSpeed_2);
            turnTimeCntrl = false;
        }
        else turnTimeCntrl_2 = false;
        turnButtonSensibilisation();


    }

    void Jump()
    {
        // Her knockerın etrafında görünmez olarak dönen bir dış merkez objesi oluşturduk. Eğer mevcut halka 2 ( yani içteki) dışarıdaki o merkeze doğru belli bir miktar git. Eğer 1(içerideki) ise merkeze doğru git.
        if (playerObject.transform.localScale.x >= 0.30)
        {
            canJump = false;
            if (selectedCircle == 2)
            {
                // eğer 0.70 olduğunda hala içerideki halkadaysa dışa zorla geçip artık halka seçmeyi devredışı bıraktırdım.
                JumpOut();

            }
            return;
        }
        else canJump = true;

        if(canJump == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.A))
            {
                if (selectedCircle == 1)
                {
                    JumpIn();
                    return;
                }
                if (selectedCircle == 2)
                {
                    JumpOut();
                    return;
                }
            }
        }
    }

    void Shoot()
    {
        if (CrossPlatformInputManager.GetButtonDown("shot"))
        {
            InstantiateProjectile.projectileCntrl = true;
        }
    }

    IEnumerator Skill()
    {
        isSkillUsed = true; // cool down fotoğrafını başlatmak için
        knocker1.SetActive(true);
        yield return new WaitForSeconds(4f);
        knocker1.SetActive(false);
        yield return new WaitForSeconds(11f);
        isSkillUsed = false;

    }

    private void SkillCoolDownCounter()
    {
        // Anlamak için : https://www.youtube.com/watch?v=wtrkrsJfz_4
        if (isSkillCoolDown == false && isSkillUsed == true)
        {
            skillCoolDownImage.fillAmount = 1f;
            isSkillCoolDown = true;
        }

        if (isSkillCoolDown == true)
        {
            skillCoolDownImage.fillAmount -= 1 / skillCoolDown * Time.deltaTime;
            if (skillCoolDownImage.fillAmount <= 0)
            {
                skillCoolDownImage.fillAmount = 0;
                isSkillCoolDown = false;
            }
        }
    }
    
    private void JumpIn()
    {
        knocker0.transform.position = Vector2.MoveTowards(knocker0.transform.position, new Vector2(0, 0), 1f);
        knocker1.transform.position = Vector2.MoveTowards(knocker1.transform.position, new Vector2(0, 0), 1f);
        selectedCircle = 2;
    }


    private void JumpOut()
    {
        knocker0.transform.position = Vector2.MoveTowards(knocker0.transform.position, outsideCenter.transform.position, 1f);
        knocker1.transform.position = Vector2.MoveTowards(knocker1.transform.position, outsideCenter2.transform.position, 1f);
        selectedCircle = 1;
        // 2. knocker aktif olduğu durumda sürekli son görülmesi takip edilir.
    }

    
}
