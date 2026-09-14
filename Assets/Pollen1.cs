using UnityEngine;

public class Pollen1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObserver.instance.AddPollen();

            Destroy(gameObject);
        }
    }
}
