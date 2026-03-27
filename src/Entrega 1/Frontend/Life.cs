using UnityEngine;
public class Life : MonoBehaviour
{
    [SerializeField] private int currentLife;
    [SerializeField] private int maxLife = 100;
    [SerializeField] private int minLife = 0;

    private Vector3 spawnPosition;

    [SerializeField] private HealthBar healthBar;

    #region Declaração de valores da vida e posição do player
    void Start()
    {
        currentLife = maxLife;
        spawnPosition = transform.position;

        // Seção Vida

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
        if (currentLife <= minLife)
        {
            Respawn();
        }

        healthBar.alterHealthBar(currentLife, maxLife);
    }

    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        currentLife -= 10;

        healthBar.alterHealthBar(currentLife, maxLife);
    }

    

    #region Respawn do Player
    private void Respawn()
    {
        Destroy(gameObject);
        transform.position = spawnPosition;
        currentLife = maxLife;
    }

    #endregion
}
