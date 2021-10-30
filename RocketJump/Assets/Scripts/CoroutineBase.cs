using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineBase : MonoBehaviour
{
    private IEnumerator DoLater(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
        StopCoroutine(DoLater(time, action));
    }

    public void DoWaitForSeconds(float time, Action action)
    {
        StartCoroutine(DoLater(time, action));
    }

    private IEnumerator DoNow(Action action)
    {
        yield return null;
        action();
        StopCoroutine(DoNow(action));
    }

    public void DoImmediately(Action action)
    {
        StartCoroutine(DoNow(action));
    }
}