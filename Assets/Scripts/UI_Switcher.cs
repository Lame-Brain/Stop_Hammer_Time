using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Switcher : MonoBehaviour
{
    public Color retroGreen, retroPurple, retroBlue, retroPink, retroYellow;
    public GameObject BG, player1Spot, player2Spot, titleText;
    public TMPro.TextMeshProUGUI TimerText;
    public Image player1Move, player2Move;
    public Sprite moveStop, moveHammer, moveTime;
    public float Timer;
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
        if(!PAUSED && !GAMEOVER)
        {
            if(Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D))
            {
                player1Move.sprite = moveStop;
                MusicManager.instance.PlaySlap();
            }
            if(Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
            {
                player1Move.sprite = moveHammer;
                MusicManager.instance.PlaySlap();
            }
            if(Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.A))
            {
                player1Move.sprite = moveTime;
                MusicManager.instance.PlaySlap();
            }

            if (Settings.instance.TwoPlayer)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player2Move.sprite = moveStop;
                    MusicManager.instance.PlaySlap();
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player2Move.sprite = moveHammer;
                    MusicManager.instance.PlaySlap();
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player2Move.sprite = moveTime;
                    MusicManager.instance.PlaySlap();
                }
            }

            if (!Settings.instance.TwoPlayer)
            {
                if(ComputerMove == 0) player2Move.sprite = moveStop;
                if(ComputerMove == 1) player2Move.sprite = moveHammer;
                if(ComputerMove == 2) player2Move.sprite = moveTime;
            }
        }
        
        if (Timer <= 0 && !GAMEOVER) 
        {
            GAMEOVER = true;
            PAUSED = true;
            titleText.SetActive(true);
            StartCoroutine(GoToLastScreenAfter1Second());
        }
    }

    IEnumerator GoToLastScreenAfter1Second()
    {
        yield return new WaitForSeconds(1f);
        GameObject _go = Instantiate(resultsPrefab, this.transform);
        _go.GetComponent<ResultsPanel>().Player1_EndMove.sprite = player1Move.sprite;
        _go.GetComponent<ResultsPanel>().Player2_EndMove.sprite = player2Move.sprite;
        if (!Settings.instance.TwoPlayer)
        {
            if (player1Move.sprite == moveStop && player2Move.sprite == moveStop) _go.GetComponent<ResultsPanel>().Result_Text.text = "TIE GAME";
            if (player1Move.sprite == moveStop && player2Move.sprite == moveHammer) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER WINS";
            if (player1Move.sprite == moveStop && player2Move.sprite == moveTime) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER LOSES";

            if (player1Move.sprite == moveHammer && player2Move.sprite == moveStop) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER LOSES";
            if (player1Move.sprite == moveHammer && player2Move.sprite == moveHammer) _go.GetComponent<ResultsPanel>().Result_Text.text = "TIE GAME";
            if (player1Move.sprite == moveHammer && player2Move.sprite == moveTime) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER WINS";

            if (player1Move.sprite == moveTime && player2Move.sprite == moveStop) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER WINS";
            if (player1Move.sprite == moveTime && player2Move.sprite == moveHammer) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER LOSES";
            if (player1Move.sprite == moveTime && player2Move.sprite == moveTime) _go.GetComponent<ResultsPanel>().Result_Text.text = "TIE GAME";
        }
        if (Settings.instance.TwoPlayer)
        {
            if (player1Move.sprite == moveStop && player2Move.sprite == moveStop) _go.GetComponent<ResultsPanel>().Result_Text.text = "TIE GAME";
            if (player1Move.sprite == moveStop && player2Move.sprite == moveHammer) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER1 WINS";
            if (player1Move.sprite == moveStop && player2Move.sprite == moveTime) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER2 WINS";

            if (player1Move.sprite == moveHammer && player2Move.sprite == moveStop) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER2 WINS";
            if (player1Move.sprite == moveHammer && player2Move.sprite == moveHammer) _go.GetComponent<ResultsPanel>().Result_Text.text = "TIE GAME";
            if (player1Move.sprite == moveHammer && player2Move.sprite == moveTime) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER1 WINS";

            if (player1Move.sprite == moveTime && player2Move.sprite == moveStop) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER1 WINS";
            if (player1Move.sprite == moveTime && player2Move.sprite == moveHammer) _go.GetComponent<ResultsPanel>().Result_Text.text = "PLAYER2 WINS";
            if (player1Move.sprite == moveTime && player2Move.sprite == moveTime) _go.GetComponent<ResultsPanel>().Result_Text.text = "TIE GAME";
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
        _random = Random.Range(0, 5);
        if (_random == 0) player1Spot.GetComponent<Image>().color = retroGreen;
        if (_random == 1) player1Spot.GetComponent<Image>().color = retroPurple;
        if (_random == 2) player1Spot.GetComponent<Image>().color = retroBlue;
        if (_random == 3) player1Spot.GetComponent<Image>().color = retroPink;
        if (_random == 4) player1Spot.GetComponent<Image>().color = retroYellow;
        _random = Random.Range(0, 5);
        if (_random == 0) player2Spot.GetComponent<Image>().color = retroGreen;
        if (_random == 1) player2Spot.GetComponent<Image>().color = retroPurple;
        if (_random == 2) player2Spot.GetComponent<Image>().color = retroBlue;
        if (_random == 3) player2Spot.GetComponent<Image>().color = retroPink;
        if (_random == 4) player2Spot.GetComponent<Image>().color = retroYellow;
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
