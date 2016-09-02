using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndStrings
{
    class CollectionPrograms
    {
        private List<ItemsDimention> ContinusSegments = null; 
        public void FindContinuousCollection(int findContinuourItemFrom)
        {
            //Populate the list object 
            var inputList = PopulateCollection();
            ContinusSegments = new List<ItemsDimention>();
            var findItem = inputList.Find(i => i.ID == findContinuourItemFrom);
            FindContinuousElement(findItem,inputList);
            if (ContinusSegments.Count > 0)
            {
                
            }
        }

        public List<ItemsDimention> PopulateCollection()
        {
            var ItemDimentionList = new List<ItemsDimention>
            {
                new ItemsDimention {X = 0, Width = 5, ID = 3},
                new ItemsDimention {X = 5, Width = 3, ID = 8},
                new ItemsDimention {X = 7, Width = 3, ID = 2},
                new ItemsDimention {X = 8, Width = 1, ID = 6},
                new ItemsDimention {X = 10, Width = 4, ID = 4},
                new ItemsDimention {X = 9, Width = 5, ID = 5}
            };

            return ItemDimentionList;
        }

        public void FindContinuousElement(ItemsDimention fromitem, List<ItemsDimention> inputList )
        {
            foreach (var itemsDimention in inputList.Where(itemsDimention => (fromitem.X + fromitem.Width) == itemsDimention.X))
            {
                ContinusSegments.Add(itemsDimention);
                FindContinuousElement(itemsDimention,inputList);
            }
        }
    }

    public class ItemsDimention
    {
        public int X { get; set; }
        public  int Width { get; set; }
        public  int ID { get; set; }

    }
}
