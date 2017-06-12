using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
    class Person {
        public int aggressiveness;      // This is counted in % from 0 (coward) to 100 (extremely aggressive).
        public object location;         // The persons current location. (this is an object because it can either
                                        // a ship, or a station.
        public Unit employment;         // Where this person works. This is used to keep track of where the person
                                        // Should go  when a ship disembarks, this person will have to
                                        // go to that ship. Will be null if the person doesn't have a ship.
        public Faction faction;         // This persons faction. (null = no faction).
        public int loyalty;             // The loyalty of this person torwards their faction.
        public string name;             // This persons name.
        public Person(int aggressiveness, object location, Faction faction, int loyalty) {
            this.aggressiveness = aggressiveness;
            this.location = location;
            this.faction = faction;
            this.loyalty = loyalty;
        }

        public bool RequestReturnToWork(Station station) {
            Random Rand = new Random();
            if (employment.faction.name == faction.name) {
                if (Rand.Next(100) <= loyalty) {
                    return true;
                } else {
                    return false;
                }
            }
            if (faction.enemies.Contains(employment.faction)) {
                // This ship is of an enemy faction so the less loyal we are
                // the higher the chance we go.
                if (Rand.Next(100) > loyalty) {
                    location = employment;
                    return true;
                } else {
                    return false;
                }
            } else {
                // We have no reason not to go.
                return true;
            }
        }
    }
}
