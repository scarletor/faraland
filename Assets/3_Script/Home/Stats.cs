using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Awake()
    {
        ins = this;
    }
    public static Stats ins;



    public Text race, element, rank, level, levelProcess, str, agi, intel, luc, damPhysic, damSpell, defPhysic, defSpell, crit, HP, baseDam, baseHP;

    public void RefreshStats(int id)
    {

        var loadedCharBaseStats = LoadFromServer.userInfo.character[id];
        race.text = "Race: " + loadedCharBaseStats.race;
        element.text = "Element: " + loadedCharBaseStats.element;
        rank.text = "Rank: " + loadedCharBaseStats.rank;
        level.text = "Level: " + loadedCharBaseStats.level;
        levelProcess.text = "LevelProcess: " + loadedCharBaseStats.levelProcess;




        var totalStr = loadedCharBaseStats.str + 1;




        str.text = "Strength: " + loadedCharBaseStats.str;
        agi.text = "Agility: " + loadedCharBaseStats.agi;
        intel.text = "Intelligent: " + loadedCharBaseStats.intel;
        luc.text = "Luck: " + loadedCharBaseStats.luc;
        damPhysic.text = "Physical damage: " + loadedCharBaseStats.damPhysic;
        damSpell.text = "Spell damage: " + loadedCharBaseStats.damSpell;
        defPhysic.text = "Physical defense: " + loadedCharBaseStats.defPhysic;
        defSpell.text = "Spell defense: " + loadedCharBaseStats.defSpell;
        crit.text = "Critical: " + loadedCharBaseStats.crit;
        HP.text = "Health: " + loadedCharBaseStats.hp;
        baseDam.text = "BaseDamage: " + loadedCharBaseStats.baseDama;
        baseHP.text = "BaseHP: " + loadedCharBaseStats.baseHP;
    }



















}
