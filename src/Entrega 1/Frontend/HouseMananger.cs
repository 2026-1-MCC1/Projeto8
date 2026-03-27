using UnityEngine;
using UnityEngine.InputSystem; 
public class HouseManager : MonoBehaviour
{
    public GameObject[] casas;
    public Transform[] pontosSpawn;

    void Start()
    {
        // Conecta as casas ao sistema
        for (int i = 0; i < casas.Length; i++)
        {
            House script = casas[i].GetComponent<House>();
            if (script != null)
            {
                script.meuID = i;
                script.gerente = this;
            }
        }
    }

    void Update()
    {
        // Verifica se o teclado existe e lê as teclas 1, 2 e 3
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.digit1Key.wasPressedThisFrame) AtacarCasa(0);
        if (keyboard.digit2Key.wasPressedThisFrame) AtacarCasa(1);
        if (keyboard.digit3Key.wasPressedThisFrame) AtacarCasa(2);
    }

    void AtacarCasa(int id)
    {
        if (id < casas.Length)
        {
            casas[id].GetComponent<House>().ReceberDano(50);
        }
    }

    public void TeletransportarCasa(int id)
    {
        int sorteio = Random.Range(0, pontosSpawn.Length);
        casas[id].transform.position = pontosSpawn[sorteio].position;
    }
}
