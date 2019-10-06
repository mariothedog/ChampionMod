using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Consumables
{
	public class PinkDrink : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Seems exotic.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(silver: 10);
        }
			
            public override bool UseItem(Player player) 
		    {
                player.AddBuff(BuffID.Tipsy, 5400);
                player.AddBuff(BuffID.Swiftness,  5400);
                player.AddBuff(BuffID.Sunflower, 5400);
              return true;
            }
			
			public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PinkPricklyPear);
			recipe.AddIngredient(ItemID.Ale);
			recipe.AddTile(TileID.Kegs);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}