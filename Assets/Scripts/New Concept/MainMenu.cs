using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayMap(int map)
    {
        SceneManager.LoadScene($"Map{map}");
    }
}