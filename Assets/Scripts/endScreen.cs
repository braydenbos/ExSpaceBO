using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScreen : MonoBehaviour
{
    public CanvasGroup forNowGroup;
    public CanvasGroup youSurvivedGroups;
    public CanvasGroup buttonGroup;

    public bool toFade;
    void Start()
    {
        forNowGroup.alpha = 0f;
        youSurvivedGroups.alpha = 0f;
        buttonGroup.alpha = 0f;
        toFade = true;
    }
    void Update()
    {
        if (toFade)
        {
            if(forNowGroup.alpha < 1f || youSurvivedGroups.alpha < 1f)
            {
                youSurvivedGroups.alpha += Time.deltaTime / 8;
                forNowGroup.alpha += Time.deltaTime / 9;
                buttonGroup.alpha += Time.deltaTime / 10;
                if (forNowGroup.alpha >= 1f)
                {
                    toFade = false;
                }
            }
        }
    }
}
