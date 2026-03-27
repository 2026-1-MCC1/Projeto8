using UnityEngine;
public class Life : MonoBehaviour
{
    [SerializeField] private int currentLife;
    [SerializeField] private int maxLife;

    void Start()
    {
        currentLife = maxLife;

        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentLife -= 10;
    }
}
