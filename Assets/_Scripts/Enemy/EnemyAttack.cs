using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    ObjectPooler objPooler;
    AudioManager audioManager;
    [SerializeField] private enum ProjectileTag
    {
        basic, 
        purple,
        blue
    }
    [SerializeField] private ProjectileTag pickedProjectileTag;  //choose type of projectile in the inspector

    private const string basicProjectileTag = "EnemyProjectile";
    private const string purpleProjectileTag = "EnemyProjectilePurple";
    private const string blueProjectileTag = "EnemyProjectileBlue";

    string[] projectileTags =
        {
            basicProjectileTag,
            purpleProjectileTag,
            blueProjectileTag
        };

    private string projectileTag;


    [SerializeField] float projectileSpeed;
    [SerializeField] float minDelay;
    [SerializeField] float maxDelay;
    float randomTimeToShoot;
    void Start()
    {
        projectileTag = projectileTags[(int)pickedProjectileTag]; // converting projectile type picked in the inspector(enum) to string
        
        objPooler = ObjectPooler.Instance;
        audioManager = AudioManager.Instance;
        randomTimeToShoot = Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        randomTimeToShoot -= Time.deltaTime;
        if (randomTimeToShoot < 0)
        {
            Attack();
            randomTimeToShoot = Random.Range(minDelay, maxDelay);
        }
    }
    void Attack()
    {

        if (CanAttack())
        {
            audioManager.PlaySound("EnemyBlaster");
            GameObject tmpProjectile = objPooler.SpawnFromPool(projectileTag, transform.position, transform.rotation);
            tmpProjectile.GetComponent<Rigidbody>().velocity = -transform.forward * projectileSpeed;
            tmpProjectile.transform.parent = null;
        }
    }

    bool CanAttack() // checking if there is 'ally' in front of the enemy so the back lines will not shoot projectiles
    {
        Ray ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                return false;
            }
            return true;
        }
        else
        {
            return true;
        }
    }
}
