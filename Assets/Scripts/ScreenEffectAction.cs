using System;
using System.Collections;
using System.Collections.Generic;
using Events;
using Project;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffectAction : MonoBehaviour
{
    private Image m_image;

    // Start is called before the first frame update
    void Start()
    {
        m_image = GetComponent<Image>();
        EventBus.Subscribe<ChangeLevelDetected>(OnChangeLevelDetected);
        EventBus.Post(new ChangeLevelDetected(null , false));
    }

    private void DelayLoading()
    {
        
    }

    private void OnChangeLevelDetected(ChangeLevelDetected obj)
    {
        var action = obj.exitAction;
        var isFadeIn = obj.isFadeIn;

        if (isFadeIn)
        {
            StartCoroutine(StartFadeIn(action));
        }
        else
        {
            StartCoroutine(StartFadeOut(action));
        }
        
        
    }


    private IEnumerator StartFadeIn(Action exitAction)
    {
        if (m_image.color.a < 1)
        {
            Color nextColor = m_image.color;
            nextColor.a = nextColor.a + 0.01f;

            m_image.color = nextColor;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(StartFadeIn(exitAction));
        }
        else
        {
            exitAction?.Invoke();
            yield return null;
        }
    }

    private IEnumerator StartFadeOut(Action exitAction)
    {
        if (m_image.color.a > 0)
        {
            Color nextColor = m_image.color;
            nextColor.a = nextColor.a - 0.01f;

            m_image.color = nextColor;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(StartFadeOut(exitAction));
        }
        else
        {
            exitAction?.Invoke();
            yield return null;
        }
    }
}