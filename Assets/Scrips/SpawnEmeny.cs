using UnityEngine;

public class SpawnEmeny : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] goldCoints;
    private float timer;
    private float timer2;
    private float timerController;
    private float timerController2;
    private float pozishenSpavn;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timerController)
        {
            pozishenSpavn = 0f;
            Spawn(timer, timerController,pozishenSpavn, enemy);
            timer = 0;
            timerController = Random.Range(0.5f, 3);

        }
        timer2 += Time.deltaTime;
        if (timer2 >= timerController2)
        {
            pozishenSpavn = Random.Range(-3, 0);
            Spawn(timer2, timerController2, pozishenSpavn, goldCoints);
            timer2 = 0;
            timerController2 = Random.Range(1f, 4f);
        }
    }
    private void Spawn(float time, float timerControl, float poz, GameObject[] objSpawn)
        {
            Instantiate(objSpawn[Random.Range(0, objSpawn.Length)], new Vector3(30, poz, 0), Quaternion.identity);
        }
}
