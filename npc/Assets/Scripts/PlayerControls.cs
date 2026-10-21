using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.RenderGraphModule;
using static UnityEngine.Rendering.DebugUI;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int health;
    private bool invul;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.x * speed * Time.deltaTime, 0f, 0f);
    }

    public void Walk(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>();

        if (direction == new Vector2(1, 0))
        {
            spriteRenderer.flipX = true;
        }
        else if (direction == new Vector2(-1, 0))
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Shoot()
    {

    }
    public void Jump()
    {

    }

    public void Damage()
    {
        if (!invul)
        {
            health -= 1;
            invul = true;
            StartCoroutine(InvulFrames());
        }
    }

    private IEnumerator InvulFrames()
    {
        for (int i = 0; i < 6; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invul = false;
    }
}
