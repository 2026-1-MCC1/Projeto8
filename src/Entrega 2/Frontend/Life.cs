using UnityEngine;
public class Life : MonoBehaviour
{
    private int currentLife;
    private int maxLife = 100;
    [SerializeField] private HealthBar healthBar;

    [SerializeField] private SpawnPointPlayer spawnPoint;

     //private Vector3 spawnPosition;

    void Start()
    {
        //spawnPosition = transform.position;
        //spawnPoint.SpawnPlayer(transform.position);
        spawnPoint = Object.FindAnyObjectByType<SpawnPointPlayer>();

        currentLife = maxLife;

         if (currentLife > maxLife)
         {
             currentLife = maxLife;
         }

        healthBar.alterHealthBar(currentLife, maxLife); // chamando o metodo para alterar na barra
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            TakeDamage();
        }
    }

    private void Respawn()
    {
        Debug.Log("faleci");

        if (spawnPoint != null)
        {
            spawnPoint.SpawnPlayer();
        }

        Destroy(gameObject);
    }

    private void TakeDamage()
    {
        currentLife -= 10;
        healthBar.alterHealthBar(currentLife, maxLife); // chamando o metodo para alterar na barra
        Debug.Log("Ai");

        if (currentLife <= 0)
        {
            currentLife = 0;
            Respawn();
        }
    }
}