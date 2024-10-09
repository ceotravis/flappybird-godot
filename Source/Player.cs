using Godot;
using System;

public partial class Player : CharacterBody2D {
	public const float Speed = 300.0f;
	public const float JumpVelocity = -200.0f;

	[Signal]
	public delegate void IncreaseScoreEventHandler();


	public override void _PhysicsProcess(double delta) {
		Vector2 velocity = Velocity;

		// Add the gravity.
 		if (!IsOnFloor()) {
			velocity += GetGravity() * (float)delta;
		} 

		// Handle Jump.
		if (Input.IsActionJustPressed("jump")) {
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		if (OS.HasFeature("editor")) {
			Vector2 direction = Input.GetVector("left", "right", "up", "down");
			if (direction != Vector2.Zero) {
				velocity.X = direction.X * Speed;
			} else {
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}

    /// <summary>
	/// Emits a signal when the player has collided with a PointCounter
	/// </summary>
	/// <param name="body"></param>
	public void ColliedWithPointCounter(Area2D body) {
		if (body.Name != "PointCounter") return;

		EmitSignal(SignalName.IncreaseScore);
	}
}
