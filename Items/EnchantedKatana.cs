using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Items
{
    public class EnchantedKatana : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Katana");
            Tooltip.SetDefault("A powerful blade, both in forgery and enchantment");
        }
        public override void SetDefaults()
        {
            item.damage = 32;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 21;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 250000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = 173;
            item.shootSpeed = 10f;
            item.crit = 15; // Terraria adds 4% crit to everything so 15 is actually 19
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedSword, 1);
            recipe.AddIngredient(ItemID.Katana, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        /*public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            // REDf, GREENf, BLUEf
            // 1f, 0f, 0f for Red
            // 0f, 1f, 0f for Green
            // 0f, 0f, 1f for Blue

            //Lighting.AddLight(hitbox.Center.ToVector2(), 1f, 0.4f, 0f);

            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(hitbox.Center.ToVector2(), 147, 163, 173, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            }

        }*/

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(hitbox.Center.ToVector2(), 0.2f, 0.6f, 1f);
        }
    }
}
