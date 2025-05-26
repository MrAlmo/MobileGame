using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TicTacToe : MonoBehaviour
{
    public Button[] cells;
    public TMP_Text[] cellTexts;
    public TMP_Text statusText;
    private string currentPlayer = "X";
    private bool gameEnded = false;
    public GameObject ticTacToeUI;
    public bool Won = false;

    void Start()
    {

        for (int i = 0; i < cells.Length; i++)
        {
            int index = i;
            cells[i].onClick.AddListener(() => MakeMove(index));
        }

        ResetGame();
    }

    public void StartGame()
    {
        if (!Won)
        {
            ticTacToeUI.SetActive(true);

            for (int i = 0; i < cells.Length; i++)
            {
                int index = i;
                cells[i].onClick.AddListener(() => MakeMove(index));
            }

            ResetGame();
        }
    }

        private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGame();
        }
    }
    public void MakeMove(int index)
    {
        if (cellTexts[index].text == "" && !gameEnded)
        {
            cellTexts[index].text = "X";
            if (CheckWin())
            {
                statusText.text = $"Winner: {currentPlayer}";
                gameEnded = true;
                Won = true;
                return;
            }
            else if (IsDraw())
            {
                statusText.text = "Draw";
                gameEnded = true;
                return;
            }

            StartCoroutine(BotMove());
        }
    }

    private IEnumerator BotMove()
    {
        statusText.text = "Turn: O";
        yield return new WaitForSeconds(0.5f);

        List<int> availableIndices = new List<int>();

        for (int i = 0; i < cellTexts.Length; i++)
        {
            if (cellTexts[i].text == "")
            {
                availableIndices.Add(i);
            }
        }

        if (availableIndices.Count == 0) yield break;

        int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];
        cellTexts[randomIndex].text = "O";

        if (CheckWin())
        {
            statusText.text = $"Winner: O";
            gameEnded = true;
        }
        else if (IsDraw())
        {
            statusText.text = "Draw";
            gameEnded = true;
        }
        else
        {
            statusText.text = $"Turn: X";
        }
    }
    private bool CheckWin()
    {
        int[,] winConditions = new int[,] {
            {0,1,2},{3,4,5},{6,7,8},
            {0,3,6},{1,4,7},{2,5,8},
            {0,4,8},{2,4,6}
        };

        for (int i = 0; i < winConditions.GetLength(0); i++)
        {
            int a = winConditions[i, 0];
            int b = winConditions[i, 1];
            int c = winConditions[i, 2];

            if (cellTexts[a].text != "" &&
                cellTexts[a].text == cellTexts[b].text &&
                cellTexts[b].text == cellTexts[c].text)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsDraw()
    {
        foreach (var text in cellTexts)
        {
            if (text.text == "") return false;
        }
        return true;
    }

    public void ResetGame()
    {
        if (!Won)
        {
            for (int i = 0; i < cellTexts.Length; i++)
            {
                cellTexts[i].text = "";
            }

            currentPlayer = "X";
            gameEnded = false;
            statusText.text = $"Turn: {currentPlayer}";
        }
    }

    public void CloseGame()
    {
        ticTacToeUI.SetActive(false);
    }
}
