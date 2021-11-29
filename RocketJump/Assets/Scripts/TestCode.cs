using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamEnDEVor.Utility;

public class TestCode : MonoBehaviour
{
    void Awake()
    {
        List<int> asdf = new List<int>();
        asdf.Add(5);
        ErrorChecker.IsNull(asdf);

        asdf.Clear();
        ErrorChecker.IsNull(asdf);
    }
}