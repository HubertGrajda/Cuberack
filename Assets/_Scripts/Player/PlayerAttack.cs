using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class PlayerAttack : MonoBehaviour
{
    ObjectPooler objPooler;
    AudioManager audioManager;

    public enum ProjectileType
    {
        basic,
        buffed,
        doubleBuffed,
        tripleBuffed
    }
    private ProjectileType _lastProjectiletype = Enum.GetValues(typeof(ProjectileType)).Cast<ProjectileType>().Last(); //last 'index' from enum
    private ProjectileType _projectileType;
    public ProjectileType projectileType
    {
        get => _projectileType;
        set
        {
            if (_projectileType != _lastProjectiletype || value < _lastProjectiletype) // to make sure we wont increment to state that does not exist
                _projectileType = value;
        }
    }
    private const string projectileTag = "PlayerProjectile";



    [SerializeField] float projectileSpeed;
    [SerializeField] private float delay;

    private float timer;
    private void Start()
    {
        _projectileType = ProjectileType.basic;
        objPooler = ObjectPooler.Instance;
        audioManager = AudioManager.Instance;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && timer < 0)
        {
            Attack();
            timer = delay;
        }
        timer -= Time.deltaTime;

    }

    void Attack()
    {
        audioManager.PlaySound("PlayerBlaster");
        switch(_projectileType)
        {
            case ProjectileType.basic:
                BasicAttack();
                break;

            case ProjectileType.buffed:
                DoubleAttack();
                break;
            case ProjectileType.doubleBuffed:
                TripleAttack();
                break;
            case ProjectileType.tripleBuffed:
                QuadrupleAttack();
                break;
        }
        


    }
    void BasicAttack()
    {
        GameObject tmpProjectile = objPooler.SpawnFromPool(projectileTag, transform.position, transform.rotation);

        tmpProjectile.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
    }
    void DoubleAttack()
    {
        GameObject tmpProjectile1 = objPooler.SpawnFromPool(projectileTag, transform.position - new Vector3(-0.2f, 0, 0), transform.rotation);
        GameObject tmpProjectile2 = objPooler.SpawnFromPool(projectileTag, transform.position + new Vector3(-0.2f, 0, 0), transform.rotation);

        tmpProjectile1.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
        tmpProjectile2.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
    }
    void TripleAttack()
    {
        GameObject tmpProjectile1 = objPooler.SpawnFromPool(projectileTag, transform.position, transform.rotation);
        GameObject tmpProjectile2 = objPooler.SpawnFromPool(projectileTag, transform.position, transform.rotation);
        GameObject tmpProjectile3 = objPooler.SpawnFromPool(projectileTag, transform.position, transform.rotation);

        tmpProjectile1.GetComponent<Rigidbody>().velocity = (transform.forward + new Vector3(0.1f, 0, 0)) * projectileSpeed;
        tmpProjectile2.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
        tmpProjectile3.GetComponent<Rigidbody>().velocity = (transform.forward - new Vector3(0.1f, 0, 0)) * projectileSpeed;
    }
    void QuadrupleAttack()
    {
        GameObject tmpProjectile1 = objPooler.SpawnFromPool(projectileTag, transform.position + new Vector3(0.1f, 0, 0), transform.rotation);
        GameObject tmpProjectile2 = objPooler.SpawnFromPool(projectileTag, transform.position + new Vector3(0.2f, 0, 0), transform.rotation);
        GameObject tmpProjectile3 = objPooler.SpawnFromPool(projectileTag, transform.position - new Vector3(0.1f, 0, 0), transform.rotation);
        GameObject tmpProjectile4 = objPooler.SpawnFromPool(projectileTag, transform.position - new Vector3(0.2f, 0, 0), transform.rotation);

        tmpProjectile1.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
        tmpProjectile2.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
        tmpProjectile3.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
        tmpProjectile4.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
    }
}
