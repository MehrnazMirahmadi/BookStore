using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.ViewModels.BookVM
{
    public class AddBookViewModel
    {
        [DisplayName("عنوان کتاب")]
        [Required(ErrorMessage = "فیلد عنوان اجباری است")]
        public string Title { get; set; }
        [DisplayName("شابک")]
        [Required(ErrorMessage = "شایک اجباری است")]
        [RegularExpression(@"^(978|979)-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$", ErrorMessage = "شابک باید در فرمت معتبر باشد. مثال: 978-3-16-148410-0")]
        public string ISBN { get; set; }
        [DisplayName("قیمت")]
        [Required(ErrorMessage = " قیمت احباری است")]
        public double Price { get; set; }
        [DisplayName("دسته بندی")]
        [Required(ErrorMessage = "دسته بندی را مشخص نمایید")]
        public int CategoryId { get; set; }
        public int BookDetailId { get; set; }
        [DisplayName("تاریخ انتشار")]
        public DateTime? PublishDate { get; set; }
        [DisplayName("انتشارات")]
        [Required(ErrorMessage = "ناشر را مشخص نمایید")]
        public int PublisherId { get; set; }

        /*************************/
        [DisplayName("تعداد بخش")]
        [Required(ErrorMessage ="اجباری")]
        public int NumberOfChapters { get; set; }
        [DisplayName("تعداد صفحات")]
        [Required(ErrorMessage = "اجباری")]
        public int NumberOfPages { get; set; }
        [DisplayName("وزن کتاب")]
        [Required(ErrorMessage = "اجباری")]
        public double Weight { get; set; }
        /************************/
        [DisplayName("نویسندگان")]
        [Required(ErrorMessage = "نویسنده یا نویسندگان اجباری است")]
        public List<int> SelectedAuthorIds { get; set; }


    }
}
