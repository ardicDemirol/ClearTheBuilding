using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelRestartParent;
    [SerializeField] private GameObject levelNextParent;

    private bool levelFinished = false;
    private Target playerHealth;
    
    private int sceneCount;
    private int sceneIndex;


    public bool GetLevelFinish
    {
        get
        {
            return levelFinished;
        }
    }

    void Start()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
    }

    void Update()
    {
        Check();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int sceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (nextSceneIndex <= sceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);

        }
        if (nextSceneIndex > sceneIndex)
        {
            SceneManager.LoadScene(0);
        }

    }

    public void Check()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;

        sceneIndex = SceneManager.sceneCountInBuildSettings - 1;


        if (enemyCount <= 0) 
        {
            if (sceneIndex == 1)
            {
                levelNextParent.gameObject.SetActive(true);
                //levelRestartParent.gameObject.SetActive(true);
            }
            if (sceneIndex == 2)
            {
                levelNextParent.gameObject.SetActive(true);
            }

        }
        if (playerHealth.GetHealth <= 0)
        {
            if (sceneIndex < sceneCount)
            {
                levelRestartParent.gameObject.SetActive(true);
            }

            //levelFinished = false;
        }
    }
}
