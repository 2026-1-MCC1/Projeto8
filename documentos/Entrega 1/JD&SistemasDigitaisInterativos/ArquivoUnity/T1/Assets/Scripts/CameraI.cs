using UnityEngine;

public class CameraI : MonoBehaviour
{
    public float velocidade = 5.0f;
    public float sensibilidadeMouse = 2.0f;
    public Transform cameraTransform; // Certifique-se de que a câmera está arrastada aqui no Inspector

    private float rotacaoX = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Verificacao de erro amigavel
        if (cameraTransform == null)
        {
            Debug.Log("Ei! Você esqueceu de arrastar a Câmera para o campo Camera Transform no script!");
        }
    }

    void Update()
    {
        // 1. ROTACAO HORIZONTAL (Gira o cilindro todo)
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        transform.Rotate(Vector3.up * mouseX);

        // 2. ROTACAO VERTICAL (Gira apenas a camera)
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);
        Debug.Log("Rotação Atual: " + rotacaoX);

        if (cameraTransform != null)
        {
            // Usando localEulerAngles para garantir a sobreposicao de valores
            cameraTransform.localEulerAngles = new Vector3(rotacaoX, 0, 0);
        }

        // 3. MOVIMENTACAO (Rente ao chao)
        float moverFrente = Input.GetAxis("Vertical");
        float moverLado = Input.GetAxis("Horizontal");

        Vector3 direcao = transform.forward * moverFrente + transform.right * moverLado;
        direcao.y = 0; // Trava o movimento no plano horizontal

        if (direcao.magnitude > 0.1f)
        {
            transform.Translate(direcao.normalized * velocidade * Time.deltaTime, Space.World);
        }
    }
}
