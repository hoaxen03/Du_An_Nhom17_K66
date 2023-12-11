function getThuChi() {
    // Gọi API lấy tất cả các khoản thu chi
    $.ajax({
        url: "/api/KhoanChi",
        method: "get",
        success: function (data) {
            // Xóa dữ liệu trong bảng
            $("#data").empty();

            // Thêm dữ liệu vào bảng
            for (var i = 0; i < data.length; i++) {
                var thuChi = data[i];

                var row = "<tr>";
                row += "<td>" + thuChi.id + "</td>";
                row += "<td>" + thuChi.tenKhoanChi + "</td>";
                row += "<td>" + thuChi.soTienCanChi + "</td>";
                row += "<td>" + thuChi.soLuongChi + "</td>";
                row += "<td>" + thuChi.NgayChi + "</td>";
                row += "<td>" + thuChi.NamChi + "</td>";
                row += "<td><button type=\"button\" class=\"btn btn-primary\">Sửa</button> <button type=\"button\" class=\"btn btn-danger\">Xóa</button> <button type=\"button\" class=\"btn btn-info\">Xem chi tiết</button></td>";

                $("#data").append(row);
            }

            // Hiển thị số dư
            var sodu = 0;
            for (var i = 0; i < data.length; i++) {
                var thuChi = data[i];

                if (thuChi.loai == "thu") {
                    sodu += thuChi.sotien;
                } else {
                    sodu -= thuChi.sotien;
                }
            }

            $("#sodu").text(sodu);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}