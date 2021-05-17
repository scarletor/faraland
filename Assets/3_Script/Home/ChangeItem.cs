using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DragonBones;
public class ChangeItem : MonoBehaviour
{
    




    public void ChangeItemH()
    {

        var thisBtnName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        var stringArr = thisBtnName.Split('_');
        var itemType = stringArr[0];
        var itemID = Int32.Parse(stringArr[1]);

        var newItem = ItemData.ins.noItem;
        var curPlayer = CharacterControl.playerUIDisplaying;
        Debug.LogError(curPlayer);
        switch (itemType)
        {


            case "HEAD":
                curPlayer.head.sprite = ItemData.ins.headItem[itemID];


                break;
            case "BODY":
                curPlayer.body.sprite = ItemData.ins.bodyItem[itemID];

                break;
            case "ARM":
                curPlayer.leftHand.sprite = ItemData.ins.handItem[itemID];
                curPlayer.rightHand.sprite = ItemData.ins.handItem[itemID];

                break;
            case "PANT":
                curPlayer.leftPant.sprite = ItemData.ins.pantItem[itemID];
                curPlayer.rightPant.sprite = ItemData.ins.pantItem[itemID];

                break;
            case "BOOT":
                curPlayer.leftFoot.sprite = ItemData.ins.bootItem[itemID];
                curPlayer.rightFoot.sprite = ItemData.ins.bootItem[itemID];

                break;
            case "MAINHAND":
                curPlayer.mainArm.sprite = ItemData.ins.mainHandItem[itemID];

                break;
            case "OFFHAND":
                curPlayer.offArm.sprite = ItemData.ins.offHandItem[itemID];

                break;
            case "PET":

                break;
        }
    }


}

