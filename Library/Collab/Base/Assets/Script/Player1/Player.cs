using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public int paperboardCount;
	private Rigidbody2D rigidBody;
	private Vector2 moveVelocity;
	private GameObject paperBoard;


    [SerializeField, Tooltip("How much hunger gained per second."), Range(0f, 100f)] float hungerRatePercentage;
    [SerializeField, Tooltip("How much hunger lost when eating."), Range(0f, 100f)] float hungerLossPerFood;

    [SerializeField] Slider foodSlider;

    bool canMove = true;
    bool throwingRock = false;
    AnimatorControllerParameter anim;

    public int spriteDirection = 1;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<AnimatorControllerParameter>();

        // Gets reference to food slider
        Slider[] sliders = FindObjectsOfType<Slider>();
        foreach (Slider slider in sliders)
        {
            if (slider.gameObject.CompareTag("Food"))
            {
                foodSlider = slider;
                break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire"))
        {
            ThrowRock();
        }

		Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		moveVelocity = moveInput.normalized * speed;

        if (speed > 0f && Mathf.Sign(moveInput.x * spriteDirection) < 0)
        {
            spriteDirection *= -1;
            FlipSprite();
        }

        Hunger();
	}

	void FixedUpdate(){
        if (!canMove) return;
		rigidBody.MovePosition(rigidBody.position + moveVelocity * Time.fixedDeltaTime);
	}

    public void ConsumeFood()
    {
        foodSlider.value += (hungerLossPerFood / 100);
    }

    void Hunger()
    {
        foodSlider.value -= (hungerRatePercentage/100) * Time.deltaTime;
    }

	public void GetPaperboard(){
		paperboardCount += 1;
	}
		
    void FlipSprite()
    {
        transform.GetChild(0).Rotate(new Vector3(0f, 180f, 0f));
    }

    void ThrowRock()
    {
        canMove = false;
        throwingRock = true;
    }

}
