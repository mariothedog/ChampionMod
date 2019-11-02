using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Materials.EnemyDrops
{
    public class SerpentsSpine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Serpent's Spine");
			Tooltip.SetDefault("It's oddly dry");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 26;
            item.height = 26;
            item.value = 1000;
            item.rare = 0;
        }
    }
}