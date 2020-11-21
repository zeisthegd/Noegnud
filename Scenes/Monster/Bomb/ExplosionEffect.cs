using Godot;
using System;

public class ExplosionEffect : Sprite
{
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		if (anim_name == "Boom")
			QueueFree();
	}
}
