using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExampleMod.Items
{
	public class BossBags : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
        {
			if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
            {
				player.QuickSpawnItem(mod.ItemType("KingsGel"), Main.rand.Next(5, 16));
			}
		}
	}
}