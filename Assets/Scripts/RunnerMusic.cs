using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMusic : MonoBehaviour
{
    public static RunnerMusic instance;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level != 4)
        {
            Destroy(this.gameObject);
        }
    }
}
