using UnityEngine;
using UnityEngine.Events;
public class DialogTrigger : MonoBehaviour
{
    public string text;
    private SpriteRenderer sp;
    public bool used;
    public UnityEvent onTrigger, onFinish;
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !used)
        {
            onTrigger?.Invoke();
            DialogManager.i.gameObject.SetActive(true);
            StartCoroutine(DialogManager.i.ShowDialog(text, onFinish));
            used = true;
        }
    }
}
