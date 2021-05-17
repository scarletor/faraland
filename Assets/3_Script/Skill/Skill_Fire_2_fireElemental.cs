using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using DragonBones;
public class Skill_Fire_2_fireElemental : Skill_Base
{
    [GUIColor(0f, 1f, 1, 1f)]
    // skill thunderStrike
    public GameObject elemental, impact;
    public bool isElemental;
    public override void CastSkill()
    {

        if (isElemental) return;
        _arm.RemoveDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);

        _arm.animation.FadeIn("CastSpell", 0.5f, 1, 1);


        var newElemental0 = Instantiate(elemental);
        var pos2 = myBody.transform.position;
        pos2.x += 3f * dir;
        pos2.x += -2f * dir;
        newElemental0.transform.transform.position = pos2;

        TurnManager.ins.elementalWaitList.Add(newElemental0.transform);



        var newElemental1 = Instantiate(elemental);
        newElemental1.transform.transform.position = pos2;
        TurnManager.ins.elementalWaitList.Add(newElemental1.transform);





        var newElemental2 = Instantiate(elemental);
        newElemental2.transform.transform.position = pos2;
        TurnManager.ins.elementalWaitList.Add(newElemental2.transform);



        var pos1 = myBody.transform.position;

        DOVirtual.DelayedCall(2, () =>
        {
            pos1.y += 7;
            pos1.x += 4;
            newElemental0.transform.DOMove(pos1, 1);
        });

        DOVirtual.DelayedCall(2.5f, () =>
        {
            pos1.x += -4;

            newElemental1.transform.DOMove(pos1, 1);
        });


        DOVirtual.DelayedCall(3, () =>
        {
            pos1.x += -4;

            newElemental2.transform.DOMove(pos1, 1);
        });









        DOVirtual.DelayedCall(3, () =>
        {
            myCharacter.PlayIdle();



        });









        gameObject.SetActive(false);
        TurnManager.ins.NextTurn();
    }

    public override void ElementalFire()
    {


        DOVirtual.DelayedCall(1f, () =>
        {

            if (CharacterControl.enemyFront.gameObject == null) return;
            if (canfire == false) return;
            canfire = false;

            GetComponent<Skill_Base>().target = CharacterControl.enemyFront.gameObject;

            transform.DOMove(target.transform.position, 1).OnComplete(() =>
            {

                DamageTarget(15);



                var newImpact = Instantiate(impact);
                newImpact.transform.position = gameObject.transform.position;


                TurnManager.ins.elementalWaitList.Remove(gameObject.transform);
                Destroy(gameObject);

            });


        });




    }














    //var standWind = Instantiate(ReferenceAll.instant.gokuEff_1[1]);
    //var posStandWin = transform.position;
    //posStandWin.y -=6;

    //standWind.transform.position = posStandWin;
    //standWind.transform.eulerAngles = _arm.transform.eulerAngles;
    //standWind.transform.localScale = new Vector3(1, 1 * _arm.transform.localScale.y, 1);


    //var gokuBall = Instantiate(ReferenceAll.instant.gokuEff_1[0]);
    //var posGokuBall = transform.position;
    //posGokuBall.y += 6;
    //gokuBall.transform.localPosition = posGokuBall;


    //DOVirtual.DelayedCall(2f, () =>
    //{
    //    var enemySidePos = target.transform.position;
    //    enemySidePos.x -= 2*dir;
    //    gokuBall.transform.DOMove(enemySidePos, .3f).OnComplete(() =>
    //    {
    //        gokuBall.transform.DOMove(target.transform.position, 3f);




    //        //create effect spell booom
    //        for (int i = 0; i < 10; i++)
    //        {
    //            var rd = target.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, 2f));
    //            DOVirtual.DelayedCall(.2f * i, () =>
    //            {
    //                Instantiate(ReferenceAll.instant.effSpell[Random.Range(0, ReferenceAll.instant.effSpell.Count)], rd, Quaternion.identity, null);
    //                DamageTarget(2);





    //            });
    //        }



    //    });
    //    standWind.SetActive(false);


    //});




    //gameObject.SetActive(false);
}

