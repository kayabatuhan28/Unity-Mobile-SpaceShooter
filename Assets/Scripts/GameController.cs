using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait, startSpawn,waweWait,score;

    [SerializeField]
    TextMeshProUGUI scoreTxt;

    [SerializeField]
    public float meteorSpeed;

    public bool gameover,dontgetin;

    [SerializeField]
    public GameObject GameOverTittle;

    [SerializeField]
    public string mainMenu;

    [SerializeField]
    GameObject enemyShip;

    public int phase;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(gameover == true && !dontgetin)
        {
            dontgetin = true;
            StartCoroutine(LoadMenu());
        }
    }

    private void Start()
    {
        phase = 0;
        score = 0;
        gameover = false;
        dontgetin = false;
        StartCoroutine(SpawnValues());
    }

    

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true) 
        {
            
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, +2.5f), 0, 10.6f);
                Quaternion spawnRotation = Quaternion.identity; // Rotation
                Instantiate(hazard, spawnPosition, spawnRotation);
                //Coroutine

                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waweWait);
            Increase();
            if(gameover == true)
            {
                break;
            }
        }

    }

    void Increase()
    {
        phase++;
        spawnCount++;
        meteorSpeed = meteorSpeed-0.25f;
        if(phase % 3 == 0)
        {
            Instantiate(enemyShip, new Vector3(0, 0, 7), transform.rotation);
        }
    }

    public void UpdateScoreTxt()
    {
        scoreTxt.text = score.ToString();
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(0.1f);
        GameController.instance.GameOverTittle.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(mainMenu);
    }

}
