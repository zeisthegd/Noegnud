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
	#endregion
	#region Override Methods
	public override void _Ready()
	{
		InitializeAllChilds();
		InitializePlayer();
	}
	public override void _Process(float delta)
	{
		playerMovementHandler.HandleMoveInput();

		playerStateMachine.HandleKeypressEvent();
	}
	public override void _PhysicsProcess(float delta)
	{
		playerMovementHandler.ApplyPhysics();
	}
	#endregion
	#region Initialize Methods
	private void InitializeAllChilds()
	{
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
	private void _on_AnimationPlayer_animation_finished(String anim_name)
	{
		if (anim_name.StartsWith("Attack"))
			playerStateMachine.AttackAnimationFinished();
	}

	#endregion
}
