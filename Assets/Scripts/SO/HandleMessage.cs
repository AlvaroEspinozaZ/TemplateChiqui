using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Handle", menuName = "ScriptableObject/Handle/Message")]
public class HandleMessage : ScriptableObject
{
    public event Action<string> ActionGeneralString;
    public event Action<int> ActionGeneralInt;
    public event Action ActionGeneral;

    public void CallEventInt(int value)
    {
        ActionGeneralInt?.Invoke(value);
    }
    public void CallEventGeneral()
    {
        ActionGeneral?.Invoke();
    }
    public void CallEventString(string value)
    {
        ActionGeneralString?.Invoke(value);
    }
}
