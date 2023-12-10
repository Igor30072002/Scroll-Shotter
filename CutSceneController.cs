using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneController : MonoBehaviour
{
    [SerializeField] private Transform hero;
    [SerializeField] private Transform followPoint;
    [SerializeField] private Transform finishPoint;
    [SerializeField] private GameObject heroGM;
    [SerializeField] private CinemachineVirtualCamera CM;
    [SerializeField] private GameObject[] blackStripes;
    [SerializeField] private Text countdownText;
    [SerializeField] private GameObject boom1;
    [SerializeField] private GameObject boom2;
    private float timer;
    private bool goTrigger;
    private bool inTrigger;

    private void Awake()
    {
        timer = 4;
        inTrigger = false;
        goTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            CM.Follow = followPoint;
            inTrigger = true;
        }
    }

    private void Update()
    {
        if (inTrigger && timer >= 1)
        {
            heroGM.SetActive(false);
            timer -= Time.deltaTime;
            countdownText.text = ((int)timer).ToString();
        }
        else if (timer > 0 && timer < 1)
        {
            timer -= Time.deltaTime;
            countdownText.text = "GO!";
            goTrigger = true;
        }
        else if (timer < 0 && goTrigger)
        {
            boom1.SetActive(true);
            countdownText.gameObject.SetActive(false);
            if (goTrigger && followPoint.position.y < finishPoint.position.y)
            {
                heroGM.SetActive(false);
                followPoint.position = new Vector2(followPoint.position.x, followPoint.position.y + 0.007f);
            }
            else if (goTrigger && followPoint.position.y >= finishPoint.position.y)
            {
                boom2.SetActive(true);
                hero.position = finishPoint.position;
                heroGM.SetActive(true);
                CM.Follow = hero;
                goTrigger = false;
            }
        }
    }
}
