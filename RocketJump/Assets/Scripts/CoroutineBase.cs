using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineBase : MonoBehaviour, IEnumeratorBase<string>
{
    public enum ECoroutineActiveType
    {
        None = 0,
        Now,
        Later,
        While,
    }

    public IEnumeratorBase<string>.RunningEnumeratorBases runningEnumeratorBases { get; set; }

    public CoroutineBase()
    {
        runningEnumeratorBases = new IEnumeratorBase<string>.RunningEnumeratorBases();
    }

    public void ClearEnumeratorBase()
    {
        runningEnumeratorBases.ClearEnumeratorBases();
    }

    public void AddEnumeratorBase(string key, Action action, float time = 0f, 
        ECoroutineActiveType coroutineActiveType = ECoroutineActiveType.None)
    {
        IEnumeratorBase<string>.EnumeratorBase newEnumeratorBase = null;
        IEnumerator newEnumerator = null;

        switch(coroutineActiveType)
        {
            case ECoroutineActiveType.None:
                LogHelper.ErrorMessage("ECoroutineActiveType is none! Please choose ECoroutineActiveType!");
                return;

            case ECoroutineActiveType.Now:
                newEnumerator = DoNow(key, action);
                break;

            case ECoroutineActiveType.Later:
                newEnumerator = DoLater(key, action, time);
                break;

            case ECoroutineActiveType.While:
                newEnumerator = DoWhile(key, action, time);
                break;
        }

        if (ErrorHelper.IsNull(newEnumerator, "This newEnumerator is NULL!"))
            return;

        newEnumeratorBase = new IEnumeratorBase<string>.EnumeratorBase(newEnumerator, action, false, time);

        if (ErrorHelper.IsNull(newEnumeratorBase, "This newEnumeratorBase is NULL!"))
            return;

        runningEnumeratorBases.AddEnumeratorBase(key, newEnumeratorBase);
    }

    public void DeleteEnumeratorBase(string key)
    {
        runningEnumeratorBases.DeleteEnumeratorBase(key);
    }

    public IEnumeratorBase<string>.EnumeratorBase GetEnumeratorBase(string key)
    {
        return runningEnumeratorBases.GetEnumeratorBase(key);
    }

    public void EditEnumeratorBase(string key, Action action, bool isRunning, float time = 0f,
        ECoroutineActiveType coroutineActiveType = ECoroutineActiveType.None)
    {
        IEnumeratorBase<string>.EnumeratorBase newEnumeratorBase = null;
        IEnumerator newEnumerator = null;

        switch (coroutineActiveType)
        {
            case ECoroutineActiveType.None:
                LogHelper.ErrorMessage("ECoroutineActiveType is none! Please choose ECoroutineActiveType!");
                return;

            case ECoroutineActiveType.Now:
                newEnumerator = DoNow(key, action);
                break;

            case ECoroutineActiveType.Later:
                newEnumerator = DoLater(key, action, time);
                break;

            case ECoroutineActiveType.While:
                newEnumerator = DoWhile(key, action, time);
                break;
        }

        if (ErrorHelper.IsNull(newEnumerator, "This newEnumerator is NULL!"))
            return;

        newEnumeratorBase = new IEnumeratorBase<string>.EnumeratorBase(newEnumerator, action, isRunning, time);

        runningEnumeratorBases.EditEnumeratorBase(key, newEnumeratorBase);
    }

    public void StopRunningAllCoroutine()
    {
        int basesCount = runningEnumeratorBases.GetCount();

        for (int i = 0; i < basesCount; i++)
        {
            if (runningEnumeratorBases.GetValueList()[i].GetRunningState())
            {
                if (ErrorHelper.IsNull(runningEnumeratorBases.GetValueList()[i].GetIEnumerator(),
                    "This IEnumerator[{0}] is NULL!", i))
                    continue;

                StopCoroutine(runningEnumeratorBases.GetValueList()[i].GetIEnumerator());
                runningEnumeratorBases.GetValueList()[i].SetRunningState(false);
            }
        }
    }

    public void StopRunningCoroutine(string key)
    {
        if (ErrorHelper.IsNull(runningEnumeratorBases.GetEnumeratorBase(key).GetIEnumerator(),
            "This IEnumerator is NULL! / Key name : {0}", key))
            return;

        StopCoroutine(runningEnumeratorBases.GetEnumeratorBase(key).GetIEnumerator());
        runningEnumeratorBases.GetEnumeratorBase(key).SetRunningState(false);
    }

    public void ActiveEnumeratorBase(string key)
    {
        if (ErrorHelper.IsNull(runningEnumeratorBases.GetEnumeratorBase(key), "This EnumeratorBase is NULL!"))
            return;

        StartCoroutine(runningEnumeratorBases.GetEnumeratorBase(key).GetIEnumerator());
    }

    private IEnumerator DoNow(string key, Action action)
    {
        if (ErrorHelper.IsNull(action, "This action : {0} is NULL", action))
            StopCoroutine(DoNow(key, action));

        if (ErrorHelper.IsNull(runningEnumeratorBases.GetEnumeratorBase(key), "This EnumeratorBase is NULL!"))
            StopCoroutine(DoNow(key, action));

        runningEnumeratorBases.GetEnumeratorBase(key).SetRunningState(true);

        action();
        yield return null;

        runningEnumeratorBases.GetEnumeratorBase(key).SetRunningState(false);
    }

    private IEnumerator DoLater(string key, Action action, float time = 0f)
    {
        if (ErrorHelper.IsNull(action, "This action : {0} is NULL", action))
            StopCoroutine(DoLater(key, action, time));

        if (ErrorHelper.IsNull(runningEnumeratorBases.GetEnumeratorBase(key), "This EnumeratorBase is NULL!"))
            StopCoroutine(DoNow(key, action));

        if (time < 0f)
            StopCoroutine(DoLater(key, action, time));

        runningEnumeratorBases.GetEnumeratorBase(key).SetRunningState(true);

        WaitForSeconds wait = new WaitForSeconds(time);
        yield return wait;
        action();

        runningEnumeratorBases.GetEnumeratorBase(key).SetRunningState(false);
    }

    private IEnumerator DoWhile(string key, Action action, float time = 0f)
    {
        if (ErrorHelper.IsNull(action, "This action : {0} is NULL", action))
            StopCoroutine(DoWhile(key, action, time));

        if (ErrorHelper.IsNull(runningEnumeratorBases.GetEnumeratorBase(key), "This EnumeratorBase is NULL!"))
            StopCoroutine(DoNow(key, action));

        if (time < 0f)
            StopCoroutine(DoWhile(key, action, time));

        runningEnumeratorBases.GetEnumeratorBase(key).SetRunningState(true);

        float wait = time;

        while (wait >= 0f)
        {
            action();
            wait -= Time.deltaTime;
            yield return null;
        }

        runningEnumeratorBases.GetEnumeratorBase(key).SetRunningState(false);
    }
}