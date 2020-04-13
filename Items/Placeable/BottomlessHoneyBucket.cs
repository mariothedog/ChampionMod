using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ChampionMod.Utils;

namespace ChampionMod.Items.Placeable
{
    public class BottomlessHoneyBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Bottomless Honey Bucket");
            Tooltip.SetDefault("Contains an endless amount of honey");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.CloneDefaults(ItemID.BottomlessBucket);
        }
        public override bool UseItem(Player player)
        {
            return LiquidHelper.ActuallyFreakingPlaceTheLiquidOMFG(player, LiquidHelper.Liquids.Honey, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottomlessBucket);
            recipe.AddIngredient(ItemID.HoneyBucket, 99);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
