using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public class Bayonet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bayonet");
            Tooltip.SetDefault("Left click to shoot a bullet.\nRight click to hit with the spear");
        }
        public override void SetDefaults()
        {
            item.damage = 34;
            item.ranged = true;
            item.noMelee = true; // So the weapon itself doesn't do damage (and only bullet/spear does)
            item.width = 80;
            item.height = 18;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = 5;
            item.knockBack = 7;
            item.value = 142500;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shootSpeed = 9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:WorldEvilGuns");
            recipe.AddRecipeGroup("ChampionMod:Tier2Broadswords");
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset() // So when holding the gun it goes slightly under the player's arm
		{
			return new Vector2(-10, 0);
		}

        public override bool AltFunctionUse(Player player) // So item can be right clicked (When holding; not in inventory)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 0) // On left click
            {
                item.melee = false;
                item.ranged = true;
                item.noUseGraphic = false;
                item.damage = 34;
                item.crit = 0; // + 4 = 4
                item.shootSpeed = 9f;
                item.UseSound = SoundID.Item11;
                item.useTime = 33;
                item.useAnimation = 33;
                item.knockBack = 6;
                item.shoot = ProjectileID.Bullet;
                item.useAmmo = AmmoID.Bullet;
            }
            else if (player.altFunctionUse == 2) // On right click
            {
                item.melee = true;
                item.ranged = false;
                item.noUseGraphic = true; // Stops the melee animation
                item.damage = 32;
                item.knockBack = 7;
                item.crit = 1; // + 4 = 5
                item.shootSpeed = 3f;
                item.UseSound = SoundID.Item1;
                item.useTime = 28;
                item.useAnimation = 28;
                item.shoot = mod.ProjectileType("BayonetProjectile");
                item.useAmmo = 0;

                return player.ownedProjectileCounts[item.shoot] < 1;
            }

            return base.CanUseItem(player);
        }
    }
}