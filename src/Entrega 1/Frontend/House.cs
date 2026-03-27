using UnityEngine;

public class House : MonoBehaviour
{
    public float vida = 100f;
    [HideInInspector] public int meuID;
    [HideInInspector] public HouseManager gerente;

    public void ReceberDano(float dano)
    {
        vida -= dano;
        Debug.Log("Casa " + meuID + " tomou dano! Vida: " + vida);

        if (vida <= 0)
        {
            vida = 100f;
            gerente.TeletransportarCasa(meuID);
        }
    }
}