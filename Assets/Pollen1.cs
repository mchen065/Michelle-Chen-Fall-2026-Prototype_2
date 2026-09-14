using UnityEngine;

public class Pollen1 : MonoBehaviour
{
    public PollenSpawner spawner;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObserver.instance.AddPollen();
            gameObject.SetActive(false);
            spawner.Nextpollen();

        }
    }
}
