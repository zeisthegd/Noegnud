using Godot;
using System;

public class Player : KinematicBody2D
{
	#region Fields
	static string spriteSheetPath = "res://Assets/Art/Player/Player.png";
	const string spriteNodeName = "Sprite";
	const string animationPlayerName = "AnimationPlayer";

	Sprite spriteSheet;
	AnimationPlayer animationPlayer;

	PlayerMovementHandler playerMovementHandler;
	PlayerStateMachine playerStateMachine;

	Hurtbox hurtBox;
	PlayerStats playerStats;
	#endregion

	#region Override Methods
	public override void _Ready()
	{
		InitializeAllChilds();
		InitializePlayer();
	}
	public override void _Process(float delta)
	{
		playerMovementHandler.HandleMoveInput();//Xử lí input di chuyển
		playerStateMachine.HandleKeypressEvent();//xử lí chuyển đổi state
	}
	public override void _PhysicsProcess(float delta)
	{
		playerMovementHandler.ApplyPhysics();
	}
	#endregion

	#region Initialize Methods

	//Ánh xạ các Child node
	private void InitializeAllChilds()
	{
		playerStats = (PlayerStats)GetNode("PlayerStats");
		hurtBox = (Hurtbox)GetNode("Hurtbox");
		spriteSheet = (Sprite)GetNode(spriteNodeName);
		animationPlayer = (AnimationPlayer)GetNode(animationPlayerName);
	}
	 
	private void InitializePlayer()
	{
		playerMovementHandler = new PlayerMovementHandler(this);
		TextureHandler.ChangePlayerTexture(spriteSheet, spriteSheetPath);

		playerStateMachine = new PlayerStateMachine(this);
	}

	#endregion

	#region Properties
	public AnimationPlayer AnimationPlayer { get => animationPlayer; }
	#endregion
	#region Signals
	//Khi kết thúc animation Attack thì chuyển State về Idle
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		if (anim_name.StartsWith("Attack"))
			playerStateMachine.AttackAnimationFinished();
	}

	private void _on_Hurtbox_area_entered(Area2D area)
	{
		TakeDamageFromMonster(area);	
	}

	//Khi nhận được tín hiệu hết máu từ PlayerStats
	//Tạo một DeathEffect
	//Biến mất
	//Sau này nên thêm animation Death
	private void _on_PlayerStats_OutOfHealth()
	{
		CombatEffect.CreateDeathEffect(this);
		QueueFree();
	}

	//Tìm hitbox của nguồn gây sát thương và áp dụng damage của hitbox đó vào HP của Player
	private void TakeDamageFromMonster(Area2D area)
	{
		if (area is Hitbox hitbox)
		{
			playerStats.CurrentHealth -= hitbox.Damage;
			
			if (playerStats.CurrentHealth >= 0)
			{
				hurtBox.CreateHitEffect();//Sau đó tạo một effect hit
				hurtBox.StartInvincibility(0.5F);//Sau đó làm cho player không thể bị tấn công trong 0.5 giây

			}
		}
	}

	#endregion
}





