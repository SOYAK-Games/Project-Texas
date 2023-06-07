using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ChangeScene();
        }
    }
    
    private void ChangeScene()
    {
        SceneManager.LoadScene("Scene1");
    }
}
