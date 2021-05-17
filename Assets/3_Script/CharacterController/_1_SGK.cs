using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using DG.Tweening;
using System;
public class _1_SGK : PlayerMoveController
{
    public int __________INHERIT____;
    public AttackBox attackBox;

    void Start()
    {
        childEnemy = GameManager.instant.enemy;
        enemyControl = childEnemy.GetComponent<PlayerMoveController>();
        childArm = gameObject.GetComponent<UnityArmatureComponent>();
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
    public PlayerMoveController wtf;

    public override void Attack() 
    {
        Debug.LogError("ATTACK FROM ____CHILD");
    }
    GameObject childEnemy;
    PlayerMoveController enemyControl;
    // big ball
    public GameObject skillHitBoxCol;
    public override void Skill1()
    {
        _arma.animation.FadeIn("Skill1", 0.2f, 1, 1);

        CameraControl.instant.FocusCamera(true);
        var standWind = Instantiate(ReferenceAll.instant.gokuEff_1[1]);
        standWind.transform.position = posStandWind.transform.position;

        standWind.transform.eulerAngles = _arma.transform.eulerAngles;
        standWind.transform.localScale = new Vector3(1, 1 * _arma.transform.localScale.y, 1);
        var gokuBall = Instantiate(ReferenceAll.instant.gokuEff_1[0]);
        gokuBall.transform.localPosition = posBigBall.transform.position;


        DOVirtual.DelayedCall(2f, () =>
        {
            gokuBall.transform.DOMove(childEnemy.GetComponent<PlayerMoveController>().getSpellPos.transform.position, .3f).OnComplete(() =>
            {
                CreateSpellImpact(childEnemy.transform.position,enemyControl);
                gokuBall.transform.DOMove(childEnemy.transform.position, 3f);
            });
            standWind.SetActive(false);


        });

        for (int i = 0; i < 10; i++)
        {
            DOVirtual.DelayedCall(2.3f + i * .15f, () =>
            {
                enemyControl.GetSkill();

            });
        }


        DOVirtual.DelayedCall(4.4f, () =>
        {
            gokuBall.active = false;
        });
    }

    public List<GameObject> pos;
    public GameObject posAttack;
    public GameObject posFireBall,posBigBall,posStandWind,posStartKame1,posMoveKame2;

    UnityArmatureComponent childArm;


    //fire small fireball
    public override void Skill3()
    {
        childArm.animation.FadeIn("Skill3", 0.07f, 1, 1);
        Debug.LogError(_arma);
        DOVirtual.DelayedCall(0.1f, () =>
        {
            var newProjectile = Instantiate(myProjectile);
            Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), myHitBox);
            newProjectile.transform.position = posFireBall.transform.position;
            newProjectile.transform.eulerAngles = gameObject.transform.eulerAngles;


            var newMuzzle = Instantiate(myMuzzle);
            newMuzzle.transform.eulerAngles = _arma.transform.eulerAngles;

            newMuzzle.transform.position = posFireBall.transform.position;

            DOVirtual.DelayedCall(3f, () =>
            {
                Destroy(newProjectile);
                Destroy(newMuzzle);





            });

        });


    }

    public override void CheckDirection()
    {

    }

    public override void RotateToEnemy()
    {

    }

    public override void GetHit()
    {

    }

    //skill kamehameha
    public override void Skill2()
    {
        _arma.RemoveDBEventListener(EventObject.COMPLETE, PlayIdle);
        _arma.animation.FadeIn("Skill2", 0.2f, 1, 1);
        CameraControl.instant.FocusCamera(true);

        chargeBeam.active = true;
        beam.GetComponent<LineRenderer>().SetPosition(0, new Vector3(0, 0, 0));
        chargeBeam.transform.position = posStartKame1.transform.position;


        for (int i = 0; i < 10; i++)
        {
            DOVirtual.DelayedCall(2.3f + i * .15f, () =>
            {
                enemyControl.GetSkill();
                var newEff = Instantiate(ReferenceAll.instant.effHit[2]);
                newEff.transform.position = target.transform.position + new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));

            });
        }



        DOVirtual.DelayedCall(2f, () =>
        {
            beam.active = true;
            beamImpact.active = true;
            chargeBeam.transform.DOMove(posMoveKame2.transform.position, .1f);
            CreateSpellImpact(enemyControl.gameObject.transform.position,enemyControl);

        });




        DOVirtual.DelayedCall(4, () =>
        {
            chargeEff.active = false;
            beam.active = false;
            beamImpact.active = false;
            _arma.AddEventListener(EventObject.COMPLETE, PlayIdle);
            _arma.animation.FadeIn("Idle", 0.2f, 1, 1);
            chargeBeam.SetActive(false);
        });






    }

}
