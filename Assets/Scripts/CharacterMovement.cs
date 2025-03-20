using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using TMPro;

public class CharacterMovement : MonoBehaviour
{

    public TextMeshProUGUI displayScore;
    private int score = 0;
    public CharacterInputs characterInputs;
    public GameManagerScript gameManagerScript;
    [SerializeField] Animator characterAnimator;
    //[SerializeField] private float movespeed = 5;
    //[SerializeField] private float jumpPower = 5;
    [SerializeField] private CharacterSO characterSO;
    [SerializeField] private Rigidbody2D characterRigidbody;
    [SerializeField] SpriteRenderer characterSpriteRenderer;
    private Vector2 moveDirection;
    int jumpCounter = 0;
    private bool isGrounding = false;

    // if level up is implemented
    //private  CharacterData characterData;
    private void Start()
    {
        //characterData = new CharacterData(characterSO);
    }

    private void Awake()
    {
        characterInputs = new CharacterInputs();
        displayScore.text = $"Strawberries: {score}";
    }
    private void OnEnable()
    {
        characterInputs.Character.Movement.Enable();

        /* enable the input of jumping
         * performed = button was pressed
         * cancelled = button was released*/
        characterInputs.Character.Jump.performed += OnJump;
        characterInputs.Character.Jump.Enable();
    }
    private void OnDisable()
    {
        characterInputs.Character.Movement.Disable();
        characterInputs.Character.Jump.performed -= OnJump;
        characterInputs.Character.Jump.Disable();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        AnimatorHandle();
        moveDirection = characterInputs.Character.Movement.ReadValue<Vector2>();

        characterRigidbody.velocity = new Vector2(moveDirection.x * characterSO.CharacterMoveSpeed, characterRigidbody.velocity.y);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounding || jumpCounter < 2)
        {
            isGrounding = false;
            characterRigidbody.velocity = new Vector2(characterRigidbody.velocity.x, characterSO.CharacterJumpPower);
            jumpCounter++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check character is interact with ground or not
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounding = true;
            jumpCounter = 0;
        }
    }
    private void AnimatorHandle()
    {
        //SetFloat("Parameter name", 
        characterAnimator.SetFloat("moveX", Mathf.Abs(characterRigidbody.velocity.x));
        characterAnimator.SetFloat("moveY", characterRigidbody.velocity.y);
        if (characterRigidbody.velocity.x > 0.01)
        {
            characterSpriteRenderer.flipX = false;
        }
        else if (characterRigidbody.velocity.x < -0.01)
        {
            characterSpriteRenderer.flipX = true;
        }
        //if (jumpCounter >= 1 && jumpCounter < 3)
        //    characterAnimator.SetBool("doubleSpace", doubleSpacePressed);
        characterAnimator.SetInteger("jumpCount", jumpCounter);
    }
    public int Addition()
    {
        score++;
        DisplayScore();
        return score;
    }
    private void DisplayScore()
    {
        displayScore.text = $"Strawberries: {score}";
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectibles"))
        {
            Addition();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy hit");
            characterAnimator.SetBool("Hit", true);
            PlayAnimationKillPlayer();
        }
    }
    private IEnumerator PlayAnimationKillPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        gameManagerScript.gameOver();

    }
}
