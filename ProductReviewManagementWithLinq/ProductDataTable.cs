using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagementWithLinq
{
    class ProductDataTable
    {
        public static void DataTableOfProducts()
        {
            DataTable productTable = new DataTable();
            productTable.Columns.Add("ProductID");
            productTable.Columns.Add("UserID");
            productTable.Columns.Add("Rating", typeof(int));
            productTable.Columns.Add("Review");
            productTable.Columns.Add("isLike", typeof(bool));

            productTable.Rows.Add("1", "1", 2, "Good", true);
            productTable.Rows.Add("2", "1", 4, "Good", true);
            productTable.Rows.Add("3", "1", 5, "Good", true);
            productTable.Rows.Add("4", "1", 6, "Good", false);
            productTable.Rows.Add("5", "1", 2, "Nice", true);
            productTable.Rows.Add("6", "1", 1, "Bad", true);
            productTable.Rows.Add("8", "1", 1, "Good", false);
            productTable.Rows.Add("8", "1", 9, "Nice", true);
            productTable.Rows.Add("2", "1", 10, "Good", true);
            productTable.Rows.Add("10", "1", 8, "Nice", true);
            productTable.Rows.Add("11", "1", 3, "Nice", true);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 8: Create Data Table And Store Some Default Values");
            Console.WriteLine("---------------------");
            DisplayAllRecords(productTable);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 9: Retrieve All \"ture\" isLike values");
            Console.WriteLine("---------------------");
            RetrieveAllTrue(productTable);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 10: All The ProductID Along With Their Average Rating");
            Console.WriteLine("---------------------");
            AverageRatingOfEachProductID(productTable);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 11: All The Records With \"Nice\" Reviews");
            Console.WriteLine("---------------------");
            AllNiceReviews(productTable);

        }

        public static void DisplayAllRecords(DataTable productTable)
        {
            var recordedData = from products in productTable.AsEnumerable() select products;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list[0] + " UserID: " + list[1] + " Rating: " + list[2] + " Review: " + list[3] + " isLike: " + list[4]);
            }
        }

        public static void RetrieveAllTrue(DataTable productTable)
        {
            var recordedData = from products in productTable.AsEnumerable() where products.Field<bool>("isLike") == true select products;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list[0] + " UserID: " + list[1] + " Rating: " + list[2] + " Review: " + list[3] + " isLike: " + list[4]);
            }
        }

        public static void AverageRatingOfEachProductID(DataTable productTable)
        {
            var recordedData = from products in productTable.AsEnumerable() group products by products.Field<string>("ProductID") into proID select new { ProductID= proID.Key , AverageRating=proID.Average(a=>a.Field<int>("Rating"))};
            foreach(var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductID + " Average Rating: " + list.AverageRating);
            }
        }

        public static void AllNiceReviews(DataTable productTable)
        {
            var recordedData = from products in productTable.AsEnumerable() where products.Field<string>("Review") == "Nice" select products;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list[0] + " UserID: " + list[1] + " Rating: " + list[2] + " Review: " + list[3] + " isLike: " + list[4]);
            }
        }
    }
}
