using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ItemData : MonoBehaviour
{






    public List<Sprite> headItem,handItem,bodyItem,pantItem,bootItem,mainHandItem,offHandItem;
    public Sprite noItem;

    public ItemInfo item1;


    public static ItemData ins;
    private void Awake()
    {
        ins = this;
    }







}

