using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Lean.Gui;
using DragonBones;
using DG.Tweening;
using System.Collections.Generic;

public  enum playerStateEnum
{
    attack,
    getHit,
    getSkill,
    die,
    skill1,
    skill2,
    skill3,
    victory

}

public enum playTypeEnum { Enemy, player, };

public class PlayerMoveController : MonoBehaviour
{
    public GameObject getSpellPos, myProjectile, myMuzzle;
    public playTypeEnum playType;

    // PUBLIC
    public float speedMovements;
    public float HP;
    // PRIVATE
    private Rigidbody2D _rigidbody;
    [SerializeField] bool continuousRightController = true;

    public GameObject target;
    PlayerMoveController targetControl, myChildControl;
    private void Start()
    {
        lastPos = transform.position;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();


        _arma.AddDBEventListener(EventObject.COMPLETE, PlayIdle);
        if (playType == playTypeEnum.Enemy)
        {
            enemy = ReferenceAll.instant.player;
            target = ReferenceAll.instant.player; 
        }
        else
        {
            enemy = ReferenceAll.instant.enemy;
            myChildControl = GameManager.instant.playerArm.gameObject.GetComponent<PlayerMoveController>();
            armRef = myChildControl.gameObject.GetComponent<arm_ref>();

            myHitBox = armRef.myHitBox;

        }


        HP = 100;
        targetControl = target.GetComponent<PlayerMoveController>();

    }










    GameObject enemy;

    [Space(20)]
    [TextArea]
    public string textArea0 = "dieAnim";
    public GameObject  dieCol;
    public int dieForce;
    void PlayDieAnim()
    {
        playerState = playerStateEnum.die;
    }

    bool isDie = false;
    public string playerStateDisplayGUI;
    public List<GameObject> myEff;
    public arm_ref armRef;
    public playerStateEnum playerState
    {
        get { return 0; }
        set
        {
            if (isDie) return;
            Debug.LogError(_arma);
            Debug.LogError(gameObject);
            var dirFromEnemy = (target.transform.position.x - transform.position.x) > 0 ? -1 : 1;
            if (value == playerStateEnum.attack)
            {
                Debug.LogError("THIS IS BUG");
            }
            if (value == playerStateEnum.getHit)
            {
                var animHit = "GetHit" + Random.Range(1, 4);
                _arma.animation.FadeIn(animHit, 0.2f, 1, 1);
                transform.DOMove(armRef.backPos.transform.position, .1f);

                myHpUI.value -= .1f;

                if (myHpUI.value <= 0)
                    playerState = playerStateEnum.die;
                playerStateDisplayGUI = playerState.ToString();
            }

            if (value == playerStateEnum.getSkill)
            {
                var animHit = "GetHit" + Random.Range(1, 4);
                _arma.animation.FadeIn(animHit, 0.2f, 1, 1);

                myHpUI.value -= .03f;

                if (myHpUI.value <= 0)
                    playerState = playerStateEnum.die;
                playerStateDisplayGUI = playerState.ToString();
            }


            if (value == playerStateEnum.die)
            {
                isDie = true;
                _arma.RemoveDBEventListener(EventObject.COMPLETE, PlayIdle);
                _arma.animation.FadeIn("Die", 0.2f, 1, 1);
                dieCol.SetActive(true);
                _rigidbody.gravityScale = 12;
                _rigidbody.AddForceAtPosition(new Vector2(300, dieForce), armRef.posDieAddForce.transform.position);
                playerStateDisplayGUI = playerState.ToString();

            }
            if (value == playerStateEnum.skill1)
            {

            }
            if (value == playerStateEnum.skill2)
            {

            }

            if (value == playerStateEnum.skill3)
            {

            }
            if (value == playerStateEnum.victory)
            {

            }


        }

    }






    public LeanJoystick joy;
    bool isFlyingIn = false;
    bool isFlyingOut = false;
    bool isIdle = false;
    public bool canMove = true;
    void CheckAnimationFly()
    {
        if (playType == playTypeEnum.Enemy) return;
        if (joy.ScaledValue.x != 0)
        {
            if (canMove == false) return;

            if ((target.transform.position.x - transform.position.x) >= 0 && joy.ScaledValue.x >= 0 && isFlyingIn == false)
            {
                isFlyingIn = true;
                isFlyingOut = false;
                isIdle = false;
                _arma.animation.FadeIn("FlyIn", 0.2f, -1, 1);
                Debug.LogError("RUN 1");
            }
            if ((target.transform.position.x - transform.position.x) >= 0 && joy.ScaledValue.x < 0 && isFlyingOut == false)
            {
                isFlyingIn = false;
                isFlyingOut = true;
                isIdle = false;
                _arma.animation.FadeIn("FlyOut", 0.2f, -1, 1);
                Debug.LogError("RUN 2");

            }


            if ((target.transform.position.x - transform.position.x) < 0 && joy.ScaledValue.x < 0 && isFlyingIn == false)
            {
                isFlyingIn = true;
                isFlyingOut = false;
                isIdle = false;
                _arma.animation.FadeIn("FlyIn", 0.2f, -1, 1);
                Debug.LogError("RUN 1");
            }
            if ((target.transform.position.x - transform.position.x) < 0 && joy.ScaledValue.x >= 0 && isFlyingOut == false)
            {
                isFlyingIn = false;
                isFlyingOut = true;
                isIdle = false;
                //  _arma.animation.FadeIn("FlyOut", 0.2f, -1, 1);
                Debug.LogError("RUN 2");

            }



        }

        else if (isIdle == false)
        {
            isIdle = true;
            isFlyingOut = false;
            isFlyingIn = false;

            if (isDie == false)
                _arma.animation.FadeIn("Idle", 0.2f, 1, 1);

        }

    }






