using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RankingController : MonoBehaviour
{
    [SerializeField] private Text[] scoresList;
    [SerializeField] private Text[] nameScoresList;
    [SerializeField] private User_SO[] ScoresUsers;
    public HandleMessage muerte;
    public User_SO userTarget;

    void Start()
    {
        RegistryNewScore(userTarget);
        SetScore(ScoresUsers);

    }
    private void OnEnable()
    {
        muerte.ActionGeneral += setUser;

    }
    private void OnDisable()
    {
        muerte.ActionGeneral -= setUser;

    }
    public void setUser()
    {
        
    }
    public void RegistryNewScore(User_SO newScore)
    {
        float[] newMaxScore = new float[5];
        string[] newMaxScoreString = new string[5];
        for (int i = 0; i < newMaxScore.Length; i++)
        {
            newMaxScore[i] = 0;
            newMaxScoreString[i] = "";
        }
        bool isCHanged = false;
        for (int i = 0; i < ScoresUsers.Length; i++)
        {
            float safePrevius = ScoresUsers[i]._score;
            string safePreviusString = ScoresUsers[i]._name;
            if (newScore._score > ScoresUsers[i]._score && !isCHanged)
            {
                newMaxScore[i]=(newScore._score);
                newMaxScoreString[i] = newScore._name;
                i++;
                isCHanged = true;
            }
            newMaxScore[i] = safePrevius;
            newMaxScoreString[i] = safePreviusString;
        }
        for (int i = 0; i < ScoresUsers.Length; i++)
        {
            ScoresUsers[i]._score = newMaxScore[i];
            ScoresUsers[i]._name = newMaxScoreString[i];
        }
    }
    public void SetScore(User_SO[] newList)
    {
        for (int i = 0; i < newList.Length; i++)
        {
            scoresList[i].text =""+ newList[i]._score + "pnts";
            nameScoresList[i].text = "" + newList[i]._name;
        }      
    }
}
