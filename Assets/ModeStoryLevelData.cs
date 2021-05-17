using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using DragonBones;
public class ModeStoryLevelData : MonoBehaviour
{
    public static ModeStoryLevelData instant;
    private void Awake()
    {
        instant = this;
    }

    [TableList(ShowIndexLabels = true)]
    public List<StoryLevelData> levelData;
    [Serializable]
    public class StoryLevelData
    {

        public heroLevel level;
        public heroList hero;

        public int HP;
        public int ATK;
        public int MP;
        public int Spell;

        public int gemResult,goldResult;


    }    
    public enum heroList 
    {
        _0_Vegeta,
        _1_Sgk,
        _2_Cell,
        _3_Fide,
        _4_Mabuu,
        _5_Beerus,

    };
    public enum heroLevel
    {
        _1,_2,_3

    };
}


