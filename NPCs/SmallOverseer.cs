using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class SmallOverseer : LargeOverseer
    {
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Drippler);
			npc.width = 58;
			npc.height = 60;
			npc.damage = 44;
			npc.defense = 17;
			npc.lifeMax = 200;
			npc.value = Item.buyPrice(0, 0, 3, 0);
			npc.knockBackResist = Main.expertMode ? 0.45f : 0.5f;
			npc.aiStyle = -1;
			banner = mod.NPCType("LargeOverseer");
			bannerItem = mod.ItemType("OverseerBanner");
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return base.SpawnChance(spawnInfo);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextFloat() < 0.5)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("PileOfEyes"));
			}
			Item.NewItem(npc.getRect(), ItemID.Lens, Main.rand.Next(1, 3));
			if (Main.rand.NextFloat() < 0.02)
			{
				Item.NewItem(npc.getRect(), ItemID.BlackLens);
			}
		}
	}
}