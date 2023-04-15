using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    public CheckPoint checkPoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();
        if (checkPoint != null)
        {
            this.checkPoint = checkPoint;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && checkPoint != null)
        {
            foreach (var buttonActivator in FindObjectsOfType<ButtonActivator>())
            {
                buttonActivator.transform.position = buttonActivator.originalPos;
            }
            checkPoint.Load();
        }
    }
}