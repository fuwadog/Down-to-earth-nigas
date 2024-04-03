using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyComponents))
        {
            enemyComponents.TakeDamage(1);
            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        Destroy(this.gameObject,3);
    }

}
