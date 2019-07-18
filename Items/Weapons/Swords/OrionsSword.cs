using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class OrionsSword : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Orion's Sword");
		}

		public override void SetDefaults() {
			item.damage = 54;           
			item.melee = true;          
			item.width = 50;            
			item.height = 50;           //Weapon's texture's height
			item.useTime = 23;          //The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 23;         //The time span of the using animation of the weapon, suggest set it the same as useTime.
			item.useStyle = 1;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 7;         //The force of knockback of the weapon. Maximum is 20
			item.value = Item.buyPrice(gold: 4);           //The value of the weapon
			item.rare = 5;              //The rarity of the weapon, from -1 to 13
			item.UseSound = SoundID.Item1;      //The sound of the weapon on use
			item.autoReuse = true;  
			item.shootSpeed = 16f    
		}

        // Uncomment this when everything with the sword including projectiles are finished

		/*public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddRecipeGroup("ChampionMod:Tier4BarSwords");
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddIngredient(ItemID.CrystalShard, 3);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.rand.Next(2);
				if (Main.rand.Next(2) == 0)
						{
						item.shoot = mod.ProjectileType("FrostStar");//Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FrostStar"), damage, knockBack, player.whoAmI);
						}
						else
						{
						item.shoot = mod.ProjectileType("FlameStar");//Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("FlameStar"), damage, knockBack, player.whoAmI);
						}
		 return true;
		}
	}
}
