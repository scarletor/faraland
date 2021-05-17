using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{


    public CharacterData heroData;
    public static GameManager instant;
    public static gameModeEnum gameMode;
    public static heroListEnum enemyHeroId;
    public static heroListEnum playerHeroId;
    public List< GameObject> characterList;
    public static bool isDemo;
    public bool isDemo2;

    private void Awake()
    {

        isDemo = isDemo2;

        instant = this;


        if (isDemo) return;
        InitPlayerSkill(9,10, 11);//make player has skill index 0 as skill0Btn, 1 as skill1Btn;
        InitEnemySkill(1, 0, 2);//make player has skill index 0 as skill0Btn, 1 as skill1Btn;


    }
    public GameObject enemyFront, playerFront;
    private void Start()
    {
        if (isDemo) return;
        SC_SetTurn();

        characterList.Add(CharacterControl.player0.gameObject);
        characterList.Add(CharacterControl.player1.gameObject);
        characterList.Add(CharacterControl.player2.gameObject);
        characterList.Add(CharacterControl.enemy0.gameObject);
        characterList.Add(CharacterControl.enemy1.gameObject);
        characterList.Add(CharacterControl.enemy2.gameObject);
        enemyFront = CharacterControl.enemyFront.gameObject;
        playerFront = CharacterControl.playerFront.gameObject;
    }




    public Image btnImage1, btnImage2, btnImage3;
    public List<Sprite> btnSpriteList;
    public void ChangeActionBtnSprite(int btn1,int btn2,int btn3)
    {
        btnImage1.sprite = btnSpriteList[btn1];
        btnImage2.sprite = btnSpriteList[btn2];
        btnImage3.sprite = btnSpriteList[btn3];


    }
    public int wtf;

    public GameObject player, playerPosList, enemy, enemyPosList;
    PlayerMoveController playerControl, enemyControl;
    public UnityArmatureComponent playerArm, enemyArm;

    public GameObject playerAttack;
    public void InitPlayerSkill(int skillID0, int skillID1, int skillID2)
    {
        if (isDemo) return;

        ChangeActionBtnSprite(3, 4, 5);
        //init skill0 for 3 player
        var newSkill = Instantiate(ReferenceAll.instant.SkillList[3],CharacterControl.player0.transform.position,Quaternion.identity,CharacterControl.player0.transform);
        CharacterControl.player0.skill0 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[6], CharacterControl.player1.transform.position, Quaternion.identity, CharacterControl.player1.transform);
        CharacterControl.player1.skill0 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[9], CharacterControl.player2.transform.position, Quaternion.identity, CharacterControl.player2.transform);
        CharacterControl.player2.skill0 = newSkill;



        //init skill 1 for 3 player
        newSkill = Instantiate(ReferenceAll.instant.SkillList[4], CharacterControl.player0.transform.position, Quaternion.identity, CharacterControl.player0.transform);
        CharacterControl.player0.skill1 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[7], CharacterControl.player1.transform.position, Quaternion.identity, CharacterControl.player1.transform);
        CharacterControl.player1.skill1 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[10], CharacterControl.player2.transform.position, Quaternion.identity, CharacterControl.player2.transform);
        CharacterControl.player2.skill1 = newSkill;


        //init skill 2 for 3 player


        newSkill = Instantiate(ReferenceAll.instant.SkillList[5], CharacterControl.player0.transform.position, Quaternion.identity, CharacterControl.player0.transform);
        CharacterControl.player0.skill2 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[8], CharacterControl.player1.transform.position, Quaternion.identity, CharacterControl.player1.transform);
        CharacterControl.player1.skill2 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[11], CharacterControl.player2.transform.position, Quaternion.identity, CharacterControl.player2.transform);
        CharacterControl.player2.skill2 = newSkill;



        //init normal attack for 3 player 
        newSkill = Instantiate(ReferenceAll.instant.attackSkill, CharacterControl.player0.transform.position, Quaternion.identity, CharacterControl.player0.transform);
        CharacterControl.player0.normalAttackSkill = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.attackSkill, CharacterControl.player1.transform.position, Quaternion.identity, CharacterControl.player1.transform);
        CharacterControl.player1.normalAttackSkill = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.attackSkill, CharacterControl.player2.transform.position, Quaternion.identity, CharacterControl.player2.transform);
        CharacterControl.player2.normalAttackSkill = newSkill;



    }
    public void InitEnemySkill(int skillID0, int skillID1, int skillID2)
    {

  


          //init skill0 for 3 player
        var newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID0],CharacterControl.enemy0.transform.position,Quaternion.identity,CharacterControl.enemy0.transform);
        CharacterControl.enemy0.skill0 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID0], CharacterControl.enemy1.transform.position, Quaternion.identity, CharacterControl.enemy1.transform);
        CharacterControl.enemy1.skill0 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID0], CharacterControl.enemy2.transform.position, Quaternion.identity, CharacterControl.enemy2.transform);
        CharacterControl.enemy2.skill0 = newSkill;



        //init skill 1 for 3 player
        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID1], CharacterControl.enemy0.transform.position, Quaternion.identity, CharacterControl.enemy0.transform);
        CharacterControl.enemy0.skill1 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID1], CharacterControl.enemy1.transform.position, Quaternion.identity, CharacterControl.enemy1.transform);
        CharacterControl.enemy1.skill1 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID1], CharacterControl.enemy2.transform.position, Quaternion.identity, CharacterControl.enemy2.transform);
        CharacterControl.enemy2.skill1 = newSkill;


        //init skill 2 for 3 player


        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID2], CharacterControl.enemy0.transform.position, Quaternion.identity, CharacterControl.enemy0.transform);
        CharacterControl.enemy0.skill2 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID2], CharacterControl.enemy1.transform.position, Quaternion.identity, CharacterControl.enemy1.transform);
        CharacterControl.enemy1.skill2 = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.SkillList[skillID2], CharacterControl.enemy2.transform.position, Quaternion.identity, CharacterControl.enemy2.transform);
        CharacterControl.enemy2.skill2 = newSkill;



        //init normal attack for 3 player 
        newSkill = Instantiate(ReferenceAll.instant.attackSkill, CharacterControl.enemy0.transform.position, Quaternion.identity, CharacterControl.enemy0.transform);
        CharacterControl.enemy0.normalAttackSkill = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.attackSkill, CharacterControl.enemy1.transform.position, Quaternion.identity, CharacterControl.enemy1.transform);
        CharacterControl.enemy1.normalAttackSkill = newSkill;

        newSkill = Instantiate(ReferenceAll.instant.attackSkill, CharacterControl.enemy2.transform.position, Quaternion.identity, CharacterControl.enemy2.transform);
        CharacterControl.enemy2.normalAttackSkill = newSkill;











    }








    public GameObject pointerTurn;
    public List<Button> actionBtn;
    public void SC_SetTurn()
    {
       




    }
 




}

