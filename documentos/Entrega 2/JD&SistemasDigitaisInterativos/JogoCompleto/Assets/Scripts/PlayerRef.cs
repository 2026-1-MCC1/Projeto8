using UnityEngine;
public class PlayerRef : MonoBehaviour
{
    public static Life PlayerL;
    public static Transform Player;

    void Awake()
    {
        PlayerL = GetComponent<Life>();
        Player = transform;
    }
}