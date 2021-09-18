using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;
    public bool TwoPlayer;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
