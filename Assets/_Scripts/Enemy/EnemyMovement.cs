using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private float speed;
    [SerializeField] private float timeToMove;
    [SerializeField] private float distance;
    

    private float interval;
    private bool isMoving;
    void Start()
    {
        interval = timeToMove;
    }
    private void OnEnable()
    {
        isMoving = false;
        timeToMove = interval;
    }


    void Update()
    {
        if (timeToMove <= 0 && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveToPlayer());
            timeToMove = interval;
        }

        timeToMove -= Time.deltaTime;
    }
    IEnumerator MoveToPlayer()
    {

        Vector3 startPosition = transform.position;
        Vector3 target = startPosition + new Vector3(0, 0, -distance);
        float time = 0;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, target, speedCurve.Evaluate(time));
            time += Time.deltaTime * speed;
            yield return null;
        }
        timeToMove = interval;
        isMoving = false;

    }

}
