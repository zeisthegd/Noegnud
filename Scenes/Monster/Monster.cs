using Godot;
using System;

public class Monster : KinematicBody2D
{
	//Các trạng thái khác nhau của Monster
	enum MonsterState
	{
		IDLE,
		WANDER,
		CHASE
	}

	protected Sprite sprite;
	protected AnimationPlayer animationPlayer;
	

	Vector2 velocity = new Vector2();//Tốc độ của Monster
	Vector2 knockBack = new Vector2();//Khi bị tấn công Monster sẽ di chuyển bằng vector Knockback


	protected MonsterStats stats;//Các thông số của Monster
	protected PlayerDetectionZone playerDetectionZone;//Khu vực mà Monster có thể nhìn thấy Player
	protected Hurtbox hurtBox;

	const int MAX_SPEED = 50;//Tốc độ di chuyển tối đa của Monster 
	const int FRICTION = 80;

	MonsterState currentState = MonsterState.IDLE;//Khởi đầu MonsterState là tuần tra
	
	public override void _Ready()
	{
		sprite = (Sprite)GetNode("Sprite");
		playerDetectionZone = (PlayerDetectionZone)GetNode("PlayerDetectionZone");
		stats = (MonsterStats)GetNode("MonsterStats");
		hurtBox = (Hurtbox)GetNode("Hurtbox");
		animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
	}

	public override void _Process(float delta)
	{
		base._Process(delta);
		DampingKnockBack();
		AutoPilot();
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);

		if(knockBack == Vector2.Zero)//Khi không bị tấn công
			velocity = MoveAndSlide(velocity);
	}

	//StateMachine mini
	private void AutoPilot()
	{
		//Kiểm tra state hiện tại
		switch(currentState)
		{
			case MonsterState.IDLE:
				StayIdle();
				break;

			case MonsterState.CHASE:
				ChasePlayer();
				break;

			case MonsterState.WANDER:
				GoWandering();
				break;

			default:
				
				break;
		}
		FlipSprite();
		
	}

	protected virtual void StayIdle()
	{
		//MoveToward là hàm làm thay đổi giá trị của một vector cho tới khi nó bằng một vector khác, theo một giá trị cho trước
		//Ở đây velocity sẽ đi dần về phía Vector2.Zero (0,0) với giá trị thay đổi theo thời gian là FRICTION * delta(1/60);
		velocity = velocity.MoveToward(Vector2.Zero, FRICTION * GetPhysicsProcessDeltaTime());
		SeekPlayer();
	}
	protected virtual void GoWandering()
	{
		//TODO
	}
	protected virtual void ChasePlayer()
	{
		//
		Player player = playerDetectionZone.Player;
		if (player != null)
		{
			var direction = (player.GlobalPosition - this.GlobalPosition).Normalized();
			velocity = velocity.MoveToward(direction * MAX_SPEED, MAX_SPEED * 2 * GetPhysicsProcessDeltaTime());
		}
		else
			currentState = MonsterState.IDLE;
	}

	private void SeekPlayer()
	{
		//Nếu playerDetectionZone có Player thì chuyển sang truy đuổi
		if (playerDetectionZone.SpottedPlayer())
		{
			currentState = MonsterState.CHASE;
		}
	}

	//Nếu có area khác chạm vào area Hurtbox
	public void _on_Hurtbox_area_entered(Area2D area)
	{
		TakeDamageFromPlayerSword(area);	
		knockBack = (this.GlobalPosition - area.GlobalPosition).Normalized() * MAX_SPEED;//knockback = đẩy lùi
	}

	private void TakeDamageFromPlayerSword(Area2D area)
	{
		//Nếu
		if (area is Hitbox swordArea)
		{
			stats.CurrentHealth -= swordArea.Damage;
			if(stats.CurrentHealth > 0)
				hurtBox.CreateHitEffect();
		}	
	}

	//Nếu đang di chuyển về bên trái
	//Lật sprite
	private void FlipSprite()
	{
		sprite.FlipH = velocity.x < 0;
	}

	//Giảm dần knockback về 0
	private void DampingKnockBack()
	{
		knockBack = knockBack.MoveToward(Vector2.Zero, FRICTION * GetPhysicsProcessDeltaTime());
		knockBack = MoveAndSlide(knockBack);
	}

	
	//Khi nhận được tín hiệu hết máu từ PlayerStats
	//Tạo một DeathEffect
	//Biến mất
	private void _on_MonsterStats_OutOfHealth()
	{
		CombatEffect.CreateDeathEffect(this);
		QueueFree();
	}

	
}
