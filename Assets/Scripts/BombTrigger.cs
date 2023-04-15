using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var bomb = other.GetComponent<Bomb>();
        if (bomb != null)
        {
            bomb.active = false;
            Instantiate(ParticaleEffects.i.explosion, bomb.transform.position, Quaternion.identity);
            bomb.gameObject.SetActive(false);
        }
    }
}