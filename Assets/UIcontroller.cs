using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIcontroller : MonoBehaviour
{
    public Text hight;
    public HandleMessage puntos;
    public User_SO userTarget;
    void Start()
    {
        puntos.ActionGeneralInt += SumarScore;
        userTarget._score = 0;
    }

    void Update()
    {
        hight.text = "Hight" + userTarget._score;
    }
    public void SumarScore(int i)
    {
        userTarget._score = userTarget._score + i;
    }
}
