using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    public static Input_Manager _INPUT_MANAGER;
    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(_INPUT_MANAGER);
        }
        else
        {
            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }
}
