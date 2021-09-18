using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Color retroGreen, retroPurple, retroBlue, retroPink, retroYellow;
    public GameObject BG, player1Icon, player2Icon, computerIcon;
    public TMPro.TextMeshProUGUI buttonText;

    private void Awake()
    {
        InvokeRepeating("SwitchBackGroundColor", 1.0f, 1.0f);
    }

    private void SwitchBackGroundColor()
    {
        int _random = Random.Range(0, 5);
        if (_random == 0) BG.GetComponent<Image>().color = retroGreen;
        if (_random == 1) BG.GetComponent<Image>().color = retroPurple;
        if (_random == 2) BG.GetComponent<Image>().color = retroBlue;
        if (_random == 3) BG.GetComponent<Image>().color = retroPink;
        if (_random == 4) BG.GetComponent<Image>().color = retroYellow;
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ChangeNumberOfPlayers()
    {
        Settings.instance.TwoPlayer = !Settings.instance.TwoPlayer;
        if (Settings.instance.TwoPlayer)
        {
            player2Icon.SetActive(true);
            computerIcon.SetActive(false);
            buttonText.text = "Switch to\n1 Player Game";
        }
        else
        {
            player2Icon.SetActive(false);
            computerIcon.SetActive(true);
            buttonText.text = "Switch to\n2 Player Game";
        }
    }    
}
