using System.Linq;
using System.Web.Mvc;
using Model;

namespace Shop.Application.Areas.Admin.Controllers
{
    [Authorize]
    public class ImageProductController : Controller
    {

        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetImageProduct(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var model = db.ImageProducts.Where(x => x.Product == id).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public string InsertImageProduct(ImageProduct imageProduct)
        {
            if (imageProduct != null)
            {
                db.ImageProducts.Add(imageProduct);
                db.SaveChanges();
                return "Thêm thành công";
            }
            else
            {
                return "Thêm không thành công";
            }
        }
        public string UpdateImageProduct(ImageProduct imageProduct)
        {
            if (imageProduct != null)
            {
                var _imageProduct = db.Entry(imageProduct);
                ImageProduct cateObj = db.ImageProducts.Where(x => x.ID == imageProduct.ID).FirstOrDefault();
                cateObj.Image = imageProduct.Image;
                db.SaveChanges();
                return "Update thành công";
            }
            else
            {
                return "Update không thành công";
            }
        }

        public string DeleteImageProduct(int? id)
        {
            if (id != null)
            {
                ImageProduct imageProduct = db.ImageProducts.Find(id);
                db.ImageProducts.Remove(imageProduct);
                db.SaveChanges();
                return "Xóa thành công";
            }
            else
            {
                return "Xóa không thành công";
            }
        }
    }
}