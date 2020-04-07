using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpipes : MonoBehaviour
{
    public GameObject pipe;
    public float height;
    public float maxtime = 1f;      // vai fazer os canos spawnarem a cada 1 segundo

    private float timer = 0f;       // usar o f depois do valor é para definir que é float mesmo, se n, podia interpretar como double ou decimal

    // Start is called before the first frame update
    void Start()
    {
        GameObject newpipe = Instantiate(pipe);     // cria cópias do gameobject pipe
        newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);     // as posições desse novo objeto newpipe (transform.position) vai ser a posição inicial do primeiro conjunto de pipes (transform.position daquele gameobject pipes lá da unity) mais uma variação no eixo y entre mais height ou menos height (Random.Range sorteia um valor entre +height e - height), sendo que nada muda no eixo x e z
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > maxtime) {       // se o timer for maior que o tempo máximo definido, outro cano vai spawnar
            GameObject newpipe = Instantiate(pipe);     // cria cópias do gameobject pipe
            newpipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);     // as posições desse novo objeto newpipe (transform.position) vai ser a posição inicial do primeiro conjunto de pipes (transform.position daquele gameobject pipes lá da unity) mais uma variação no eixo y entre mais height ou menos height (Random.Range sorteia um valor entre +height e - height), sendo que nada muda no eixo x e z
            Destroy(newpipe, 20f);      // depois de 20 segundos o cano é destruido pra n sobrecarregar o jogo
            timer = 0;  // reiniciar o timer
        }

        timer += Time.deltaTime;    // função que calcula o tempo que passou, então a cada novo loading o timer vai sendo atualizado em tempo real
    }
}
