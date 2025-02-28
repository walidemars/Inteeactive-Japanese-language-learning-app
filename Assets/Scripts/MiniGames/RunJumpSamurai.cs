using System.Collections;
using UnityEngine;

public class RunJumpSamurai : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Game());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Game()
    {
        yield return new WaitForSeconds(5);
        LevelsManager.Instance.NextGame();
    }
}
