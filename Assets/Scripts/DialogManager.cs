using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    public static DialogManager i;
    public TextMeshProUGUI dialogText;
    void Start()
    {
        Close();
        i = this;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void ShowDialog(string text)
    {
        Show();
        StartCoroutine(TypeDialog(text));
    }
    public IEnumerator TypeDialog(string line)
    {
        Show();
        yield return new WaitForEndOfFrame();
        dialogText.text = " ";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / 30f);
        }
        yield return new WaitForSeconds(1.5f);
        Close();

    }
}
