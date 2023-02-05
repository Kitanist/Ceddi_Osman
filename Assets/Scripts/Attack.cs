using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange = 1f;
    public int attackDamage = 10;
    public GameObject Bullet;
    public bool canBullet, a = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("SA");
            if (a)
            {
                Player.Instance.playerAnimator.SetBool("osmannormal", true);
                a = false;
            }
            else
            {
                Player.Instance.playerAnimator.SetBool("ýþýn", true);
                a = true;
            }
            
            AttackEnemy(attackRange,attackDamage);
            if (canBullet)
            {
                DashAttack(attackRange * 10, attackDamage * 2, 5);
            }
        }
    }

    void DashAttack(float attackRange,int attackDamage,float knockBack)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);
        Instantiate(Bullet);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-knockBack, 0);
    }
    void AttackEnemy(float attackRange,int attackDamage)
    {
        Debug.Log("AS");
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
}
