using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ChampionMod.NPCs.Bosses.Netherworm
{
	internal class NetherwormBody : Netherworm
    {
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
		}
	}
}