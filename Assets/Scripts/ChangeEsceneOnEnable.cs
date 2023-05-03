using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeEsceneOnEnable : MonoBehaviour
{
    public string sceneName;

    private void OnEnable()
    {
        SceneManager.LoadScene(sceneName);
    }
}
