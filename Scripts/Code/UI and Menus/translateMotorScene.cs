using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translateMotorScene : MonoBehaviour
{
    public Text[] texts;
    void Start()
    {
        if (PlayerPrefs.GetInt("language") == 0)
        {
            //1
            texts[0].text = "Amacımız kırmızı kralı korumak. Eğer düşmanları engelleyemezsek kırmızı kral gittikçe büyüyecek ve patlayacak.";
            //2
            texts[1].text = "Knocker objesini sağa hareket ettirmek için ekranın sağına dokun.";
            //3
            texts[2].text = "Şimdi de knocker objesini sola hareket ettirmek için ekranın soluna dokunmalısın.";
            //4
            texts[3].text = "Süper! Artık kırmızı kralı korumaya hazırsın. Hareket butonlarını kullanarak birkaç düşmanı yok edelim.";
            //5
            texts[4].text = "çok iyi gidiyorsun! Bu beyaz canlılar ise bizim dostlarımız. Onları öldürmemeyi dene çünkü onlar kırmızı kralı küçültecek.";
            //6
            texts[5].text = "Eğer kırmızı kral yeterince küçükse, sıçrama butonunu kullanarak çemberler arasında hareket edebilirsin.";
            //7
            texts[6].text = "Bir şey daha! Düşmanları kolayca yok etmek için, özel bir yetenği kullanabilirsin ama dikkatli ol çünkü her istediğinde kullanamayacaksın.";
            //8
            texts[7].text = "Ah! Neredeyse unutuyordum. Bir düşmanı uzaktan vurabilmek için kurşun butonlarını kullanabilirsin. Ufak bir ipucu: Menzilli düşmanları yok etmek için buna ihtiyacın var.";
            //9
            texts[8].text = "Ve işte başlıyoruz. Artık hazırsın.";
            //10
            texts[9].text = "Geç";



        }

        if (PlayerPrefs.GetInt("language") == 1)
        {
            //1
            texts[0].text = "Your objective is protect our red king. if any enemy hit to the king, king will grow up.if king is too big, he wil explode!";
            //2
            texts[1].text = "You can rotate the knocker clockwise, touch the  right side of the screen!";
            //3
            texts[2].text = "Great! You can rotate the knocker counterclockwise, you should touch the left side!";
            //4
            texts[3].text = "Nice! Now you are able to defend our king! Lets kill the enemy by using movement skills!";
            //5
            texts[4].text = "You are doing very well! These white creatures are our friends.Try to not kill them, because they shrink red king!";
            //6
            texts[5].text = "If king is small enough, you can jump between circles by using jump button!";
            //7
            texts[6].text = "one more thing ! For kill the enemys easily, you can use your skill. But use it carefully, because you can't use it when ever you want!";
            //8
            texts[7].text = "Ah! I Almost forgot it, for shoot the enemy, you can use this shoot buttons. Here is a trick : You can't kill the ranged enemy without shooting!";
            //9
            texts[8].text = "And here we go! you are ready now!";
            //10
            texts[9].text = "Skip";

        }

        if (PlayerPrefs.GetInt("language") == 2)
        {

            //1
            texts[0].text = "Votre objectif est de protéger notre roi rouge. si un ennemi touche le roi, le roi grandira. Si le roi est trop grand, il explosera!";
            //2
            texts[1].text = "Vous pouvez faire pivoter knocker dans le sens des aiguilles d'une montre, touchez le côté droit de l'écran!";
            //3
            texts[2].text = "Génial! Vous pouvez faire tourner knocker dans le sens antihoraire, vous devez toucher le côté gauche!";
            //4
            texts[3].text = "Agréable! Vous pouvez maintenant défendre notre roi!Tuerons l'ennemi en utilisant votre compétence!";
            //5
            texts[4].text = "Tu t'en sors très bien! Ces créatures blanches sont nos amis. Essayez de ne pas les tuer, car elles rétrécissent le roi rouge!";
            //6
            texts[5].text = "Si le roi est assez petit, vous pouvez sauter entre les cercles en utilisant le bouton de saut!";
            //7
            texts[6].text = "Encore une chose! Pour tuer les ennemis facilement, vous pouvez utiliser votre compétence.Mais utilisez-le avec précaution, car vous ne pouvez pas l'utiliser quand vous le souhaitez!";
            //8
            texts[7].text = "Ah! Je l'ai presque oublié, pour tirer sur l'ennemi, vous pouvez utiliser ces boutons de tir.Voici une astuce: vous ne pouvez pas tuer l'ennemi à distance sans tirer!";
            //9
            texts[8].text = "Allez! vous êtes prêt maintenant!";
            //10
            texts[9].text = "Passer";
        }
    }
}

