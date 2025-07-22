
using UnityEngine;


[CreateAssetMenu(menuName = "NPC Information", fileName = "New NPC Info")]
public class npcInfo : ScriptableObject
{
    public string npcName;

    public string npccatchPhrase;

    public Sprite npcSprite;

    public int npcArmourLevel;

    public float npcSpeed;

    public bool npcIsFriendly;


} // end of class
