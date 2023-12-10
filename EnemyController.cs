using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Collider2D[] collider2D;
    [SerializeField] private Animator[] animators;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image enemyImage;
    [SerializeField] private Text enemyHPText;
    [SerializeField] private Health[] enemyHP;
    private int colliderIndex;
    private string enemyName;
    public string EnemyName => enemyName;
    private bool onTrigger;
    public bool OnTrigger => onTrigger;

    private void Awake()
    {
        onTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < collider2D.Length; i++)
        {
            if (collider2D[i] != null && collider2D[i].gameObject != null && collision.gameObject != null)
            {
                if (collider2D[i].gameObject.name == collision.gameObject.name)
                {
                    enemyName = enemies[i].name;
                    colliderIndex = i;
                    onTrigger = true;
                    enemyImage.gameObject.SetActive(true);
                    enemyImage.sprite = sprites[colliderIndex];
                    break;
                }
            }
        }
    }

    private void Update()
    {
        if (enemies.Length > colliderIndex && enemies[colliderIndex] != null)
        {
            enemyHPText.text = enemyHP[colliderIndex].CurrentHealth.ToString();
            if (!spriteRenderers[colliderIndex].flipX)
            {
                if (OnTrigger && transform.position.x < enemies[colliderIndex].transform.position.x)
                {
                    enemies[colliderIndex].transform.position = new Vector2(enemies[colliderIndex].transform.position.x - 0.001f, enemies[colliderIndex].transform.position.y);
                    animators[colliderIndex].SetTrigger("Walk");
                }
            }
            else if (spriteRenderers[colliderIndex].flipX)
            {
                if (OnTrigger && transform.position.x > enemies[colliderIndex].transform.position.x)
                {
                    enemies[colliderIndex].transform.position = new Vector2(enemies[colliderIndex].transform.position.x + 0.001f, enemies[colliderIndex].transform.position.y);
                    animators[colliderIndex].SetTrigger("Walk");
                }
            }
        }
        else
        {
            enemyImage.gameObject.SetActive(false);
        }
    }
}