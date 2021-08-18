using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LógicaPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator lebron;
    public float x, y;


    public Rigidbody rb;
    public float fuerzaSalto = 8.0f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        puedoSaltar = false; 
        lebron = GetComponent<Animator>();
    }


    void FixedUpdate()
    {

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
    }
    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        lebron.SetFloat("VelX", x);
        lebron.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lebron.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            lebron.SetBool("tocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        lebron.SetBool("tocoSuelo", false);
        lebron.SetBool("salte", false);
    }
}
 