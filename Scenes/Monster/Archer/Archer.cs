using Godot;
using System;

public class Archer : Monster
{
	[Export]
	PackedScene fireball;

	bool canAttack = true;

	Timer attackCooldown;
	public override void _Ready()
	{
		base._Ready();
		attackCooldown = (Timer)GetNode("AttackCooldown");
	}
	public override void _Process(float delta)
	{
		base._Process(delta);
		if (!animationPlayer.IsPlaying())
			QueueFree();
	}
	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
	}
	protected override void GoWandering()
	{
		base.GoWandering();
		PlayWanderOrIdle();
	}
	protected override void ChasePlayer()
	{
		PlayWanderOrIdle();
		Player player = playerDetectionZone.Player;
		if (player != null)
		{
			Attack();
			var direction = (player.GlobalPosition - this.GlobalPosition).Normalized();
			velocity = velocity.MoveToward(direction * MAX_SPEED, MAX_SPEED * 2 * GetPhysicsProcessDeltaTime());
		}
		else
			currentState = MonsterState.WANDER;
		if (knockBack == Vector2.Zero)
			velocity = MoveAndSlide(velocity);
	}
	protected override void Attack()
	{
		base.Attack();
		if(canAttack)
		{
			velocity = Vector2.Zero;
			canAttack = false;
			animationPlayer.Play("Attack");
			ShootFireball();
		}
	}
	private void PlayWanderOrIdle()
	{
		if (velocity != Vector2.Zero)
			animationPlayer.Play("Wander");
		else animationPlayer.Play("Idle");
	}
	private void ShootFireball()
	{
		Fireball newFireball = (Fireball)fireball.Instance();	
		newFireball.GlobalPosition = this.GlobalPosition;
		newFireball.SetDirection(Global.GetPlayer().GlobalPosition - this.GlobalPosition);
		Global.CurrentScene.GetNode("MainSort").AddChild(newFireball);
		attackCooldown.Start();
	}
	private void _on_AttackCooldown_timeout()
	{
		canAttack = true;
	}

}



