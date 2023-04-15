using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
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
    public IEnumerator ShowDialog(string text, UnityEvent onFinish)
    {
        Show();
        yield return (TypeDialog(text));
        onFinish?.Invoke();
        Close();

    }
    public IEnumerator TypeDialog(string line)
    {
        yield return new WaitForEndOfFrame();
        dialogText.text = " ";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / 30f);
        }
        yield return new WaitForSeconds(1.5f);

    }
    // public IEnumerator TypeDialog(Dialog dialog)
    // {

    //     foreach (var line in dialog.lines)
    //     {
    //         yield return new WaitForEndOfFrame();
    //         dialogText.text = " ";
    //         foreach (var letter in line.ToCharArray())
    //         {
    //             dialogText.text += letter;
    //             yield return new WaitForSeconds(1f / 30f);
    //         }
    //         yield return new WaitForSeconds(1.5f);
    //     }

    // }
}
// public class Dialog
// {
//     public List<string> lines;
//     public Dialog(List<string> lines)
//     {
//         this.lines = lines;
//     }
// }
