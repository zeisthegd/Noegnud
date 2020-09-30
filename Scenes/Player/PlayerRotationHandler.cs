using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerRotationHandler
{
	Player player;
	Vector2 globalMousePosition;
	public PlayerRotationHandler(Player player)
	{
		this.player = player;
	}
	public void MakePlayerLookAtCursor(Sprite sprite)
	{
		globalMousePosition = player.GetGlobalMousePosition();
		if (globalMousePosition.x < player.GlobalPosition.x)
			sprite.FlipH = true;
		else
			sprite.FlipH = false;
	}


}
