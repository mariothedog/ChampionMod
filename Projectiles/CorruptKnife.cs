using ChampionMod.Items.Weapons.Throwing;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class CorruptKnife : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Corrupt Knife");
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.BoneJavelin);
            //projectile.aiStyle = 113;
        }
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 1200);
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
           drawCacheProjsBehindProjectiles.Add(index);
        }
    }
}