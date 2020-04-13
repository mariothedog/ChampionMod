using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ChampionMod.Utils;

namespace ChampionMod.Items.Placeable
{
    public class BottomlessLavaBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Bottomless Lava Bucket");
            Tooltip.SetDefault("Contains an endless amount of lava. Be cautious!");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.CloneDefaults(ItemID.BottomlessBucket);
        }
        public override bool UseItem(Player player)
        {
            return LiquidHelper.ActuallyFreakingPlaceTheLiquidOMFG(player, LiquidHelper.Liquids.Lava, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottomlessBucket);
            recipe.AddIngredient(ItemID.LavaBucket, 99);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
