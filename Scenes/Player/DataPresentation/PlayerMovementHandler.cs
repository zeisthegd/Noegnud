using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerMovementHandler
{
    private static Vector2 velocity;
	private Vector2 direction;
    

	private Player player;
	private string inputLeft = "move_left", inputRight = "move_right",
		inputUp = "move_up", inputDown = "move_down";

	private int runSpeed = 200; 

    

    public PlayerMovementHandler(Player newPlayer)
	{
		this.player = newPlayer;
	}

	public void HandleMoveInput()
	{
		direction = new Vector2();
		var listOfActions = new Dictionary<string, Vector2>();
   
		listOfActions.Add(inputLeft, new Vector2(-1, 0));
		listOfActions.Add(inputRight, new Vector2(1, 0));
		listOfActions.Add(inputUp, new Vector2(0, -1));
		listOfActions.Add(inputDown, new Vector2(0, 1));

		foreach(var action in listOfActions)
		{
			if (Input.IsActionPressed(action.Key))
				direction += action.Value;
		}
	}

	public void ApplyPhysics()
	{
        velocity = new Vector2();
        velocity = direction.Normalized() * runSpeed;
		velocity = player.MoveAndSlide(velocity);
	}

	public void ApplyKnockBack(Vector2 knockback)
    {
		velocity += knockback;
    }

    #region Properties

    public static Vector2 PlayerVelocity { get => velocity;}

    #endregion

}

