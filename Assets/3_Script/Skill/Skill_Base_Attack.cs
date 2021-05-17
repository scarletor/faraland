using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DragonBones;
using UnityEngine.UI;
public class Skill_Base_Attack : Skill_Base
{



    public override void CastSkill()
    {
        Debug.LogError("CAST SKILL NORMAL ATTACK__00000" + target);

        var basePos = transform.parent.transform.position;
        transform.parent.transform.DOMove(target.transform.position + new Vector3(-4*dir, 0), .4f).OnComplete(() =>
        {
            _arm.animation.FadeIn("Attack1", 0.1f, 1, 1);
            DOVirtual.DelayedCall(.2f, () =>
            {
                DamageTarget(35);




            });
        });



        DOVirtual.DelayedCall(1.5f, () =>
        {
            transform.parent.transform.DOMove(basePos, .3f);
            _arm.animation.FadeIn("Idle", 0.1f, 1, 1);

        });

        TurnManager.ins.DisablePlayerBtn();
        TurnManager.ins.NextTurn();


        gameObject.SetActive(false);



    }





}
