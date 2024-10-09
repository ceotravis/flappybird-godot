using Godot;
using System;

public partial class PillarSpawner : Marker2D {
	readonly Random random = new();

	[Export]
	public PackedScene PillarScene { get; set; }

	Pillar pillarBottom;
	Pillar pillarTop;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		CreatePillars();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public void TimerTimeout() {
		CreatePillars();
	}

	/// <summary>
	/// Creates two pillars: one at the bottom and one at the top of the screen, with randomized positions.
	/// </summary>
	/// <remarks>
	/// - The bottom pillar's Y position is adjusted randomly between 0 and 50 units downwards.
	/// - The bottom pillar's X position is slightly adjusted by a random value between -45 and 12 units.
	/// - The top pillar's X position is offset further from the bottom pillar's position, and its Y position
	///   is adjusted based on the height of the bottom pillar. If the bottom pillar is higher than 45 units
	///   on the Y axis, the top pillar is placed farther away to maintain a gap between them.
	/// - The top pillar is also rotated by 180 degrees to face downwards.
	/// </remarks>
	private void CreatePillars() {
		var pillarBottomPosition = Position;
		pillarBottomPosition.Y -= random.Next(0, 50);
		pillarBottomPosition.X += random.Next(-45, 12);
		pillarBottom = CreatePillar(pillarBottomPosition);
		AddChild(pillarBottom);

		var pillarTopPosition = new Vector2(Position.X + random.Next(220, 260), Position.Y);

		switch (pillarBottomPosition.Y) {
			case > 45:
				pillarTopPosition.Y -= random.Next(700, 780);
				break;
			case < 45:
				pillarTopPosition.Y -= random.Next(510, 600);
				break;
		}

		pillarTop = CreatePillar(pillarTopPosition);
		pillarTop.Rotation = (float)Math.PI;
		AddChild(pillarTop);
	}

	/// <summary>
	/// Create a pillar at a specific position
	/// </summary>
	/// <param name="position">The position the pillar should be created at</param>
	/// <returns>A pillar</returns>
	private Pillar CreatePillar(Vector2 position) {
		var pillar = PillarScene.Instantiate<Pillar>();
		pillar.Position = position;

		return pillar;
	}


}
