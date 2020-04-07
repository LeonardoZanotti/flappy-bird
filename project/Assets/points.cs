using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    public gamecontroller controller;       // gamecontroller.cs sendo definido como controller

    void Start() {
        controller = FindObjectOfType<gamecontroller>();    // sempre que iniciar ele vai procurar o objeto que tem o script gamecontroller, pq do jeito que tá feito não dá pra referenciar manualmente lá na unity
    }

    void OnTriggerEnter2D(Collider2D colisor) {           // is Trigger permite que objetos passem por dentro de outros sem serem barrados, mas a colisão ainda é verificada
        controller.score++;     // score que tá definido no gamecontroller recebe +1 quando o pássaro passar pelo colisor
        controller.scoretext.text = controller.score.ToString();    // o texto que tá definido lá no gamecontroller recebe o score string
    }
}
