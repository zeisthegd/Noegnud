using Godot;
using System;

public class Fireball : KinematicBody2D
{
	[Export]
	PackedScene hitEffect;
	KinematicBody2D target;

	Vector2 velocity = new Vector2();
	Vector2 direction = new Vector2();

	public override void _Ready()
	{
		TargetPlayer();
		RotateToTarget();
		velocity = direction * 3;
	}
	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		
		velocity = MoveAndSlide(velocity);
	}


	private void _on_Hitbox_body_entered(KinematicBody2D body)
	{
		if(body is Player player)
		{
			CreateHitEffect();
			QueueFree();
		}
		
	}

	private void RotateToTarget()
	{
		this.Rotation = target.GlobalPosition.AngleToPoint(this.GlobalPosition);
	}

	public void TargetPlayer()
	{
		this.target = Global.GetPlayer();
	}
	public void SetDirection(Vector2 direction)
	{
		this.direction = direction;
	}


	private void CreateHitEffect()
	{
		Node2D hitFX = (Node2D)hitEffect.Instance();
		var currentScene = GetTree().CurrentScene;
		currentScene.GetNode("MainSort").AddChild(hitFX);
		hitFX.GlobalPosition = this.GlobalPosition;
	}
	private void _on_DieTime_timeout()
	{
		QueueFree();
	}
}






