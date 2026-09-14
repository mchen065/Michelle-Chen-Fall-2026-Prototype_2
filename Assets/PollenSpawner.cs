using UnityEngine;

public class PollenSpawner : MonoBehaviour
{
    public GameObject[] pollenObjects;
    private int currenPollen = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Hide all pollens first
        for (int i = 0; i < pollenObjects.Length; i++)
        {
            pollenObjects[i].SetActive(false);
            //Show first pollen
            pollenObjects[0].SetActive(true);
        }
    }

    // Update is called once per frame

    public void Nextpollen()
    {
        currenPollen++;
        if (currenPollen >= pollenObjects.Length)
        {
            currenPollen = 0;
        }
        pollenObjects[currenPollen].SetActive(true);
    }
}
