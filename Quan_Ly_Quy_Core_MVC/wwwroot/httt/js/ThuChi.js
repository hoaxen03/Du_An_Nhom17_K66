const body = document.querySelector("body");
body.addEventListener("DOMContentLoaded", function() {
    // Lấy tất cả các khoản thu chi
    getThuChi();

    // Thêm khoản thu chi mới
    $("#formThuChi").on("submit", function (event) {
        event.preventDefault();

        // Lấy dữ liệu từ form
        var tenKhoanChi = $("#tenKhoanChi").val();
        var soTienCanChi = $("#soTienCanChi").val();
        var soLuongChi = $("#SoLuongChi").val();
        var NgayChi = $("#NgayChi").val();
        var NamChi = $("#NamChi").val();

        // Gọi API thêm khoản thu chi
        $.ajax({
            url: "/api/KhoanChi",
            method: "post",
            data: {
                tenKhoanChi: tenKhoanChi,
                soTienCanChi : soTienCanChi,
                soLuongChi : soLuongChi,
                NgayChi: NgayChi,
                NamChi : NamChi
            },
            success: function (data) {
                // Hiển thị thông báo thành công
                alert("Thêm khoản thu chi thành công!");

                // Lấy lại tất cả các khoản thu chi
                getThuChi();
            },
            error: function (error) {
                // Hiển thị thông báo lỗi
                alert(error.responseText);
            }
        });
    });

    // Sửa khoản thu chi
    function suaThuChi(id) {
        // Lấy dữ liệu từ form
        var tenKhoanChi = $("#tenKhoanChi" + id).val();
        var soTienCanChi = $("#soTienCanChi" + id).val();
        var soLuongChi = $("#SoLuongChi" + id).val();
        var NgayChi = $("#NgayChi" + id).val();
        var NamChi = $("#NamChi" + id).val();

        // Gọi API sửa khoản thu chi
        $.ajax({
            url: "/api/KhoanChi/" + id,
            method: "put",
            data: {
                tenKhoanChi: tenKhoanChi,
                soTienCanChi: soTienCanChi,
                soLuongChi: soLuongChi,
                NgayChi: NgayChi,
                NamChi: NamChi

            },
            success: function (data) {
                // Hiển thị thông báo thành công
                alert("Sửa khoản thu chi thành công!");

                // Lấy lại tất cả các khoản thu chi
                getThuChi();
            },
            error: function (error) {
                // Hiển thị thông báo lỗi
                alert(error.responseText);
            }
        });
    }

    // Xóa khoản thu chi
    function xoaThuChi(id) {
        // Hỏi người dùng xác nhận
        var confirm = confirm("Bạn có chắc chắn muốn xóa khoản thu chi này không?");

        if (confirm) {
            // Gọi API xóa khoản thu chi
            $.ajax({
                url: "/api/KhoanChi/" + id,
                method: "delete",
                success: function (data) {
                    // Hiển thị thông báo thành công
                    alert("Xóa khoản thu chi thành công!");

                    // Lấy lại tất cả các khoản thu chi
                    getThuChi();
                },
                error: function (error) {
                    // Hiển thị thông báo lỗi
                    alert(error.responseText);
                }
            });
        }
    }
    // Hàm lấy tất cả các khoản thu chi
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

})