using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    // VARIABLE DE MOVIMIENTO:
    // └    Esta variable la utilizarás para ajustar la fuerza
    //      del movimiento físico.
    
    public float fuerzaLineal = 150,
                 fuerzaGiro = 30;
    
    // VARIABLES DE LA CLASE INPUT:
    // └    LAS VARIABLES "horizontal" y "vertical" TIENES que
    //      utilizarlas para el valor float que
    //      devuelve la clase INPUT con las teclas W, A, S, D,
    //      o las flechas del cursor.
    private float horizontal,
                  vertical;
    
    // VARIABLES EMPLEADAS PARA LA ANIMACIÓN:
    // └    No tienes que hacer nada.
    //      Variable booleana configurada para ser "true" cuando hay movimiento
    //      y "false" cuando no hay movimiento.
    public bool isMoving;
    public Animator anim;
    // MÉTODO EMPLEADO PARA LA ANIMACIÓN:
    // └    No tienes que hacer nada.
    //      Hace que la variable booleana IsMoving sea "true" si hay movimiento
    //      y "false" cuando no hay movimiento.
    private Rigidbody rb;
    //creamos una variable privada para almacenar el rigidbody
    private void Animating()
    {
        if (vertical != 0)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
    }
    private void Update()
    {
        Animating();
    }
    void Start()
    {
        //Aqui almacenamos el rigidbody del personaje en una variable al iniciar el juego
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //con estas dos variables tipo float, registramos la entrada del teclado 
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //Despues añadiendolo los metodos addforce y torque le damos el movimiento del personaje
        rb.AddForce(transform.forward * vertical * fuerzaLineal);
        rb.AddTorque(transform.up * horizontal * fuerzaGiro);
    }

}
