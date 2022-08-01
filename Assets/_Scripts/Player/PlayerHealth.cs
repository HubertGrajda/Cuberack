using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerHealth : MonoBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;

    private PlayerAttack playerAttack;

    private Animator anim;
    private const string damagedAnim = "Damaged";
    private const string deathAnim = "Death";

    [SerializeField] private int maxHp;
    private int currHp;

    [SerializeField] private GameObject healthPoint;
    private List<GameObject> healthBar = new List<GameObject>();

    [SerializeField] private Transform healthbarTransform;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.Instance;

        playerAttack = GetComponent<PlayerAttack>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        currHp = maxHp;
        HealthBar();
    }
    public void Damaged(uint damage)
    {
        audioManager.PlaySound("PlayerDamaged");
        for (int i = 0; i < damage; i++)
        {
            currHp--;
            if (currHp <= 0)
            {
                Death();
                return;
            }
            healthBar[currHp].SetActive(false);
        }
        if(playerAttack.projectileType != PlayerAttack.ProjectileType.basic)
        {
            playerAttack.projectileType--;
        }
    }
    void Death()
    {
        anim.SetTrigger(deathAnim);
        gameManager.EndOfTheGame();
        gameManager.gameState = GameManager.GameState.Loss;
    }
    public void Heal(uint value)
    {
        for (int i = 0; i < value; i++)
        {
            if (currHp < maxHp)
            {
                healthBar[currHp].SetActive(true);
                currHp++;
            }
        }

    }

    void HealthBar()
    {
        for (int i = 0; i < maxHp; i++)
        {
            GameObject instantiated = Instantiate(healthPoint, healthbarTransform).gameObject;

            healthBar.Add(instantiated);
            if (i != 0)
                instantiated.transform.position = healthBar[i - 1].transform.position + new Vector3(1, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            anim.SetTrigger(damagedAnim);
            Damaged(1);
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Death();
        }
    }
}
