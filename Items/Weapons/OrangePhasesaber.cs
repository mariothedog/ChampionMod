using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons
{
	public class OrangePhasesaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orange Phasesaber");
			Tooltip.SetDefault("Phasesabers, now in orange.");
		}
		public override void SetDefaults()
		{
			item.damage = 41;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 27000;
			item.rare = 4;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.scale = 1.15f;
			item.useTurn = true;

			// Crit by default is 4
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("OrangePhaseblade"), 1);
			recipe.AddIngredient(ItemID.CrystalShard, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			// Orange Lighting
            Lighting.AddLight(hitbox.Center.ToVector2(), 1f, 0.4f, 0f);
        }
	}
}
