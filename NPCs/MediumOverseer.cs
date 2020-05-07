using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class MediumOverseer : LargeOverseer
    {
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Drippler);
			npc.width = 66;
			npc.height = 62;
			npc.damage = 48;
			npc.defense = 20;
			npc.lifeMax = 250;
			npc.value = Item.buyPrice(0, 0, 4, 50);
			npc.knockBackResist = Main.expertMode ? 0.4f : 0.45f;
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
			Item.NewItem(npc.getRect(), mod.ItemType("PileOfEyes"));
			Item.NewItem(npc.getRect(), ItemID.Lens, Main.rand.Next(1, 4));
			if (Main.rand.NextFloat() < 0.04)
			{
				Item.NewItem(npc.getRect(), ItemID.BlackLens);
			}
		}
	}
}