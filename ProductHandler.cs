using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class ProductHandler
    { 
        public void TopRecords(List<ProductReview> reviews)
        {
            var topRecords = (from ProductReview in reviews
                              orderby ProductReview.Ratings descending
                              select ProductReview
                            ).Take(3);
            foreach(ProductReview review in topRecords)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", review.ProductID, review.UserID, review.Ratings, review.Review, review.IsLike);
            }
        }
        public void GetRecordBasedOnRating(List<ProductReview> reviews)
        {
            var selectedRecords = from ProductReview in reviews
                                  where (ProductReview.ProductID == 1 && ProductReview.Ratings > 3) ||
                                    (ProductReview.ProductID == 4 && ProductReview.Ratings > 3) ||
                                    (ProductReview.ProductID == 9 && ProductReview.Ratings > 3)
                                  select ProductReview;
            foreach (ProductReview records in selectedRecords)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", records.ProductID, records.UserID, records.Ratings, records.Review, records.IsLike);
            }
        }

        public void GetCount(List<ProductReview> reviews)
        {
            var usersGroupedByCountry = reviews.GroupBy(user => user.ProductID);
            Console.WriteLine(usersGroupedByCountry.Count());
            
        }
        public void SkipRecords(List<ProductReview> reviews)
        {
            var middleNames = reviews.Skip(5).ToList();
            foreach (ProductReview records in middleNames)
            {
                Console.WriteLine("Product: {0},{1},{2},{3},{4}", records.ProductID, records.UserID, records.Ratings, records.Review, records.IsLike);
            }
        }
    }
}
