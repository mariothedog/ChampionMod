using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Materials.BossDrops
{
    public class KingsGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King's Gel");
            Tooltip.SetDefault("Not for consumption");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 26;
            item.height = 26;
            item.value = 5000;
        }
    }
}