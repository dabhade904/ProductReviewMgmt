using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public static class ProductHandler
    {
       public static List<ProductReview> productList = new List<ProductReview>();
        public static List<ProductReview> ListOfRecords()
        {          
            productList.Add(new ProductReview(1, 1, 5, "good", false));
            productList.Add(new ProductReview(2, 2, 2, "good", false));
            productList.Add(new ProductReview(3, 4, 3, "good", true));
            productList.Add(new ProductReview(4, 5, 1, "bad", false));
            productList.Add(new ProductReview(6, 1, 3.5, "good", true));
            productList.Add(new ProductReview(2, 4, 3, "good", true));
            productList.Add(new ProductReview(7, 7, 4.5, "good", true));
            productList.Add(new ProductReview(1, 4, 4, "good", true));
            productList.Add(new ProductReview(9, 8, 3, "good", true));
            productList.Add(new ProductReview(7, 3, 1, "bad", false));
            productList.Add(new ProductReview(11, 1, 5, "good", true));
            productList.Add(new ProductReview(3, 10, 3, "good", false));
            return productList;
        }
        public static void TopRecords()
        {
            var topRecords = (from ProductReview in ListOfRecords()
                              orderby ProductReview.Ratings descending
                              select ProductReview
                            ).Take(3);
            foreach(ProductReview review in topRecords)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", review.ProductID, review.UserID, review.Ratings, review.Review, review.IsLike);
            }
        }
        public static void GetRecordBasedOnRating()
        {
            var selectedRecords = from ProductReview in ListOfRecords()
                                  where (ProductReview.ProductID == 1 && ProductReview.Ratings > 3) ||
                                    (ProductReview.ProductID == 4 && ProductReview.Ratings > 3) ||
                                    (ProductReview.ProductID == 9 && ProductReview.Ratings > 3)
                                  select ProductReview;
            foreach (ProductReview records in selectedRecords)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", records.ProductID, records.UserID, records.Ratings, records.Review, records.IsLike);
            }
        }
        public static void GetCountOfRecords()
        {
            var recordData = ListOfRecords()
                .GroupBy(user => user.ProductID).
                Select(user=> new { ProductID =user.Key,Count=user.Count()});
            foreach(var reocrdCount in recordData)
            {
                Console.WriteLine(reocrdCount.ProductID + " ------- " + recordData.Count());
            }  
        }
        public static void SkipRecords()
        {
            var skipRecord = ListOfRecords().Skip(5).ToList();
            foreach (ProductReview records in skipRecord)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", records.ProductID, records.UserID, records.Ratings, records.Review, records.IsLike);
            }
        }
    }
}
