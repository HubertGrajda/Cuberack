using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PowerUp_Spawn))]
public class EnemyHealth : MonoBehaviour
{
    GameManager gameManager;
    private PowerUp_Spawn powerUps;
    private ScoreDisplay scoreDisp;
    private EnemiesManager enemiesManager;

    [SerializeField] private int maxHp;
    private int currHp;
    private void Awake()
    {
        gameManager = GameManager.Instance;
        powerUps = GetComponent<PowerUp_Spawn>();
        enemiesManager = FindObjectOfType<EnemiesManager>();
        scoreDisp = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
    }
    private void Start()
    {
        currHp = maxHp;
    }
    private void OnEnable()
    {
        currHp = maxHp;
    }
    void Death()
    {
        gameObject.SetActive(false);

        gameManager.score++;
        if (gameManager.gameState == GameManager.GameState.InGame) // just in case to not change score if player's projectile kill an enemy after death
            scoreDisp.SetText();

        enemiesManager.enemiesKilled++;
        enemiesManager.IfAllEnemiesKilled();
        powerUps.Lottery();
    }
    public void Damaged(int damage)
    {
        currHp -= damage;
        if (currHp == 0)
        {
            Death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Damaged(1);
            other.gameObject.SetActive(false);
        }

    }
}
