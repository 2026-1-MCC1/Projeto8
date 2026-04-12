using UnityEngine;
public class Life : MonoBehaviour
{
    private int currentLife;
    private int maxLife = 100;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currentLife = maxLife;

        /* if (currentLife > maxLife)
         {
             currentLife = maxLife;
         }
         if (currentLife < 0)
         {
             currentLife = 0;
            // Respawn();
         }*/

        healthBar.alterHealthBar(currentLife, maxLife);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentLife -= 10;
        healthBar.alterHealthBar(currentLife, maxLife);
    }
}
