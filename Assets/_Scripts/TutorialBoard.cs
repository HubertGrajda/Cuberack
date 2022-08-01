using UnityEngine;

public class TutorialBoard : MonoBehaviour
{
    [SerializeField] private GameObject board;

    private void Start()
    {
        
        if (!GameManager.Instance.tutorialSeen)
        {
            GameManager.Instance.tutorialSeen = true;
            Time.timeScale = 0f;
            board.SetActive(true);
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            board.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
