using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using ChampionMod.Utils;

namespace ChampionMod.Items.Placeable
{
    public class BottomlessLavaBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Bottomless Lava Bucket");
            Tooltip.SetDefault("Contains an endless amount of lava");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.CloneDefaults(ItemID.BottomlessBucket);
        }
        public override bool UseItem(Player player)
        {
            return LiquidHelper.ActuallyFreakingPlaceTheLiquidOMFG(player, LiquidHelper.Liquids.Lava);
        }

        public override void AddRecipes()
        {
        }
    }
}
