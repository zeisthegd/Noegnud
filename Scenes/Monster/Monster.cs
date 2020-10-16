using Godot;
using System;

public class Monster : KinematicBody2D
{
	enum MonsterState
	{
		IDLE,
		WANDER,
		CHASE
	}

	Sprite sprite;

	

	PlayerDetectionZone playerDetectionZone;

	Vector2 velocity = new Vector2();
	Vector2 knockBack = new Vector2();

	MonsterStats stats;
	Hurtbox hurtBox;

	const int MAX_SPEED = 50;
	const int FRICTION = 30;



	MonsterState currentState = MonsterState.IDLE;
	
	public override void _Ready()
	{
		sprite = (Sprite)GetNode("Sprite");
		playerDetectionZone = (PlayerDetectionZone)GetNode("PlayerDetectionZone");
		stats = (MonsterStats)GetNode("MonsterStats");
		hurtBox = (Hurtbox)GetNode("Hurtbox");
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

		velocity = MoveAndSlide(velocity);
	}

	private void AutoPilot()
	{
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
		velocity = velocity.MoveToward(Vector2.Zero, FRICTION * GetPhysicsProcessDeltaTime());
		SeekPlayer();
	}
	protected virtual void GoWandering()
	{

	}
	protected virtual void ChasePlayer()
	{
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
		if(playerDetectionZone.SpottedPlayer())
		{
			currentState = MonsterState.CHASE;
		}
	}

	public void _on_Hurtbox_area_entered(Area2D area)
	{
		TakeDamageFromPlayerSword(area);	
		knockBack = (this.GlobalPosition - area.GlobalPosition).Normalized() * MAX_SPEED;
	}

	private void TakeDamageFromPlayerSword(Area2D area)
	{
		
		if (area is Hitbox swordArea)
		{
			GD.Print(area.Name);
			stats.CurrentHealth -= swordArea.Damage;
			if(stats.CurrentHealth > 0)
				hurtBox.CreateHitEffect();
		}	
	}
	private void FlipSprite()
	{
		sprite.FlipH = velocity.x < 0;
	}
	private void DampingKnockBack()
	{

		knockBack = knockBack.MoveToward(Vector2.Zero, FRICTION * GetPhysicsProcessDeltaTime());
		knockBack = MoveAndSlide(knockBack);
	}

	

	private void _on_MonsterStats_OutOfHealth()
	{
		CombatEffect.CreateDeathEffect(this);
		QueueFree();
	}

	
}
