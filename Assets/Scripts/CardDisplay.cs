
using UnityEngine;

using TMPro;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    public GameObject statsCard;

    public TMP_Text npcName;

    public TMP_Text npcCatchPhrase;

    public TMP_Text npcArmour;

    public TMP_Text npcSpeed;

    public TMP_Text npcIsFriendly;

    public Image artWork;





    public void ShowCharacterCard(npcInfo stats)
    {
        // show the chatacter stats card
        statsCard.SetActive(true);


        npcName.text = "My name is " + stats.npcName;

        npcName.text = "My catchphrase is " + stats.npccatchPhrase;

        npcName.text = "My armour is " + stats.npcArmourLevel;

        npcName.text = "My speed is " + stats.npcSpeed;

        artWork.sprite = stats.npcSprite;


        // if the character is friendly
        if (stats.npcIsFriendly)
        {
            // show a friendly greeting
            npcIsFriendly.text = "Greetings . . .";
        }

        // otherwise
        else
        {
            // show a not so friendly greeting
            npcIsFriendly.text = "Amscray! . . .";
        }
    }


} // end of class
