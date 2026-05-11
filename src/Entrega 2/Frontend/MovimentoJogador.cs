using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    public float velocidade = 4f;
    public float velocidadeCorrida = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(x, 0, z);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(movimento * velocidadeCorrida * Time.deltaTime);
        }
        else
        {
            transform.Translate(movimento * velocidade * Time.deltaTime);
        }
    }
}