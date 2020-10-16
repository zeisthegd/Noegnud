using Godot;
using System;

public class Hurtbox : Area2D
{
	PackedScene hitEffect = (PackedScene)ResourceLoader.Load("res://Scenes/VFX/EnemyFX/HitEffect.tscn");

	bool invincible = false;

	Timer invincibleTimer;


	[Signal]
	public delegate void InvincibilityStarted();
	[Signal]
	public delegate void InvincibilityEnded();


	public override void _Ready()
	{
		base._Ready();
		invincibleTimer = (Timer)GetNode("InvincibleTimer");

	}


	public void SetInvincible(bool value)
	{
		invincible = value;
		if (invincible == true)
		{
			EmitSignal(nameof(InvincibilityStarted));
		}
		else
			EmitSignal(nameof(InvincibilityEnded));
	}

	public void StartInvincibility(float duration)
	{
		invincible = true;
		invincibleTimer.Start(duration);
	}

	public void CreateHitEffect()
	{
		Node2D hitFX = (Node2D)hitEffect.Instance();
		var currentScene = GetTree().CurrentScene;
		currentScene.AddChild(hitFX);
		hitFX.GlobalPosition = this.GlobalPosition;

	}
	private void _on_Invincible_Timer_timeout()
	{
		invincible = false;
	}

	private void _on_Hurtbox_InvincibilityStarted()
	{
		Monitorable = false;
	}

	private void _on_Hurtbox_InvincibilityEnded()
	{
		Monitorable = true;
	}
	public bool Invincible { get => invincible; set => invincible = value; }
}






