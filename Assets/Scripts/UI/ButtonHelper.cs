using UnityEngine;

public class ButtonHelper : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        LevelLoader.Instance.LoadScene(sceneIndex);
    }
}
