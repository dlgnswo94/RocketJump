using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DateTime time = new DateTime(2021, 2, 3);
        DefaultValueManagement<DateTime>.GetDefaultValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
