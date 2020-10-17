using Godot;
using System;

public class PlayerDetectionZone : Area2D
{
	Player player = null;

	//Nếu có player trong PlayerDetectionZone return true
	public bool SpottedPlayer()
	{
		return player != null;
	}

	//Khi một object tiến vào PlayerDetectionZone
	//Phương thức này sẽ kiểm tra body có phải là Player hay không
	private void _on_PlayerDetectionZone_body_entered(KinematicBody2D body)
	{
		if(body is Player playerBody)
        {
			this.player = playerBody;
		}
	}

	//Khi một object ra khỏi PlayerDetectionZone
	//Nếu là Player, this.player = null
	private void _on_PlayerDetectionZone_body_exited(KinematicBody2D body)
	{
		if (body is Player playerBody)
		{
			this.player = null;
		}
	}

	public Player Player { get => player; }
}



