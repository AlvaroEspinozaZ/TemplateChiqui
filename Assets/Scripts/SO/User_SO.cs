using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "User_SO", menuName = "ScriptableObject/Score/User", order = 2)]
public class User_SO : ScriptableObject
{
    [SerializeField] public string _name;
    [SerializeField] public float _score;

    public void SetName(string na)
    {
        _name = na;
    }
}
