using Godot;
using System;

public class CombatEffect : AnimatedSprite
{
	static PackedScene deathEffect = (PackedScene)ResourceLoader.Load("res://Scenes/VFX/EnemyFX/EnemyDeathEffect.tscn");
	public override void _Ready()
	{
		Play();
	}
	private void _on_CombatEffect_animation_finished()
	{
		QueueFree();
	}

	public static void CreateDeathEffect(Node2D spawningScene)
	{
		CombatEffect deathFX = (CombatEffect)deathEffect.Instance();
		spawningScene.GetParent().AddChild(deathFX);
		deathFX.Offset = new Vector2(0, -8);
		deathFX.GlobalPosition = spawningScene.GlobalPosition;
	}
}

