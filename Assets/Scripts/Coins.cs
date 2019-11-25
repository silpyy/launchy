using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private AudioSource aSource;

    private TextMeshProUGUI score;

    // Start is called before the first frame update
    private void Start()
    {
        aSource = transform.parent.GetComponent<AudioSource>();
        score = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        aSource.Play();
        GameController.gC.IncreaseScore();
        score.text = GameController.gC.GetScore().ToString();
        gameObject.SetActive(false);
    }
}