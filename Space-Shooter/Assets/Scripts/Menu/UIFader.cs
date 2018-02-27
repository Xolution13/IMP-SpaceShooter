using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour {

    public CanvasGroup uiElement;
    private bool fadeUsed = false;

    public void FadeIn()
    {
        if(!fadeUsed)
        {
            StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
            uiElement.blocksRaycasts = true;
            fadeUsed = true;
        }

    }

    public void FadeOut()
    {
        uiElement.blocksRaycasts = false;
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1)
                break;

            yield return new WaitForEndOfFrame();
        }
    }
}
