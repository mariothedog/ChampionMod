using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Melee.Swords
{
	public class OrionsSword : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orion's Sword");
		}

		public override void SetDefaults()
        {
			item.damage = 54;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.buyPrice(gold: 4);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("FlameStar");
            item.shootSpeed = 16f;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:Tier4BarSwords");
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddIngredient(ItemID.CrystalShard, 3);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.Next(2) == 0)
			{
			    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FrostStar"), damage, knockBack, player.whoAmI);
			}
			else
			{
			    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FlameStar"), damage, knockBack, player.whoAmI);
			}

            return false;
		}
	}
}