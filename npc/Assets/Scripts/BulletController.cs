using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("CU");

            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerControls>().Damage();
            }

            Destroy(gameObject);
        }
    }
}
