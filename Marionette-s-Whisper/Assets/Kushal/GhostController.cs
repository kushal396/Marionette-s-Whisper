using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float damagePerSecond = 20f;
    public float healPerSecond = 10f;
    public float detectionRadius = 5f;

    private HealthController playerHealthController;

    private void Start()
    {
        playerHealthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Player"));

        if (colliders.Length > 0)
        {
            float damage = damagePerSecond * Time.deltaTime;
            playerHealthController.TakeDamage(damage);
        }
        else
        {
            float heal = healPerSecond * Time.deltaTime;
            playerHealthController.Heal(heal);
        }
    }
}
