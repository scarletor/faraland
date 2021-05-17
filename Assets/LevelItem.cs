using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class LevelItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        level = transform.GetSiblingIndex();
        gameObject.transform.GetChild(3).GetComponent<Text>().text = level.ToString();


        RefreshLevelList();
    }


    void RefreshLevelList()
    {
        //check lock or unlock
        isUnlocked = UserData01.GetLevelUnlock(level);
        if (!isUnlocked)
        {


            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);


            Debug.LogError(UIMng.instant.highestLevel + "__"+level);
            if (UIMng.instant.highestLevel == level)
            {
                Debug.LogError("XOA BO MAY DI ");
            }else
            gameObject.GetComponent<Image>().color = new Color(.5f, .5f, .5f, 1);
        }
    }
    public int level, max;
    public bool isUnlocked;



}
