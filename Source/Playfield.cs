using Godot;
using System;

public partial class Playfield : Node2D {

	private int score = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Player player = GetNode<Player>("Player");
		player.Position = GetViewportRect().Size / 2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public void OnIncreaseScore() {
		score++;

		Label scoreLabel = GetNode<Label>("UI/ScoreLabel");

		scoreLabel.Text = $"Score: {score}";
	}
}
