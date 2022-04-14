using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardVideos : MonoBehaviour {

    private int nroVideosVistos;
    public Text nroVideosText;

    private int nroVideosVistos2;
    public Text nroVideosText2;

    private int nroVideosVistos3;
    public Text nroVideosText3;

    private int nroVideosVistos4;
    public Text nroVideosText4;


    public GameObject bloqueoTenis;
    public GameObject bloqueoBasket;
    public GameObject bloqueoBaseball;
    public GameObject bloqueoBeach;

    public GameObject failed;
    public GameObject skipped;

    public void OnEnable()
    {
        nroVideosVistos = PlayerPrefs.GetInt("Tenis");
        if(nroVideosVistos == 5)
        {
            bloqueoTenis.SetActive(false);
        }

        nroVideosVistos2 = PlayerPrefs.GetInt("Basket");
        if (nroVideosVistos2 == 5)
        {
            bloqueoBasket.SetActive(false);
        }

        nroVideosVistos3 = PlayerPrefs.GetInt("Base");
        if (nroVideosVistos3 == 5)
        {
            bloqueoBaseball.SetActive(false);
        }

        nroVideosVistos4 = PlayerPrefs.GetInt("Beach");
        if (nroVideosVistos4 == 10)
        {
            bloqueoBeach.SetActive(false);
        }
    }

    public void ShowAdTenis()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo",new ShowOptions() {resultCallback = HandleAdResult });
        }
    }

    public void ShowAdBasket()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult2 });
        }
    }

    public void ShowAdBaseBall()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult3 });
        }
    }

    public void ShowAdBeach()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult4 });
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                nroVideosVistos++;
                nroVideosText.text = nroVideosVistos.ToString() + "/5";
                PlayerPrefs.SetInt("Tenis", nroVideosVistos);

                if(nroVideosVistos == 5)
                {
                    bloqueoTenis.SetActive(false);
                }
                break;
            case ShowResult.Skipped:
                skipped.SetActive(true);
                break;
            case ShowResult.Failed:
                failed.SetActive(true);
                break;
        }
    }

    private void HandleAdResult2(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                nroVideosVistos2++;
                nroVideosText2.text = nroVideosVistos2.ToString() + "/5";
                PlayerPrefs.SetInt("Basket", nroVideosVistos2);

                if (nroVideosVistos2 == 5)
                {
                    bloqueoBasket.SetActive(false);
                }
                break;
            case ShowResult.Skipped:
                skipped.SetActive(true);
                break;
            case ShowResult.Failed:
                failed.SetActive(true);
                break;
        }
    }

    private void HandleAdResult3(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                nroVideosVistos3++;
                nroVideosText3.text = nroVideosVistos3.ToString() + "/5";
                PlayerPrefs.SetInt("Base", nroVideosVistos3);

                if (nroVideosVistos3 == 5)
                {
                    bloqueoBaseball.SetActive(false);
                }
                break;
            case ShowResult.Skipped:
                skipped.SetActive(true);
                break;
            case ShowResult.Failed:
                failed.SetActive(true);
                break;
        }
    }

    private void HandleAdResult4(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                nroVideosVistos4++;
                nroVideosText4.text = nroVideosVistos4.ToString() + "/10";
                PlayerPrefs.SetInt("Beach", nroVideosVistos4);

                if (nroVideosVistos4 == 10)
                {
                    bloqueoBeach.SetActive(false);
                }
                break;
            case ShowResult.Skipped:
                skipped.SetActive(true);
                break;
            case ShowResult.Failed:
                failed.SetActive(true);
                break;
        }
    }
}
