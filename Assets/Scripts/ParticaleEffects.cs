using UnityEngine;

public class ParticaleEffects : MonoBehaviour
{
    public GameObject explosion;
    public static ParticaleEffects i;

    void Awake()
    {
        i = this;
    }

}