using UnityEngine;
 
public class BlockHit : MonoBehaviour
{
    // Pour le cours, limiter le nombre d'interactions possible avec le bloc
    // Et quand c'est atteint, changer l'opacité du sprite (voir ligne 15)
    private SpriteRenderer sr;
    private Animator animator;
 
    [SerializeField]
    private int maxHits = 2;
 
    private int currentHits = 0;

    [SerializeField]
    private GameObject itemPrefab;
 
    void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
 
        
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
 
        ContactPoint2D contact = collision.GetContact(0);
 
        if (contact.normal.y > 0.5f && currentHits < maxHits)
        {
            currentHits = currentHits + 1;
            animator.SetTrigger("Hit");

            if(itemPrefab != null)
            {
                GameObject item = Instantiate(itemPrefab, 
                transform.position + Vector3.up, 
                Quaternion.identity);
            }
 
            if (currentHits == maxHits)
            {
                sr.color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
    }
}