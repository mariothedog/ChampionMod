using ChampionMod.NPCs.Generic;
using static Terraria.ModLoader.ModContent;

namespace ChampionMod.NPCs.Bosses.Netherworm
{
	public abstract class Netherworm : Worm
	{
		public override void Init()
		{
			minLength = 6;
			maxLength = 12;
			tailType = NPCType<NetherwormTail>();
			bodyType = NPCType<NetherwormBody>();
			headType = NPCType<NetherwormHead>();
			speed = 5.5f;
			turnSpeed = 0.045f;
		}
	}
}