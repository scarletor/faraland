using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DragonBones;

public class Skill_Normal_1_kame : Skill_Base
{

    //SKIL KAMEKAMEHA





    public GameObject chargeBeam,beam,beamImpact,chargeEff;

    public override void CastSkill()
    {





        _arm.RemoveDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);

        _arm.animation.FadeIn("Skill2", 0.2f, 1, 1);
        chargeBeam.SetActive(true);
        beam.GetComponent<LineRenderer>().SetPosition(0, new Vector3(0, 0, 0));


        var startBeamPos = transform.position;
        startBeamPos.y -= 1;
        chargeBeam.transform.position = startBeamPos;


        for (int i = 0; i < 10; i++)
        {
            DOVirtual.DelayedCall(2.3f + i * .15f, () =>
            {
                //enemyControl.GetSkill();


                DamageTarget(10);
                CreateSpellImpactTarget2();


          

            });
        }


        // posStartBeamMove
        DOVirtual.DelayedCall(2f, () =>
        {
            beam.active = true;
            beamImpact.active = true;
            var posKameMove2 = myBody.transform.position;
            posKameMove2.x += 3*dir;

            posKameMove2.z = -10*dir;
            chargeBeam.transform.DOMove(posKameMove2, .1f);

            isBeamFire = true;



            //CreateSpellImpact(enemyControl.gameObject.transform.position, enemyControl);

        });




        DOVirtual.DelayedCall(4, () =>
        {
            chargeEff.active = false;
            beam.active = false;
            beamImpact.active = false;
            _arm.animation.FadeIn("Idle", 0.2f, 1, 1);
            chargeBeam.SetActive(false);
            var lastBoom = Instantiate(ReferenceAll.instant.bigNova, target.transform.position, Quaternion.identity, null);

            _arm.AddDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);

            TurnManager.ins.NextTurn();

            gameObject.SetActive(false);

        });










    }
    bool isBeamFire = false;
    private void Update()
    {
        if (isBeamFire == false) return;
        if (target == null) return;
        var posBeamImpact = target.transform.position;
        posBeamImpact.z = -11;
        beamImpact.transform.position = posBeamImpact;
        beam.GetComponent<LineRenderer>().SetPosition(0, chargeBeam.transform.position);

        var posEndBeam = target.transform.position;
        posEndBeam.z = -10;
        beam.GetComponent<LineRenderer>().SetPosition(1, posEndBeam);

        beam.GetComponent<LineRenderer>().sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * 3, 0);
    }


}
