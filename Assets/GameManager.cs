using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI tmPro;
    public int score = 0;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int _score)
    {
        score += _score;
        tmPro.text = $"Score : {score}";
    }
}
