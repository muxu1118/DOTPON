using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkManager : MonoBehaviour
{
    public static NetWorkManager Instance { get; private set; }

    public int TotalPlayer;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
