using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Items
{
    public class AmberPhaseblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amber Phaseblade");
            Tooltip.SetDefault("Phaseblade made of amber");
        }
        public override void SetDefaults()
        {
            item.damage = 50000;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 1;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 100;
            item.value = 100000000;
            item.rare = 13;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            //item.shoot = 132;
            //item.shootSpeed = 1f;
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
            // REDf, GREENf, BLUEf
            // 1f, 0f, 0f for Red
            // 0f, 1f, 0f for Green
            // 0f, 0f, 1f for Blue
            Lighting.AddLight(hitbox.Center.ToVector2(), 1f, 0.4f, 0f);
        }

        /*public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/AmberPhaseblade_glowmask");
            spriteBatch.Draw
                (
                    texture,
                    new Vector2
                    (
                        item.position.X - Main.screenPosition.X + item.width * 0.5f,
                        item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                    ),
                    new Rectangle(0, 0, texture.Width, texture.Height),
                    Color.White,
                    rotation,
                    texture.Size() * 0.5f,
                    scale,
                    SpriteEffects.None,
                    0f
                );
        }*/
    }
}
