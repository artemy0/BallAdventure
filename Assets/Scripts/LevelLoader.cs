using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance; //реализуесм singleto, что бы в дальнейшем использовать данный скрипт в любой сцене

    [SerializeField] private Animator _foregroundAnimator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 

            DontDestroyOnLoad(gameObject);
        }
        else if (Instance.gameObject != gameObject)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Player.GameOver += () => LoadScene(2);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadLevelCoroutine(sceneIndex));
    }

    //public void ReloadCurrentScene()
    //{
    //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    StartCoroutine(LoadLevelCoroutine(currentSceneIndex));
    //}

    private IEnumerator LoadLevelCoroutine(int sceneIndex)
    {
        _foregroundAnimator.gameObject.SetActive(true);
        _foregroundAnimator.SetTrigger("GoIn");
        yield return new WaitForSeconds(_foregroundAnimator.GetCurrentAnimatorClipInfo(0).Length);

        SceneManager.LoadScene(sceneIndex);
        while (!SceneManager.GetActiveScene().isLoaded)
            yield return null;

        _foregroundAnimator.SetTrigger("GoOut");
        yield return new WaitForSeconds(_foregroundAnimator.GetCurrentAnimatorClipInfo(0).Length);
        _foregroundAnimator.gameObject.SetActive(false);
    }
}
