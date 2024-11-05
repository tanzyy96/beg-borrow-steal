using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // LateUpdate is called after Update
    // FixedUpdate is called at a fixed interval
    // We use FixedUpdate to avoid the stuttering effect where the player bounces off walls because movement is applied before collision detection in Update()
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        AnimateMovement(direction);

        transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);


                // Flip sprite using transform.localScale
                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
