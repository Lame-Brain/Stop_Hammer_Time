using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Switcher : MonoBehaviour
{
    public Color retroGreen, retroPurple, retroBlue, retroPink, retroYellow;
    public GameObject BG;
    public TMPro.TextMeshProUGUI TimerText;
    public Image player1Move, player2Move;
    public Sprite moveStop, moveHammer, moveTime;
    public float Timer;
    public bool Player2;
    public GameObject resultsPrefab;

    private bool PAUSED = false, GAMEOVER = false;
    private int ComputerMove;


    private void Awake()
    {
        InvokeRepeating("SwitchBackGroundColor", 1.0f, 1.0f);
        InvokeRepeating("TimerCountDown", .1f, .1f);
        InvokeRepeating("GetComputerMove", .2f, .2f);
    }

    private void Update()
    {
        if (Timer <= 0)
        {
            PAUSED = true;
            GAMEOVER = true;
        }

        if(!PAUSED && !GAMEOVER)
        {
            if(Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
            {
                player1Move.sprite = moveStop;
            }
            if(Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
            {
                player1Move.sprite = moveHammer;
            }
            if(Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A))
            {
                player1Move.sprite = moveTime;
            }

            if (Player2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player2Move.sprite = moveStop;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player2Move.sprite = moveHammer;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player2Move.sprite = moveTime;
                }
            }

            if (!Player2)
            {
                if(ComputerMove == 0) player2Move.sprite = moveStop;
                if(ComputerMove == 1) player2Move.sprite = moveHammer;
                if(ComputerMove == 2) player2Move.sprite = moveTime;
            }
        }

        if (GAMEOVER)
        {
            Instantiate(resultsPrefab, this.transform);
        }
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

    private void TimerCountDown()
    {
        if (!PAUSED) Timer -= 0.1f;
        TimerText.text = Timer.ToString("00.0");
    }

    private void GetComputerMove()
    {
        if(Timer > .5f) ComputerMove = Random.Range(0, 3);
    }
}
