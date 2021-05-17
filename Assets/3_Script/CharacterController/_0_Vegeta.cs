using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using DG.Tweening;
using System;
public class _0_Vegeta : PlayerMoveController
{

    [Space(20)]
    [TextArea]
    public string Inherit_Vegeta = "Vegeta";

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

    public override void Attack()
    {
        Debug.LogError("ATTACK FROM ____CHILD");
    }

    GameObject childEnemy;
    PlayerMoveController enemyControl;



    public List<GameObject> benzierFireBall;

    // cast multi fireball
    public GameObject posChargeEff, multiFireBallProject, multiFireBallProjectMuzzle, posSpawnMultiFireBall, vegetaChargeEff;

    public float speedFireBall;
    public override void Skill1()
    {
        Debug.LogError("SKILL 1");
        childArm.animation.FadeIn("Skill1", 0.2f, 1, 1);


        // create charge Eff
        CameraControl.instant.FocusCamera(true);
        var newChargeEff = Instantiate(vegetaChargeEff);
        newChargeEff.transform.position = posChargeEff.transform.position;
        newChargeEff.transform.eulerAngles = childArm.transform.eulerAngles;
        newChargeEff.transform.localScale = new Vector3(1, 1 * childArm.transform.localScale.y, 1);




        // create multi ball
        DOVirtual.DelayedCall(2f, () =>
        {

        for (int i = 0; i < 5; i++)
        {
            DOVirtual.DelayedCall(.3f * i, () =>
           {
               enemyControl.GetSkill();

               var newMultiFireBall = Instantiate(multiFireBallProject);
               newMultiFireBall.transform.position = posSpawnMultiFireBall.transform.position;

               var newMultiFireBallMuzzle = Instantiate(multiFireBallProjectMuzzle);
               newMultiFireBallMuzzle.transform.position = posSpawnMultiFireBall.transform.position;



               Vector2 pos = transform.position + enemyControl.transform.position / 2;
               var rdVector2 = new Vector2(UnityEngine.Random.Range(-2, 2), UnityEngine.Random.Range(2,-2));


               pos = benzierFireBall[UnityEngine.Random.Range(0, benzierFireBall.Count - 1)].transform.position;

               var vecArray = new Vector3[] { posSpawnMultiFireBall.transform.position, pos, enemyControl.transform.position };
               newMultiFireBall.transform.DOPath(vecArray, speedFireBall, PathType.CatmullRom, PathMode.Full3D, 10, Color.red);

           });

            //var newMultiFireBallMuzzle = Instantiate(multiFireBallProject);
            //newMultiFireBallMuzzle.transform.position = posSpawnMultiFireBall.transform.position;


            //newMultiFireBall.transform.DOMove(childEnemy.GetComponent<PlayerMoveController>().getSpellPos.transform.position, .5f).OnComplete(() =>
            // {
            //     CreateSpellImpact(childEnemy.transform.position, enemyControl);
            // });




    }




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
    chargeEff.SetActive(false);
});
    }

    public GameObject skill2Eff;
public override void Skill2()
{
    Debug.LogError("SKILL 2");


    childArm.animation.FadeIn("Skill2", 0.2f, 1, 1);

    CameraControl.instant.FocusCamera(true);
    var standWind = Instantiate(skill2Eff);
    standWind.transform.position = posStandWind.transform.position;

    standWind.transform.eulerAngles = _arma.transform.eulerAngles;
    standWind.transform.localScale = new Vector3(1, 1 * _arma.transform.localScale.y, 1);
    var gokuBall = Instantiate(ReferenceAll.instant.gokuEff_1[0]);
    gokuBall.transform.localPosition = posBigBall.transform.position;


    DOVirtual.DelayedCall(2f, () =>
    {
        gokuBall.transform.DOMove(childEnemy.GetComponent<PlayerMoveController>().getSpellPos.transform.position, .3f).OnComplete(() =>
        {
            CreateSpellImpact(childEnemy.transform.position, enemyControl);
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
public GameObject posSkill3, posBigBall, posStandWind;
public Collider2D hitBox;
UnityArmatureComponent childArm;


//fire small fireball
public override void Skill3()
{
    childArm.animation.FadeIn("Skill3", 0.07f, 1, 1);
    DOVirtual.DelayedCall(0.1f, () =>
    {
        var newProjectile = Instantiate(myProjectile);



        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), hitBox);

        newProjectile.transform.position = posSkill3.transform.position;

        newProjectile.transform.eulerAngles = gameObject.transform.eulerAngles;


        var newMuzzle = Instantiate(myMuzzle);
        newMuzzle.transform.eulerAngles = gameObject.transform.eulerAngles;

        newMuzzle.transform.position = posSkill3.transform.position;

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


}
