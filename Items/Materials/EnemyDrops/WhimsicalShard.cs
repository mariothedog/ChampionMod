using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Materials.EnemyDrops
{
    public class WhimsicalShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("They playfully hop around in your hands");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 26;
            item.height = 26;
            item.value = 15000;
            item.rare = 4;
        }
    }
}