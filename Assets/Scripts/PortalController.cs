using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    Transform destination;

    [SerializeField]
    float speed = 3.0F;

    Rigidbody2D _playerRb;

    private void Start()
    {
        _playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Vector2.Distance(player.position, transform.position) > 0.3F)
            {
                StartCoroutine(Teleport());
            }
        }
    }

    IEnumerator Teleport()
    {
        _playerRb.simulated = false;
        StartCoroutine(MoveTo());
        yield return new WaitForSeconds(0.5F);

        player.position = destination.position;
        yield return new WaitForSeconds(0.5F);
        _playerRb.simulated = true;
    }

    IEnumerator MoveTo()
    {
        float timer = 0.0F;
        while (timer < 0.5F)
        {
            player.position = Vector2.MoveTowards(player.position, transform.position, speed * Time.deltaTime);//Calcula la distancia y tiempo entre 2 puntos
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }
}
