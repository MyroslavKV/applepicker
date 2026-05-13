using UnityEngine;


public class CharAnimation : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Animator animator;

    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 10f;

    [SerializeField] Rigidbody rb;

    Vector3 movementVector;
    void Update()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        float verticalInputValue = Input.GetAxis("Vertical");

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        movementVector = camForward * verticalInputValue + camRight * horizontalInputValue;

        if (movementVector.magnitude > 1f)
            movementVector.Normalize();

        // Animation state
        if (movementVector != Vector3.zero)
            animator.SetInteger("state", 1);
        else
            animator.SetInteger("state", 0);
    }

    void FixedUpdate()
    {
        MoveCharacter();
        TurnCharacter();
    }

    void MoveCharacter()
    {
        Vector3 movementAmount = movementVector * speed;

        rb.MovePosition(rb.position + movementAmount);
    }

    void TurnCharacter()
    {
        if (movementVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementVector);
            Quaternion rotation = Quaternion.Lerp(
                rb.rotation,
                toRotation,
                rotationSpeed * Time.deltaTime
            );

            rb.MoveRotation(rotation);
        }
    }
}
