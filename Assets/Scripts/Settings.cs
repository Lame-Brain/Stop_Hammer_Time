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
        StartCoroutine(BeginGame());
    }

    IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(2.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
