using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
public class Skill_Thunder_1_rainThunder : Skill_Base
{
    [GUIColor(0f, 1f, 1, 1f)]
    // skill thunderStrike
    public GameObject rain;
    public override void CastSkill()
    {

        _arm.animation.FadeIn("Skill1", 0.2f, 1, 1);




        var newThunder = Instantiate(rain);
        newThunder.transform.position = target.transform.position;
        TurnManager.ins.NextTurn();


    }





}
