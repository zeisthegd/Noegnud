using Godot;
using System;

public class Bomb : Monster
{
	[Export]
	PackedScene explosionEffect;
	bool exploded = false;
	bool charging = false;

	public override void _Ready()
	{
		base._Ready();
	}
	public override void _Process(float delta)
	{
		base._Process(delta);
		if (exploded)
			QueueFree();

	}
	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
	}

	protected override void GoWandering()
	{
		if(!charging)
		{
			base.GoWandering();
			InRangeToAttack();
		}	
	}
	protected override void ChasePlayer()
	{
		if (!charging)		
		{
			base.ChasePlayer();
			InRangeToAttack();
		}
		
	}
	protected override void Attack()
	{
		if(!charging)
		{
			base.Attack();
			Charge();
		}
		
	}

	private async void Charge()
	{
		animationPlayer.Play("Charge");
		charging = true;

		var timer = new Timer();
		AddChild(timer);
		timer.WaitTime = 0.75F;
		timer.Start();
		await ToSignal(timer, "timeout");

		Explode();
	}

	private void Explode()
	{
		ExplosionEffect explosion = (ExplosionEffect)explosionEffect.Instance();
		Global.CurrentScene.GetNode("MainSort").AddChild(explosion);
		explosion.GlobalPosition = this.GlobalPosition;
		animationPlayer.Play("Explode");
	}

	private void InRangeToAttack()
	{
		if(Global.GetPlayer() != null)
		{
			if (GlobalPosition.DistanceTo(Global.GetPlayer().GlobalPosition) < 15)
				ChangeToAttack();
		}
		
	}
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		if (anim_name == "Explode")
			exploded = true;
	}
}



