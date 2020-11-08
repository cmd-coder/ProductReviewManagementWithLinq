using System;
using System.Collections.Generic;

namespace ProductReviewManagementWithLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Management Program");
            //UC1
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID=1,UserID=1,Rating=2,Review="Good",isLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductID=3,UserID=1,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductID=4,UserID=1,Rating=6,Review="Good",isLike=false},
                new ProductReview(){ProductID=5,UserID=1,Rating=2,Review="nice",isLike=true},
                new ProductReview(){ProductID=6,UserID=1,Rating=1,Review="bad",isLike=true},
                new ProductReview(){ProductID=8,UserID=1,Rating=1,Review="Good",isLike=false},
                new ProductReview(){ProductID=8,UserID=1,Rating=9,Review="nice",isLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=10,Review="nice",isLike=true},
                new ProductReview(){ProductID=10,UserID=1,Rating=8,Review="nice",isLike=true},
                new ProductReview(){ProductID=11,UserID=1,Rating=3,Review="nice",isLike=true}
            };

            foreach(var list in productReviewList)
            {
                Console.WriteLine("ProductID: " + list.ProductID + " UserID: " + list.UserID + " Rating: " + list.Rating + " Review: " + list.Review + " isLike: " + list.isLike);
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 2: Top Three Records With Highest Rating");
            Console.WriteLine("---------------------");
            Management management = new Management();
            management.TopRecords(productReviewList);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 3: Rating Greater Than 3 And ProductID Equal To 1, 4 or 9");
            Console.WriteLine("---------------------");
            management.SelectRecords(productReviewList);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 4: Count of Each Review For ProductID");
            Console.WriteLine("---------------------");
            management.RetrieveCountOfRecords(productReviewList);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 5: Retrieve Only ProductID and Review");
            Console.WriteLine("---------------------");
            management.RetrieveOnlyProductIDAndReview(productReviewList);

            Console.WriteLine("---------------------");
            Console.WriteLine("Use Case 6: Skip Top 5 Records And Print Rest");
            Console.WriteLine("---------------------");
            management.SkipTop5Records(productReviewList);

        }
    }
}
