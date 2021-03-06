using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Tools
{
	public class RoyalPickaxe : ModItem
	{
		public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("It's really slimey");
		}

		public override void SetDefaults()
        {
			item.damage = 6;
			item.melee = true;
			item.width = 16;
			item.height = 16;
			item.useTime = 20;
			item.useAnimation = 20;
			item.pick = 60;
			item.useStyle = 1;
			item.knockBack = 3;
            item.value = 250000;
            item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(mod.ItemType("KingsGel"), 5);
			recipe.AddIngredient(ItemID.Gel, 100);
			recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 12);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 33);
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 1200, false); // Slimed debuff for 20 seconds
        }
    }
}