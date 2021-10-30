using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionBase<T1>
{
    public ActionBase actionBase { get; set; }

    public class ActionBase
    {
        private Dictionary<T1, Action> actionDictionary;

        public ActionBase()
        {
            actionDictionary = new Dictionary<T1, Action>();
            DefaultValueChecker<Dictionary<T1, Action>>.IsDefaultValue(actionDictionary);
        }

        public void AddAction(T1 key, Action action)
        {
            if (ErrorHelper.IsNull(actionDictionary, "actionDictionary is NULL!"))
                return;

            if (actionDictionary.ContainsKey(key))
            {
                LogHelper.WarningMessage("This Action already exist.");
                return;
            }

            actionDictionary.Add(key, action);
        }

        public void EditAction(T1 key, Action action)
        {
            if (ErrorHelper.IsNull(actionDictionary, "actionDictionary is NULL!"))
                return;

            if (!actionDictionary.ContainsKey(key))
            {
                LogHelper.WarningMessage("This Action doesn't exist.");
                return;
            }

            actionDictionary[key] = action;
        }

        public Action GetAction(T1 key)
        {
            if (ErrorHelper.IsNull(actionDictionary, "actionDictionary is NULL!"))
                return null;

            if (!actionDictionary.ContainsKey(key))
            {
                LogHelper.WarningMessage("This Action doesn't exist.");
                return null;
            }

            if (ErrorHelper.IsNull(actionDictionary[key], "This Action doesn't exist."))
                return null;

            return actionDictionary[key];
        }

        public void ClearActions()
        {
            if (ErrorHelper.IsNull(actionDictionary, "actionDictionary is NULL!"))
                return;

            actionDictionary.Clear();
        }
    }
}