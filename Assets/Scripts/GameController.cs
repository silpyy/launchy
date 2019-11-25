using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gC;

    public List<Transform> charactersList;

    public Transform characters;

    private int characterCount = 1;

    private int score = 0;
    public bool done = false;

    private void Awake()
    {
        gC = this;
        characters = GameObject.Find("Characters").transform;
        foreach (Transform child in characters)
        {
            charactersList.Add(child);
            child.gameObject.SetActive(false);
        }
        charactersList[0].gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (done && characterCount < charactersList.Count)
        {
            charactersList[characterCount].gameObject.SetActive(true);
            characterCount++;
            done = false;
        }
    }

    public void IncreaseScore()
    {
        score += 1;
    }

    public int GetScore()
    {
        return score;
    }
}