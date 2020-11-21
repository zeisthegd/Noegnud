using Godot;
using System;

//Hurtbox dùng để nhận sát thương đến từ Hitbox
//Dùng chung cho Player và Monster
public class Hurtbox : Area2D
{
	PackedScene hitEffect = (PackedScene)ResourceLoader.Load("res://Scenes/VFX/EnemyFX/HitEffect.tscn");

	bool invincible = false;

	Timer invincibleTimer;

	//Custom Signal
	//Người phát triển có thể tạo những signal riêng
	//Và kết nối các signal này tới những hàm cần thiết
	[Signal]
	public delegate void InvincibilityStarted();
	[Signal]
	public delegate void InvincibilityEnded();


	public override void _Ready()
	{
		base._Ready();
		invincibleTimer = (Timer)GetNode("InvincibleTimer");

	}

	//Nếu người chơi bị tấn công
	//Người chơi sẽ không thể bị tấn công lần nữa sau một khoảng thời gian
	public void SetInvincible(bool value)
	{
		invincible = value;
		if (invincible == true)
		{
			EmitSignal(nameof(InvincibilityStarted));//Phương thức EmitSignal sẽ phát ra tín hiệu được truyền vào
		}
		else
			EmitSignal(nameof(InvincibilityEnded));
	}

	//Bắt đầu
	public void StartInvincibility(float duration)
	{
		//Bắt đầu cho nhân vật bị tấn công một khoảng thời gian không thể bị tấn công (duration)
		SetInvincible(true);
		//Bắt đầu bộ đếm ngược thời gian bắt đầu bằng duration giảm dần về 0 theo thời gian thực	
		if (invincibleTimer.TimeLeft <= 0)
			invincibleTimer.Start(duration);
	}

	public void CreateHitEffect()
	{
		//Tạo ra một hit effect tại vị trí của người bị tấn công
		Node2D hitFX = (Node2D)hitEffect.Instance();
		var currentScene = GetTree().CurrentScene;
		currentScene.AddChild(hitFX);
		hitFX.GlobalPosition = this.GlobalPosition;
	}

	//Sau khi bộ đếm ngược thời gian đếm về 0
	private void _on_Invincible_Timer_timeout()
	{
		SetInvincible(false);
	}

	//Phương thức này nhận tín hiệu InvincibilityStarted
	private void _on_Hurtbox_InvincibilityStarted()
	{
		//Property Monitorable:
		//- true: các area khác có thể va chạm với area này.
		//- false: các area khác không thể va chạm với area này.

		//Khi tín hiệu InvincibilityStarted được phát ra
		//Monitorable sẽ được chuyển thành false
		//Để tránh nhân vật bị tấn công bị tấn công thêm lần nữa 
		//sau một khoảng thời gian(duration) nhất định
		SetDeferred("Monitorable", false);
	}

	//Phương thức này nhận tín hiệu InvincibilityEnded
	private void _on_Hurtbox_InvincibilityEnded()
	{
		SetDeferred("Monitorable", true);
	}

	public bool Invincible { get => invincible; set => invincible = value; }
}






