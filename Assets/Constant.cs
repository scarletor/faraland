using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //playerpref

    public static string IS_PLAYER_UNLOCK = "isPlayerUnlock";
    public static string LEVEL_UNLOCKED = "LEVEL_UNLOCKED";
    public static string CURRENT_HERO_PLAYING = "CURRENT_HERO_PLAYING";
  

}

public enum gameModeEnum
{
    PVP,
    story,
    arcade,
    tournament
}
public enum heroListEnum
{
    _0_Vegeta,
    _1_Songoku,
    _2_Cell,
    _3_Fide,
    _4_Mabu,
    _5_Beerus,
    _6_Piccolo,
    _7_Kai,
    _8_Gohan,
    _9_Krillin,

}