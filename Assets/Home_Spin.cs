using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Home_Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(2, () => { RotateSpin(); });
    }

    // Update is called once per frame
    void Update()
    {

    }










    public void OnClickSpinFree()
    {
        RotateSpin();
    }



    public void OnClickSpinManyTimes()
    {

    }




    public void OnClickSpinAd()
    {

    }



    public GameObject spin, spinFreeBtn;
    public void RotateSpin()
    {
        var rd = Random.Range(3f, 6f);
        spin.transform.DORotate(new Vector3(1, 1, Random.Range(1300, 1700)), rd, RotateMode.FastBeyond360).OnComplete(() => { LightSpinEnd(); });
        LightSpining(rd);
    }
    public List<Image> spinLight;

    public void LightSpining(float second)
    {
        var secondTemp = second * 10;
        secondTemp = secondTemp - secondTemp / 10;

        var countLight = 0;
        for (int i = 0; i < secondTemp; i++)
        {
            DOVirtual.DelayedCall(.1f * i, () =>
            {

                foreach (Image light in spinLight)
                {
                    light.color = Color.black;
                }
                spinLight[countLight].color = Color.white;
                Debug.LogError(countLight);

                countLight++;
                if (countLight >= 8) countLight = 0;

            });

        }


    }


    public void LightSpinEnd()
    {
        for (int i = 0; i < 4; i++)
        {
            DOVirtual.DelayedCall(.3f * i, () =>
            {

                foreach (Image light in spinLight)
                {
                    light.color = Color.black;
                }

            });

            DOVirtual.DelayedCall(.15f + .3f * i, () =>
             {

                 foreach (Image light in spinLight)
                 {
                     light.color = Color.white;
                 }

             });



        }
    }
    public GameObject slideBar, closeBtn, rewardGR1, rewardGR2, rewardGR3, rewardGR4;
    public List<GameObject> rewardGR;

    public void OnClickShowSpinReward(int index)
    {
        foreach (GameObject item in rewardGR)
        {
            item.SetActive(false);
        }
        slideBar.transform.DOMoveX(17, 1);
        closeBtn.SetActive(true);

        rewardGR[index].SetActive(true);
    }

    public void OnClickCloseSpinReward()
    {
        slideBar.transform.DOMoveX(-.2f, 1);
        closeBtn.SetActive(false);

    }


}
