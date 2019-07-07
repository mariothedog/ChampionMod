using Microsoft.Xna.Framework;
using Terraria; 
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Guns
{
    public class AgonyBearer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gets stronger as your health decreases");
        }

        public override void SetDefaults()
        {
            item.damage = 5; // Starting damage
            item.ranged = true;
            item.width = 36;
            item.height = 22;
            item.useTime = 25; // Fast but just barely
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4; // Weak knockback - Starting knockback
            item.UseSound = SoundID.Item41; // Same sound as the phoenix blaster
            item.shoot = 10;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Bullet;
            item.rare = 3; // Orange rarity
            item.value = 100000; // 2 Gold
        }

        // Change damage based on health
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            if (player.statLifeMax2 != 0) // Used to prevent a divide by 0 error if another mod set the max hp to 0 somehow
            {
                float healthRemaining = (float)player.statLife / player.statLifeMax2; // Fraction of health left
                if (healthRemaining == 1)
                {
                    damage = 5;
                }
                else if (healthRemaining >= 0.8)
                {
                    damage = 10;
                }
                else if (healthRemaining >= 0.6)
                {
                    damage = 20;
                }
                else if (healthRemaining >= 0.4)
                {
                    damage = 30;
                }
                else if (healthRemaining >= 0.2)
                {
                    damage = 40;
                }
            }
        }

        // Change knockback based on health
        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            if (player.statLifeMax2 != 0) // Used to prevent a divide by 0 error if another mod set the max hp to 0 somehow
            {
                float healthRemaining = (float)player.statLife / player.statLifeMax2; // Fraction of health left
                if (healthRemaining == 1)
                {
                    knockback = 4;
                }
                else if (healthRemaining >= 0.8)
                {
                    knockback = 5;
                }
                else if (healthRemaining >= 0.6)
                {
                    knockback = 6;
                }
                else if (healthRemaining >= 0.4)
                {
                    knockback = 7;
                }
                else if (healthRemaining >= 0.2)
                {
                    knockback = 8;
                }
            }
        }

        // So the gun is held in the player's hand
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        // So bullet comes out of muzzle
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            position.Y -= 5;
			return true;
		}
    }
}