    Vector2 lastPos;
    void GetSpeed()
    {
        Vector2 curPos = transform.position;

        lastPos = curPos;

    }
    public virtual void CheckDirection()
    {
        if ((transform.position.x - enemy.transform.position.x) > 0)
        {
            _arma.gameObject.transform.localScale = new Vector2(1, -1);
        }
        else
            _arma.gameObject.transform.localScale = new Vector2(1, 1);


    }

    void LookAtEnemy()
    {

    }


    public Text textX, textY, textSum;
    float offsetMoveX = 1.5f;
    float offsetMoveY = 1.5f;
    float distantce;
    void FixedUpdate()
    {
        CheckAnimationFly();
        MoveByJoyStick();
        CheckDirection();
        BeamControl();
        RotateToEnemy();


        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Charge();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Skill1();
        }
    }

    public GameObject beamImpact;
    GameObject beamStartPos;
    void BeamControl()
    {
        if (playType == playTypeEnum.Enemy) return;
        beamImpact.transform.position = target.transform.position;
        beam.GetComponent<LineRenderer>().SetPosition(0, chargeBeam.transform.position);
        beam.GetComponent<LineRenderer>().SetPosition(1, target.transform.position);

        beam.GetComponent<LineRenderer>().sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * 3, 0);
    }


    public virtual void RotateToEnemy()
    {
        if (isDie) return;
        _arma.gameObject.transform.right = -(gameObject.transform.position - enemy.transform.position);
    }
    void MoveByJoyStick()
    {
        if (playType == playTypeEnum.Enemy) return;
        if (canMove == false) return;
        _rigidbody.MovePosition(transform.position + (transform.up * joy.ScaledValue.y * Time.deltaTime * speedMovements) +
            (transform.right * joy.ScaledValue.x * offsetMoveX * Time.deltaTime * speedMovements));

    }
    public void PlayIdle(string type, EventObject eventObject)
    {
        _arma.animation.FadeIn("Idle", 0.2f, 1, 1);

    }


    [Space(30)]
    [TextArea]

    public string attackArea = "attackArea";
    List<GameObject> posSpawnEff;
    public bool isHitEnemy;
    public UnityArmatureComponent _arma;
    [SerializeField]
    int attackStep = 0;
    private IEnumerator coroutine;
    public virtual void Attack()
    {
        if (attackStep == -1) return;

        armRef.attackBox.isCritical = false;
        armRef.attackBox.gameObject.SetActive(true);



        var temPos = armRef.posAttack.transform.position;
        temPos.z = 0;
        gameObject.transform.DOLocalMove(temPos, .1f);




        DOVirtual.DelayedCall(.1f, () =>
        {
            armRef.attackBox.gameObject.SetActive(false);
        });
        canMove = false;
        attackStep++;
        if (attackStep == 1)
        {
            _arma.animation.FadeIn("Atack1", 0.1f, 1, 1);

            if (isHitEnemy == true)
                DOVirtual.DelayedCall(.1f, () =>
                {
                    var part = Instantiate(ReferenceAll.instant.effHit[1]);
                    part.transform.parent = null;
                    part.transform.position = posSpawnEff[0].transform.position;
                });

        }


        if (attackStep == 2)
        {
            _arma.animation.FadeIn("Atack2", 0.1f, 1, 1);
            if (isHitEnemy == true)
                DOVirtual.DelayedCall(.1f, () =>
            {
                var part = Instantiate(ReferenceAll.instant.effHit[1]);
                part.transform.parent = null;
                part.transform.position = posSpawnEff[1].transform.position;
            });
        }

        if (attackStep == 3)

        {
            _arma.animation.FadeIn("Atack3", 0.1f, 1, 1);



            if (isHitEnemy == true)
                DOVirtual.DelayedCall(.1f, () =>
             {
                 var part = Instantiate(ReferenceAll.instant.effHit[1]);
                 part.transform.parent = null;
                 part.transform.position = posSpawnEff[2].transform.position;
             });
        }


        if (attackStep == 4)
        {
            _arma.animation.FadeIn("Atack4", 0.1f, 1, 1);
            armRef.attackBox.isCritical = true;




            attackStep = -1;
            DOVirtual.DelayedCall(1f, () =>
            {
                attackStep = 0;
                CameraControl.instant.canMoveCamera = true;

            });


        }




        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = ResetAttackStep();
        StartCoroutine(coroutine);
    }

    float timeSinceLastAttack;
    int pressAttackCount = 0;
    public void OnClickAttack()
    {

        if (Time.timeSinceLevelLoad - timeSinceLastAttack >= 0.16f)
        {
            Attack();
            timeSinceLastAttack = Time.timeSinceLevelLoad;

        }
    }
    IEnumerator corou_delayAttack;
    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(.4f);

    }







    bool isCorouRun = false;
    IEnumerator ResetAttackStep()
    {
        //attackBoxCol.SetActive(false);
        yield return new WaitForSeconds(.7f);
        attackStep = 0;
        canMove = true;

    }
    public GameObject chargeEff;
    public void Charge()
    {
        _arma.RemoveDBEventListener(EventObject.COMPLETE, PlayIdle);
        _arma.animation.FadeIn("Charge", 0.2f, -1, 1);
        chargeEff.active = true;

    }
    public void ReleaseCharge()
    {
        _arma.AddDBEventListener(EventObject.COMPLETE, PlayIdle);
        _arma.animation.FadeIn("Idle", 0.2f, 1, 1);
        chargeEff.active = false;

    }



    // big ball
    public virtual void Skill1()
    {
        myChildControl.Skill1();



    }

    //kameha
    public GameObject chargeBeam, beam;
    public virtual void Skill2()
    {
        Debug.LogError(myChildControl);
        myChildControl.Skill2();




    }


    //fire small fireball
    public virtual void Skill3()
    {

        myChildControl.Skill3();


    }



    public void Defend()
    {
        _arma.RemoveDBEventListener(EventObject.COMPLETE, PlayIdle);
        _arma.animation.FadeIn("Defend", 0.2f, 1, 1);
    }

    public void ReleaseDefend()
    {
        _arma.AddDBEventListener(EventObject.COMPLETE, PlayIdle);
        _arma.animation.FadeIn("Idle", 0.2f, 1, 1);

    }






    [Space(30)]
    [TextArea]
    public string textArea1 = "attackHitBox";
    public Collider2D myHitBox;
    public Slider myHpUI;
    public GameObject backPos, getCritBackPos;
    public virtual void GetHit()
    {
        playerState = playerStateEnum.getHit;
    }
    public void GetSkill()
    {
        playerState = playerStateEnum.getSkill;
    }
    public RectTransform target1;
    public AnimationCurve animationCurve;

    private RectTransform rectTransform;
    private Vector3 start;
    private Vector3 end;

    private Coroutine coroutine1;

    private void Start1()
    {

        rectTransform = GetComponent<RectTransform>();
        start = rectTransform.position;
        end = target1.position + new Vector3(target1.rect.width / 2f, target1.rect.height / 2f, 0f);
    }

    public void GetCriticalStrike()
    {
        _arma.animation.FadeIn("GetCritical", 0.2f, 1, 1);
        transform.DOMove(armRef.posGetCritical.transform.position, 1);
        _arma.RemoveDBEventListener(EventObject.COMPLETE, PlayIdle);

        CreateTrail();
        DOVirtual.DelayedCall(1f, () =>
        {
            _arma.animation.FadeIn("Idle", 0.2f, 1, 1);
            _arma.AddDBEventListener(EventObject.COMPLETE, PlayIdle);
        });

    }

    float tem = 0;
    void CreateTrail()
    {
        tem = tem + 0.1f;

        for (int i = 0; i < 10; i++)
        {
            DOVirtual.DelayedCall(.07f * i, () =>
              {
                  var newGo = Instantiate(_arma.gameObject);
                  newGo.transform.position = gameObject.transform.position;
                  newGo.GetComponent<UnityArmatureComponent>().animation.Play("GetCritical");
                  newGo.AddComponent<ArmatureFadeOut>();
              });

        }




    }
    public void CreateSpellImpact(Vector3 pos,PlayerMoveController target)
    {
        for (int i = 0; i < 10; i++)
        {
            var rd = pos + new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, 2f));
            DOVirtual.DelayedCall(.2f * i, () =>
            {
                Instantiate(ReferenceAll.instant.effSpell[Random.Range(0, ReferenceAll.instant.effSpell.Count)], rd, Quaternion.identity, null);
            });
        }
        DOVirtual.DelayedCall(2, () =>
        {
            Instantiate(ReferenceAll.instant.bigNova, enemy.transform.position, Quaternion.identity, null);
            target.GetCriticalStrike();

        });
    }



}
