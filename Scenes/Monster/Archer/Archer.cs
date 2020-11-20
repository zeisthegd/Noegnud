using Godot;
using System;

public class Archer : Monster
{
	public override void _Ready()
	{
		base._Ready();
	}
	public override void _Process(float delta)
	{
		base._Process(delta);
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
		base.ChasePlayer();
		PlayWanderOrIdle();
	}

	protected override void Attack()
	{
		base.Attack();
		
	}

	private void PlayWanderOrIdle()
	{
		if (velocity != Vector2.Zero)
			animationPlayer.Play("Wander");
		else animationPlayer.Play("Idle");
	}
}
