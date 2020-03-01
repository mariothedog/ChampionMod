using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ChampionMod.NPCs.Bosses.Netherworm
{
    internal class NetherwormTail : Netherworm
    {
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerTail);
			npc.aiStyle = -1;
		}

		public override void Init()
		{
			base.Init();
			tail = true;
		}
	}
}