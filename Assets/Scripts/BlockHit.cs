using UnityEngine;
 
public class BlockHit : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }
 
        ContactPoint2D contact = collision.GetContact(0);
        if (contact.normal.y > 0.5f)
        {
            animator.SetTrigger("Hit");
        }
    }
}