using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translateMotor : MonoBehaviour
{

    public Text[] texts;
    int cntr = 0;
    public Sprite[] flags;
    public GameObject button;
    public GameObject buuttonIn;

    public Text[] velocity;


    public void translator()
    {
        button.GetComponent<Image>().sprite = flags[PlayerPrefs.GetInt("language")];

        if (PlayerPrefs.GetInt("language") == 0)
        {
            texts[0].text = "Takma Ad Giriniz";
            texts[1].text = "KNOCKER'e Hoşgeldin !";
            texts[2].text = "En Az 3 Karakter Gir";

            //redking
            texts[3].text = "O bir kahraman. Evrenin karanlık güçleriyle mücadelesi nesiller boyudur devam ediyor!";
            //white
            texts[4].text = "Özü hayat ağacından olan bu eski dostun korumasına ihtiyacımız var.";
            //yuvarlak
            texts[5].text = "okyanusun derinliklerinde evrildi. Tehlikeli ve pis. ona bulaşmamak en iyisi...";
            //diken
            texts[6].text = "Bu vahşi yaratığın kahvaltısı kara madde...";
            //virus
            texts[7].text = "bir uzaylı? bir hayalet? uzaylı bir hayalet? Seni yakaladığında ne yapacağını kimse bilmiyor.";
            //tukuren
            texts[8].text = "Petrolden hortladığı dedikoduları var. Bu acımasız haydut sana asit tükürüyor. Ona karşı çok dikkatli ol.";
            //karakter
            texts[9].text = "KARAKTERLER";
            //dil seçeneği
            texts[10].text = "Dil Seçeneği:";
            //leaderBoard
            texts[11].text = "LİDER TABLOSU";
            //highScore
            texts[12].text = "En Yüksek Skor: "+ PlayerPrefs.GetInt("high");
            //about us
            texts[13].text = "HAKKIMIZDA";
            //buutons
            texts[14].text = "BUTONLAR";
            //skil
            texts[15].text = "Bu özel yetenek tuşu sayesinde bir süreliğine 2 knocker objesi kullanabilirsiniz.";
            //shot
            texts[16].text = "Düşmanları uzaktan vurmak için knocker objesinin kurşun özelliğini kullanmanızı sağlar. Bazı düşmanları yok edebilmek için bu özelliiği kullanmak şarttır.";
            //jump
            texts[17].text = "Knocker objesini 2 çember arasında sıçratabilmek için bu butonu kullanabilirsiniz. Doğru kullanılması halinde büyük avantajlar sağlar.";
            //leader
            texts[18].text = "LİDER TABLOSU";
            //leader
            texts[19].text = "LİDER TABLOSU";
            //iyilestirme
            texts[20].text = "İYİLEŞTİRME";
            //rate
            texts[21].text = "Bizi Değerlendir!";
            //support
            texts[22].text = "Oyunumuzu oynarken eğleniyorsan, bir dakikanı ayırıp bizi puanlar mısın? Desteğin için teşekkür ederiz.";
            // right left
            texts[23].text = "Ekranın sağına ve soluna dokunarak knocker objesini hareket ettirebilirsiniz.";
            //velocity and damage
            for (int i = 0; i < velocity.Length; i++)
            {
                if (i % 2 == 0)
                {
                    velocity[i].text = "HIZ";
                }
                if(i%2 == 1)
                {
                    velocity[i].text = "HASAR";
                    if (i == 7)
                    {
                        velocity[i].text = "HASAR/SN";
                    }
                }
            }


        }

        if (PlayerPrefs.GetInt("language") == 1)
        {

            texts[0].text = "Enter Nickname";
            texts[1].text = "Welcome to KNOCKER !";
            texts[2].text = "enter at least 3 characters";

            //redKing
            texts[3].text = "He is a hero. Struggling with dark souls of universe. His fight continues for generations!";
            //white
            texts[4].text = "Her fountain is the tree of life. She is here to give you mother protection.";
            //blackCircle
            texts[5].text = "Evolved in deep ocean. Dangerous, filthy. Better not to mess with!";
            //diken spawn
            texts[6].text = "This savage monstrous creature eats dark matter for breakfast!";
            //topak virus
            texts[7].text = "An alien? A ghost? An alien ghost? No one knows what he's going to do when he catches you!";
            //spitle tukuren
            texts[8].text = "It has been gossiped that he was emerged from petroleum. This brutal bandit spits acid on you! Be very careful with this demon.";
            //characters
            texts[9].text = "CHARACTERS";
            //dil
            texts[10].text = "Language Option:";
            //leader
            texts[11].text = "LEADERBOARD";
            //score
            texts[12].text = "High Score: "+ PlayerPrefs.GetInt("high");
            //about us
            texts[13].text = "ABOUT US";
            //buutons
            texts[14].text = "BUTTONS";
            //skil
            texts[15].text = "With this special skill, you can use 2 knockers.";
            //shot
            texts[16].text = "Allows you to use the knocker item's projectile feature to hit enemies from afar. It is essential to use this feature to destroy some enemies.";
            //jump
            texts[17].text = "You can use this button to jump the Knocker between 2 circles. It provides great advantages if used correctly.";
            //leader
            texts[18].text = "LEADERBOARD";
            //leader
            texts[19].text = "LEADERBOARD";
            //iyilestirme
            texts[20].text = "HEALİNG";
            //rate
            texts[21].text = "Rate Us!";
            //support
            texts[22].text = "Would you take a moment and rate us if you have fun with our game? Thanks for your support.";
            // right left
            texts[23].text = "You can move the knocker object by touching the left and right of the screen.";

            //velocity and damage
            for (int i = 0; i < velocity.Length; i++)
            {
                if (i % 2 == 0)
                {
                    velocity[i].text = "SPEED";
                }
                if (i % 2 == 1)
                {
                    velocity[i].text = "DAMMAGE";
                    if (i == 7)
                    {
                        velocity[i].text = "DAMMAGE/SN";
                    }
                }
            }


        }

        if (PlayerPrefs.GetInt("language") == 2)
        {

            texts[0].text = "Entrez le Surnom";
            texts[1].text = "Bienvenue à KNOCKER";
            texts[2].text = "entrez au moins 3 caractères";

            //redKing
            texts[3].text = "C'est un héros. Lutter contre les âmes sombres de l'univers.Son combat continue pendant des générations!";
            //white
            texts[4].text = "Sa fontaine est l'arbre de vie. Vous avez besoin de son protectorat. C'est une vieille amie.";
            //black circle
            texts[5].text = "évolué dans les profondeurs de l'océan.. Dangereux, sale. Mieux vaut ne pas jouer avec lui!";
            //spawn
            texts[6].text = "Cette créature monstrueuse sauvage mange de la matière noire au petit-déjeuner!";
            //virus
            texts[7].text = "Un alien? Un fantôme? Un fantôme extraterrestre? Personne ne sait ce qu'il va faire quand il vous surprendra!";
            //spitle
            texts[8].text = "On a dit qu'il était sorti du pétrole. Ce bandit brutal crache de l'acide sur vous! Soyez très prudent avec ce démon.";
            //character
            texts[9].text = "LES CARACTERES";
            //dil
            texts[10].text = "Option de Langue: ";
            //leader
            texts[11].text = "CLASSEMENT";
            //Score
            texts[12].text = "Score élevé: "+ PlayerPrefs.GetInt("high");
            //about us
            texts[13].text = "A PROPOS DE NOUS";
            //buutons
            texts[14].text = "BOUTONS";
            //skil
            texts[15].text = "Avec cette compétence spéciale, vous pouvez utiliser 2 knocker.";
            //shot
            texts[16].text = "Vous permet d'utiliser la fonction de balle de knocker pour frapper les ennemis de loin. Il est essentiel d'utiliser cette fonctionnalité pour détruire certains ennemis.";
            //jump
            texts[17].text = "Vous pouvez utiliser ce bouton pour sauter l'objet Knocker entre 2 cercles. Il offre de grands avantages s'il est utilisé correctement.";
            //leader
            texts[18].text = "CLASSEMENT";
            //leader
            texts[19].text = "CLASSEMENT";
            //iyilestirme
            texts[20].text = "GUÉRISON";
            //rate
            texts[21].text = "évaluez nous!";
            //support
            texts[22].text = "Pourriez-vous prendre un moment et nous évaluer si vous vous amusez avec notre jeu? Merci pour votre aide.";
            // right left
            texts[23].text = "Vous pouvez déplacer knocker en touchant la gauche et la droite de l'écran.";

            //velocity and damage
            for (int i = 0; i < velocity.Length; i++)
            {
                if (i % 2 == 0)
                {
                    velocity[i].text = "VİTESSE";
                }
                if (i % 2 == 1)
                {
                    velocity[i].text = "DOMMAGE";
                    if (i == 7)
                    {
                        velocity[i].text = "DOMMAGE/SN";
                    }
                }
            }

        }
    }

    public void selectLanguage(int selectedButtonCntr)
    {
        if(selectedButtonCntr == 0)
        {
            cntr++;
            if (cntr == 3)
            {
                cntr = 0;
            }
            PlayerPrefs.SetInt("language", cntr);
            button.GetComponent<Image>().sprite = flags[cntr];
            buuttonIn.GetComponent<Image>().sprite = flags[cntr];
            translator();
        }
    }
}
