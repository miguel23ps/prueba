using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    //variables float para el movimiento y el retardo de empezar
    public float frecuenciaMovimiento = 1.0f;
    public float tiempoRetardo = 5.0f;
    public float velocidad = 2.0f;
    //variable transform que almacena el transform del cubo
    private Transform miTransform = null;
    public Coroutine movimientoCoroutine;
    //almacena la variable game object del personaje que controlamos
    public GameObject girlGO;
    public bool moverDerecha = true;
    public bool moverIzquierda = false;
    public bool movimiento = true;

    private void Start()
    {
        movimientoCoroutine = StartCoroutine(Movimiento(tiempoRetardo, frecuenciaMovimiento));
        miTransform = GetComponent<Transform>();
    }
    //creamos un metodo IEnumerator para el movimiento del cubo
    IEnumerator Movimiento(float retardo, float frecuencia)
    {
        // Se espera el tiempo de retraso indicado antes de comenzar el movimiento
        yield return new WaitForSeconds(retardo);
        while (true)
        {
            // Movimiento del cubo hacia la derecha
            if (moverDerecha == true)
            {
                while (miTransform.position.x <= 5)
                {
                    // Movemos el objeto hacia la derecha
                    miTransform.position += Vector3.right * Time.deltaTime * velocidad;
                    yield return null;
                }
                moverDerecha = false;
                moverIzquierda = true;
            }
            yield return new WaitForSeconds(frecuencia);
            // Movimiento del cubo hacia la izquierda
            if (moverIzquierda == true)
            {
                while (miTransform.position.x >= -5)
                {
                    // Movemos el objeto hacia la izquierda
                    miTransform.position += Vector3.left * Time.deltaTime * velocidad;
                    yield return null;
                }
                moverDerecha = true;
                moverIzquierda = false;
            }
            yield return new WaitForSeconds(frecuencia);
        }
    }
    //creamos un metodo collision enter para detectar cuando un objeto entra en contacto con el
    void OnCollisionEnter(Collision coll)
    {
        //con este if cuando un objeto haya entrado en contacto con su collider, si tiene el tag de player, detiene la coroutine de movimiento
        if (coll.gameObject.tag == "Player")
        {
            StopCoroutine(movimientoCoroutine);
        }
    }
}
