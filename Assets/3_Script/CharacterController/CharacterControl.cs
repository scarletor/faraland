using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DragonBones;
using DG.Tweening;
using System.Collections.Generic;
using Sirenix.OdinInspector;
public class CharacterControl : MonoBehaviour
{

    public static CharacterControl playerFront, enemyFront, player0, player1, player2, playerUIDisplaying, enemy0, enemy1, enemy2;

    public GameObject skill0, skill1, skill2, normalAttackSkill;
    void Awake()
    {


        switch (gameObject.name)
        {
            case "Enemy0": enemy0 = this; break;
            case "Enemy1": enemy1 = this; break;
            case "Enemy2": enemy2 = this; break;
            case "Player0": player0 = this; break;
            case "Player1": player1 = this; break;
            case "Player2": player2 = this; break;


        }

        enemyFront = enemy0;
        playerFront = player0;


    }

    [SerializeField]
    public bool isDie;



    public SpriteRenderer head, body, mainArm, offArm, leftPant, rightPant, leftFoot, rightFoot, leftHand, rightHand;
    private void Start()
    {
        if (GameManager.isDemo) return;
        PlayIdle();
        _arm.AddDBEventListener(EventObject.COMPLETE, PlayIdle);

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name=="Play")myHP = 100;
        PlayIdle();
        isDie = false;
    }

    public void PlayIdle()
    {
        _arm.animation.FadeIn("Idle", 0.2f, -1, 1);
        _arm.AddDBEventListener(EventObject.COMPLETE, PlayIdle);

    }

    public void PlayIdle(string type, EventObject eventObject)
    {
        _arm.animation.FadeIn("Idle", 0.2f, -1, 1);
        _arm.AddDBEventListener(EventObject.COMPLETE, PlayIdle);


    }

    public UnityArmatureComponent _arm;

    int _myHPGS;
    [SerializeField]
    public int myHP
    {
        get { return _myHPGS; }
        set
        {
            _myHPGS = value;
            myHPTxt.text = "HP: " + value;




            if (_myHPGS <= 0)
            {
                iDie();
            }
            else

            {
                _arm.animation.FadeIn("GetHit1", 0.2f, 1, 1);

            }
        }

    }

    public void iDie()
    {
        _arm.animation.FadeIn("Die", 0.2f, 1, 1);
        _arm.RemoveDBEventListener(EventObject.COMPLETE, PlayIdle);
        isDie = true;
        DOVirtual.DelayedCall(1, () =>
        {
            UIMng.instant.RemoveCharacterDie();
            Debug.LogError("DESTROY");




            Destroy(gameObject);

        });


    }




    public Text myHPTxt;
    [Button]
    public void remove1Health()
    {
        myHP--;
    }



    [Button]
    public void add1Health()
    {
        myHP++;
    }


}
