using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnumeratorBase<T1>
{
    public RunningEnumeratorBases runningEnumeratorBases { get; set; }

    public class RunningEnumeratorBases
    {
        private Dictionary<T1, EnumeratorBase> runningEnumeratorBases;

        public RunningEnumeratorBases()
        {
            runningEnumeratorBases = new Dictionary<T1, EnumeratorBase>();
            DefaultValueChecker<Dictionary<T1, EnumeratorBase>>.IsDefaultValue(runningEnumeratorBases);
        }

        public void ClearEnumeratorBases()
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return;

            runningEnumeratorBases.Clear();
        }

        public void AddEnumeratorBase(T1 key, IEnumerator enumerator, Action action, float time = 0f)
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return;

            if (runningEnumeratorBases.ContainsKey(key))
            {
                LogHelper.WarningMessage("This key already exists. / Key name: {0}", key);
                return;
            }

            EnumeratorBase enumeratorBase = new EnumeratorBase(enumerator, action, false, time);

            if (ErrorHelper.IsNull(enumeratorBase, "This enumeratorBase is NULL!"))
                return;

            runningEnumeratorBases.Add(key, enumeratorBase);
        }

        public void AddEnumeratorBase(T1 key, EnumeratorBase enumeratorBase)
        {
            if (ErrorHelper.IsNull(enumeratorBase, "This enumeratorBase is NULL!"))
                return;

            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return;

            if (runningEnumeratorBases.ContainsKey(key))
            {
                LogHelper.WarningMessage("This key already exists. / Key name: {0}", key);
                return;
            }

            runningEnumeratorBases.Add(key, enumeratorBase);
        }

        public void DeleteEnumeratorBase(T1 key)
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return;

            if (!runningEnumeratorBases.ContainsKey(key))
            {
                LogHelper.WarningMessage("This key doesn't exists. / Key name: {0}", key);
                return;
            }

            runningEnumeratorBases.Remove(key);
        }

        public EnumeratorBase GetEnumeratorBase(T1 key)
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return null;

            if (!runningEnumeratorBases.ContainsKey(key))
            {
                LogHelper.WarningMessage("This key doesn't exists. / Key name: {0}", key);
                return null;
            }

            if (ErrorHelper.IsNull(runningEnumeratorBases[key], "This EnumeratorBase is NULL!"))
                return null;

            return runningEnumeratorBases[key];
        }

        public void EditEnumeratorBase(T1 key, IEnumerator enumerator, Action action, bool isRunning, float time = 0f)
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return;

            if (!runningEnumeratorBases.ContainsKey(key))
            {
                LogHelper.WarningMessage("This key doesn't exists. / Key name: {0}", key);
                return;
            }

            if (ErrorHelper.IsNull(runningEnumeratorBases[key], "This EnumeratorBase is NULL!"))
                return;

            EnumeratorBase newEnumeratorBase = new EnumeratorBase(enumerator, action, isRunning, time);

            if (ErrorHelper.IsNull(newEnumeratorBase, "This newEnumeratorBase is NULL!"))
                return;

            runningEnumeratorBases[key] = newEnumeratorBase;
        }

        public void EditEnumeratorBase(T1 key, EnumeratorBase enumeratorBase)
        {
            if (ErrorHelper.IsNull(enumeratorBase, "This enumeratorBase is NULL!"))
                return;

            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return;

            if (!runningEnumeratorBases.ContainsKey(key))
            {
                LogHelper.WarningMessage("This key doesn't exists. / Key name: {0}", key);
                return;
            }

            if (ErrorHelper.IsNull(runningEnumeratorBases[key], "This EnumeratorBase is NULL!"))
                return;

            runningEnumeratorBases[key] = enumeratorBase;
        }

        public Dictionary<T1, EnumeratorBase> GetRunningEnumeratorBases()
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return null;

            return runningEnumeratorBases;
        }

        public int GetCount()
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return 0;

            return runningEnumeratorBases.Count;
        }

        public List<T1> GetKeyList()
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return null;

            List<T1> keyList = new List<T1>(runningEnumeratorBases.Keys);

            if (ErrorHelper.IsNull(keyList, "This keyList is NULL!"))
                return null;

            return keyList;
        }

        public List<EnumeratorBase> GetValueList()
        {
            if (ErrorHelper.IsNull(runningEnumeratorBases, "This enumeratorBaseDictionary is NULL!"))
                return null;

            List<EnumeratorBase> valueList = new List<EnumeratorBase>(runningEnumeratorBases.Values);

            if (ErrorHelper.IsNull(valueList, "This valueList is NULL!"))
                return null;

            return valueList;
        }
    }

    public class EnumeratorBase
    {
        private IEnumerator enumerator;
        private Action action;
        private float time;
        private bool isRunning;

        public EnumeratorBase(IEnumerator enumerator, Action action, bool isRunning = false, float time = 0f)
        {
            this.enumerator = enumerator;
            this.action = action;
            this.isRunning = isRunning;
            this.time = time;
        }

        public IEnumerator GetIEnumerator()
        {
            if (ErrorHelper.IsNull(this, "This IEnumeratorBase is NULL!"))
                return null;

            if (ErrorHelper.IsNull(enumerator, "This enumerator is NULL!"))
                return null;

            return enumerator;
        }

        public void SetIEnumerator(IEnumerator enumerator)
        {
            if (ErrorHelper.IsNull(this, "This IEnumeratorBase is NULL!"))
                return;

            if (ErrorHelper.IsNull(enumerator, "This enumerator is NULL!"))
                return;

            this.enumerator = enumerator;
        }

        public Action GetAction()
        {
            if (ErrorHelper.IsNull(this, "This IEnumeratorBase is NULL!"))
                return null;

            if (ErrorHelper.IsNull(action, "This action is NULL!"))
                return null;

            return action;
        }

        public float GetTime()
        {
            if (ErrorHelper.IsNull(this, "This IEnumeratorBase is NULL!"))
                return 0f;

            return time;
        }

        public bool GetRunningState()
        {
            if (ErrorHelper.IsNull(this, "This IEnumeratorBase is NULL!"))
                return false;

            return isRunning;
        }

        public void SetRunningState(bool isRunning)
        {
            if (ErrorHelper.IsNull(this, "This IEnumeratorBase is NULL!"))
                return;

            this.isRunning = isRunning;
        }
    }
}