using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform bulletOrigin;

    private enum State
    {
        Shoot,
        Roll,
        Transition
    }

    private State currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StateChanger());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.Roll)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (currentState == State.Shoot)
        {

        }
    }

    private IEnumerator StateChanger()
    {
        currentState = State.Shoot;
        StartCoroutine(Shoot(3));
        yield return new WaitForSeconds(1.5f);

        currentState = State.Transition;
        yield return new WaitForSeconds(0.5f);

        currentState = State.Roll;
        yield return new WaitForSeconds(1f);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

        currentState = State.Transition;
        yield return new WaitForSeconds(0.5f);


        StartCoroutine(StateChanger());
    }

    private IEnumerator Shoot(int repetitions)
    {
        for (int i = 0; i < repetitions; i++)
        {
            Instantiate(bulletObject, bulletOrigin.transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControls>().Damage();
        }
    }
}
