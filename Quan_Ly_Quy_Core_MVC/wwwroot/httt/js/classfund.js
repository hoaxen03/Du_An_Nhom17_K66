// Tạo một đối tượng XMLHttpRequest để gửi và nhận dữ liệu từ API
var xhr = new XMLHttpRequest();

// Định nghĩa một hàm để xử lý khi nhận được dữ liệu từ API
xhr.onload = function () {
    // Kiểm tra xem trạng thái của yêu cầu có thành công không
    if (xhr.status === 200) {
        // Phân tích dữ liệu JSON trả về từ API
        var data = JSON.parse(xhr.responseText);
        // Tìm một phần tử HTML có id là "balance" để hiển thị số dư của quỹ lớp học
        var balanceElement = document.getElementById("balance");
        // Nếu tìm thấy phần tử HTML, thì gán giá trị của số dư vào nội dung của phần tử
        if (balanceElement) {
            balanceElement.innerHTML = data.balance;
        }
    }
};

// Mở một yêu cầu GET đến URL của API
xhr.open("GET", "http://localhost:5077/api/Student");

// Gửi yêu cầu
xhr.send();