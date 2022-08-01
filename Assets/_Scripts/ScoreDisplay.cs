using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class ScoreDisplay : MonoBehaviour
{
    GameManager gameManager;
    private TMP_Text text;
    private void Awake()
    {
        gameManager = GameManager.Instance;
        text = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        if (gameManager.gameState == GameManager.GameState.InGame)
        {
            gameManager.score = 0;
        }
        SetText();
    }

    public void SetText()
    {
        if (gameManager.gameState != GameManager.GameState.InGame)
        {
            Debug.Log(gameManager.gameState);
            if (gameManager.gameState == GameManager.GameState.Victory)
                text.text = "You Win! \n Total score: " + Convert.ToString(gameManager.score) + " points";
            else if (gameManager.gameState == GameManager.GameState.Loss)
                text.text = "You Lose! \n Total score: " + Convert.ToString(gameManager.score) + " points";
        }
        else
            text.text = "score: " + Convert.ToString(gameManager.score) + " points";
    }

}
