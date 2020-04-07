using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public float speed = 1f;        // velocidade do pássaro é um float. usar o f depois do valor é para definir que é float mesmo, se n, podia interpretar como double ou decimal
    private Rigidbody2D rig;    // para o RigidBody2D do pássaro se usa a variável rig 
    
    public float RotateUpSpeed = 1, RotateDownSpeed = 1;

    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();   // pega o rigidbody2d do bird
    }

    FlappyYAxisTravelState flappyYAxisTravelState;

        enum FlappyYAxisTravelState
         {
             GoingUp, GoingDown
         }

        Vector3 birdRotation = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {     // se o botão esquerdo (0) for clicado
            rig.velocity = Vector2.up * speed;  // a classe velocity do rigidbody vai sofrer aumento na velocidade na direção do Vector2.up que é pra cima
        }

        
        if (GetComponent<Rigidbody2D>().velocity.y > 0) flappyYAxisTravelState = FlappyYAxisTravelState.GoingUp;
        else flappyYAxisTravelState = FlappyYAxisTravelState.GoingDown;

        float degreesToAdd = 0;

        switch (flappyYAxisTravelState)
        {
            case FlappyYAxisTravelState.GoingUp:
                degreesToAdd = 6 * RotateUpSpeed;
                break;
            case FlappyYAxisTravelState.GoingDown:
                degreesToAdd = -3 * RotateDownSpeed;
                break;
            default:
                break;
        }
        //solution with negative eulerAngles found here: http://answers.unity3d.com/questions/445191/negative-eular-angles.html

        //clamp the values so that -90<rotation<45 *always*
        birdRotation = new Vector3(0, 0, Mathf.Clamp(birdRotation.z + degreesToAdd, -90, 45));
        transform.eulerAngles = birdRotation;
    }

    void OnCollisionEnter2D(Collision2D colisor) {      // quando o passaralho bater em qualquer parada ele aciona isso
        gameover.SetActive(true);   // aquele gameobject gameover aparece
        Time.timeScale = 0;     // pausa o jogo pois a escala de tempo ta como 0, ou seja, o tempo n passa
    }
}
