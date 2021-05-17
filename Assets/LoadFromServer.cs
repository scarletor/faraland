using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class LoadFromServer : MonoBehaviour
{
    void Start()
    {




        GetCharacterData();




    }
    public static UserInfo userInfo;

    public void GetCharacterData()
    {
        var path = "/StreamingAssets/0_JsonLoaded/dataChar1.json";
        string dataCharJson = File.ReadAllText(Application.dataPath + path);
        userInfo = JsonUtility.FromJson<UserInfo>(dataCharJson);


    }






}
