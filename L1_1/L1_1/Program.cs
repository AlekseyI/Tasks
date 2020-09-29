using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Наследование, инкапсуляция, полиморфизм
            List<Tower> listTowers = new List<Tower>(3);

            RedGem redGem = new RedGem("Red Gem");
            Tower towerWithRedGem = new Tower(redGem);
            listTowers.Add(towerWithRedGem);

            GreenGem greenGem = new GreenGem("Green Gem");
            Tower towerWithGreenGem = new Tower(greenGem);
            listTowers.Add(towerWithGreenGem);

            BlueGem blueGem = new BlueGem("Blue Gem");
            Tower towerWithBlueGem = new Tower(blueGem);
            listTowers.Add(towerWithBlueGem);

            foreach (var tower in listTowers)
            {
                tower.ActivateGem(true);
            }

            Console.ReadKey();
        }
    }
}
