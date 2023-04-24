using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Image one, two;
    public Sprite oneSp, twoSp;
    public bool forward;
    public void PlayMap(int map)
    {
        SceneManager.LoadScene($"Map{map}");
    }
    void Update()
    {
        if (two.fillAmount == 1 || two.fillAmount == 0)
        {
            forward = !forward;
        }
        two.fillAmount += forward ? (Time.deltaTime / 60) : -(Time.deltaTime / 60);
    }
}