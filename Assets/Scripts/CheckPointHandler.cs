using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    public static CheckPointHandler i;
    public CheckPoint checkPoint;
    void Awake()
    {
        i = this;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();
        if (checkPoint != null)
        {
            // check if colliding with a checkpoint and if true set it the the current checkpoint
            if (this.checkPoint != null && this.checkPoint.index > checkPoint.index)
            {
                return;
            }
            this.checkPoint = checkPoint;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && checkPoint != null)
        {
            Restart();
        }
    }
    public void Restart()
    {
        // reset game to last checkpoint
        foreach (var buttonActivator in FindObjectsOfType<ButtonActivator>())
        {
            // get every button activator and reset its position
            buttonActivator.transform.position = buttonActivator.originalPos;
        }
        foreach (var bomb in FindObjectsOfType<Bomb>())
        {
            // get every bomb and reset its position
            bomb.transform.position = bomb.originalPos;
            bomb.active = bomb.initialState;
            bomb.time = bomb.originalTime;
            bomb.gameObject.SetActive(false);
        }
        foreach (var btn in FindObjectsOfType<pButton>())
        {
            //get every button and set it to its initial state
            btn.SetActive(btn.initialState);
        }
        foreach (var dialogTrigger in FindObjectsOfType<DialogTrigger>())
        {
            // reset state of each dialog trigger
            dialogTrigger.used = false;
        }
        foreach (var bombTrigger in FindObjectsOfType<BombTrigger>())
        {
            // reset state of each bomb trigger
            bombTrigger.gameObject.SetActive(true);
            bombTrigger.bc.enabled = true;
            bombTrigger.onNotTriggered?.Invoke();
        }
        checkPoint.Load(); // reset player pos
    }
}