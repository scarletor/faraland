using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UserData01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateNewData();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CreateNewData()
    {


        SetHeroUnlock(1);
        SetHeroUnlock(0);
        SetHeroUnlock(2);


        SetLevelUnlock(1);
        SetLevelUnlock(0);

        Debug.LogError(GetHeroUnlocked(0));
        Debug.LogError(GetHeroUnlocked(1));

    }


    public static void SetHeroUnlock(int id)
    {
        PlayerPrefs.SetInt(Constant.IS_PLAYER_UNLOCK + id, 1);

    }
    public static bool GetHeroUnlocked(int id)
    {
        var isUnlocked = PlayerPrefs.GetInt(Constant.IS_PLAYER_UNLOCK + id);


        if (isUnlocked == 1) return true;
        else return false;
    }



    public static void SetCurrentHeroPlaying(int id)
    {
        PlayerPrefs.SetInt(Constant.CURRENT_HERO_PLAYING, id);

    }

    public static int GetCurrentHeroPlaying()
    {
        return PlayerPrefs.GetInt(Constant.CURRENT_HERO_PLAYING);

    }
    public static void SetLevelUnlock(int id)
    {
        PlayerPrefs.SetInt(Constant.LEVEL_UNLOCKED+id,1);

    }


    public static bool GetLevelUnlock(int id)
    {
        bool isUnlocked = PlayerPrefs.GetInt(Constant.LEVEL_UNLOCKED+ id.ToString())==1 ? true : false;

        
        return isUnlocked;
    }


}
