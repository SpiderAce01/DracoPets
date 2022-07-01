using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    #region Singleton
    public static ScoreTracker instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ScoreTracker found");
            return;
        }
        instance = this;
    }
    #endregion

    public int score;
    public Text scoreText;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    
    void Update()
    {
        score = (int)Vector3.Distance(transform.position, startPos);
        scoreText.text = score.ToString() + " M";
    }
}
