using UnityEngine;

public class SpawnPointPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    void Awake()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject NewPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        NewPlayer.tag = "Player";
    }
}