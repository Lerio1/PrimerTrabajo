using UnityEngine;

public class MoverLeñador : MonoBehaviour
{
    [SerializeField] private float distanciaAvance = 10f;
    



    public void MoverLenador()
    {
        // Mueve el icono del leñador hacia la derecha una distancia específica
        transform.Translate(Vector2.right * distanciaAvance);
        //Debug.Log("Funciona");
    }
}
