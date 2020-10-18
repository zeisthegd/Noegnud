using Godot;
using System;

//Chịu trách nhiệm cho state wander của monster
public class WanderController : Node2D
{
	[Export]
	float wanderTime = 3f;
	[Export]
	float maxRandomSpeed = 50f;

	Timer wanderDuration;
	private Vector2 wanderDirection;
	public override void _Ready()
	{
		base._Ready();
		wanderDuration = (Timer)GetNode("wanderDuration");
	}

	//Random một vector hướng di chuyển với một vận tốc di chuyển random
	public void UpdateWanderDirection()
	{
		if (wanderDuration.TimeLeft <= 0)
		{
			float randomX = (float)GD.RandRange(-1, 1);
			float randomY = (float)GD.RandRange(-1, 1);

			float randomSpeed = (float)GD.RandRange(0, maxRandomSpeed);
			wanderDirection = new Vector2(randomX, randomY) * randomSpeed;
			wanderDuration.Start(wanderTime);
		}

	}

	private void _on_Timer_timeout()
	{
		wanderDirection = Vector2.Zero;
		UpdateWanderDirection();
	}

	public Vector2 WanderVelocity { get => wanderDirection; }

}



