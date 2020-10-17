using Godot;
using System;

public class Bat : Monster
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

	protected override void StayIdle()
	{
		base.StayIdle();
	}
	protected override void GoWandering()
	{
		base.GoWandering();
	}
	protected override void ChasePlayer()
	{
		base.ChasePlayer();
	}
}
