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
    }
}
