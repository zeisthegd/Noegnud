using Godot;
using System;

public class PlayerDetectionZone : Area2D
{
	Player player = null;

	public override void _Ready()
	{

	}

	public bool SpottedPlayer()
	{
		return player != null;
	}

	private void _on_PlayerDetectionZone_body_entered(KinematicBody2D body)
	{
		if(body is Player playerBody)
        {
			player = playerBody;
		}
	}


	private void _on_PlayerDetectionZone_body_exited(KinematicBody2D body)
	{
		if (body is Player playerBody)
		{
			player = null;
		}
	}

	public Player Player { get => player; }
}



