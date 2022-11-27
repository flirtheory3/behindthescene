using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	Rigidbody2D rigid;
	SpriteRenderer spriteRenderer;
	RaycastHit2D rayHit, JumpCheck;
	
	[SerializeField] PhysicsMaterial2D bounce;
	Animator anim;
	BoxCollider2D col2d;
	public float maxSpeed;
	public bool isJump;
	public float jumpPower = 0;
	float param = 1;


	void Awake () 
	{
		rigid = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		 var obj = FindObjectsOfType<PlayerMove>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	void Start() {
	 col2d = GetComponent<BoxCollider2D>();
	}
	void FixedUpdate() //지속적인 키업데이트
	{
		float h = Input.GetAxisRaw("Horizontal");
		
		// 좌우이동
		if (isJump == false && !Input.GetButton("Jump") && rigid.velocity.y >= 0)
		{
			rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
			if (h > 0)
			{
				spriteRenderer.flipX = false;
			}
			else if (h < 0)
			{
				spriteRenderer.flipX = true;
			}
		}

		// 좌우 maxSpeed조절
		if (rigid.velocity.x > maxSpeed && isJump == false)
			rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);

		else if (rigid.velocity.x < maxSpeed * (-1) && isJump == false)
			rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

		if(rigid.velocity.y < 0)
        {
			rayHit = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Platform"));
			JumpCheck = Physics2D.Raycast(rigid.position, Vector2.down, 2, LayerMask.GetMask("Platform"));
			isJump = true;
			if(rayHit.collider != null)
            {
				if (rayHit.distance < 1)
                {
					isJump = false;
					rigid.sharedMaterial = null;
					anim.SetBool("IsJump", false);
				}
            }
        }
		if (isJump == true)
			rigid.sharedMaterial = bounce;
		if(isJump == true){
			anim.SetBool("IsWalk",false);
			anim.SetBool("IsJump",true);
		}
		}

	void Update() //단발적인 키업데이트
    {
		
		float h = Input.GetAxisRaw("Horizontal");

		// 멈춤
		if (Input.GetButtonUp("Horizontal") && isJump == false)
			rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
		// 점프파워충전
		if (Input.GetButton("Jump") && isJump == false)
		{
			anim.SetBool("IsReadyJump", true);
			rigid.velocity = new Vector2(0, 0);
			if (jumpPower <= 10)
				jumpPower = jumpPower + 0.1f;
			if (param <= 2)
				param = param + 0.03f;
		}

		// 점프
		if (Input.GetButtonUp("Jump") && isJump == false){
			anim.SetBool("IsReadyJump", false);
			anim.SetBool("IsJump", true);
			if (h > 0)
            {
				spriteRenderer.flipX = false;
				rigid.AddForce(Vector2.up * param * jumpPower + Vector2.right * (3 - param) * jumpPower, ForceMode2D.Impulse);
			}
			else if(h < 0)
            {
				spriteRenderer.flipX = true;
				rigid.AddForce(Vector2.up * param * jumpPower + Vector2.left * (3 - param) * jumpPower, ForceMode2D.Impulse);
			}
			else if(h == 0)
            {
				rigid.AddForce(Vector2.up * jumpPower * param, ForceMode2D.Impulse);
            }	
			isJump = true;
			jumpPower = 0;
		}

		// 애니메이션
		if (Input.GetButtonUp("Horizontal") && isJump == false)
			anim.SetBool("IsWalk", false);
		if (Input.GetButton("Horizontal") && isJump == false)
        {
			if(Input.GetButton("Jump"))
				anim.SetBool("IsWalk", false);
			else
				anim.SetBool("IsWalk", true);
        }	
	}

}


