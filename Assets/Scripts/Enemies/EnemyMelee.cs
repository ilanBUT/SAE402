using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [Header("Paramètres d'attaque")]
    public Transform attackPoint; // L'endroit où la langue frappe
    public float attackRange = 0.5f; // La portée du coup de langue
    public LayerMask playerLayer; // Pour être sûr de ne taper que le joueur
    public int damage = 1; // Les dégâts infligés
    public float attackCooldown = 2f; // Le temps d'attente entre deux coups de langue

    private float nextAttackTime = 0f;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Crée un cercle invisible au niveau du attackPoint pour chercher le joueur
        Collider2D playerCollider = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        // Si le joueur est trouvé dans le cercle ET que le temps de recharge est écoulé
        if (playerCollider != null && Time.time >= nextAttackTime)
        {
            Attack();
            // Réinitialise le temps d'attente
            nextAttackTime = Time.time + attackCooldown;
        }
    }

   void Attack()
    {
        // 1. Lance juste l'animation d'attaque
        if (anim != null)
        {
            anim.SetTrigger("Attack");
        }
    }

    // CETTE FONCTION SERA APPELÉE PAR L'ANIMATION ELLE-MÊME
    public void TriggerLanguageDamage()
    {
        // On vérifie SI le joueur est devant AU MOMENT où la langue sort
        Collider2D playerCollider = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if (playerCollider != null)
        {
            Debug.Log("BAM ! La langue touche le joueur !");
            
            // Met ton code de dégâts ici (pense à enlever les /* */ si tu l'as activé)
            /*
            PlayerHealth healthScript = playerCollider.GetComponent<PlayerHealth>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(damage);
            }
            */
        }
    }
    // Cette fonction sert juste à dessiner un cercle rouge dans Unity pour t'aider à régler la portée !
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}