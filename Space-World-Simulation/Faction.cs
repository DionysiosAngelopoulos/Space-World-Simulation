using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questia {
    class Faction {
        public List<Faction> enemies = new List<Faction>();
        public List<Faction> alies  = new List<Faction>();

        public void MakeFriend(Faction faction) {
            alies.Add(faction);
            foreach (Faction f in faction.enemies) {
                if (enemies.Contains(f) == false) {
                    enemies.Add(f);
                }
            }
        }

        public void MakeEnemy(Faction faction) {
            enemies.Add(faction);
        }
    }
}
