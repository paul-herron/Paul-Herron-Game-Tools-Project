using UnityEngine;

public class Target : MonoBehaviour
{
    //VALUES
    public float health = 50f;
    public float carCount = 5;
    public AudioSource Explode;
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
        carCount -= 1;
        TallyText.tally -= 1;
        Debug.Log("SkyCar Down! " + carCount + " SkyCars remain!");

    }
}
