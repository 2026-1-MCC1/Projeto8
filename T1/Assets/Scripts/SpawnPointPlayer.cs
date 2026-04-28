using UnityEngine;

public class SpawnPointPlayer : MonoBehaviour
{
    public GameObject playerPrefab;
    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}