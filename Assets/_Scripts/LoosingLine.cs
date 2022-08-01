using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosingLine : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.gameState = GameManager.GameState.Loss;
            gameManager.EndOfTheGame();
        }
        else
            other.gameObject.SetActive(false);
    }
}
