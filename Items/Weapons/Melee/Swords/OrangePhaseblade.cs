using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Melee.Swords
{
	public class OrangePhaseblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orange Phaseblade");
			Tooltip.SetDefault("Phaseblades, now in orange");
		}
		public override void SetDefaults()
		{
			item.damage = 21;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 27000;
			item.rare = 1;
			item.UseSound = SoundID.Item15;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Amber, 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			// Orange lighting
            Lighting.AddLight(hitbox.Center.ToVector2(), 1f, 0.4f, 0f);
        }
	}
}
