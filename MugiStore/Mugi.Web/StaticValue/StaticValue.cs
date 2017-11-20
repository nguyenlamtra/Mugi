using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.StaticValue
{
    public class StaticValue
    {
        public const string PREFIX_IMAGE_LINK_URL = "/images/ProductImages/";
        public const string SRC_NULL_IMAGE = "/images/ProductImages/null.png";
        public const string PAYMENTTYPE_1 = "Thanh toán khi nhận hàng";
        public const string PAYMENTTYPE_2 = "Thanh toán thông qua Ngân lượng";
        public const string RECEIVER = "n13dccn202@student.ptithcm.edu.vn";
        public const string URL_PAYMENT_SUCCESS = "http://localhost:56271/Product/HomePage";
        public const string URL_SEARCH = "/Staff/UpdateProduct?productId=";
        public const string URL_SEARCH_HOME_PAGE = "/Product/ProductDetails?productId=";
        public const string URL_SEARCH_GOODSRECEIPT = "/Staff/GoodsReceiptProduct?productId=";

        public const string PERMISSION_STAFF = "STAFF";
        public const string PERMISSION_CUSTOMER = "CUSTOMER";

        // Error require
        public const string REQUIRE_PRODUCTNAME = "Vui lòng nhập tên sản phẩm";
        public const string REQUIRE_NAME = "Vui lòng nhập tên";
        public const string REQUIRE_DESCRIPTION = "Vui lòng nhập mô tả";
        public const string REQUIRE_IMAGE = "Vui lòng chọn ảnh";
        public const string REQUIRE_PROPERTY = "Vui lòng nhập thuộc tính";
        public const string REQUIRE_PROPRETYVALUE = "Vui lòng nhập giá trị thuộc tính";
        public const string REQUIRE_SUPPLIER = "Vui lòng nhập nhà sản xuất";
        public const string REQUIRE_SUBCATEGORY = "Vui lòng nhập loại sản phẩm";
        public const string REQUIRE_NAME_LENGTH = "Độ dài tên không được quá 20";
        public const string REQUIRE_DESCRIPTION_LENGTH = "Độ dài mô tả không được quá 100";
        public const string REQUIRE_PASSWORD_LENGTH = "Độ dài password >6 và <20";
        public const string REQUIRE_PASSWORD = "Vui lòng nhập mật khẩu";
        public const string REQUIRE_NOT_NULL = "Vui lòng nhập thông tin vào trường này";
        public const string REQUIRE_PHONE = "Số điện thoại không đúng định dạng";
        public const string REQUIRE_EMAIL_FORMAT = "Email không đúng định dạng!";
        public const string REQUIRE_EMAIL = "Vui lòng nhập địa chỉ Email!";
        public const string REQUIRE_GENDER = "Vui lòng nhập giới tính!";
        public const string REQUIRE_FULLNAME_LENGTH = "Độ dài tên >6 và <30";
        public const string REQUIRE_USERNAME_LENGTH = "Độ dài tên >6 và <20";
        public const string REQUIRE_PROPERTYVALUE_LENGTH = "Độ dài thuộc tính >0 và <20";
        public const string REQUIRE_PROMOTION_PERCENT = "Phần trăm khuyến mãi bé hơn 100%";
        public const string REQUIRE_PROMOTION = "Vui lòng nhập phần trăm khuyến mãi";
        public const string REQUIRE_STARTDAY = "Vui lòng nhập ngày bắt đầu";
        public const string REQUIRE_ENDDAY = "Vui lòng nhập ngày kết thúc";
        public const string REQUIRE_LIST_PRODUCT_PROMOTION = "Vui lòng chọn các sản phẩm được khuyến mãi";

        //public const string REQUIRE_PRODUCTNAME = "";


        public const string LOGIN_PAGE = "LoginStaff";
        public const string CONTROLLER_LOGIN_PAGE = "Staff";

        public const int MAX_PHONE_LENGTH = 11;
        public const int MIN_PHONE_LENGTH = 10;
        public const int PROPERTYNAME_LENGTH = 20;
        public const int SUPPLIERNAME_LENGTH = 20;
        public const int PRODUCTNAME_LENGTH = 20;
        public const int NAME_LENGTH = 20;
        public const int DESCRIPTION_LENGTH = 100;
        public const int MAX_PASSWORD_LENGTH = 20;
        public const int MIN_PASSWORD_LENGTH = 6;
        public const int MIN_FULLNAME_LENGTH = 6;
        public const int MAX_FULLNAME_LENGTH = 30;
        public const int MIN_USERNAME_LENGTH = 6;
        public const int MAX_USERNAME_LENGTH = 20;
        public const int MAX_PROPERTYVALUE_LENGTH = 20;


        // Order Status
        public const string STATUS_CONFIRMED = "Confirmed";
        public const string STATUS_DENIED = "Denied";
        public const string STATUS_DELIVERING = "Delivering";
        public const string STATUS_HANDLING = "Handling";
        public const string STATUS_COMPLETED = "Completed";

        // Mail info
        public const string MAIL_FROM_NAME = "Nguyễn Lam Trà";
        public const string MAIL_FROM_ADDRESS = "nguyenlamtra95@gmail.com";

        // Payment
        public const string URL_RETURN = "http://localhost:56271/Order/Success";
        public const string TOKEN = "GiACgyAIvfTq3ED71ES5zGtqXnIidEcWFO6v6UI6cUhS7de1kgSXTl0pePG";
        public const string URL_SUBMIT_PAYMENT = "https://www.sandbox.paypal.com/cgi-bin/webscr";

        public const string ACCOUNT_BUSINESS = "nguyenlamtra95@gmail.com";
    }
}
