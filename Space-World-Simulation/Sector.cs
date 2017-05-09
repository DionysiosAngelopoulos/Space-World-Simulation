using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questia {
    class Sector {
        public Sector[] connections;
        public List<Unit> units = new List<Unit>();

        public void Update() {
            Random rand = new Random();
            foreach (Unit u in units) {
                List<Unit> con = new List<Unit>();
                foreach (Unit u2 in units) {
                    if (u2 == u) {
                        continue;
                    }
                    if (u.faction.enemies.Contains(u2.faction)) {
                        if (rand.Next(0, 2) == 1)  {
                            con.Add(u2);
                        }
                    }
                }
                if (con.Count != 0) {
                    int n = rand.Next(0, con.Count);
                    con[n].hull -= u.dpt;
                    // u atacks a random enemy
                    Console.WriteLine(u.name + " -> " + con[n].name);
                }
            }
        }
    }
}
