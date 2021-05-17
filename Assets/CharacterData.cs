using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using DragonBones;
using System.IO;
public class CharacterData : MonoBehaviour
{
    public static CharacterData instant;
    private void Awake()
    {
        instant = this;




    }

    [TableList(ShowIndexLabels = true)]
    public List<CharacterStats> characterStats;
  



    private void Start()
    {
        //CreateCharacterDataJson();
    }


    public void CreateCharacterDataJson()
    {

        UserInfo userInf = new UserInfo();

        userInf.character[0] = new CharacterStats();
        userInf.character[0].item = new ItemInfo[9];
        userInf.character[0].item[0] = new ItemInfo();
        userInf.character[0].item[1] = new ItemInfo();
        userInf.character[0].item[2] = new ItemInfo();
        userInf.character[0].item[3] = new ItemInfo();
        userInf.character[0].item[4] = new ItemInfo();
        userInf.character[0].item[5] = new ItemInfo();
        userInf.character[0].item[6] = new ItemInfo();
        userInf.character[0].item[7] = new ItemInfo();
        userInf.character[0].item[8] = new ItemInfo();

        userInf.character[0].element = ElementEnum.fire;
        userInf.character[0].race = RaceEnum.human;


        userInf.character[0].name = "char0";
        userInf.character[0].index = 0;
        userInf.character[0].str = 1;
        userInf.character[0].agi = 2;
        userInf.character[0].intel = 3;
        userInf.character[0].damSpell = 32;
        userInf.character[0].damPhysic = 53;

        userInf.character[0].item[0].agi = 1;
        userInf.character[0].item[0].str = 11;
        userInf.character[0].item[0].intel = 31;
        userInf.character[0].item[0].luc = 4;
        userInf.character[0].item[0].ItemType = ItemTypeSlotEnum.head;

        userInf.character[0].item[1].agi = 1;
        userInf.character[0].item[1].str = 11;
        userInf.character[0].item[1].intel = 31;
        userInf.character[0].item[1].luc = 4;
        userInf.character[0].item[1].ItemType = ItemTypeSlotEnum.armor;



        userInf.character[1] = new CharacterStats();
        userInf.character[1].item = new ItemInfo[9];
        userInf.character[1].item[0] = new ItemInfo();
        userInf.character[1].item[1] = new ItemInfo();
        userInf.character[1].item[2] = new ItemInfo();
        userInf.character[1].item[3] = new ItemInfo();
        userInf.character[1].item[4] = new ItemInfo();
        userInf.character[1].item[5] = new ItemInfo();
        userInf.character[1].item[6] = new ItemInfo();
        userInf.character[1].item[7] = new ItemInfo();
        userInf.character[1].item[8] = new ItemInfo();

        userInf.character[1].element = ElementEnum.water;
        userInf.character[1].race = RaceEnum.orc;

        userInf.character[1].name = "char1";
        userInf.character[1].index = 11;
        userInf.character[1].str = 112;
        userInf.character[1].agi = 123;
        userInf.character[1].intel = 112;
        userInf.character[1].damSpell = 1992;
        userInf.character[1].damPhysic = 153;

        userInf.character[1].item[0].agi = 1;
        userInf.character[1].item[0].str = 11;
        userInf.character[1].item[0].intel = 31;
        userInf.character[1].item[0].luc = 4;
        userInf.character[1].item[0].ItemType = ItemTypeSlotEnum.mainHand;

        userInf.character[1].item[1].agi = 1;
        userInf.character[1].item[1].str = 11;
        userInf.character[1].item[1].intel = 31;
        userInf.character[1].item[1].luc = 4;
        userInf.character[1].item[1].ItemType = ItemTypeSlotEnum.offHand;





        userInf.character[2] = new CharacterStats();
        userInf.character[2].item = new ItemInfo[9];
        userInf.character[2].item[0] = new ItemInfo();
        userInf.character[2].item[1] = new ItemInfo();
        userInf.character[2].item[2] = new ItemInfo();
        userInf.character[2].item[3] = new ItemInfo();
        userInf.character[2].item[4] = new ItemInfo();
        userInf.character[2].item[5] = new ItemInfo();
        userInf.character[2].item[6] = new ItemInfo();
        userInf.character[2].item[7] = new ItemInfo();
        userInf.character[2].item[8] = new ItemInfo();

        userInf.character[2].element = ElementEnum.normal;
        userInf.character[2].race = RaceEnum.human;

        userInf.character[2].name = "char2";
        userInf.character[2].index = 20;
        userInf.character[2].str = 21;
        userInf.character[2].agi = 22;
        userInf.character[2].intel = 23;
        userInf.character[2].damSpell = 232;
        userInf.character[2].damPhysic = 253;


        userInf.character[2].item[0].agi = 1;
        userInf.character[2].item[0].str = 11;
        userInf.character[2].item[0].intel = 31;
        userInf.character[2].item[0].luc = 4;
        userInf.character[2].item[0].ItemType = ItemTypeSlotEnum.mainHand;

        userInf.character[2].item[1].agi = 1;
        userInf.character[2].item[1].str = 11;
        userInf.character[2].item[1].intel = 31;
        userInf.character[2].item[1].luc = 4;
        userInf.character[2].item[1].ItemType = ItemTypeSlotEnum.offHand;





        string dataJson = JsonUtility.ToJson(userInf);
        var path = "/0_JsonLoaded/dataChar1.json";
        File.WriteAllText(Application.dataPath + path, dataJson);

    }



    
}
[Serializable]
public class UserInfo
{
    public CharacterStats[] character = new CharacterStats[3];

}

[Serializable]

public class CharacterStats
{
    public string name;

    public RaceEnum race;
    public ElementEnum element;
    public int rank;
    public int level;
    public int levelProcess;

    public int index;
    public int str;
    public int agi;
    public int intel;
    public int luc;

    public int damSpell;
    public int damPhysic;
    public int defPhysic;
    public int defSpell;
    public int crit;
    public int hp;
    public int evade;
    public int accuracy;

    public int baseDama;
    public int baseHP;


    public ItemInfo[] item;

}
[Serializable]
public class ItemInfo
{
    public string itemName;
    public int str;
    public int agi;
    public int intel;
    public int luc;

    public int dam;
    public int def;
    public int crit;
    public int hp;
    public int evade;
    public int accuracy;
    public ItemTypeSlotEnum ItemType;

}
[Serializable]

public enum ItemTypeSlotEnum
{
    mainHand,
    offHand,
    head,
    armor,
    arm,
    pant,
    foot,
    pet,



}
[Serializable]

public enum RaceEnum
{
    human,
    orc,
    elf,
    dragonBorn,
    fairy,
    angel,
    demon,
}
[Serializable]

public enum ElementEnum
{
    normal,
    fire,
    water,
    grass,
    rock,
    thunder,
    ice,
}
