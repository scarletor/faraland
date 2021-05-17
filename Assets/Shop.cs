using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        if(UIMng.instant.shopTabDisplay==4)
        {
            OnClickSwitchTab(3);

            UIMng.instant.shopTabDisplay =0;
            return;

        }

        if (UIMng.instant.shopTabDisplay == 2)
        {
            OnClickSwitchTab(1);

            UIMng.instant.shopTabDisplay = 0;
            return;

        }
        if (UIMng.instant.shopTabDisplay == 1)
        {
            OnClickSwitchTab(0);

            UIMng.instant.shopTabDisplay = 0;
            return;

        }


        if (UIMng.instant.shopTabDisplay == 0)
        {
            OnClickSwitchTab(0);
            return;

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public List<GameObject> scrollViewList, tabBtnList;




    public void OnClickSwitchTab(int index)
    {
        foreach(GameObject item in scrollViewList)
        {
            item.SetActive(false);
        }

        foreach(GameObject item in tabBtnList)
        {
            item.GetComponent<Image>().color = new Color(1, 1, 1, .3f);
        }


        tabBtnList[index].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        scrollViewList[index].SetActive(true);



    }







}
