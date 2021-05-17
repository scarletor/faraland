using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using DragonBones;
public class UIMng : MonoBehaviour
{
    public static UIMng instant;
    private void Awake()
    {
        instant = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        currentScene = homeUI;
        //OnClickSelectChar(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string sceneStateStringDisplayOnly;
    public GameObject homeUI, modeUI, play, playControl, topUI;
    public GameObject currentScene, nextScene;
    public bool canClickUI = true;
    enum sceneStateEnum
    {
        home,
        game,
        spin,
        shop,
        videoAd,
        quest,
        mode,
        tournament,
        story,
        PVP,
        gift

    }
    private sceneStateEnum _sceneState;
    public GameObject backBtn;
    sceneStateEnum sceneState
    {
        get { return _sceneState; }
        set
        {
            sceneStateStringDisplayOnly = value.ToString();
            _sceneState = value;
            backBtn.SetActive(true);

            switch (value)
            {
                case sceneStateEnum.home:
                    backBtn.SetActive(false);
                    FadeOutCurrentScene();// this is to make current scene fadeOut
                    FadeInScene(homeUI);                     // this is to make next scene fadeIn
                    break;
                case sceneStateEnum.game:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Play");




                    break;
                case sceneStateEnum.mode:
                    Debug.LogError("mode");

                    FadeOutCurrentScene();
                    FadeInScene(modeUI);
                    break;

                case sceneStateEnum.tournament:
                    Debug.LogError("tournament");


                    FadeOutCurrentScene();
                    FadeInScene(tournaMentUI);

                    OnEnableTournamentView();
                    break;

                case sceneStateEnum.story:

                    FadeOutCurrentScene();
                    FadeInScene(storyUI);
                    OnEnableStoryView();
                    break;
                case sceneStateEnum.PVP:

                    FadeOutCurrentScene();
                    FadeInScene(PVPUI);
                    OnEnableViewPVP();
                    break;
                case sceneStateEnum.quest:

                    FadeOutCurrentScene();
                    FadeInScene(questUI);
                    break;
                case sceneStateEnum.videoAd:
                    shopTabDisplay = 4;
                    FadeOutCurrentScene();
                    FadeInScene(shopUI);
                    break;
                case sceneStateEnum.spin:

                    FadeOutCurrentScene();
                    FadeInScene(spinUI);
                    break;
                case sceneStateEnum.shop:

                    FadeOutCurrentScene();
                    FadeInScene(shopUI);
                    break;
                case sceneStateEnum.gift:

                    FadeOutCurrentScene();
                    FadeInScene(giftUI);
                    break;

            }
        }
    }

    CanvasGroup currentSceneCanvasGroup;
    void FadeOutCurrentScene()
    {
        currentSceneCanvasGroup = currentScene.GetComponent<CanvasGroup>();
        currentScene.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), .3f);
        InvokeRepeating("FadeOutSceneSchedule", 0, Time.deltaTime);
    }

    void FadeOutSceneSchedule()
    {
        currentSceneCanvasGroup.alpha -= 0.06f;
        if (currentSceneCanvasGroup.alpha <= 0)
        {
            CancelInvoke("FadeOutSceneSchedule");
            currentScene.SetActive(false);

            var temp = currentScene;
            currentScene = nextScene;
            nextScene = temp;

        }
    }




    CanvasGroup nextSceneCanvasGroup;
    void FadeInScene(GameObject sceneGO)
    {
        sceneGO.SetActive(true);
        nextSceneCanvasGroup = sceneGO.GetComponent<CanvasGroup>();
        sceneGO.transform.localScale = new Vector3(0, 0, 0);
        sceneGO.transform.DOScale(new Vector3(1, 1, 1), .3f);
        InvokeRepeating("FadeInSceneSchedule", 0, Time.deltaTime);
        nextScene = sceneGO;

    }

    void FadeInSceneSchedule()
    {
        nextSceneCanvasGroup.alpha += 0.06f;
        if (nextSceneCanvasGroup.alpha >= 1)
        {
            CancelInvoke("FadeInSceneSchedule");



        }
    }



    public void onClickMode()
    {
        sceneState = sceneStateEnum.mode;
    }

    public void onClickBack()
    {
        Debug.LogError(sceneState);
        switch (sceneState)
        {
            case sceneStateEnum.tournament:
                sceneState = sceneStateEnum.mode;
                break;

            case sceneStateEnum.mode:
                sceneState = sceneStateEnum.home;
                break;


            case sceneStateEnum.story:
                sceneState = sceneStateEnum.mode;
                break;
            case sceneStateEnum.PVP:
                sceneState = sceneStateEnum.mode;
                break;
            case sceneStateEnum.quest:
                sceneState = sceneStateEnum.home;
                break;

            case sceneStateEnum.videoAd:
                sceneState = sceneStateEnum.home;

                break;
            case sceneStateEnum.spin:
                sceneState = sceneStateEnum.home;

                break;
            case sceneStateEnum.shop:
                sceneState = sceneStateEnum.home;

                break;
            case sceneStateEnum.gift:
                sceneState = sceneStateEnum.home;

                break;
        }

    }


    public void onWWTFF()
    {
        Debug.LogError("CLICK onWWTFF");

        Debug.LogError("CLICK onWWTFF");
    }







    [Space(30)] // 10 pixels of spacing here.
    [TextArea]
    public string modeArea = "Mode";
    public GameObject modeSelector;
    public string modeSelecting;
    public Text descriptionModeUI;
    public void onClickSelectMode(GameObject thisBtn)
    {
        modeSelector.transform.position = new Vector2(thisBtn.transform.position.x, modeSelector.transform.position.y);



        //refresh display text in UI
        switch (thisBtn.gameObject.name)
        {
            case "@story_Btn":
                descriptionModeUI.text = "this is story mode bla bla";
                break;
            case "@tournament_Btn":
                descriptionModeUI.text = "this is tournament mode bla bla";
                break;
            case "@pvp_Btn":
                descriptionModeUI.text = "this is PVP mode bla bla";
                break;
            case "@arcade_Btn":
                descriptionModeUI.text = "this is ARCADE mode bla bla";
                break;
        }
        modeSelecting = thisBtn.gameObject.name;

    }
    public void onClickPlayInModeScene()
    {
        switch (modeSelecting)
        {
            case "@story_Btn":
                sceneState = sceneStateEnum.story;
                break;
            case "@tournament_Btn":
                sceneState = sceneStateEnum.tournament;
                break;
            case "@pvp_Btn":
                sceneState = sceneStateEnum.PVP;

                break;
            case "@arcade_Btn":
                break;
        }
    }

    public void GoHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }




    [Space(30)]
    [TextArea]
    public string modeTournamentArea = "tournament";
    public GameObject tournaMentUI, heroList;
    public int selectingHero;

    //display hero unlock or not
    public void OnEnableTournamentView()
    {
        //add callback to heroListBtn
        RegisterBtnSelectHero();

        tournaMentUI.SetActive(true);
        // refresh Hero list
        var id = 0;
        foreach (UnityEngine.Transform hero in heroList.transform)
        {
            var isUnlocked = UserData01.GetHeroUnlocked(id);
            Debug.LogError(hero + "  " + UserData01.GetHeroUnlocked(id));
            id++;
            if (isUnlocked == true)
            {
                hero.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                hero.GetComponent<Image>().color = new Color(.3f, .3f, .3f, 1f);
            }
        }

        //set default selecting hero 
        var selectingHero = UserData01.GetCurrentHeroPlaying();
        OnClickHero(selectingHero);




    }

    public GameObject heroParent, currentHeroDisplay, buyBtn, goBtn, selector;
    public void OnClickHero(int id)
    {
    }
    int count = 0;
    public void RegisterBtnSelectHero()
    {
        count = 0;
        foreach (UnityEngine.Transform btn in heroList.transform)
        {
            var temp = count;
            btn.GetComponent<Button>().onClick.AddListener(() => { OnClickHero(temp); });
            count++;

        }
    }

    public Text attackTxt, hpTxt, mpTxt, spellTxt, priceTxt, nameTxt;

    public void OnClickPlayTournament()
    {
        GameManager.gameMode = gameModeEnum.tournament;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }






    [Space(30)]
    [TextArea]
    public string modeStoryArea = "mode_story";
    public GameObject storyUI;
    public GameObject storySelector;
    public List<LevelItem> levelItemList;
    public int highestLevel = 0;
    public void OnEnableStoryView()
    {
        storyUI.SetActive(true);
        RefreshLevelList();
        AddModeStoryBtnCallBack();
    }
    public void RefreshLevelList()
    {
        //refresh selector to highest level
        foreach (LevelItem Item in levelItemList)
        {
            if (Item.level > highestLevel && Item.isUnlocked == true)
            {
                highestLevel = Item.level;
            }

        }
        highestLevel += 2;
        storySelector.transform.position = new Vector2(levelItemList[highestLevel].transform.position.x, levelItemList[highestLevel].transform.position.y + 3f);
    }


    public void AddModeStoryBtnCallBack()
    {
        foreach (LevelItem item in levelItemList)
        {
            item.gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShowLevelInfoPopup(item.level);
            });
        }
    }

    public GameObject popupLevelInfo, armModeStoryParent, spawnPos, modeStoryPlayBtn;
    public Text enemyModeStoryName, enemyModeStoryATK, enemyModeStoryHP, enemyModeStorySpell, enemyModeStoryMP, rewardGem, rewardGold;

    public void ShowLevelInfoPopup(int id)
    {

    }

    public void OnClickCloseModeStory()
    {
        popupLevelInfo.SetActive(false);
    }
    public void OnClickPlayModeStory()
    {
        GameManager.gameMode = gameModeEnum.story;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }




    [Space(30)]
    [TextArea]
    public string modePVPArea = "mode_PVP";
    public GameObject PVPUI, PVPselectorEnemy, PVPselectorPlayer, enemyArmParent, playerArmParent;
    public List<Button> heroPVPBtnList;
    public Text enemyName, enemyAtk, enemyHp, enemySpell, enemyMP, playerName, playerAtk, playerHp, playerSpell, playerMP;

    bool isChoosingPlayer;
    public void OnEnableViewPVP()
    {
        PVPUI.SetActive(true);
        RegisterOnClickHeroPVPCallBack();
        SetFirstHeroDisplayModePVP();
        Debug.LogError(pos.transform.position);

    }


    public void RegisterOnClickHeroPVPCallBack()
    {
        foreach (Button child in heroPVPBtnList)
        {
            child.onClick.AddListener(() => { OnClickHeroModePVP(child.transform.GetSiblingIndex()); });
            Debug.LogError(child);
        }
    }

    public void OnClickHeroModePVP(int id)
    {


    }


    public void SetFirstHeroDisplayModePVP()
    {
        isChoosingPlayer = true;
    }


    public GameObject pickBtn, repickBtn;
    public void OnClickRepick()
    {
        isChoosingPlayer = true;
        pickBtn.SetActive(isChoosingPlayer);
        repickBtn.SetActive(!isChoosingPlayer);
        selectorPVPState.transform.position = new Vector2(-6.5f, -2.3f);


    }


    public GameObject selectorPVPState, pos;
    public void OnClickPick()
    {
        isChoosingPlayer = false;
        pickBtn.SetActive(isChoosingPlayer);
        repickBtn.SetActive(!isChoosingPlayer);

        selectorPVPState.transform.position = new Vector2(6.5f, -2.3f);
    }

    public void OnClickPlayPVP()
    {
        GameManager.gameMode = gameModeEnum.PVP;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }




    [Space(30)]
    [TextArea]
    public string allHomeBtnArea = "all home btn";
    public GameObject questUI, videoAdUI, spinUI, shopUI, giftUI;
    public void OnClickQuest()
    {
        sceneState = sceneStateEnum.quest;
    }

    public void OnClickVideoAd()
    {
        shopTabDisplay = 4;
        sceneState = sceneStateEnum.videoAd;
    }

    public void OnClickSpin()
    {
        sceneState = sceneStateEnum.spin;
    }
    /// <summary>
    /// //1 show coin, 2 show gem, 3 show pack, 4 show ad
    /// </summary>
    public int shopTabDisplay;

    public void OnClickShop(int tabShow)//1 show coin, 2 show gem, 3 show pack, 4 show ad
    {
        if (sceneState == sceneStateEnum.shop) return;
        shopTabDisplay = tabShow;
        sceneState = sceneStateEnum.shop;
    }
    public void OnClickGift()
    {
        sceneState = sceneStateEnum.gift;
    }






    [Space(30)]
    [TextArea]
    public string castSkillBtn = "castSkillBtn";


    public GameObject skill1GO, skill0GO, skill2GO, skill3GO;
    public void OnClickSkill0()
    {
        CharacterControl.playerFront.skill0.SetActive(true);
    }

    public void OnClickSkill1()
    {
        CharacterControl.playerFront.skill1.SetActive(true);
    }
    public void OnClickSkill2()
    {
        CharacterControl.playerFront.skill2.SetActive(true);
    }


    public void OnClickAttack()
    {
        CharacterControl.playerFront.normalAttackSkill.SetActive(true);
    }







    public List<UnityEngine.Transform> BtnList, characterList;
    public void OnClickSelectChar(int id)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Play") return;






        foreach (UnityEngine.Transform btn in BtnList)
        {
            btn.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .3f);

        }
        foreach (UnityEngine.Transform character in characterList)
        {
            character.gameObject.SetActive(false);

        }
        if (id == 0) CharacterControl.playerUIDisplaying = CharacterControl.player0;
        if (id == 1) CharacterControl.playerUIDisplaying = CharacterControl.player1;
        if (id == 2) CharacterControl.playerUIDisplaying = CharacterControl.player2;




        BtnList[id].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        characterList[id].gameObject.SetActive(true);



        Stats.ins.RefreshStats(id);




    }

    public void OnClickPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }




    public List<Button> playerChangeCharBtn;
    public List<GameObject> enemyChangeCharBtn;

    public GameObject frontCharBtn, posChangeCharFrontBtn, posChangeCharFrontChar, posChangeCharBack;
    public void OnClickChangeChar(int id)
    {
        var thisBtn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (thisBtn == frontCharBtn) return;

        TurnManager.ins.Turn = TurnEnum.player;



        if (id == 0) GameManager.instant.ChangeActionBtnSprite(3, 4, 5);
        if (id == 1) GameManager.instant.ChangeActionBtnSprite(6, 7, 8);

        if (id == 2) GameManager.instant.ChangeActionBtnSprite(9, 10, 11);




        foreach (Button btn in playerChangeCharBtn)
        {
            btn.GetComponent<Image>().color = new Color(1, 1, 1, .3f);
        }
        thisBtn.GetComponent<Image>().color = new Color(1, 1, 1, 1f);


        thisBtn.transform.DOMove(posChangeCharFrontBtn.transform.position, .3f);

        frontCharBtn.transform.DOMove(thisBtn.transform.position, .3f);




        if (id == 0)
        {
            CharacterControl.playerFront.transform.GetChild(0).GetComponent<UnityEngine.Animation>().Play("FadeOut");

            DOVirtual.DelayedCall(2, () =>
            {

                //CharacterControl.player0.transform.DOMove(posChangeCharFrontChar.transform.position, .3f);

                //player MOVE IN
                CharacterControl.player0.transform.GetChild(0).GetComponent<UnityEngine.Animation>().Play("FadeIn");
                CharacterControl.player0.transform.position = posChangeCharFrontChar.transform.position;


                //player MOVE OUT



                DOVirtual.DelayedCall(3, () =>
                {


                    CharacterControl.playerFront.transform.DOMove(posChangeCharBack.transform.position, .01f);
                    CharacterControl.playerFront = CharacterControl.player0;



                });




            });





        }



        if (id == 1)
        {



            CharacterControl.player1.transform.DOMove(posChangeCharFrontChar.transform.position, .3f);
            CharacterControl.playerFront.transform.DOMove(CharacterControl.player1.transform.position, .3f);
            CharacterControl.playerFront = CharacterControl.player1;






        }

        if (id == 2)
        {
            CharacterControl.player2.transform.DOMove(posChangeCharFrontChar.transform.position, .3f);
            CharacterControl.playerFront.transform.DOMove(CharacterControl.player2.transform.position, .3f);
            CharacterControl.playerFront = CharacterControl.player2;






        }

        frontCharBtn = thisBtn;

    }


    public UnityEngine.Transform posEnemyFront, posPlayerFront;
    public void RemoveCharacterDie()
    {

        if (CharacterControl.enemy0.isDie == true && CharacterControl.enemy0)
        {
            CharacterControl.enemy1.transform.DOMove(posEnemyFront.position, 1);
            CharacterControl.enemy2.transform.DOMove(CharacterControl.enemy1.transform.position, 1);
            enemyChangeCharBtn[0].SetActive(false);
            enemyChangeCharBtn[1].transform.DOMove(enemyChangeCharBtn[0].transform.position, .3f);
            enemyChangeCharBtn[2].transform.DOMove(enemyChangeCharBtn[1].transform.position, .3f);
            CharacterControl.enemyFront = CharacterControl.enemy1;


        }
        else if (CharacterControl.enemy1.isDie == true && CharacterControl.enemy1)
        {
            CharacterControl.enemy2.transform.DOMove(posEnemyFront.position, 1);
            CharacterControl.enemyFront = CharacterControl.enemy2;
            enemyChangeCharBtn[1].SetActive(false);
            enemyChangeCharBtn[2].transform.DOMove(enemyChangeCharBtn[0].transform.position, .3f);

        }
        else if (CharacterControl.enemy2.isDie == true && CharacterControl.enemy2)
        {
            CharacterControl.enemy2.transform.DOMove(posEnemyFront.position, 1);
            CharacterControl.enemyFront = CharacterControl.enemy2;
            enemyChangeCharBtn[2].SetActive(false);
            DOVirtual.DelayedCall(1, () =>
            {
                OnClickPause();
            });
        }
        else if (CharacterControl.player0.isDie == true && CharacterControl.player0)
        {
            playerChangeCharBtn[0].gameObject.SetActive(false);

            if (CharacterControl.player2)
            {
                CharacterControl.player2.transform.DOMove(posPlayerFront.position, 1);
                CharacterControl.playerFront = CharacterControl.player2;
                return;
            }

            if (CharacterControl.player1)
            {
                CharacterControl.player1.transform.DOMove(posPlayerFront.position, 1);
                CharacterControl.playerFront = CharacterControl.player1;
                return;
            }


        }


        else if (CharacterControl.player1.isDie == true && CharacterControl.player1)
        {
            playerChangeCharBtn[1].gameObject.SetActive(false);

            if (CharacterControl.player2)
            {
                CharacterControl.player2.transform.DOMove(posPlayerFront.position, 1);
                CharacterControl.playerFront = CharacterControl.player2;
                return;
            }

            if (CharacterControl.player0)
            {
                CharacterControl.player0.transform.DOMove(posPlayerFront.position, 1);
                CharacterControl.playerFront = CharacterControl.player0;
                return;
            }


        }




        else if (CharacterControl.player2.isDie == true && CharacterControl.player2)
        {
            playerChangeCharBtn[2].gameObject.SetActive(false);

            if (CharacterControl.player0)
            {
                CharacterControl.player0.transform.DOMove(posPlayerFront.position, 1);
                CharacterControl.playerFront = CharacterControl.player0;
                return;
            }

            if (CharacterControl.player1)
            {
                CharacterControl.player1.transform.DOMove(posPlayerFront.position, 1);
                CharacterControl.playerFront = CharacterControl.player1;
                return;
            }


        }




    }


    public GameObject winUI;


    public void OnClickReplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Play");
    }

    public void OnClickPause()
    {
        winUI.SetActive(true);
    }

    public void OnClickLand()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayChangeChar");
    }



    public GameObject gate, character, startPos, endPos, curChar, land1Eff, landPos, jumpPos, pos1, charJump, fireMeteor, meteorImpact;
    public void Change(int id)
    {





        if (id == 1)
        {
            Destroy(curChar);

            var newChar = Instantiate(character);

            newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Land1", 0.1f, 1, 1);

            DOVirtual.DelayedCall(.2f, () =>
            {
                var eff = Instantiate(land1Eff);
                eff.transform.position = landPos.transform.position;
                CameraControl.instant.ShakeCamera();
            });



            DOVirtual.DelayedCall(1, () =>
            {
                newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Idle", 0.3f, 1, 1);

            });
            newChar.transform.position = startPos.transform.position;


            newChar.transform.DOMove(endPos.transform.position, 0.2f);
            curChar = newChar;

        }




        if (id == 2)
        {
            Destroy(curChar);

            var newChar = Instantiate(charJump);
            newChar.SetActive(true);

            newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Land3", 0.1f, 0, 0);

            newChar.GetComponent<DOTweenPath>().onComplete.AddListener(() =>
            {


                newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Land1", 0.1f, 0, 0);
                var eff = Instantiate(land1Eff);
                eff.transform.position = landPos.transform.position + new Vector3(0, -1f);
                CameraControl.instant.ShakeCamera();

                DOVirtual.DelayedCall(1, () =>
                {
                    newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Idle", 0.3f, 1, 1);

                });

            });





            curChar = newChar;

        }



        if (id == 0)
        {
            Destroy(curChar);

            var newChar = Instantiate(character);

            newChar.transform.position = new Vector3(-35, 20);
            newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Land1", 0.05f, 1, 1);

            var lastScale = newChar.transform.localScale;
            newChar.transform.localScale = new Vector3(.5f, .5f);



            newChar.transform.DOMove(landPos.transform.position, 1).SetEase(Ease.Linear);

            var meteor = Instantiate(fireMeteor);
            meteor.transform.position = new Vector3(-35, 20);


            meteor.transform.DOMove(landPos.transform.position, 1).SetEase(Ease.Linear).OnComplete(() =>
            {
                Destroy(meteor);
                var eff = Instantiate(land1Eff);
                eff.transform.position = landPos.transform.position;




                var meteorImp = Instantiate(meteorImpact);
                meteorImp.transform.position = landPos.transform.position;





                CameraControl.instant.ShakeCamera();

                newChar.transform.DOScale(lastScale, .1f);
                //newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Land1", 0.2f, 1, 1);
                newChar.transform.position += new Vector3(0, 4f);






                DOVirtual.DelayedCall(2, () =>
                {
                    newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Idle", 0.3f, 1, 1);

                });



            });





            curChar = newChar;


        }




        if (id == 3)
        {
            Destroy(curChar);

            var newChar = Instantiate(charJump);
            newChar.SetActive(true);

            newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Land3", 0.1f, 0, 0);



            DOVirtual.DelayedCall(1, () =>
            {
                for (int i = 0; i < 12; i++)
                {
                    DOVirtual.DelayedCall((.02f * i) + 0.2f, () =>
                      {
                          var wtf = Instantiate(character);
                          wtf.transform.position = newChar.transform.position;

                          wtf.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.Play("Land3");
                          foreach (UnityEngine.Transform child in wtf.transform.GetChild(0))
                          {
                              child.gameObject.AddComponent<ArmatureFadeOut>();


                              foreach (UnityEngine.Transform child2 in child)
                              {
                                  child2.gameObject.AddComponent<ArmatureFadeOut>();

                              }

                          }
                      });
                }



            });


            newChar.GetComponent<DOTweenPath>().onComplete.AddListener(() =>
            {


                newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Land1", 0.1f, 0, 0);
                var eff = Instantiate(land1Eff);
                eff.transform.position = landPos.transform.position + new Vector3(0, -1f);
                CameraControl.instant.ShakeCamera();

                DOVirtual.DelayedCall(1, () =>
                {
                    newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Idle", 0.3f, 1, 1);

                });

            });

            curChar = newChar;


        }


        if (id == 4)
        {
            curChar.transform.GetChild(0).GetComponent<UnityEngine.Animation>().Play("FadeOut");

            DOVirtual.DelayedCall(3, () =>
            {


                var newChar = Instantiate(character);

                var pos = landPos.transform.position;
                pos.y += 4;
                pos.x += Random.Range(2f, 5f);
                newChar.transform.position = pos;
                Destroy(curChar);


                newChar.transform.GetChild(0).GetComponent<UnityArmatureComponent>().animation.FadeIn("Idle", 0.05f, 0, 1);
                newChar.transform.GetChild(0).GetComponent<UnityEngine.Animation>().Play("FadeIn");


                curChar = newChar;

            });









        }










    }


}
