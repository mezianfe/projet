using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method called by the play button
    public void PlayGame()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Method called by the quit button
    public void QuitGame()
    {
        // Exit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
