using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    private static Manager _instance;
    public static Manager Instance {
        get
        {
            if(_instance == null)
            {
                _instance = new Manager();
            }
            return _instance;
        }
    }

    private Manager() //
    {

    }
    public int version = 1;
}
