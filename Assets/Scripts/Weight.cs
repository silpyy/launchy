using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField] private ParticleSystem cloudFx;

    private Rigidbody2D rb;

    private GameObject activeCharacter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        foreach (Transform child in GameController.gC.characters)
        {
            if (child.gameObject.activeSelf)
                activeCharacter = child.gameObject;
        }

        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;

        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        CloudFX();

        activeCharacter.SetActive(false);
        GameController.gC.done = true;
        gameObject.SetActive(false);
    }

    private void CloudFX()
    {
        Instantiate(cloudFx, transform.position, Quaternion.identity);
        Instantiate(cloudFx, activeCharacter.transform.position, Quaternion.identity);
    }
}